import type { Currency, TaxCategory } from './money'

export type UserRole = 'Cashier' | 'Manager' | 'Owner'
export interface User { id: string; name: string; email: string; role: UserRole; isActive: boolean }
export interface AuthResponse { token: string; expiresAt: string; user: User; shopId: string }
export interface Shop {
  id: string; name: string; nameAr: string | null; vatNumber: string | null; address: string | null
  phone: string | null; receiptFooter: string | null; defaultLanguage: 'ar' | 'en'
  pricesIncludeVat: boolean; lbpCashUnit: number
}
export interface Register { id: string; code: string; name: string; isActive: boolean; lastNumber: number }
export interface ExchangeRate { id: string; lbpPerUsd: number; effectiveFrom: string }
export interface VatRate { id: string; rateBps: number; effectiveFrom: string }
export interface Product {
  id: string; categoryId: string | null; name: string; nameAr: string | null; barcode: string | null
  priceCurrency: Currency; priceMinor: number; taxCategory: TaxCategory; isActive: boolean; updatedAt: string
}
export type ProductInput = Omit<Product, 'id' | 'updatedAt'>
export type PaymentMethod = 'Cash' | 'Card'
export interface SaleLine {
  productId: string | null; name: string; nameAr: string | null; quantity: number
  priceCurrency: Currency; unitPriceMinor: number; discountMinor: number; taxCategory: TaxCategory
  lineTotalMinor?: number; vatMinor?: number
}
export interface SalePayment { method: PaymentMethod; currency: Currency; amountMinor: number }
export interface SaleRequest {
  id: string; registerCode: string; number: number; soldAt: string
  lbpPerUsd: number; vatRateBps: number; pricesIncludeVat: boolean
  lines: SaleLine[]; payments: SalePayment[]; changeUsdCents: number; changeLbp: number
}
export interface Sale extends SaleRequest {
  invoiceNumber: string; cashierId: string
  totalUsdCents: number; totalLbp: number; vatUsdCents: number; vatLbp: number
  status: 'Completed' | 'Voided'; voidReason: string | null; reviewNote: string | null
}
export interface DailyReport {
  date: string; salesCount: number; voidedCount: number; totalUsdCents: number; totalLbp: number; vatLbp: number
  cashUsdCents: number; cashLbp: number; cardUsdCents: number; cardLbp: number; needsReviewCount: number
}

export class ApiError extends Error {
  status: number
  constructor(status: number, message: string) {
    super(message)
    this.status = status
  }
}

/** True when the request never reached the server (no internet or power cut), as opposed to a refusal. */
export const isOffline = (error: unknown) => !(error instanceof ApiError)

const TOKEN_KEY = 'lebpos.token'
export const getToken = () => localStorage.getItem(TOKEN_KEY)
export const setToken = (token: string | null) =>
  token ? localStorage.setItem(TOKEN_KEY, token) : localStorage.removeItem(TOKEN_KEY)

let onUnauthorized: () => void = () => {}
export const setUnauthorizedHandler = (handler: () => void) => { onUnauthorized = handler }

async function request<T>(method: string, path: string, body?: unknown): Promise<T> {
  const token = getToken()
  const response = await fetch(`/api${path}`, {
    method,
    headers: {
      ...(body !== undefined ? { 'Content-Type': 'application/json' } : {}),
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
    },
    body: body !== undefined ? JSON.stringify(body) : undefined,
  })
  if (response.status === 401 && token && !path.startsWith('/auth/')) onUnauthorized()
  if (!response.ok) {
    let message = `Request failed (${response.status})`
    try {
      const problem = await response.json()
      const firstError = problem.errors ? Object.values(problem.errors as Record<string, string[]>)[0]?.[0] : null
      message = firstError ?? problem.message ?? problem.title ?? message
    } catch { /* no JSON body */ }
    throw new ApiError(response.status, message)
  }
  return response.status === 204 ? (undefined as T) : ((await response.json()) as T)
}

export const api = {
  registerShop: (body: { shopName: string; ownerName: string; email: string; password: string }) =>
    request<AuthResponse>('POST', '/auth/register-shop', body),
  login: (email: string, password: string) => request<AuthResponse>('POST', '/auth/login', { email, password }),
  me: () => request<User>('GET', '/me'),
  shop: () => request<Shop>('GET', '/shop'),
  updateShop: (shop: Omit<Shop, 'id'>) => request<Shop>('PUT', '/shop', shop),
  registers: () => request<Register[]>('GET', '/registers'),
  currentRate: () => request<ExchangeRate>('GET', '/exchange-rates/current'),
  setRate: (lbpPerUsd: number) => request<ExchangeRate>('POST', '/exchange-rates', { lbpPerUsd }),
  vatRates: () => request<VatRate[]>('GET', '/vat-rates'),
  products: (includeInactive = false) => request<Product[]>('GET', `/products?includeInactive=${includeInactive}`),
  createProduct: (product: ProductInput) => request<Product>('POST', '/products', product),
  updateProduct: (id: string, product: ProductInput) => request<Product>('PUT', `/products/${id}`, product),
  createSale: (sale: SaleRequest) => request<Sale>('POST', '/sales', sale),
  sales: (from: string, to: string) =>
    request<Sale[]>('GET', `/sales?from=${encodeURIComponent(from)}&to=${encodeURIComponent(to)}&take=500`),
  voidSale: (id: string, reason: string) => request<Sale>('POST', `/sales/${id}/void`, { reason }),
  dailyReport: () => request<DailyReport>('GET', '/reports/daily'),
}
