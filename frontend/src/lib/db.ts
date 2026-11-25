import Dexie, { type Table } from 'dexie'
import type { ExchangeRate, Product, SaleRequest, Shop, User, VatRate } from './api'

/** A sale saved on the device. It stays here until the server confirms it. */
export interface StoredSale {
  id: string
  shopId: string
  request: SaleRequest
  status: 'pending' | 'synced' | 'error'
  error?: string
  totalUsdCents: number
  totalLbp: number
  vatLbp: number
}

export interface Meta { key: string; value: unknown }

/** Everything the till needs to keep selling without internet. */
export interface TillData {
  shop: Shop
  rate: ExchangeRate | null
  vatRates: VatRate[]
  registerCode: string
}

class PosDatabase extends Dexie {
  products!: Table<Product, string>
  sales!: Table<StoredSale, string>
  meta!: Table<Meta, string>

  constructor() {
    super('lebanon-pos')
    this.version(1).stores({
      products: 'id, barcode, name',
      sales: 'id, status',
      meta: 'key',
    })
  }
}

export const db = new PosDatabase()

export async function getMeta<T>(key: string): Promise<T | undefined> {
  return (await db.meta.get(key))?.value as T | undefined
}

export const setMeta = (key: string, value: unknown) => db.meta.put({ key, value })

export const getCachedUser = () => getMeta<User>('user')
export const getTillData = () => getMeta<TillData>('till')

/** Removes one shop's data from the device when a user signs out. Unsent sales are kept for that shop's next sign-in. */
export async function clearCachedShop() {
  await db.products.clear()
  await db.meta.bulkDelete(['user', 'till'])
}

/**
 * The next invoice number for this till, counted on the device so numbers have no gaps
 * even when sales are made offline.
 */
export async function takeNextInvoiceNumber(shopId: string, registerCode: string): Promise<number> {
  return db.transaction('rw', db.meta, async () => {
    const key = `counter:${shopId}:${registerCode}`
    const next = ((await getMeta<number>(key)) ?? 0) + 1
    await setMeta(key, next)
    return next
  })
}

/** Moves the counter forward to at least the server's last number (after a reinstall or on a second device). */
export async function raiseInvoiceCounter(shopId: string, registerCode: string, lastNumber: number) {
  await db.transaction('rw', db.meta, async () => {
    const key = `counter:${shopId}:${registerCode}`
    if (((await getMeta<number>(key)) ?? 0) < lastNumber) await setMeta(key, lastNumber)
  })
}
