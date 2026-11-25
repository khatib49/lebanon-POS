import { useEffect, useState, type FormEvent } from 'react'
import { api, type Product, type ProductInput } from '../lib/api'
import { localName, useI18n } from '../lib/i18n'
import { formatMoney, parseAmount, type Currency, type TaxCategory } from '../lib/money'
import { canManage, useSession } from '../lib/session'

const empty: ProductInput = {
  categoryId: null, name: '', nameAr: '', barcode: '', priceCurrency: 'USD', priceMinor: 0, taxCategory: 'Standard', isActive: true,
}

export function Products() {
  const { t, language } = useI18n()
  const { user, sync } = useSession()
  const [products, setProducts] = useState<Product[]>([])
  const [editing, setEditing] = useState<{ id: string | null; form: ProductInput; price: string } | null>(null)
  const [error, setError] = useState('')
  const manage = canManage(user)

  const load = () => api.products(true).then(setProducts).catch((err) => setError((err as Error).message))
  useEffect(() => { void load() }, [])

  async function save(event: FormEvent) {
    event.preventDefault()
    if (!editing) return
    setError('')
    const body: ProductInput = {
      ...editing.form,
      nameAr: editing.form.nameAr || null,
      barcode: editing.form.barcode || null,
      priceMinor: parseAmount(editing.form.priceCurrency, editing.price),
    }
    try {
      if (editing.id) await api.updateProduct(editing.id, body)
      else await api.createProduct(body)
      setEditing(null)
      await load()
      void sync()
    } catch (err) {
      setError((err as Error).message)
    }
  }

  const set = (patch: Partial<ProductInput>) => editing && setEditing({ ...editing, form: { ...editing.form, ...patch } })

  return (
    <div className="mx-auto max-w-4xl space-y-4 p-4">
      <div className="flex items-center justify-between">
        <h1 className="text-xl font-bold">{t('products')}</h1>
        {manage && <button className="btn-gold" onClick={() => setEditing({ id: null, form: empty, price: '' })}>{t('addProduct')}</button>}
      </div>
      {error && !editing && <p className="rounded-lg bg-red-50 p-2 text-sm text-red-700" role="alert">{error}</p>}
      <div className="card overflow-x-auto p-0">
        <table className="w-full text-start">
          <thead className="bg-mist text-sm">
            <tr><th className="p-3 text-start">{t('name')}</th><th className="p-3 text-start">{t('barcode')}</th><th className="p-3 text-start">{t('price')}</th><th className="p-3" /></tr>
          </thead>
          <tbody className="divide-y divide-cedar/10">
            {products.map((product) => (
              <tr key={product.id} className={product.isActive ? '' : 'text-ink/40'}>
                <td className="p-3 font-semibold">{localName(language, product)}{!product.isActive && ` (${t('inactive')})`}</td>
                <td className="p-3" dir="ltr">{product.barcode}</td>
                <td className="p-3" dir="ltr">{formatMoney(product.priceCurrency, product.priceMinor)}</td>
                <td className="p-3 text-end">
                  {manage && (
                    <button className="font-semibold text-gold-dark underline" onClick={() => setEditing({
                      id: product.id,
                      form: { ...product, nameAr: product.nameAr ?? '', barcode: product.barcode ?? '' },
                      price: product.priceCurrency === 'USD' ? (product.priceMinor / 100).toFixed(2) : String(product.priceMinor),
                    })}>{t('edit')}</button>
                  )}
                </td>
              </tr>
            ))}
            {products.length === 0 && <tr><td className="p-6 text-center text-ink/60" colSpan={4}>{t('noProducts')}</td></tr>}
          </tbody>
        </table>
      </div>

      {editing && (
        <div className="fixed inset-0 z-10 flex items-center justify-center bg-cedar/60 p-4" role="dialog" aria-modal="true">
          <form onSubmit={save} className="card w-full max-w-md space-y-3 p-5">
            <h2 className="text-lg font-bold">{editing.id ? t('editProduct') : t('addProduct')}</h2>
            <label className="block"><span className="label">{t('name')}</span><input className="input" required autoFocus value={editing.form.name} onChange={(e) => set({ name: e.target.value })} /></label>
            <label className="block"><span className="label">{t('nameAr')}</span><input className="input" dir="rtl" value={editing.form.nameAr ?? ''} onChange={(e) => set({ nameAr: e.target.value })} /></label>
            <label className="block"><span className="label">{t('barcode')}</span><input className="input" dir="ltr" value={editing.form.barcode ?? ''} onChange={(e) => set({ barcode: e.target.value })} /></label>
            <div className="grid grid-cols-2 gap-3">
              <label className="block"><span className="label">{t('price')}</span><input className="input" dir="ltr" inputMode="decimal" required value={editing.price} onChange={(e) => setEditing({ ...editing, price: e.target.value })} /></label>
              <div>
                <label className="label" htmlFor="f-currency">{t('currency')}</label>
                <select id="f-currency" className="input" value={editing.form.priceCurrency} onChange={(e) => set({ priceCurrency: e.target.value as Currency })}>
                  <option value="USD">USD ($)</option><option value="LBP">LBP</option>
                </select>
              </div>
            </div>
            <div>
              <label className="label" htmlFor="f-tax">{t('tax')}</label>
              <select id="f-tax" className="input" value={editing.form.taxCategory} onChange={(e) => set({ taxCategory: e.target.value as TaxCategory })}>
                <option value="Standard">{t('taxStandard')}</option><option value="Exempt">{t('taxExempt')}</option><option value="ZeroRated">{t('taxZero')}</option>
              </select>
            </div>
            <label className="flex items-center gap-2"><input type="checkbox" checked={editing.form.isActive} onChange={(e) => set({ isActive: e.target.checked })} />{t('active')}</label>
            {error && <p className="rounded-lg bg-red-50 p-2 text-sm text-red-700" role="alert">{error}</p>}
            <div className="flex gap-2">
              <button type="button" className="btn-ghost" onClick={() => { setEditing(null); setError('') }}>{t('cancel')}</button>
              <button className="btn-primary flex-1">{t('save')}</button>
            </div>
          </form>
        </div>
      )}
    </div>
  )
}
