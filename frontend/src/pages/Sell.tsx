import { useEffect, useMemo, useRef, useState } from 'react'
import { Link } from 'react-router-dom'
import type { PaymentMethod, Product, SaleRequest } from '../lib/api'
import { db, takeNextInvoiceNumber } from '../lib/db'
import { localName, useI18n } from '../lib/i18n'
import { calculateChange, calculateSale, formatLbp, formatMoney, formatUsd, parseAmount, usdCentsToLbp } from '../lib/money'
import { canManage, useSession } from '../lib/session'
import { syncPendingSales, vatRateOn } from '../lib/sync'
import { Receipt } from '../components/Receipt'

interface CartLine { product: Product; quantity: number }

export function Sell() {
  const { t, language } = useI18n()
  const { till, user, online, refreshPending } = useSession()
  const [products, setProducts] = useState<Product[]>([])
  const [search, setSearch] = useState('')
  const [cart, setCart] = useState<CartLine[]>([])
  const [paying, setPaying] = useState(false)
  const [done, setDone] = useState<SaleRequest | null>(null)
  const searchRef = useRef<HTMLInputElement>(null)
  const [openedAt] = useState(() => new Date())

  useEffect(() => {
    void db.products.toArray().then((all) => setProducts(all.filter((p) => p.isActive)))
  }, [till])

  const rate = till?.rate?.lbpPerUsd ?? 0
  const vatBps = till ? vatRateOn(till, openedAt) : 0

  const visible = useMemo(() => {
    const query = search.trim().toLowerCase()
    if (!query) return products
    return products.filter((p) =>
      p.name.toLowerCase().includes(query) || (p.nameAr ?? '').includes(query) || p.barcode === query)
  }, [products, search])

  const lines = cart.map((line) => ({
    productId: line.product.id,
    name: line.product.name,
    nameAr: line.product.nameAr,
    quantity: line.quantity,
    priceCurrency: line.product.priceCurrency,
    unitPriceMinor: line.product.priceMinor,
    discountMinor: 0,
    taxCategory: line.product.taxCategory,
  }))
  const totals = rate > 0 && till ? calculateSale(lines, rate, vatBps, till.shop.pricesIncludeVat) : null

  function add(product: Product) {
    setCart((current) => {
      const existing = current.find((line) => line.product.id === product.id)
      return existing
        ? current.map((line) => (line === existing ? { ...line, quantity: line.quantity + 1 } : line))
        : [...current, { product, quantity: 1 }]
    })
  }

  function setQuantity(productId: string, quantity: number) {
    setCart((current) => quantity <= 0
      ? current.filter((line) => line.product.id !== productId)
      : current.map((line) => (line.product.id === productId ? { ...line, quantity } : line)))
  }

  // A barcode scanner types the code and presses Enter: an exact match goes straight into the cart.
  function onSearchEnter() {
    const code = search.trim()
    const match = products.find((p) => p.barcode === code) ?? (visible.length === 1 ? visible[0] : undefined)
    if (match) {
      add(match)
      setSearch('')
    }
  }

  async function complete(payments: SaleRequest['payments'], changeUsdCents: number, changeLbp: number) {
    if (!till || !totals) return
    const sale: SaleRequest = {
      id: crypto.randomUUID(),
      registerCode: till.registerCode,
      number: await takeNextInvoiceNumber(till.shop.id, till.registerCode),
      soldAt: new Date().toISOString(),
      lbpPerUsd: rate,
      vatRateBps: vatBps,
      pricesIncludeVat: till.shop.pricesIncludeVat,
      lines,
      payments,
      changeUsdCents,
      changeLbp,
    }
    // Saved on the device first, so the sale survives a power or internet cut.
    await db.sales.put({
      id: sale.id, shopId: till.shop.id, request: sale, status: 'pending',
      totalUsdCents: totals.totalUsdCents, totalLbp: totals.totalLbp, vatLbp: totals.vatLbp,
    })
    setCart([])
    setPaying(false)
    setDone(sale)
    await refreshPending()
    void syncPendingSales(till.shop.id).then(refreshPending)
  }

  if (!till) return <p className="p-6">{t('loading')}</p>

  if (done) {
    return (
      <div className="mx-auto max-w-md space-y-4 p-4">
        {!online && <p className="rounded-lg bg-gold/30 p-3 text-sm font-semibold print:hidden">{t('savedOffline')}</p>}
        <Receipt sale={done} shop={till.shop} cashierName={user?.name ?? ''} />
        <div className="flex gap-3 print:hidden">
          <button className="btn-ghost flex-1" onClick={() => window.print()}>{t('print')}</button>
          <button className="btn-primary flex-1" autoFocus onClick={() => { setDone(null); searchRef.current?.focus() }}>{t('newSale')}</button>
        </div>
      </div>
    )
  }

  if (rate <= 0) {
    return (
      <div className="mx-auto max-w-md p-6">
        <div className="card space-y-3 text-center">
          <p className="font-semibold">{t('noRate')}</p>
          {canManage(user) ? <Link className="btn-gold" to="/settings">{t('setRate')}</Link> : <p className="text-sm text-ink/60">{t('managerOnly')}</p>}
        </div>
      </div>
    )
  }

  return (
    <div className="grid gap-4 p-4 lg:grid-cols-[1fr_24rem]">
      <section className="space-y-3">
        <input
          ref={searchRef}
          autoFocus
          className="input text-lg"
          placeholder={t('search')}
          value={search}
          onChange={(event) => setSearch(event.target.value)}
          onKeyDown={(event) => event.key === 'Enter' && onSearchEnter()}
        />
        {products.length === 0 ? (
          <div className="card text-center">
            <p className="mb-3">{t('noProducts')}</p>
            {canManage(user) && <Link className="btn-gold" to="/products">{t('addFirstProduct')}</Link>}
          </div>
        ) : (
          <div className="grid grid-cols-2 gap-3 sm:grid-cols-3 xl:grid-cols-4">
            {visible.map((product) => (
              <button key={product.id} className="card text-start transition hover:ring-2 hover:ring-gold" onClick={() => add(product)}>
                <div className="font-semibold">{localName(language, product)}</div>
                <div className="mt-1 text-cedar" dir="ltr">{formatMoney(product.priceCurrency, product.priceMinor)}</div>
                {product.priceCurrency === 'USD' && (
                  <div className="text-sm text-ink/60" dir="ltr">{formatLbp(usdCentsToLbp(product.priceMinor, rate))}</div>
                )}
              </button>
            ))}
          </div>
        )}
      </section>

      <aside className="card flex flex-col gap-3 self-start lg:sticky lg:top-4">
        <div className="flex items-center justify-between">
          <h2 className="text-lg font-bold">{t('cart')}</h2>
          <span className="text-sm text-ink/60" dir="ltr">$1 = {formatLbp(rate)}</span>
        </div>
        {cart.length === 0 ? (
          <p className="py-6 text-center text-ink/60">{t('emptyCart')}</p>
        ) : (
          <ul className="divide-y divide-cedar/10">
            {cart.map((line, index) => (
              <li key={line.product.id} className="flex items-center gap-2 py-2">
                <div className="min-w-0 flex-1">
                  <div className="truncate font-semibold">{localName(language, line.product)}</div>
                  <div className="text-sm text-ink/60" dir="ltr">
                    {formatMoney(line.product.priceCurrency, totals?.lines[index].lineTotalMinor ?? 0)}
                  </div>
                </div>
                <button className="btn-ghost px-3" aria-label="-" onClick={() => setQuantity(line.product.id, line.quantity - 1)}>−</button>
                <span className="w-8 text-center font-semibold">{line.quantity}</span>
                <button className="btn-ghost px-3" aria-label="+" onClick={() => setQuantity(line.product.id, line.quantity + 1)}>+</button>
              </li>
            ))}
          </ul>
        )}
        {totals && cart.length > 0 && (
          <>
            <div className="border-t border-cedar/10 pt-3">
              <div className="flex items-baseline justify-between">
                <span className="font-semibold">{t('total')}</span>
                <span className="text-2xl font-bold" dir="ltr">{formatUsd(totals.totalUsdCents)}</span>
              </div>
              <div className="text-end text-lg font-semibold text-cedar" dir="ltr">{formatLbp(totals.totalLbp)}</div>
            </div>
            <div className="flex gap-2">
              <button className="btn-ghost" onClick={() => setCart([])}>{t('clear')}</button>
              <button className="btn-gold flex-1 text-lg" onClick={() => setPaying(true)}>{t('pay')}</button>
            </div>
          </>
        )}
      </aside>

      {paying && totals && (
        <PayDialog
          totalUsdCents={totals.totalUsdCents}
          totalLbp={totals.totalLbp}
          totalUsdExact={totals.totalUsdExact}
          rate={rate}
          cashUnit={till.shop.lbpCashUnit}
          onCancel={() => setPaying(false)}
          onConfirm={complete}
        />
      )}
    </div>
  )
}

function PayDialog(props: {
  totalUsdCents: number; totalLbp: number; totalUsdExact: number; rate: number; cashUnit: number
  onCancel: () => void
  onConfirm: (payments: SaleRequest['payments'], changeUsdCents: number, changeLbp: number) => Promise<void>
}) {
  const { t } = useI18n()
  const [method, setMethod] = useState<PaymentMethod>('Cash')
  const [usdText, setUsdText] = useState('')
  const [lbpText, setLbpText] = useState('')
  const [busy, setBusy] = useState(false)

  const payments = [
    { method, currency: 'USD' as const, amountMinor: parseAmount('USD', usdText) },
    { method, currency: 'LBP' as const, amountMinor: parseAmount('LBP', lbpText) },
  ].filter((payment) => payment.amountMinor > 0)
  const result = calculateChange(props.totalUsdExact, payments, props.rate, props.cashUnit)

  async function confirm() {
    setBusy(true)
    await props.onConfirm(payments, result.changeUsdCents, result.changeLbp)
  }

  return (
    <div className="fixed inset-0 z-10 flex items-center justify-center bg-cedar/60 p-4" role="dialog" aria-modal="true">
      <div className="card w-full max-w-md space-y-4 p-5">
        <div className="text-center">
          <div className="text-3xl font-bold" dir="ltr">{formatUsd(props.totalUsdCents)}</div>
          <div className="text-xl font-semibold text-cedar" dir="ltr">{formatLbp(props.totalLbp)}</div>
        </div>
        <div className="grid grid-cols-2 gap-2">
          {(['Cash', 'Card'] as const).map((option) => (
            <button key={option} className={method === option ? 'btn-primary' : 'btn-ghost'} onClick={() => setMethod(option)}>
              {t(option === 'Cash' ? 'cash' : 'card')}
            </button>
          ))}
        </div>
        <div className="grid grid-cols-2 gap-3">
          <div>
            <label className="label" htmlFor="f-paidUsd">{t('paidUsd')}</label>
            <input id="f-paidUsd" className="input text-lg" dir="ltr" inputMode="decimal" autoFocus value={usdText} onChange={(e) => setUsdText(e.target.value)} />
            <button className="mt-1 text-sm font-semibold text-gold-dark underline" onClick={() => { setUsdText((props.totalUsdCents / 100).toFixed(2)); setLbpText('') }}>{t('exactUsd')}</button>
          </div>
          <div>
            <label className="label" htmlFor="f-paidLbp">{t('paidLbp')}</label>
            <input id="f-paidLbp" className="input text-lg" dir="ltr" inputMode="numeric" value={lbpText} onChange={(e) => setLbpText(e.target.value)} />
            <button className="mt-1 text-sm font-semibold text-gold-dark underline" onClick={() => { setLbpText(String(props.totalLbp)); setUsdText('') }}>{t('exactLbp')}</button>
          </div>
        </div>
        <div className="rounded-lg bg-mist p-3 text-center" aria-live="polite">
          {!result.isPaid ? (
            <>
              <div className="text-sm font-semibold">{t('remaining')}</div>
              <div className="text-lg font-bold" dir="ltr">{formatUsd(result.remainingUsdCents)} <span className="text-sm font-normal">{t('or')}</span> {formatLbp(result.remainingLbp)}</div>
            </>
          ) : result.changeUsdCents > 0 || result.changeLbp > 0 ? (
            <>
              <div className="text-sm font-semibold">{t('change')}</div>
              <div className="text-lg font-bold" dir="ltr">
                {[result.changeUsdCents > 0 && formatUsd(result.changeUsdCents), result.changeLbp > 0 && formatLbp(result.changeLbp)].filter(Boolean).join(' + ')}
              </div>
            </>
          ) : (
            <div className="text-lg font-bold">{t('paidInFull')}</div>
          )}
        </div>
        <div className="flex gap-2">
          <button className="btn-ghost" onClick={props.onCancel} disabled={busy}>{t('cancel')}</button>
          <button className="btn-gold flex-1 text-lg" disabled={!result.isPaid || busy} onClick={confirm}>{t('confirmSale')}</button>
        </div>
      </div>
    </div>
  )
}
