import { describe, expect, it } from 'vitest'
import { calculateChange, calculateSale, parseAmount, type LineInput } from './money'

// The same cases as the server's MoneyTests, so both sides stay in step.
const RATE = 89_500
const VAT = 1100

const usd = (cents: number, extra: Partial<LineInput> = {}): LineInput => ({
  priceCurrency: 'USD', unitPriceMinor: cents, quantity: 1, discountMinor: 0, taxCategory: 'Standard', ...extra,
})
const lbp = (pounds: number, quantity = 1): LineInput => ({
  priceCurrency: 'LBP', unitPriceMinor: pounds, quantity, discountMinor: 0, taxCategory: 'Standard',
})

describe('calculateSale', () => {
  it('shows the lira total of a dollar sale at the sale rate', () => {
    const totals = calculateSale([usd(1250)], RATE, VAT, true)
    expect(totals.totalUsdCents).toBe(1250)
    expect(totals.totalLbp).toBe(1_118_750)
  })

  it('takes VAT out of a VAT-inclusive price', () => {
    const totals = calculateSale([usd(1110)], RATE, VAT, true)
    expect(totals.vatUsdCents).toBe(110)
    expect(totals.vatLbp).toBe(98_450)
  })

  it('adds VAT on top of a VAT-exclusive price', () => {
    expect(calculateSale([usd(1000)], RATE, VAT, false).totalUsdCents).toBe(1110)
  })

  it('charges no VAT on exempt products', () => {
    const totals = calculateSale([usd(500, { taxCategory: 'Exempt' }), usd(1110)], RATE, VAT, true)
    expect(totals.totalUsdCents).toBe(1610)
    expect(totals.vatUsdCents).toBe(110)
  })

  it('keeps the exact lira total of a lira-only sale', () => {
    const totals = calculateSale([lbp(150_000), lbp(75_000, 2)], RATE, VAT, true)
    expect(totals.totalLbp).toBe(300_000)
    expect(totals.totalUsdCents).toBe(335)
  })

  it('totals mixed-currency lines in both currencies', () => {
    const totals = calculateSale([usd(1000), lbp(89_500)], RATE, VAT, true)
    expect(totals.totalUsdCents).toBe(1100)
    expect(totals.totalLbp).toBe(984_500)
  })

  it('applies weighed quantities and discounts per line', () => {
    const totals = calculateSale([usd(800, { quantity: 1.25, discountMinor: 100, taxCategory: 'Exempt' })], RATE, VAT, true)
    expect(totals.totalUsdCents).toBe(900)
  })
})

describe('calculateChange', () => {
  it('gives change as whole dollars plus rounded lira', () => {
    const result = calculateChange(12.5, [{ currency: 'USD', amountMinor: 2000 }], RATE, 1000)
    expect(result).toMatchObject({ isPaid: true, changeUsdCents: 700, changeLbp: 45_000 })
  })

  it('accepts dollars and lira together', () => {
    const result = calculateChange(12.5, [{ currency: 'USD', amountMinor: 1000 }, { currency: 'LBP', amountMinor: 250_000 }], RATE, 1000)
    expect(result).toMatchObject({ isPaid: true, changeUsdCents: 0, changeLbp: 26_000 })
  })

  it('reports what is still owed in both currencies', () => {
    const result = calculateChange(12.5, [{ currency: 'USD', amountMinor: 1000 }], RATE, 1000)
    expect(result).toMatchObject({ isPaid: false, remainingUsdCents: 250, remainingLbp: 224_000 })
  })

  it('treats the rounded lira total as paid', () => {
    const result = calculateChange(3.35, [{ currency: 'LBP', amountMinor: 300_000 }], RATE, 1000)
    expect(result).toMatchObject({ isPaid: true, changeLbp: 0 })
  })
})

describe('parseAmount', () => {
  it('reads dollars as cents and lira with thousands separators', () => {
    expect(parseAmount('USD', '12.5')).toBe(1250)
    expect(parseAmount('LBP', '1,118,750')).toBe(1_118_750)
    expect(parseAmount('USD', 'abc')).toBe(0)
  })
})
