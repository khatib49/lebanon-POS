import { BrowserRouter, NavLink, Navigate, Route, Routes } from 'react-router-dom'
import { I18nProvider, useI18n } from './lib/i18n'
import { SessionProvider, useSession } from './lib/session'
import { Login } from './pages/Login'
import { Products } from './pages/Products'
import { Sales } from './pages/Sales'
import { Sell } from './pages/Sell'
import { Settings } from './pages/Settings'

function Shell() {
  const { t } = useI18n()
  const { user, loading, online, pendingCount, signOut, sync, till } = useSession()

  if (loading) return <p className="p-6">{t('loading')}</p>
  if (!user) return <Login />

  const link = ({ isActive }: { isActive: boolean }) =>
    `rounded-lg px-3 py-2 font-semibold ${isActive ? 'bg-gold text-cedar' : 'text-white hover:bg-cedar-light'}`

  return (
    <div className="min-h-screen">
      <header className="flex flex-wrap items-center gap-2 bg-cedar px-4 py-2 text-white print:hidden">
        <span className="me-2 text-lg font-bold">{till?.shop.name ?? t('appName')}</span>
        <nav className="flex flex-1 flex-wrap gap-1">
          <NavLink to="/" end className={link}>{t('sell')}</NavLink>
          <NavLink to="/products" className={link}>{t('products')}</NavLink>
          <NavLink to="/sales" className={link}>{t('sales')}</NavLink>
          <NavLink to="/settings" className={link}>{t('settings')}</NavLink>
        </nav>
        <button
          className={`rounded-full px-3 py-1 text-sm font-semibold ${online ? 'bg-cedar-light' : 'bg-gold text-cedar'}`}
          onClick={() => void sync()}
          title={t('syncNow')}
        >
          {online ? t('online') : t('offline')}
          {pendingCount > 0 && ` · ${pendingCount} ${t('waitingToSync')}`}
        </button>
        <span className="text-sm">{user.name}</span>
        <button className="text-sm underline" onClick={() => void signOut()}>{t('signOut')}</button>
      </header>
      <main>
        <Routes>
          <Route path="/" element={<Sell />} />
          <Route path="/products" element={<Products />} />
          <Route path="/sales" element={<Sales />} />
          <Route path="/settings" element={<Settings />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </main>
    </div>
  )
}

export default function App() {
  return (
    <I18nProvider>
      <BrowserRouter>
        <SessionProvider>
          <Shell />
        </SessionProvider>
      </BrowserRouter>
    </I18nProvider>
  )
}
