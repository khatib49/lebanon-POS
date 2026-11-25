import { api, ApiError, isOffline } from './api'
import { db, raiseInvoiceCounter, setMeta, type TillData } from './db'

/** Downloads the shop's settings, rate, VAT and products so the till can work offline. */
export async function refreshTillData(): Promise<TillData> {
  const [shop, registers, vatRates, products] = await Promise.all([
    api.shop(), api.registers(), api.vatRates(), api.products(),
  ])
  const rate = await api.currentRate().catch((error) => {
    if (error instanceof ApiError && error.status === 404) return null
    throw error
  })
  const register = registers.find((r) => r.isActive) ?? registers[0]
  const till: TillData = { shop, rate, vatRates, registerCode: register.code }

  await db.transaction('rw', db.products, db.meta, async () => {
    await db.products.clear()
    await db.products.bulkPut(products)
    await setMeta('till', till)
  })
  await raiseInvoiceCounter(shop.id, register.code, register.lastNumber)
  return till
}

let syncing = false

/**
 * Sends sales that are still waiting on the device. A sale the server refuses is marked with the
 * reason and kept, so nothing sold is ever lost. Only the signed-in shop's sales are sent.
 * Returns how many of its sales are still waiting.
 */
export async function syncPendingSales(shopId: string): Promise<number> {
  const waiting = async () =>
    (await db.sales.where('status').equals('pending').toArray()).filter((s) => s.shopId === shopId)
  if (syncing) return (await waiting()).length
  syncing = true
  try {
    const pending = await waiting()
    pending.sort((a, b) => a.request.number - b.request.number)
    for (const sale of pending) {
      try {
        await api.createSale(sale.request)
        await db.sales.update(sale.id, { status: 'synced', error: undefined })
      } catch (error) {
        if (isOffline(error) || (error instanceof ApiError && (error.status === 401 || error.status >= 500))) break
        await db.sales.update(sale.id, { status: 'error', error: (error as Error).message })
      }
    }
    return (await waiting()).length
  } finally {
    syncing = false
  }
}

/** The VAT rate in force on a given day, from the shop's dated list. */
export function vatRateOn(till: TillData, date: Date): number {
  const day = date.toLocaleDateString('en-CA', { timeZone: 'Asia/Beirut' })
  const inForce = till.vatRates
    .filter((r) => r.effectiveFrom <= day)
    .sort((a, b) => b.effectiveFrom.localeCompare(a.effectiveFrom))[0]
  return inForce?.rateBps ?? 0
}
