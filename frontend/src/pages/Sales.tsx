import { useCallback, useEffect, useState } from 'react'
import { api, type DailyReport, type Sale } from '../lib/api'
import { db, type StoredSale } from '../lib/db'
import { useI18n } from '../lib/i18n'
import { formatLbp, formatUsd } from '../lib/money'
import { canManage, useSession } from '../lib/session'

/** Start of today in Beirut, as a UTC timestamp. */
function beirutDayStart(): Date {
  const now = new Date()
  const beirutNow = new Date(now.toLocaleString('en-US', { timeZone: 'Asia/Beirut' }))
  const offsetMs = beirutNow.getTime() - now.getTime()
  beirutNow.setHours(0, 0, 0, 0)
  return new Date(beirutNow.getTime() - offsetMs)
}

export function Sales() {
  const { t } = useI18n()
  const { user, till, pendingCount } = useSession()
  const [sales, setSales] = useState<Sale[]>([])
  const [waiting, setWaiting] = useState<StoredSale[]>([])
  const [report, setReport] = useState<DailyReport | null>(null)
  const [error, setError] = useState('')
  const manage = canManage(user)

  const load = useCallback(async () => {
    const unsent = await db.sales.where('status').anyOf('pending', 'error').toArray()
    setWaiting(unsent.filter((sale) => sale.shopId === till?.shop.id))
    try {
      const start = beirutDayStart()
      setSales(await api.sales(start.toISOString(), new Date(start.getTime() + 24 * 3600 * 1000).toISOString()))
      if (manage) setReport(await api.dailyReport())
      setError('')
    } catch (err) {
      setError((err as Error).message)
    }
  }, [manage, till?.shop.id])

  // Reload when the list of waiting sales changes (a sale synced or a new one was made).
  useEffect(() => {
    const timer = window.setTimeout(() => void load(), 0)
    return () => window.clearTimeout(timer)
  }, [load, pendingCount])

  async function cancelSale(sale: Sale) {
    const reason = window.prompt(t('voidReason'))
    if (!reason?.trim()) return
    try {
      await api.voidSale(sale.id, reason)
      await load()
    } catch (err) {
      setError((err as Error).message)
    }
  }

  return (
    <div className="mx-auto max-w-4xl space-y-4 p-4">
      <h1 className="text-xl font-bold">{t('sales')} · {t('today')}</h1>
      {report && (
        <div className="grid grid-cols-2 gap-3 md:grid-cols-4">
          <Tile label={t('salesCount')} value={String(report.salesCount)} note={`${t('cancelled')}: ${report.voidedCount}`} />
          <Tile label={t('total')} value={formatUsd(report.totalUsdCents)} note={formatLbp(report.totalLbp)} />
          <Tile label={t('cashInDrawer')} value={formatUsd(report.cashUsdCents)} note={formatLbp(report.cashLbp)} />
          <Tile label={t('vat')} value={formatLbp(report.vatLbp)} note={`${t('needsReview')}: ${report.needsReviewCount}`} />
        </div>
      )}
      {error && <p className="rounded-lg bg-gold/30 p-2 text-sm" role="alert">{error}</p>}

      {waiting.length > 0 && (
        <div className="card space-y-2">
          {waiting.map((sale) => (
            <div key={sale.id} className="flex items-center justify-between gap-3">
              <span dir="ltr">{sale.request.registerCode}-{String(sale.request.number).padStart(6, '0')}</span>
              <span dir="ltr">{formatUsd(sale.totalUsdCents)}</span>
              <span className={sale.status === 'error' ? 'font-semibold text-red-700' : 'text-gold-dark'}>
                {t(sale.status === 'error' ? 'error' : 'pending')}{sale.error ? `: ${sale.error}` : ''}
              </span>
            </div>
          ))}
        </div>
      )}

      <div className="card overflow-x-auto p-0">
        <table className="w-full">
          <thead className="bg-mist text-sm">
            <tr><th className="p-3 text-start">{t('invoice')}</th><th className="p-3 text-start">{t('date')}</th><th className="p-3 text-start">{t('total')}</th><th className="p-3 text-start">{t('status')}</th><th className="p-3" /></tr>
          </thead>
          <tbody className="divide-y divide-cedar/10">
            {sales.map((sale) => (
              <tr key={sale.id} className={sale.status === 'Voided' ? 'text-ink/40 line-through' : ''}>
                <td className="p-3 font-semibold" dir="ltr">{sale.invoiceNumber}</td>
                <td className="p-3" dir="ltr">{new Date(sale.soldAt).toLocaleTimeString('en-GB', { timeZone: 'Asia/Beirut', hour: '2-digit', minute: '2-digit' })}</td>
                <td className="p-3" dir="ltr">{formatUsd(sale.totalUsdCents)} · {formatLbp(sale.totalLbp)}</td>
                <td className="p-3 text-sm">
                  {sale.status === 'Voided' ? `${t('cancelled')}: ${sale.voidReason}` : sale.reviewNote ? `${t('needsReview')}: ${sale.reviewNote}` : ''}
                </td>
                <td className="p-3 text-end">
                  {manage && sale.status === 'Completed' && (
                    <button className="font-semibold text-red-700 underline" onClick={() => cancelSale(sale)}>{t('voidSale')}</button>
                  )}
                </td>
              </tr>
            ))}
            {sales.length === 0 && <tr><td className="p-6 text-center text-ink/60" colSpan={5}>{t('noSales')}</td></tr>}
          </tbody>
        </table>
      </div>
    </div>
  )
}

function Tile({ label, value, note }: { label: string; value: string; note: string }) {
  return (
    <div className="card">
      <div className="text-sm font-semibold text-ink/60">{label}</div>
      <div className="text-xl font-bold" dir="ltr">{value}</div>
      <div className="text-sm text-cedar" dir="ltr">{note}</div>
    </div>
  )
}
