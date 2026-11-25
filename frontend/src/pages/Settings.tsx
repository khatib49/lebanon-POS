import { useState, type FormEvent } from 'react'
import { api, type Shop } from '../lib/api'
import { useI18n } from '../lib/i18n'
import { formatLbp } from '../lib/money'
import { canManage, useSession } from '../lib/session'

export function Settings() {
  const { t, language, setLanguage } = useI18n()
  const { user, till, sync } = useSession()
  const [rateText, setRateText] = useState('')
  // The form starts from the saved shop details and keeps the owner's edits until they are saved.
  const [draft, setShop] = useState<Shop | null>(null)
  const shop = draft ?? till?.shop ?? null
  const [message, setMessage] = useState('')
  const [error, setError] = useState('')
  const isOwner = user?.role === 'Owner'

  async function run(action: () => Promise<unknown>) {
    setMessage('')
    setError('')
    try {
      await action()
      await sync()
      setMessage(t('saved'))
    } catch (err) {
      setError((err as Error).message)
    }
  }

  const saveRate = (event: FormEvent) => {
    event.preventDefault()
    void run(async () => { await api.setRate(Number(rateText.replace(/[,\s]/g, ''))); setRateText('') })
  }

  const saveShop = (event: FormEvent) => {
    event.preventDefault()
    if (shop) void run(() => api.updateShop(shop))
  }

  const text = (name: 'name' | 'nameAr' | 'vatNumber' | 'address' | 'phone' | 'receiptFooter') => ({
    value: shop?.[name] ?? '',
    disabled: !isOwner,
    onChange: (event: { target: { value: string } }) => shop && setShop({ ...shop, [name]: event.target.value }),
  })

  return (
    <div className="mx-auto max-w-2xl space-y-4 p-4">
      <h1 className="text-xl font-bold">{t('settings')}</h1>
      {message && <p className="rounded-lg bg-green-50 p-2 text-sm text-green-800" role="status">{message}</p>}
      {error && <p className="rounded-lg bg-red-50 p-2 text-sm text-red-700" role="alert">{error}</p>}

      <form onSubmit={saveRate} className="card space-y-3">
        <h2 className="font-bold">{t('exchangeRate')}</h2>
        <p>{t('currentRate')}: <strong dir="ltr">{till?.rate ? `$1 = ${formatLbp(till.rate.lbpPerUsd)}` : '—'}</strong></p>
        {canManage(user) ? (
          <div className="flex items-end gap-2">
            <div className="flex-1">
              <label className="label" htmlFor="f-lbpPerUsd">{t('lbpPerUsd')}</label>
              <input id="f-lbpPerUsd" className="input" dir="ltr" inputMode="numeric" required placeholder="89,500" value={rateText} onChange={(e) => setRateText(e.target.value)} />
            </div>
            <button className="btn-gold">{t('setRate')}</button>
          </div>
        ) : <p className="text-sm text-ink/60">{t('managerOnly')}</p>}
      </form>

      {shop && (
        <form onSubmit={saveShop} className="card space-y-3">
          <h2 className="font-bold">{t('shopSettings')}</h2>
          {!isOwner && <p className="text-sm text-ink/60">{t('ownerOnly')}</p>}
          <div className="grid gap-3 sm:grid-cols-2">
            <label className="block"><span className="label">{t('shopName')}</span><input className="input" required {...text('name')} /></label>
            <label className="block"><span className="label">{t('nameAr')}</span><input className="input" dir="rtl" {...text('nameAr')} /></label>
            <label className="block"><span className="label">{t('vatNumber')}</span><input className="input" dir="ltr" {...text('vatNumber')} /></label>
            <label className="block"><span className="label">{t('phone')}</span><input className="input" dir="ltr" {...text('phone')} /></label>
          </div>
          <label className="block"><span className="label">{t('address')}</span><input className="input" {...text('address')} /></label>
          <label className="block"><span className="label">{t('receiptFooter')}</span><input className="input" {...text('receiptFooter')} /></label>
          <div className="grid gap-3 sm:grid-cols-2">
            <div>
              <label className="label" htmlFor="f-cashUnit">{t('cashUnit')}</label>
              <input id="f-cashUnit" className="input" dir="ltr" type="number" min={1} max={100000} disabled={!isOwner} value={shop.lbpCashUnit} onChange={(e) => setShop({ ...shop, lbpCashUnit: Number(e.target.value) })} />
            </div>
            <label className="flex items-center gap-2 self-end pb-2">
              <input type="checkbox" disabled={!isOwner} checked={shop.pricesIncludeVat} onChange={(e) => setShop({ ...shop, pricesIncludeVat: e.target.checked })} />
              {t('pricesIncludeVat')}
            </label>
          </div>
          {isOwner && <button className="btn-primary">{t('save')}</button>}
        </form>
      )}

      <div className="card space-y-3">
        <h2 className="font-bold">{t('language')}</h2>
        <div className="flex gap-2">
          <button className={language === 'ar' ? 'btn-primary' : 'btn-ghost'} onClick={() => setLanguage('ar')}>{t('arabic')}</button>
          <button className={language === 'en' ? 'btn-primary' : 'btn-ghost'} onClick={() => setLanguage('en')}>{t('english')}</button>
        </div>
      </div>
    </div>
  )
}
