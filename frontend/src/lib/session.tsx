import { createContext, useCallback, useContext, useEffect, useMemo, useState, type ReactNode } from 'react'
import { getToken, isOffline, setToken, setUnauthorizedHandler, type AuthResponse, type User } from './api'
import { clearCachedShop, db, getCachedUser, getTillData, setMeta, type TillData } from './db'
import { refreshTillData, syncPendingSales } from './sync'

interface Session {
  user: User | null
  till: TillData | null
  online: boolean
  pendingCount: number
  loading: boolean
  signIn: (auth: AuthResponse) => Promise<void>
  signOut: () => Promise<void>
  /** Sends waiting sales and downloads fresh products, rate and settings. */
  sync: () => Promise<void>
  refreshPending: () => Promise<void>
}

const SessionContext = createContext<Session | null>(null)
const SYNC_INTERVAL_MS = 30_000

export function SessionProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<User | null>(null)
  const [till, setTill] = useState<TillData | null>(null)
  const [online, setOnline] = useState(navigator.onLine)
  const [pendingCount, setPendingCount] = useState(0)
  const [loading, setLoading] = useState(true)

  const refreshPending = useCallback(async () => {
    const shopId = (await getTillData())?.shop.id
    const pending = await db.sales.where('status').equals('pending').toArray()
    setPendingCount(pending.filter((s) => s.shopId === shopId).length)
  }, [])

  const sync = useCallback(async () => {
    if (!getToken()) return
    try {
      const fresh = await refreshTillData()
      setTill(fresh)
      setOnline(true)
      setPendingCount(await syncPendingSales(fresh.shop.id))
    } catch (error) {
      if (isOffline(error)) setOnline(false)
    }
  }, [])

  const signOut = useCallback(async () => {
    setToken(null)
    await clearCachedShop()
    setUser(null)
    setTill(null)
  }, [])

  const signIn = useCallback(async (auth: AuthResponse) => {
    setToken(auth.token)
    await setMeta('user', auth.user)
    setUser(auth.user)
    setTill(await refreshTillData())
    await refreshPending()
  }, [refreshPending])

  // On start, open the till from what is saved on the device, then refresh if there is internet.
  useEffect(() => {
    setUnauthorizedHandler(() => void signOut())
    void (async () => {
      if (getToken()) {
        setUser((await getCachedUser()) ?? null)
        setTill((await getTillData()) ?? null)
        await refreshPending()
        void sync()
      }
      setLoading(false)
    })()
  }, [refreshPending, signOut, sync])

  useEffect(() => {
    const goOnline = () => { setOnline(true); void sync() }
    const goOffline = () => setOnline(false)
    window.addEventListener('online', goOnline)
    window.addEventListener('offline', goOffline)
    const timer = window.setInterval(() => void sync(), SYNC_INTERVAL_MS)
    return () => {
      window.removeEventListener('online', goOnline)
      window.removeEventListener('offline', goOffline)
      window.clearInterval(timer)
    }
  }, [sync])

  const value = useMemo<Session>(
    () => ({ user, till, online, pendingCount, loading, signIn, signOut, sync, refreshPending }),
    [user, till, online, pendingCount, loading, signIn, signOut, sync, refreshPending],
  )
  return <SessionContext.Provider value={value}>{children}</SessionContext.Provider>
}

export function useSession(): Session {
  const context = useContext(SessionContext)
  if (!context) throw new Error('useSession must be used inside SessionProvider')
  return context
}

export const canManage = (user: User | null) => user?.role === 'Manager' || user?.role === 'Owner'
