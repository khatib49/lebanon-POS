import type { SaleRequest, Shop } from '../lib/api'
import { calculateSale, formatLbp, formatMoney, formatUsd } from '../lib/money'
import { localName, useI18n } from '../lib/i18n'

/** A receipt sized for 80 mm thermal paper. It always shows the rate and the total in both currencies. */
export function Receipt({ sale, shop, cashierName }: { sale: SaleRequest; shop: Shop; cashierName: string }) {
  const { t, language } = useI18n()
  const totals = calculateSale(sale.lines, sale.lbpPerUsd, sale.vatRateBps, sale.pricesIncludeVat)
  const invoice = `${sale.registerCode}-${String(sale.number).padStart(6, '0')}`
  const soldAt = new Date(sale.soldAt).toLocaleString('en-GB', { timeZone: 'Asia/Beirut', dateStyle: 'short', timeStyle: 'short' })

  return (
    <div className="receipt mx-auto w-[72mm] bg-white p-3 font-mono text-[12px] leading-5 text-black shadow">
      <div className="text-center">
        <div className="text-base font-bold">{language === 'ar' ? shop.nameAr || shop.name : shop.name}</div>
        {shop.address && <div>{shop.address}</div>}
        {shop.phone && <div dir="ltr">{shop.phone}</div>}
        {shop.vatNumber && <div>{t('vatNumber')}: <span dir="ltr">{shop.vatNumber}</span></div>}
      </div>
      <hr className="my-2 border-dashed border-black" />
      <div className="flex justify-between"><span>{t('invoice')}</span><span dir="ltr">{invoice}</span></div>
      <div className="flex justify-between"><span>{t('date')}</span><span dir="ltr">{soldAt}</span></div>
      <div className="flex justify-between"><span>{t('cashier')}</span><span>{cashierName}</span></div>
      <hr className="my-2 border-dashed border-black" />
      {sale.lines.map((line, index) => (
        <div key={index} className="mb-1">
          <div>{localName(language, line)}</div>
          <div className="flex justify-between" dir="ltr">
            <span>{line.quantity} × {formatMoney(line.priceCurrency, line.unitPriceMinor)}</span>
            <span>{formatMoney(line.priceCurrency, totals.lines[index].lineTotalMinor)}</span>
          </div>
        </div>
      ))}
      <hr className="my-2 border-dashed border-black" />
      <div className="flex justify-between text-sm font-bold"><span>{t('total')}</span><span dir="ltr">{formatUsd(totals.totalUsdCents)}</span></div>
      <div className="flex justify-between text-sm font-bold"><span /><span dir="ltr">{formatLbp(totals.totalLbp)}</span></div>
      <div className="flex justify-between"><span>{t('rate')}</span><span dir="ltr">$1 = {formatLbp(sale.lbpPerUsd)}</span></div>
      <div className="flex justify-between">
        <span>{t('vat')} {sale.vatRateBps / 100}%{sale.pricesIncludeVat ? ` (${t('vatIncluded')})` : ''}</span>
        <span dir="ltr">{formatLbp(totals.vatLbp)}</span>
      </div>
      <hr className="my-2 border-dashed border-black" />
      {sale.payments.map((payment, index) => (
        <div key={index} className="flex justify-between">
          <span>{t('paid')} ({t(payment.method === 'Cash' ? 'cash' : 'card')})</span>
          <span dir="ltr">{formatMoney(payment.currency, payment.amountMinor)}</span>
        </div>
      ))}
      {(sale.changeUsdCents > 0 || sale.changeLbp > 0) && (
        <div className="flex justify-between">
          <span>{t('change')}</span>
          <span dir="ltr">
            {[sale.changeUsdCents > 0 && formatUsd(sale.changeUsdCents), sale.changeLbp > 0 && formatLbp(sale.changeLbp)].filter(Boolean).join(' + ')}
          </span>
        </div>
      )}
      <div className="mt-3 text-center">{shop.receiptFooter || t('thankYou')}</div>
    </div>
  )
}
