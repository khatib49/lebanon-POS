import { createContext, useCallback, useContext, useEffect, useMemo, useState, type ReactNode } from 'react'

export type Language = 'ar' | 'en'

const en = {
  appName: 'lebanon-POS',
  sell: 'Sell', products: 'Products', sales: 'Sales', settings: 'Settings', signOut: 'Sign out',
  signIn: 'Sign in', createShop: 'Create a shop', email: 'Email', password: 'Password',
  shopName: 'Shop name', yourName: 'Your name', haveAccount: 'I already have an account',
  newShop: 'Open a new shop', passwordHint: 'At least 8 characters',
  wrongLogin: 'Wrong email or password.', needInternetToSignIn: 'You need internet to sign in the first time.',
  offline: 'Offline', online: 'Online', waitingToSync: 'waiting to sync', syncNow: 'Sync now',
  search: 'Search by name or barcode', noProducts: 'No products yet.', addFirstProduct: 'Add your first product',
  cart: 'Cart', emptyCart: 'Scan or tap a product to start.', total: 'Total', pay: 'Pay', clear: 'Clear',
  rate: 'Rate', noRate: 'Set today’s exchange rate before selling.', setRate: 'Set rate',
  paidUsd: 'Paid in dollars', paidLbp: 'Paid in lira', exactUsd: 'Exact $', exactLbp: 'Exact LBP',
  cash: 'Cash', card: 'Card', remaining: 'Still owed', change: 'Change to give', or: 'or',
  confirmSale: 'Complete sale', cancel: 'Cancel', paidInFull: 'Paid in full',
  receipt: 'Receipt', print: 'Print', newSale: 'New sale', invoice: 'Invoice', cashier: 'Cashier',
  vat: 'VAT', vatIncluded: 'VAT included', vatNumber: 'VAT number', paid: 'Paid', date: 'Date', item: 'Item',
  savedOffline: 'Saved on this device. It will sync when the internet is back.',
  addProduct: 'Add product', editProduct: 'Edit product', name: 'Name', nameAr: 'Arabic name', barcode: 'Barcode',
  price: 'Price', currency: 'Currency', tax: 'VAT type', taxStandard: 'Standard (VAT applies)',
  taxExempt: 'Exempt (basic foods)', taxZero: 'Zero-rated', active: 'Active', save: 'Save', saved: 'Saved.',
  inactive: 'Inactive', edit: 'Edit',
  today: 'Today', salesCount: 'Sales', cancelled: 'Cancelled', cashInDrawer: 'Cash in drawer', cardPayments: 'Card',
  needsReview: 'Needs review', voidSale: 'Cancel sale', voidReason: 'Why is this sale being cancelled?',
  noSales: 'No sales yet today.', status: 'Status', pending: 'Waiting to sync', synced: 'Synced', error: 'Refused',
  shopSettings: 'Shop details', exchangeRate: 'Exchange rate', lbpPerUsd: 'LBP for 1 USD', currentRate: 'Current rate',
  address: 'Address', phone: 'Phone', receiptFooter: 'Receipt footer', pricesIncludeVat: 'Shelf prices include VAT',
  cashUnit: 'Smallest lira amount in cash', language: 'Language', arabic: 'Arabic', english: 'English',
  managerOnly: 'Only a manager or owner can do this.', ownerOnly: 'Only the owner can change this.',
  qty: 'Qty', remove: 'Remove', loading: 'Loading…', thankYou: 'Thank you',
}

type Key = keyof typeof en

const ar: Record<Key, string> = {
  appName: 'lebanon-POS',
  sell: 'البيع', products: 'المنتجات', sales: 'المبيعات', settings: 'الإعدادات', signOut: 'تسجيل الخروج',
  signIn: 'تسجيل الدخول', createShop: 'إنشاء متجر', email: 'البريد الإلكتروني', password: 'كلمة المرور',
  shopName: 'اسم المتجر', yourName: 'اسمك', haveAccount: 'لدي حساب',
  newShop: 'فتح متجر جديد', passwordHint: '8 أحرف على الأقل',
  wrongLogin: 'البريد الإلكتروني أو كلمة المرور غير صحيحة.', needInternetToSignIn: 'تحتاج إلى الإنترنت لتسجيل الدخول أول مرة.',
  offline: 'غير متصل', online: 'متصل', waitingToSync: 'بانتظار المزامنة', syncNow: 'مزامنة الآن',
  search: 'ابحث بالاسم أو الباركود', noProducts: 'لا توجد منتجات بعد.', addFirstProduct: 'أضف أول منتج',
  cart: 'السلة', emptyCart: 'امسح أو اضغط على منتج للبدء.', total: 'المجموع', pay: 'الدفع', clear: 'مسح',
  rate: 'سعر الصرف', noRate: 'حدّد سعر الصرف اليوم قبل البيع.', setRate: 'تحديد السعر',
  paidUsd: 'المدفوع بالدولار', paidLbp: 'المدفوع بالليرة', exactUsd: 'المبلغ $', exactLbp: 'المبلغ ل.ل',
  cash: 'نقداً', card: 'بطاقة', remaining: 'المتبقي', change: 'الباقي للزبون', or: 'أو',
  confirmSale: 'إتمام البيع', cancel: 'إلغاء', paidInFull: 'مدفوع بالكامل',
  receipt: 'الإيصال', print: 'طباعة', newSale: 'بيع جديد', invoice: 'فاتورة', cashier: 'الكاشير',
  vat: 'الضريبة', vatIncluded: 'تشمل الضريبة', vatNumber: 'الرقم الضريبي', paid: 'المدفوع', date: 'التاريخ', item: 'الصنف',
  savedOffline: 'تم الحفظ على هذا الجهاز. ستتم المزامنة عند عودة الإنترنت.',
  addProduct: 'إضافة منتج', editProduct: 'تعديل المنتج', name: 'الاسم', nameAr: 'الاسم بالعربية', barcode: 'الباركود',
  price: 'السعر', currency: 'العملة', tax: 'نوع الضريبة', taxStandard: 'عادي (تطبّق الضريبة)',
  taxExempt: 'معفى (مواد أساسية)', taxZero: 'نسبة صفر', active: 'فعّال', save: 'حفظ', saved: 'تم الحفظ.',
  inactive: 'غير فعّال', edit: 'تعديل',
  today: 'اليوم', salesCount: 'المبيعات', cancelled: 'ملغاة', cashInDrawer: 'النقد في الصندوق', cardPayments: 'بطاقة',
  needsReview: 'تحتاج مراجعة', voidSale: 'إلغاء البيع', voidReason: 'لماذا يتم إلغاء هذا البيع؟',
  noSales: 'لا توجد مبيعات اليوم.', status: 'الحالة', pending: 'بانتظار المزامنة', synced: 'تمت المزامنة', error: 'مرفوض',
  shopSettings: 'بيانات المتجر', exchangeRate: 'سعر الصرف', lbpPerUsd: 'ليرة لكل دولار', currentRate: 'السعر الحالي',
  address: 'العنوان', phone: 'الهاتف', receiptFooter: 'تذييل الإيصال', pricesIncludeVat: 'أسعار الرف تشمل الضريبة',
  cashUnit: 'أصغر مبلغ نقدي بالليرة', language: 'اللغة', arabic: 'العربية', english: 'English',
  managerOnly: 'هذا الإجراء للمدير أو المالك فقط.', ownerOnly: 'هذا الإعداد للمالك فقط.',
  qty: 'الكمية', remove: 'حذف', loading: 'جارٍ التحميل…', thankYou: 'شكراً لكم',
}

const dictionaries = { en, ar }
const LANGUAGE_KEY = 'lebpos.language'

interface I18n { language: Language; setLanguage: (language: Language) => void; t: (key: Key) => string }

const I18nContext = createContext<I18n | null>(null)

export function I18nProvider({ children }: { children: ReactNode }) {
  const [language, setLanguageState] = useState<Language>(
    () => (localStorage.getItem(LANGUAGE_KEY) as Language | null) ?? 'ar',
  )

  useEffect(() => {
    document.documentElement.lang = language
    document.documentElement.dir = language === 'ar' ? 'rtl' : 'ltr'
  }, [language])

  const setLanguage = useCallback((next: Language) => {
    localStorage.setItem(LANGUAGE_KEY, next)
    setLanguageState(next)
  }, [])

  const value = useMemo<I18n>(
    () => ({ language, setLanguage, t: (key) => dictionaries[language][key] }),
    [language, setLanguage],
  )
  return <I18nContext.Provider value={value}>{children}</I18nContext.Provider>
}

export function useI18n(): I18n {
  const context = useContext(I18nContext)
  if (!context) throw new Error('useI18n must be used inside I18nProvider')
  return context
}

/** A product's name in the current language, falling back to the other one. */
export const localName = (language: Language, item: { name: string; nameAr: string | null }) =>
  language === 'ar' ? item.nameAr || item.name : item.name
