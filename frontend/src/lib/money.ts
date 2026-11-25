// Money maths for the till. This mirrors the server's SaleCalculator and ChangeCalculator
// (backend/src/LebanonPos.Domain/Money) so a sale made offline gets the same totals the
// server computes later. Amounts are whole numbers: USD in cents, LBP in pounds.

export type Currency = 'USD' | 'LBP'
export type TaxCategory = 'Standard' | 'Exempt' | 'ZeroRated'

export interface LineInput {
  priceCurrency: Currency
  unitPriceMinor: number
  quantity: number
  discountMinor: number
  taxCategory: TaxCategory
}

export interface SaleTotals {
  lines: { lineTotalMinor: number; vatMinor: number }[]
  usdPartCents: number
  lbpPart: number
  totalUsdCents: number
  totalLbp: number
  vatUsdCents: number
  vatLbp: number
  /** Exact total in dollars, used to compare with mixed-currency payments. */
  totalUsdExact: number
}

export interface PaymentResult {
  isPaid: boolean
  remainingUsdCents: number
  remainingLbp: number
  changeUsdCents: number
  changeLbp: number
}

/** Rounds half away from zero, like the server; the small nudge absorbs floating-point error. */
export function round(value: number): number {
  return Math.sign(value) * Math.round(Math.abs(value) + 1e-9)
}

export const usdCentsToLbp = (cents: number, rate: number) => round((cents * rate) / 100)
export const lbpToUsdCents = (lbp: number, rate: number) => round((lbp * 100) / rate)
export const toUsd = (currency: Currency, minor: number, rate: number) =>
  currency === 'USD' ? minor / 100 : minor / rate

export function roundLbpToUnit(lbp: number, unit: number): number {
  return unit <= 1 ? round(lbp) : round(lbp / unit) * unit
}

export function calculateSale(
  lines: LineInput[],
  lbpPerUsd: number,
  vatRateBps: number,
  pricesIncludeVat: boolean,
): SaleTotals {
  let usdPart = 0
  let lbpPart = 0
  let vatUsd = 0
  let vatLbp = 0
  const results = lines.map((line) => {
    const amount = round(line.unitPriceMinor * line.quantity) - line.discountMinor
    let vat = 0
    let total = amount
    if (line.taxCategory === 'Standard' && vatRateBps > 0) {
      if (pricesIncludeVat) {
        vat = round((amount * vatRateBps) / (10000 + vatRateBps))
      } else {
        vat = round((amount * vatRateBps) / 10000)
        total = amount + vat
      }
    }
    if (line.priceCurrency === 'USD') {
      usdPart += total
      vatUsd += vat
    } else {
      lbpPart += total
      vatLbp += vat
    }
    return { lineTotalMinor: total, vatMinor: vat }
  })

  return {
    lines: results,
    usdPartCents: usdPart,
    lbpPart,
    totalUsdCents: usdPart + lbpToUsdCents(lbpPart, lbpPerUsd),
    totalLbp: usdCentsToLbp(usdPart, lbpPerUsd) + lbpPart,
    vatUsdCents: vatUsd + lbpToUsdCents(vatLbp, lbpPerUsd),
    vatLbp: usdCentsToLbp(vatUsd, lbpPerUsd) + vatLbp,
    totalUsdExact: usdPart / 100 + lbpPart / lbpPerUsd,
  }
}

/** Half a cash unit, in dollars: differences this small are rounding, not money owed. */
export const tolerance = (rate: number, cashUnit: number) => Math.max(0.005, Math.max(cashUnit, 1) / 2 / rate)

/**
 * What is still owed, or the change to give. US coins do not circulate in Lebanon, so change is
 * suggested as whole dollars plus lira rounded to the shop's cash unit.
 */
export function calculateChange(
  totalUsdExact: number,
  payments: { currency: Currency; amountMinor: number }[],
  lbpPerUsd: number,
  lbpCashUnit: number,
): PaymentResult {
  const paid = payments.reduce((sum, p) => sum + toUsd(p.currency, p.amountMinor, lbpPerUsd), 0)
  const difference = paid - totalUsdExact
  const allowed = tolerance(lbpPerUsd, lbpCashUnit)

  if (difference < -allowed) {
    const remaining = -difference
    return {
      isPaid: false,
      remainingUsdCents: Math.ceil(remaining * 100 - 1e-9),
      remainingLbp: roundLbpToUnit(remaining * lbpPerUsd, lbpCashUnit),
      changeUsdCents: 0,
      changeLbp: 0,
    }
  }
  if (difference <= allowed) {
    return { isPaid: true, remainingUsdCents: 0, remainingLbp: 0, changeUsdCents: 0, changeLbp: 0 }
  }
  const wholeDollars = Math.floor(difference + 1e-9)
  return {
    isPaid: true,
    remainingUsdCents: 0,
    remainingLbp: 0,
    changeUsdCents: wholeDollars * 100,
    changeLbp: roundLbpToUnit((difference - wholeDollars) * lbpPerUsd, lbpCashUnit),
  }
}

// Numbers are always shown with Latin digits, in Arabic and English alike.
const usdFormat = new Intl.NumberFormat('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })
const lbpFormat = new Intl.NumberFormat('en-US', { maximumFractionDigits: 0 })

export const formatUsd = (cents: number) => `$${usdFormat.format(cents / 100)}`
export const formatLbp = (lbp: number) => `${lbpFormat.format(lbp)} LBP`
export const formatMoney = (currency: Currency, minor: number) =>
  currency === 'USD' ? formatUsd(minor) : formatLbp(minor)

/** Reads what a cashier typed ("12.5", "1,118,750") as cents or pounds; empty or invalid text is 0. */
export function parseAmount(currency: Currency, text: string): number {
  const value = Number(text.replace(/[,\s]/g, ''))
  if (!Number.isFinite(value) || value < 0) return 0
  return currency === 'USD' ? round(value * 100) : round(value)
}
