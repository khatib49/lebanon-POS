import { useState, type FormEvent } from 'react'
import { api, ApiError, isOffline } from '../lib/api'
import { useI18n } from '../lib/i18n'
import { useSession } from '../lib/session'

export function Login() {
  const { t, language, setLanguage } = useI18n()
  const { signIn } = useSession()
  const [creating, setCreating] = useState(false)
  const [form, setForm] = useState({ shopName: '', ownerName: '', email: '', password: '' })
  const [error, setError] = useState('')
  const [busy, setBusy] = useState(false)

  const field = (name: keyof typeof form) => ({
    value: form[name],
    onChange: (event: { target: { value: string } }) => setForm({ ...form, [name]: event.target.value }),
  })

  async function submit(event: FormEvent) {
    event.preventDefault()
    setBusy(true)
    setError('')
    try {
      await signIn(creating ? await api.registerShop(form) : await api.login(form.email, form.password))
    } catch (err) {
      if (isOffline(err)) setError(t('needInternetToSignIn'))
      else if (err instanceof ApiError && err.status === 401) setError(t('wrongLogin'))
      else setError((err as Error).message)
    } finally {
      setBusy(false)
    }
  }

  return (
    <div className="flex min-h-screen items-center justify-center bg-cedar p-4">
      <form onSubmit={submit} className="card w-full max-w-sm space-y-4 p-6">
        <div className="flex items-center justify-between">
          <h1 className="text-2xl font-bold text-cedar">{t('appName')}</h1>
          <button type="button" className="text-sm font-semibold text-gold-dark" onClick={() => setLanguage(language === 'ar' ? 'en' : 'ar')}>
            {language === 'ar' ? 'English' : 'العربية'}
          </button>
        </div>
        <h2 className="text-lg font-semibold">{creating ? t('createShop') : t('signIn')}</h2>
        {creating && (
          <>
            <label className="block"><span className="label">{t('shopName')}</span><input className="input" required {...field('shopName')} /></label>
            <label className="block"><span className="label">{t('yourName')}</span><input className="input" required {...field('ownerName')} /></label>
          </>
        )}
        <label className="block"><span className="label">{t('email')}</span><input className="input" type="email" dir="ltr" required autoComplete="username" {...field('email')} /></label>
        <div>
          <label className="label" htmlFor="f-password">{t('password')}</label>
          <input id="f-password" className="input" type="password" dir="ltr" required minLength={creating ? 8 : 1} autoComplete={creating ? 'new-password' : 'current-password'} {...field('password')} />
          {creating && <p className="mt-1 text-sm text-ink/60">{t('passwordHint')}</p>}
        </div>
        {error && <p className="rounded-lg bg-red-50 p-2 text-sm text-red-700" role="alert">{error}</p>}
        <button className="btn-primary w-full" disabled={busy}>{creating ? t('createShop') : t('signIn')}</button>
        <button type="button" className="w-full text-sm font-semibold text-cedar underline" onClick={() => { setCreating(!creating); setError('') }}>
          {creating ? t('haveAccount') : t('newShop')}
        </button>
      </form>
    </div>
  )
}
