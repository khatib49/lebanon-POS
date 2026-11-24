# POS feature standards vs gaps worldwide (2025–2026): have / don't-have evidence base

> **Method note for the report writer (read first).** Research date: 24 Nov 2026. **Every fact below comes from web-search result summaries of the linked pages, not from a full read of the page** — no page was fetched directly in this session. Summaries of vendor help-centre pages are generally reliable but may miss conditions (region, plan, hardware). Wherever a vendor is not named for a feature, treat it as **"unclear"**, not "does not have". Evidence strength labels used: **Strong** = vendor's own help centre / developer docs; **Medium** = vendor marketing, changelog, or vendor-run community forum; **Weak** = third-party aggregator, review site, competitor blog, or vendor-supplied directory listing.

## 1. Offline: can you keep selling, including cards? Time limits and what breaks

### Takeaway
Offline selling (cash + queued card payments) is table stakes among the leaders, but always with caps, merchant liability, and a list of things that stop working (gift cards, loyalty, house accounts/customer credit, customer search). Nobody found here documents customer credit/tabs working offline; Toast and Rewaa explicitly switch it off.

### Cited Findings
- **Square**: offline payments must be uploaded within 72 hours of the start of the offline session (24 hours recommended); for Square Reader and Square Stand the offline session ends after 24 hours; payments not uploaded in 72 hours expire and cannot be recovered. (Strong) — [Square help: offline payments time limits](https://squareup.com/help/us/en/article/8106-offline-payments-time-limits)
- **Square**: not available offline — EBT/SNAP, Afterpay, Cash App Pay, Square Gift Cards, Tap to Pay on iPhone/Android, manually keyed cards; Interac debit (Canada); Services mode, Square Kiosk, Square Invoices; new online orders may not appear. Seller bears liability for expired/declined/disputed offline payments; a per-transaction offline cap can be set. (Strong) — [Square help: process offline payments FAQ](https://squareup.com/help/gb/en/article/7775-process-offline-payments-faq)
- **Square**: notice that offline payments would be enabled automatically on all devices in April 2026 unless the seller acts. (Strong, from summary) — [Square help: offline payments time limits](https://squareup.com/help/us/en/article/8106-offline-payments-time-limits)
- **Toast**: devices switch to offline mode about 40 seconds after losing internet; cash and card still accepted (cards stored and submitted later, unless the location chose "do not accept card payments"). **Unavailable offline: gift cards, loyalty redemptions, Tender API payments, text to pay, customer credits, comp cards and house accounts**; no card pre-auth. While offline staff cannot close checks, declare cash tips, reconcile cash/tips or clock out. Merchant is liable for declines; per-transaction offline limit applies (set via Customer Care in AU/CA/IE/UK). (Strong) — [Toast: Use Toast in Offline Mode](https://support.toasttab.com/en/article/Using-Toast-in-Offline-Mode?lang=en_US); [Toast: offline payments overview](https://doc.toasttab.com/doc/platformguide/platformOfflinePaymentsOverview.html); [Toast: manage offline payments (AU/CA/IE/UK)](https://support.toasttab.com/en/article/Identify-Offline-Payments-Canada-Ireland-the-U-K)
- **Shopify POS**: offline you can take cash and custom payment methods; offline card acceptance must be switched on in advance and is capped at a merchant-set total; **cannot accept or sell gift cards, search for customers, accept tips, use Tap to Pay on iPhone, take swipe/manual-entry cards, or complete ship-to-customer orders** offline. (Strong) — [Shopify help: offline payments](https://help.shopify.com/en/manual/sell-in-person/shopify-pos/selling-offline/offline-payments?r_done=1); [Shopify help: using POS offline](https://help.shopify.com/en/manual/sell-in-person/shopify-pos/selling-offline)
- **Shopify POS**: a third-party article claims gift cards/store credit can be taken offline as custom payment methods — this conflicts with Shopify's own help centre. (Weak) — [First Pier](https://firstpier.com/resources/shopify-pos-offline-mode); contradicted by [Shopify help](https://help.shopify.com/en/manual/sell-in-person/shopify-pos/selling-offline/offline-payments?r_done=1)
- **Clover**: Station, Station 2018, Mini, Mobile and Flex accept offline payments for up to 7 days by default; per-transaction and total offline limits apply; capturing a pre-auth needs to be online; Clover Go SDK does not support offline (store-and-forward). (Strong) — [Clover docs: handling offline payments](https://docs.clover.com/docs/handling-offline-payments); [Clover docs: Clover Go offline payments](https://docs.clover.com/dev/docs/clover-go-offline-payments)
- **Clover** defaults as documented by ShopKeep/Lightspeed: 7-day rule cannot be changed; default $500 per transaction and $5,000 total offline. (Strong, but a third-party integration doc) — [ShopKeep support: offline credit payments for Clover devices](https://shopkeep-support.lightspeedhq.com/support/advanced/offline-credit-payments)
- **Lightspeed Retail (X-Series)**: enters offline mode automatically after more than two minutes without connection; requires a prior sync and existing login; offline card payments must be enabled in advance and merchant is liable; offline payments are not tied to a sale record and cannot be cancelled/refunded while offline. (Strong) — [Lightspeed X-Series support](https://x-series-support.lightspeedhq.com/hc/articles/25533690950427)
- **Lightspeed Restaurant (K-Series)**: local POS devices keep working with onsite printers/KDS during an internet outage; integrated card payments are not processed in real time — terminal used in standalone mode (LTE/4G) or Lightspeed Payments terminal offline mode. A separate Lightspeed Restaurant article says printers stop working offline; the two sources conflict (likely different product lines: K-Series vs older L-Series). (Strong, conflicting) — [Lightspeed K-Series: offline POS functionality](https://k-series-support.lightspeedhq.com/hc/en-us/articles/53028167251867-Offline-POS-functionality); contradicted by [Lightspeed resto support](https://resto-support.lightspeedhq.com/hc/en-us/articles/5304147660955)
- **Loyverse**: POS app keeps making sales and working with shifts offline; offline sales are not visible in Back Office until the device reconnects and syncs. No offline card or loyalty detail in the summary. (Strong) — [Loyverse help: offline use](https://help.loyverse.com/help/offline-work-of-pos)
- **Zettle**: offline payments exist but only chip and contactless; magstripe not supported. (Strong) — [Zettle help: offline payments](https://www.zettle.com/gb/help/articles/7102116-offline-payments)
- **SumUp**: developer docs describe offline transactions via SDK with explicitly started offline sessions; no merchant-facing limits found. (Strong for SDK only) — [SumUp developer: offline transactions](https://developer.sumup.com/terminal-payments/sdks/offline-transactions/)
- **Epos Now**: offline card processing is an opt-in setting; default maximum £20 per purchase for its accounts; transactions stored on the payment device and submitted on reconnect. (Medium, vendor marketing/guide dated 2025-03) — [Epos Now: offline credit card processing](https://www.eposnow.com/us/resources/offline-credit-card-processing/)
- **Rewaa** (Saudi): offline mode activates automatically when internet drops during a sale; **B2B taxable invoices cannot be issued offline (ZATCA), and creating quotes, adding new customers, and postpaid (pay-later) payments are not supported offline.** (Strong) — [Rewaa help: selling offline in compliance with ZATCA](https://intercom.help/rewaa/en/articles/11426915-how-to-sell-offline-in-compliance-with-zatca)
- **Odoo**: third-party modules exist specifically to make POS credit payment work offline, implying it is not a core offline capability. (Weak/Medium) — [Odoo Apps: bi_pos_credit_payment_offline](https://apps.odoo.com/apps/modules/18.0/bi_pos_credit_payment_offline/)
- **CeevTech** (Lebanon): vendor-supplied G2 listing says the restaurant POS works "through power and internet cuts". (Weak, vendor-supplied) — [G2 seller page: CeevTech](https://www.g2.com/sellers/ceevtech)

### Inferences
- "Offline mode" in the leaders is a degraded cash-plus-risky-cards mode of a cloud product, with windows measured in hours to days (Square 24h/72h, Clover 7 days) and low caps (Epos Now £20; Clover $500/$5,000). It is designed for short outages, not for a market with daily power/internet cuts.
- The features that break offline are exactly the relationship features (customer lookup, loyalty, gift cards, house accounts/credit). A product whose **customer credit tabs, customer search and approvals work fully offline** would be differentiated — Toast and Rewaa document the opposite.
- Offline card risk matters little in Lebanon (cash-dominant), so an entrant can skip the hardest part (store-and-forward card liability) while exceeding incumbents on everything else offline.

### Gaps
- Foodics offline behaviour: no documentation surfaced — unclear.
- Loyverse: whether loyalty points/customer lookup work offline — unclear.
- BIM POS, Omega offline architecture (local server vs cloud) — no source found.
- Lightspeed and SumUp/Zettle offline duration limits and caps — not found.
- No source found giving a maximum offline duration for Shopify POS or Toast.

## 2. Multi-currency at the register (price in one currency, tender in another, change in a second currency, dual-currency receipt)

### Takeaway
Native dual-currency tendering is rare in mainstream SMB POS: Square and Shopify POS explicitly do not do it, Lightspeed has it only in Restaurant K-Series (as a "foreign currency payment method"), and Odoo needs paid third-party modules. It exists in enterprise/duty-free style systems (Oracle Xstore/Simphony, LS Central, NCR Aloha, Vista, KORONA) and in local Lebanese vendors — so this is a strong differentiator against global SMB tools but table stakes against Lebanese incumbents.

### Cited Findings
- **Square**: help page states charging customers in different currencies with Square POS is not available; account country fixes the currency. (Strong) — [Square help: can I accept multiple currencies](https://square.com/help/us/en/article/5415)
- **Square** forum demand: a Canadian bar asked to enter US cash at a set rate — Square replied the POS only records CAD; a long-running "Feature Request: charge customers in different currencies using Square POS" thread exists with many replies; sellers use a discount modifier as a workaround. (Medium, forum posts of mixed/older dates) — [Square community: US cash conversion at a bar](https://community.squareup.com/t5/Using-Square/US-Cash-conversion-for-sale-in-Canada-at-a-bar/m-p/75822); [Square community: feature request thread](https://community.squareup.com/t5/Payments-Troubleshooting/Feature-Request-Charge-customers-in-different-currencies-using/m-p/161970/highlight/true)
- **Shopify POS**: community threads request multi-currency POS support; search summary states Shopify POS cannot sell in multiple currencies. (Medium) — [Shopify community: multi-currency support for POS](https://community.shopify.com/t/multi-currency-support-for-pos/576562); [Shopify community: display local currency on POS while travelling](https://community.shopify.com/t/how-can-i-display-local-currency-on-my-pos-system-while-traveling/184018)
- **Lightspeed Restaurant (K-Series)**: supported — set up a foreign currency with an exchange rate in Back Office, add it as a payment method; **the receipt shows both local and foreign currencies**. (Strong) — [Lightspeed K-Series support](https://k-series-support.lightspeedhq.com/hc/articles/1260804656969)
- **Lightspeed Retail (R-Series)**: "multicurrency" is for vendors/purchase orders only (manual exchange rate, permanent once enabled, rate not auto-updated); no register-level foreign tender found. (Strong for PO feature; register tender = unclear) — [Lightspeed Retail support](https://retail-support.lightspeedhq.com/hc/articles/1260804903129)
- **Odoo POS**: many third-party App Store modules add second-currency payment, rate editable from the payment screen, change printed in both currencies, change computed in the currency handed over, dual-currency cash control. Their abundance (versions 12–19, a dozen+ vendors) indicates the core product does not cover it. (Medium) — [pos_multiple_currency](https://apps.odoo.com/apps/modules/17.0/pos_multiple_currency); [eg_pos_multi_currency_payment](https://apps.odoo.com/apps/modules/19.0/eg_pos_multi_currency_payment); [dps_dynamic_multicurrency_cashcontrol](https://apps.odoo.com/apps/modules/18.0/dps_dynamic_multicurrency_cashcontrol); [dps_aio_pos_dual_currency](https://apps.odoo.com/apps/modules/19.0/dps_aio_pos_dual_currency)
- **KORONA POS**: manual says more than one currency can be used (aimed at airports/tourist gift shops); currencies are created in Settings and attached to payment methods. Change handling not described in summary. (Strong) — [KORONA manual: currencies](https://manual.koronapos.com/currencies/); [KORONA manual: payment methods](https://manual.koronapos.com/payment-methods/)
- **Enterprise systems with documented foreign-currency tender**: LS Central (payment with foreign currency), Oracle Xstore (foreign currency maintenance, exchange rates), NCR Aloha (foreign currencies), Vista cinema POS (give change displayed in local currency). (Strong) — [LS Retail help](https://help.lsretail.com/lscentral130/Content/LS%20Retail/Safe%20Management/Payment%20with%20Foreign%20Currency.htm); [Oracle Xstore](https://docs.oracle.com/en/industries/retail/retail-xstore-point-of-service/21.0/rpxug/foreign-currency-maintenance.htm); [NCR Aloha](https://docs.ncrvoyix.com/restaurant/aloha-pos/implementing/field_definitions/foreign_currencies); [Vista help](https://help.vista.co/hc/en-nz/articles/4415244155801)
- **Elementary POS**: recently added cash payments in multiple currencies while keeping account and prices in base currency. (Medium) — [Elementary POS blog](https://elementarypos.com/en/new-feature-payments-in-multiple-currencies/)
- **Open-source demand signals**: NexoPOS "Multi Currency Feature" discussion; Open Source POS wiki page on alternate-currency receipts. (Medium) — [NexoPOS discussion #1358](https://github.com/Blair2004/NexoPOS/discussions/1358); [opensourcepos wiki](https://www.github.com/opensourcepos/opensourcepos/wiki/Alternate-Currency-Receipts-and-Invoices)
- **Loyverse**: Capterra review summary lists "multiple currencies" among features users have requested. (Weak) — [Capterra: Loyverse reviews](https://www.capterra.com/p/150632/Loyverse-POS/reviews/?page=2)
- **BIM POS** (Lebanon): own blog describes choosing accepted currencies per location, showing menu prices in the customer's currency, fixed or live exchange rates. LBP not named in the summary. (Medium, vendor marketing) — [BIM POS blog](https://bimpos.com/blog/is-your-restaurant-pos-ready-to-serve-a-global-customer-base-0)
- **CeevTech** (Lebanon): vendor-supplied listings say it handles USD and LBP with the exchange rate frozen per transaction. (Weak, vendor-supplied) — [G2: CeevTech](https://www.g2.com/sellers/ceevtech); [Slashdot: CeevTech ERP](https://slashdot.org/software/p/CeevTech-ERP/)
- Lebanese market expectation (competitor blog, low reliability): a POS must handle LBP and USD pricing, apply the rate at transaction time and report in both; many restaurants price in USD with LBP equivalents shown. (Weak) — [voxire blog](https://voxire.pages.dev/blog/best-pos-systems-lebanese-restaurants-2026/)
- Lebanese banks sell dual-currency card terminals (BLC: $40 install, $5/month, fees valid as of 30/09/2026) — a bank product, separate from POS software. (Strong for the bank fee) — [BLC Bank fees](https://www.blcbank.com/business/fees)

### Inferences
- Among the named global SMB vendors, only Lightspeed K-Series has a documented native foreign-currency tender with a dual-currency receipt. Square, Shopify POS = documented "no". Toast, Clover, SumUp, Zettle, Epos Now, Loyverse, Foodics, Rewaa = unclear (no evidence of support found; these are mostly single-country-currency products tied to their own payment processing).
- Even where supported, the model is "foreign currency as an occasional payment method" (tourist use case), not "two co-equal currencies in one drawer every transaction" with mixed tender, change in either currency, and dual-currency drawer counts. The Odoo module market shows what the full requirement looks like (rate edit at payment screen, change in both currencies, dual-currency cash control).
- For lebanon-POS, dual currency is a must-have to match BIM/CeevTech/local vendors, and a clear advantage versus Loyverse/Square-type imports.

### Gaps
- Hike POS, Erply, Oracle Simphony specifics: not surfaced.
- Whether any vendor supports dual-currency **cash-drawer counts/Z-reports** natively (only an Odoo third-party module found).
- Foodics, Rewaa, Toast, Clover, SumUp, Zettle, Epos Now, Loyverse multi-currency tender: unclear — no source either way (Loyverse only via a weak review mention).
- Omega (Lebanon): nothing found.

## 3. Customer credit / house accounts / pay-later tabs

### Takeaway
House accounts with credit limits and statements are common in the mid/upper tier (Toast, Square, Lightspeed, Foodics, Rewaa, Odoo), so the core ledger is a differentiator-tier feature, not white space. The white space is collection: no evidence found of automated WhatsApp/SMS debt reminders from any named vendor, and several vendors disable credit offline.

### Cited Findings
- **Toast**: house accounts with a configurable charge limit (overage goes to a separate payment); balances paid on POS or by invoice (invoice recommended); reporting page in Toast Web for transactions, invoices and payments. Unavailable in offline mode. (Strong) — [Toast: house accounts overview](https://doc.toasttab.com/doc/platformguide/platformHouseAccountsOverview.html); [Toast: managing house account settings](https://doc.toasttab.com/doc/platformguide/platformManageHouseAccountsSettings.html); [Toast: offline mode](https://support.toasttab.com/en/article/Using-Toast-in-Offline-Mode?lang=en_US)
- **Square**: Square House Accounts with a per-account spending limit; Square states house accounts cannot be used to extend loans, impose finance charges, or accept repayment in instalments. Square Invoices are not supported offline. (Strong) — [Square help: create and charge house accounts](https://squareup.com/help/us/en/article/8034); [Square developer: house accounts](https://developer.squareup.com/docs/payments-api/take-payments/house-accounts)
- **Square** earlier forum history: reps said adding credit to a customer profile was not available and suggested invoices or gift cards; sellers asked for partial payment on open tickets. (Medium, older threads — superseded at least partly by House Accounts) — [Square community: payment methods](https://community.squareup.com/t5/Archived-Discussions-Read-Only/payment-methods/td-p/232804); [Square community: partial payment on open tickets](https://community.squareup.com/t5/Square-Point-of-Sale/Partial-payment-on-open-tickets/m-p/773899)
- **Lightspeed Retail (R-Series)**: customer credit accounts with credit limit, account statement preparation/preview, activity review; set limit to $0 to deactivate. Lightspeed Golf: credit limit plus three house-account reports including monthly statements export. (Strong) — [Lightspeed Retail: managing customer credit accounts](https://retail-support.lightspeedhq.com/hc/articles/20656766930459-Managing-customer-credit-accounts); [Lightspeed Golf](https://golf-support.lightspeedhq.com/hc/en-us/articles/9814588594843)
- **Foodics**: House Account lets customers buy on credit and pay later, with a house-account limit; repayment at any branch in the Cashier app or registered in Console; available in Foodics One. (Strong; some detail from an older help domain) — [Foodics help: enabling house accounts](https://help.foodics.com/hc/en-us/articles/4408281561490-Enabling-House-Accounts-for-Customers); [Foodics help: adding credit to client house account](https://help.foodics.com/hc/en-us/articles/8803226566940-Adding-Credit-to-Client-House-Account); [Foodics (older): adding house account transaction](https://foodics.helpjuice.com/558684-adding-house-account-transaction)
- **Rewaa**: postpaid payment as a register option, payable in one or multiple instalments; controllable per cashier via a "Post Payment" permission; not supported offline. (Strong) — [Rewaa help: postpaid payment permission](https://intercom.help/rewaa/en/articles/8717231-postpaid-payment-permission-for-users); [Rewaa help: selling offline](https://intercom.help/rewaa/en/articles/11426915-how-to-sell-offline-in-compliance-with-zatca)
- **Odoo POS**: core "Customer account" payment method (identify customer, uses receivable account) with "Settle orders / Settle invoices" in POS. Enforced credit limits come from third-party modules; one vendor states that by default Odoo only warns when the limit is exceeded and the cashier can still choose Customer Account. (Strong for core; Medium/Weak for the default-behaviour claim) — [Odoo docs: customer account](https://www.odoo.com/documentation/master/applications/sales/point_of_sale/payment_methods/customer_credit.html); [Odoo Apps: sensible_pos_credit_limit](https://apps.odoo.com/apps/modules/18.0/sensible_pos_credit_limit)
- **Shopify POS**: store credit can be viewed/added/removed from customer details in POS; refunds can be issued as store credit (2025 changelog); email notification when store credit is issued (9 Sep 2025). This is prepaid/refund credit, not a debt tab. A community thread asks how to implement net-30 charge accounts in POS; workaround = custom manual payment method or third-party app. Shopify also shipped B2B payment reminders (B2B invoices, not POS tabs). (Strong for store credit; Medium for workaround) — [Shopify changelog: store credit on POS](https://changelog.shopify.com/posts/store-credit-is-now-available-on-pos); [Shopify changelog: store credit email notification](https://changelog.shopify.com/posts/send-customers-an-email-notification-when-they-receive-store-credit); [Shopify community: net 30 charge account in POS](https://community.shopify.com/t/how-can-i-implement-a-net-30-charge-account-feature-in-pos/5047/2); [Shopify changelog: B2B payment reminders](https://changelog.shopify.com/posts/increase-on-time-b2b-payments-with-payment-reminders)
- **Loyverse**: Capterra review summary lists "layaway" and "customer credit" among user-requested features; Loyverse help-centre payment topics list nothing on customer credit; POS has Open Tickets. (Weak) — [Capterra: Loyverse reviews](https://www.capterra.com/p/150632/Loyverse-POS/reviews/?page=2); [Loyverse help: payments](https://help.loyverse.com/help/payments)

### Inferences
- A customer-credit ledger with limits is offered by at least six named vendors, so lebanon-POS's tab feature is parity with the mid-tier and an advantage over Loyverse-class free tools (where it appears absent, weak evidence) and Shopify POS (no debt tabs natively).
- Square's explicit prohibition on instalment repayment and Toast's "pay by invoice" model show that Western house accounts are corporate-billing tools, not the informal neighbourhood "دفتر/tab" with partial repayments. Rewaa (instalments allowed) is closer to the MENA use case.
- The differentiating layer is: partial repayments, credit working offline, statements, and **reminders over WhatsApp** — no evidence of the last from any named vendor.

### Gaps
- No source found showing any named vendor sending automated WhatsApp or SMS debt reminders for house accounts — treat as "unclear / no evidence", not confirmed absent.
- Clover house accounts (likely via App Market apps): not surfaced — unclear.
- SumUp, Zettle, Epos Now customer credit: not researched — unclear.
- Loyverse: no primary source confirming absence of customer credit; only a review-site mention of user requests.
- BIM POS, Omega, CeevTech customer credit: no source found.

## 4. Right-to-left Arabic UI and Arabic receipt printing

### Takeaway
Proper Arabic RTL is documented for Gulf-focused products (Zoho POS KSA edition, Qoyod, LS Central, Oracle Simphony) but could not be confirmed from primary sources for Square, Loyverse or Shopify POS; Shopify's POS app listing says it is not translated into Arabic. Arabic on thermal printers is a well-known engineering trap (reversed, unjoined letters) whose standard fix is printing the receipt as an image.

### Cited Findings
- **Shopify POS**: Shopify's own app page states the POS app is not translated into Arabic. (Strong, from summary of Arabic-locale app listing) — [Shopify App Store: Point of Sale (ar)](https://apps.shopify.com/shopify-pos?locale=ar)
- **Square**: an aggregator says Square localisation is primarily optimised for English-speaking markets; a Lebanese competitor blog says "No Arabic RTL". Neither cites Square docs. (Weak) — [FitGap: Arabic POS software](https://us.fitgap.com/search/pos-software/arabic?page=2); [voxire blog](https://voxire.pages.dev/blog/best-pos-systems-lebanese-restaurants-2026/)
- **Loyverse**: POS app supports 40+ languages and Back Office 30+; receipt language can be set separately; Arabic/RTL not named in the official pages surfaced. FitGap claims full Arabic RTL support — unverified. (Strong for language counts; Weak for RTL claim) — [Loyverse help: how to change language](https://help.loyverse.com/help/how-change-language); [FitGap](https://us.fitgap.com/search/pos-software/arabic?page=2)
- **Zoho POS (KSA edition)**: complete Arabic UI with full RTL support. (Medium, vendor blog) — [Zoho blog: Zoho POS for Saudi](https://blog.zoho.com/pos/zoho-pos-for-saudi.html)
- **Qoyod POS**: release notes on POS languages (and dark mode). (Medium) — [Qoyod release note](https://www.qoyod.com/en/releases/pos-languages-dark-mode/)
- **LS Central**: dedicated localisation docs for Arabic receipts, Arabic character printing and item Arabic description. (Strong) — [LS Central: Arabic receipt](https://help.lscentral.lsretail.com/Content/Localization/Arabic-Receipt.htm); [LS Central: Arabic characters printing](https://help.lscentral.lsretail.com/Content/Localization/AE/Arabic-Print-Receipt-Functionality.htm)
- **Oracle Simphony**: documents configuring right-to-left reading languages and multiple languages on guest checks/receipts. (Strong) — [Oracle Simphony: RTL languages](https://docs.oracle.com/cd/F32325_01/doc.192/f32328/t_checks_right_left_reading_languages.htm)
- **Odoo**: third-party module for Arabic product names in POS; forum threads on Arabic POS receipts. (Medium) — [Odoo Apps: cst_pos_product_arabic_name](https://apps.odoo.com/apps/modules/18.0/cst_pos_product_arabic_name); [Odoo forum: POS Arabic receipt](https://www.odoo.com/forum/help-1/question/pos-arabic-receipt-148075)
- **CeevTech**: vendor-supplied listing states Arabic and English support. (Weak) — [G2: CeevTech](https://www.g2.com/sellers/ceevtech)
- **Thermal-printer Arabic bugs**: printers take codes left-to-right so RTL text prints reversed; simple reversal still breaks letter joining (initial/medial/final forms); developers report inability to get joined Arabic in native ESC/POS; code pages (Windows-1256, ISO-8859-6) work on only some models; recommended fix is rendering text to a bitmap and printing the image. (Medium — developer forums, multiple independent reports, some older) — [B4X forum](https://www.b4x.com/android/forum/posts/914687); [MIT App Inventor community: Xprinter Arabic](https://community.appinventor.mit.edu/t/unable-to-print-in-arabic-on-xprinter-xp-p810/96322/9); [Ionic forum](https://forum.ionicframework.com/t/bluetooth-printer-does-not-printing-arabic-in-good-format/165101); [StackOverflow mirror: ESC/POS Arabic](https://kiwix.lema.org/stackoverflow.com_en_all_2023-11/questions/55919544/esc-pos-printing-arabic-characters-withthermal-printer)

### Inferences
- Arabic RTL is table stakes for MENA-built products and a gap (or at least unverified) for US/EU-built SMB tools — a positive differentiator vs imports, parity vs Foodics/Rewaa/BIM.
- For a web POS, rasterised (image) receipt printing is the safe default for Arabic and mixed Arabic/English lines; it should be marketed as "Arabic receipts that print correctly on cheap printers".

### Gaps
- Foodics and Rewaa Arabic UI: almost certainly supported (Saudi vendors) but no source surfaced in this session — mark as "expected, unverified here".
- Loyverse and Square RTL: no primary source either way — unclear.
- Toast, Clover, Lightspeed, SumUp, Zettle, Epos Now Arabic: not researched — unclear.

## 5. WhatsApp integration (receipts, ordering, reminders, reports)

### Takeaway
WhatsApp is not a native feature of any named global leader in the evidence found; it appears mainly through Odoo third-party modules (receipts by WhatsApp, via Business API or unofficial WhatsApp Web sessions). This is thin evidence, but it points to WhatsApp receipts/reminders being white space among global vendors.

### Cited Findings
- **Odoo POS**: numerous third-party modules send POS receipts/invoices over WhatsApp — as PDF/image attachment, via a WhatsApp button on the receipt screen, manual or automatic; some use the official WhatsApp Business API with templates, others use WhatsApp Web sessions (per-user login, phone must be online). (Medium) — [Odoo Apps: whatsapp_pos_integration](https://apps.odoo.com/apps/modules/19.0/whatsapp_pos_integration); [Odoo Apps: pos_whatsapp_receipt](https://apps.odoo.com/apps/modules/19.0/pos_whatsapp_receipt); [Odoo Apps: pragmatic_odoo_pos_whatsapp_integration](https://apps.odoo.com/apps/modules/19.0/pragmatic_odoo_pos_whatsapp_integration); [Webkul guide](https://webkul.com/blog/odoo-pos-send-receipt-greetings-via-whatsapp/amp/)
- **Paladin POS** uses SMS with a link (not WhatsApp) for remote manager approval — an example of messaging-channel approvals. (Strong) — [Paladin knowledge base](https://portal.paladinpos.com/knowledge-base/remote-manager-approval/)

### Inferences
- Native WhatsApp receipts, debt reminders and daily owner reports would be a visible differentiator against Square/Toast/Shopify/Loyverse-class products, which centre on email/SMS receipts.
- Two implementation routes exist in the wild: official Business API (template approval, per-message cost) and "click-to-chat"/WhatsApp Web (free, manual send). The latter fits an offline-first web app (wa.me deep link with prefilled text) without API costs.

### Gaps
- Foodics, Rewaa, Square, Toast, Shopify, Lightspeed, Loyverse, Clover native WhatsApp features: nothing surfaced — unclear (not confirmed absent). Foodics/Rewaa in particular may have marketplace integrations.
- BIM POS / Omega / CeevTech WhatsApp ordering or receipts: no source found.

## 6. Loss prevention: blind counts, approvals, manager PINs, remote owner approval, audit logs

### Takeaway
Role permissions and manager-PIN approvals are standard; blind cash counts and activity logs are common; **remote owner approval from a phone** exists only in a handful of niche/vertical vendors (EmaginePOS, NRS, KwickPOS, STORIS, Paladin, Vista) and was not found for any of the named leaders.

### Cited Findings
- **Shopify POS**: POS activity log captures cash-drawer operations (open, add cash, remove cash, mid-session counts). (Strong) — [Shopify changelog: POS activity log](https://changelog.shopify.com/posts/pos-activity-log)
- **Lightspeed**: own blog recommends a "blind close" where the employee counts without seeing the expected total. (Medium — guidance, not feature documentation) — [Lightspeed blog: retail cash handling](https://www.lightspeedhq.com/blog/retail-cash-handling/)
- **Toast**: permission "1.15 Offline/Background Credit Card Processing" lets staff approve offline payments above the limit (example of granular numbered permissions); cash drawer reports incl. Cash Activity Audit referenced in (deprecated) cash-management docs. (Strong / partly dated) — [Toast: manage offline payments](https://support.toasttab.com/en/article/Identify-Offline-Payments-Canada-Ireland-the-U-K); [Toast: deprecated cash management](https://doc.toasttab.com/doc/platformguide/platformDeprecatedCashManagement.html)
- **Rewaa**: per-cashier payment permissions (e.g. disable Post Pay). (Strong) — [Rewaa help](https://intercom.help/rewaa/en/articles/8717231-postpaid-payment-permission-for-users)
- **Vori** (US grocery POS): manager-approval thresholds for pay-ins, pay-outs, refunds and discounts; 6-digit PIN for specific actions or above a set amount. (Strong) — [Vori help](https://help.vori.com/streamline-pos-operations-with-new-till-and-manager-approval-settings)
- **Remote approval exists at**: EmaginePOS Manager app (push notification for void/comp/discount override, approve/deny with order details); NRS Remote Manager Override (several managers, first to respond decides); KwickPOS Remote Approval; STORIS NextGen; Paladin (SMS link); Vista (remote authorisation). (Strong for vendor docs/app listings; Weak for the KwickPOS Reddit post) — [EmaginePOS Manager app](https://apps.apple.com/us/app/id968079921); [NRS remote manager override](https://nrsplus.com/rmo/); [Paladin](https://portal.paladinpos.com/knowledge-base/remote-manager-approval/); [Vista help](https://help.vista.co/hc/en-nz/articles/18321060373401-Requesting-remote-authorisation-from-a-manager); [Reddit r/restaurant (mirror)](https://redlib.ssps.io/r/restaurant/comments/1l1031t/discussion_remote_approval_on_pos_gamechanger_for)
- **Heartland**: push notifications for voids/discounts are threshold alerts, not approval requests. (Strong) — [Heartland support: push notifications](https://heartlandpos.zendesk.com/hc/en-us/articles/4403830497563-Push-Notifications)
- A patent covers approving a POS permission request from a control inside a phone notification. (Strong as existence of patent; legal relevance not assessed) — [Google Patents US10867291B1](https://patents.google.com/patent/US10867291)
- Dual-currency cash control in Odoo exists only as a third-party module. (Medium) — [Odoo Apps: dps_dynamic_multicurrency_cashcontrol](https://apps.odoo.com/apps/modules/18.0/dps_dynamic_multicurrency_cashcontrol)

### Inferences
- Table stakes: roles/permissions, manager PIN for void/refund/discount, shift/drawer open-close with variance. Differentiator: blind counts, immutable audit log surfaced to the owner. White space among SMB leaders: remote approve/deny from the owner's phone, and dual-currency drawer counts.
- Remote approval needs connectivity at both ends, which conflicts with offline-first; an offline fallback (one-time owner code or manager PIN with after-the-fact owner notification) is needed.
- The US10867291B1 patent should be checked by counsel if the product ships approve-from-notification and ever enters the US; not relevant to Lebanon-only operation (inference, not legal advice).

### Gaps
- Square, Clover, Lightspeed, Loyverse, Foodics official docs on void/refund approval settings, blind counts and audit-log contents: not surfaced — unclear.
- Camera/CCTV-overlay integration: not researched; no source.
- Who holds the US10867291B1 patent and its status: not checked.

## 7. Owner mobile app, proactive alerts, AI assistants

### Takeaway
Conversational AI assistants became a standard announcement among the leaders in 2025–2026 (Square AI, Toast IQ, Shopify Sidekick/Magic, Lightspeed AI, Clover), mostly as dashboard Q&A over sales data; the BIM POS site also advertises an AI ("Bimmie"). Proactive owner alerts are documented only patchily.

### Cited Findings
- **Square AI**: open beta in the dashboard for existing customers; natural-language insights on sales trends, top items, staff performance; 2026 Canadian launch reported. (Medium, trade press) — [Tech.co: integrate AI POS](https://tech.co/pos-system/integrate-ai-pos-system); [Retail Insider](https://retail-insider.com/?p=191630)
- **Toast IQ**: assistant embedded in Toast POS across sales, labour, guest and menu data; Toast also announced a set of AI agents; Toast IQ Grow (marketing) price reported inconsistently ($499/month vs from $699/month). (Medium; price conflict noted) — [Toast blog: Toast IQ](https://pos.toasttab.com/blog/on-the-line/toast-iq); [NRN: Toast unveils AI agents](https://www.nrn.com/restaurant-technology/toast-unveils-an-array-of-new-ai-agents-for-restaurants); [eMarketer](https://www.emarketer.com/content/toast-leans-management-marketing-ai-tools-relieve-owner-stress)
- **Clover** (Fiserv) joined Toast and Square in selling AI as a time-saver for small businesses. (Medium) — [eMarketer](https://www.emarketer.com/content/fiserv-s-clover-joins-toast-square-selling-ai-time-saver-small-businesses)
- **Lightspeed AI**: embedded conversational assistant across retail and restaurant platforms. (Medium/Weak, news site) — [Business News Today](https://business-news-today.com/lightspeed-commerce-nyse-lspd-launches-ai-assistant-across-retail-and-restaurant-platforms/)
- **Shopify**: Shopify Magic (content generation) and Sidekick (reporting/operations assistant). (Medium) — [Tech.co](https://tech.co/pos-system/integrate-ai-pos-system)
- **BIM POS**: site banner promotes "Meet Bimmie: AI, Costs Optimization, and beyond" webinar. (Medium, vendor site banner as shown in search result title) — [BIM POS site](https://bimpos.com/gh/blog/is-your-restaurant-pos-ready-to-serve-a-global-customer-base)
- **Heartland**: threshold-based push notifications for voids and discounts to a handheld. (Strong) — [Heartland support](https://heartlandpos.zendesk.com/hc/en-us/articles/4403830497563-Push-Notifications)

### Inferences
- "AI assistant" is moving from differentiator to expected at the top end, but is English-first, online-only and bundled into higher tiers. An Arabic-capable assistant or simply a proactive daily WhatsApp summary ("sales, cash variance, voids, overdue tabs") would be differentiated for the Lebanese SMB owner.

### Gaps
- Owner mobile apps (Square Dashboard app, Toast Now, Loyverse Dashboard, Lightspeed Insights etc.) and what alerts they push: not surfaced in this session — no sources; treat as unclear.
- Whether any assistant works in Arabic: no source.

## 8. Onboarding: self-serve sign-up, catalogue import, time to first sale

### Takeaway
Square documents AI/assisted menu creation from a PDF/JPG/PNG upload, import from another platform (including Toast, via WoFlow) and AI-generated starter menus — but with human-in-the-loop turnaround (email when ready, mostly under 24 hours) and reported availability limits. No equivalent documentation surfaced for other vendors.

### Cited Findings
- **Square for Restaurants**: menu creation options include upload a file or photo (PDF, JPG, PNG), import from another platform such as Toast (via third-party WoFlow, by sign-in or public URL), or generate a custom starter menu; seller reviews and clicks Approve; Square emails when ready, "most menu builds take under 24 hours"; one help page says upload/import are currently only for quick-service restaurants. (Strong; availability caveat may be dated) — [Square help: create and update menus](https://squareup.com/help/us/en/article/6424-create-and-update-menus)
- **Loyverse**: add-ons have a 14-day free trial started from Back Office with no credit card; core POS is free — implies fully self-serve sign-up. (Strong) — [Loyverse pricing](https://loyverse.com/pricing)
- **BIM POS**: pricing only available by contacting the vendor (implies sales-led onboarding). (Weak, Capterra listing) — [Capterra: BIM POS](https://www.capterra.com/p/143097/BIM-POS/reviews/)

### Inferences
- Instant, on-device menu/catalogue import from a photo (no 24-hour wait, works for retail price lists and Arabic menus) would beat the best documented incumbent flow.
- Self-serve sign-up is table stakes among global app-based POS (Square, Loyverse, Shopify, SumUp, Zettle) and a differentiator against Lebanese/Gulf sales-led vendors.

### Gaps
- Toast, Lightspeed, Clover, Foodics, Rewaa onboarding (installer requirement, time to first sale): no sources surfaced.
- Barcode product databases (GS1/open product DB lookups) in any vendor: not researched; no source.
- Any measured "time to first sale" figures: none found.

## 9. Hardware openness, web/PWA POS and its limits

### Takeaway
Loyverse, Shopify and Lightspeed document bring-your-own hardware with supported-printer lists; Clover terminals are tied to their processor. A browser-based POS can print and scan, but direct USB/serial/Bluetooth device access works only in Chromium browsers — not Safari/iOS — and iOS Safari storage has eviction rules that an offline-first PWA must design around.

### Cited Findings
- **Loyverse**: publishes tested/recommended printer list; compatible with Sunmi built-in printers; on Android other ESC/POS models can be tried ("not every printer may work"); iOS requires Epson-compatible ESC/POS with Ethernet. (Strong) — [Loyverse hardware](https://loyverse.com/hardware); [Loyverse help: supported printers](https://help.loyverse.com/help/supported-printers); [Loyverse help: other printers on Android](https://help.loyverse.com/help/how-set-other-printers-loyverse-pos)
- **Square**: POS is compatible with a wide variety of third-party accessories (compatibility table by device). (Strong) — [Square help: hardware compatibility by device](https://square.com/help/us/en/article/6334)
- **Shopify POS**: supported-hardware tables by model; third-party retailers allowed outside hardware-store countries. (Strong) — [Shopify help: supported hardware](https://help.shopify.com/en/manual/sell-in-person/hardware/supported-hardware)
- **Lightspeed Retail X-Series**: supported hardware, plus "compatible but unsupported" hardware allowed. (Strong) — [Lightspeed X-Series support](https://x-series-support.lightspeedhq.com/hc/articles/25534085601051)
- **Clover**: terminals cannot be repointed at another processor. (Weak, vendor blog title) — [Katalyst: what it costs to leave your POS](https://www.katalystos.com/blog/what-it-costs-to-leave-your-pos)
- **Web Serial**: Chromium desktop and recent Chrome on Android only; Safari (macOS/iOS/iPadOS) does not support it and WebKit opposes the spec. **WebUSB**: negative standards position from at least one vendor; unlikely to become Baseline. (Strong) — [caniuse: Web Serial](https://caniuse.com/web-serial); [caniuse: WebUSB](https://caniuse.com/webusb); [web-features explorer: WebUSB](https://web-platform-dx.github.io/web-features-explorer/features/webusb)
- **Browser printing workarounds**: Epson/Star network printers with built-in web server accept jobs over HTTP; USB/Bluetooth browser printing only in Chrome/Edge; iOS needs vendor SDK (e.g. Bixolon Web Print SDK), network printing, or a local/cloud print agent. (Medium) — [WCPOS docs: printers](https://docs.wcpos.com/hardware/printers.md); [Bixolon Web Print SDK](https://www.bixolon.com/software_view.php?idx=320); [HPRT: print POS receipts from web app](https://fr.hprt.com/Product/POS-PRINTERS/how-to-print-pos-receipts-from-web-app.html); [Openbravo: WebBluetooth and WebUSB for POS hardware](https://www.openbravo.com/blog/?p=63804)
- **Safari storage**: since iOS/iPadOS 13.4 and Safari 13.1 there is a seven-day cap on script-writable storage (IndexedDB, service worker registrations, Cache API) for sites used in Safari; web.dev says this does not apply to PWAs added to the home screen. (Strong) — [web.dev: storage for the web](https://web.dev/articles/storage-for-the-web)
- **Caveats to the home-screen exemption**: a WebKit bug report describes a home-screen PWA losing service worker and IndexedDB data after a week of non-use; Apple developer forum threads raise the same concern; WebKit's storage-policy post says home-screen web apps get the same quotas as in-browser and that origins with an active page or persistent mode may be excluded from eviction. (Strong sources; behaviour disputed) — [WebKit bug 266559](https://bugs.webkit.org/show_bug.cgi?id=266559); [Apple developer forums](https://developer.apple.com/forums/thread/710157); [WebKit: updates to storage policy](https://webkit.org/?p=14403); [MDN: storage quotas and eviction criteria](https://developer.mozilla.org/docs/Web/API/Storage_API/Storage_quotas_and_eviction_criteria)
- Unverified community claim: on iOS persistent-storage requests are always denied and IndexedDB is limited to ~50 MB. (Weak — could not be confirmed against WebKit/web.dev) — [swoff docs](https://swoff.netlify.app/docs/concepts/ios-safari-limitations)

### Inferences
- For a web/PWA POS, the reliable hardware matrix is: Android or Windows with Chrome/Edge (WebUSB/Web Serial/Web Bluetooth printing, keyboard-wedge scanners), or network printers over HTTP; iPad/iPhone only with network printers or a helper. This should be stated openly in the compatibility list.
- Offline-first on iOS must assume local data can be evicted: require install-to-home-screen, call `navigator.storage.persist()`, sync aggressively when online, and offer export/backup of unsynced sales. Android Chrome is the safer primary target.
- "Runs on the phone/tablet/PC you already own" is table stakes among app-based vendors (Loyverse, Square, Shopify) but a differentiator against proprietary-terminal vendors (Clover, Toast).

### Gaps
- Chrome/Android storage quota numbers and persistence behaviour: not surfaced in summaries.
- Barcode scanner behaviour in browsers (keyboard-wedge vs WebHID): no direct source; keyboard-wedge working is an untested assumption.
- Toast hardware lock-in: not surfaced in this session — unclear.
- Examples of production PWA POS products and their documented limits: only WCPOS (WooCommerce) docs surfaced.

## 10. Pricing transparency, contracts, termination, data portability

### Takeaway
The market splits cleanly: app-based vendors publish prices and have no contracts (Loyverse explicitly: no contracts, no cancellation fees), while Toast/Clover/Lightspeed are associated with multi-year terms, auto-renewal and early-termination fees; Lebanese BIM POS is quote-only. Public monthly pricing with no lock-in is a real differentiator in the restaurant and Lebanese segments.

### Cited Findings
- **Loyverse**: free core POS (sales, 31-day analytics, essential inventory, loyalty, customer display, kitchen display, multi-store, integrations); paid add-ons; "no contracts, no cancellation fees, no monthly minimums"; 14-day add-on trials without credit card. Add-on prices conflict between sources/regions (US page: $5/month per store for one add-on; llms.txt: Employee Management €5/month per employee, Advanced Inventory €25/month per store; third-party review: $25/month per store). (Strong for structure; price figures conflicting) — [Loyverse pricing (US)](https://loyverse.com/en-us/pricing); [Loyverse llms.txt](https://loyverse.com/llms.txt); [Merchant Maverick: Loyverse review](https://www.merchantmaverick.com/reviews/loyverse-review/)
- **Toast**: reviews report 24-month contracts and early-termination fees of $15,000–$30,000 (reviewer-reported; treat with caution); a 2024 guide says annual auto-renewal with cancellation 30 days before term end and an ETF; a competitor guide estimates ETF as remaining subscription fees. (Weak/Medium; figures conflict) — [NerdWallet: Toast POS review 2026](https://www.nerdwallet.com/business/software/reviews/toast-pos); [Lavu: how to cancel Toast contract](https://lavu.com/how-to-cancel-toast-contract)
- **Toast FTC lawsuit**: a competitor blog reports an FTC suit filed 29 October 2026 targeting early-termination fees of $150 per remaining month and cancellation friction; Toast denies the claims; allegations are unproven. (Weak — single competitor-blog source via search summary; verify before use) — [KORONA POS blog: Toast FTC lawsuit](https://koronapos.com/blog/toast-ftc-lawsuit/)
- **Clover**: terms depend on reseller; minimum 1-year contract with 30 days' notice reported; ETFs around $295–$595, three-year auto-renewing terms common, one report of a non-cancellable 48-month first term; hardware cannot be repointed to another processor. (Weak — third-party/competitor sources) — [Katalyst: what it costs to leave your POS](https://www.katalystos.com/blog/what-it-costs-to-leave-your-pos); [NerdWallet: Toast competitors](https://www.nerdwallet.com/business/software/best/toast-competitors)
- **Lightspeed**: a review lists "early cancellation fee" and "must use Lightspeed Payments" as cons. (Weak) — [Merchant Maverick](https://www.merchantmaverick.com/?p=22488)
- **Canada**: the Code of Conduct for the Payment Card Industry requires an information summary box disclosing key contract dates, cancellation terms and equipment obligations. (Medium, vendor blog describing regulation) — [Toast Canada blog: compare POS agreements](https://pos.toasttab.com/ca/blog/on-the-line/how-to-compare-restaurant-pos-agreements)
- **BIM POS**: pricing available only by contacting the vendor. (Weak, Capterra listing) — [Capterra: BIM POS](https://www.capterra.com/p/143097/BIM-POS/reviews/)
- **Foodics**: export of ZATCA e-invoices with sync status (a data-export example); B2B BNPL "Flex" programme and micro-instalments for subscriptions via Foodics Pay. (Medium) — [Foodics changelog: ZATCA e-invoice export](https://changelog.foodics.com/zatca-e-invoice-export-ksa-only-K5TH2); [Foodics press: Flex program](https://foodics.com/press/foodics-launches-flex-program)

### Inferences
- "Public price, month-to-month, cancel anytime, export your data" is a credible wedge against quote-only Lebanese vendors and against contract-heavy restaurant platforms. It is only parity against Loyverse/Square.
- Regulatory attention on termination fees (FTC report, Canadian code) suggests lock-in is a recognised pain point; position data export/portability as a headline promise.

### Gaps
- Whether Square, Shopify, SumUp, Zettle, Epos Now, Foodics, Rewaa publish prices and their contract terms: covered by the sibling pricing research, not confirmed here.
- Data export/portability specifics (formats, full catalogue + sales history export) for each vendor: no sources surfaced.
- Omega and CeevTech pricing visibility: no source found.

## 11. Restaurant guest tech: QR order/pay, waiter call, tables, KDS, delivery aggregation

### Takeaway
QR order-and-pay, table management, KDS and first-party online ordering are standard on restaurant-focused platforms (Square, Toast, Lightspeed); Loyverse includes a kitchen display free. Evidence gathered here is mostly marketing-level and thin for Foodics and Lebanese vendors.

### Cited Findings
- **Square**: QR code menus let guests order and pay from their phones. (Weak/Medium, UK comparison site) — [Mobile Transaction: QR code menus comparison UK](https://www.mobiletransaction.org/qr-code-menus-comparison-uk)
- **Lightspeed Restaurant**: customers can order and pay at the table from their phones; Lightspeed Tableside can take tap/chip-and-PIN when the internet is down. (Medium, vendor pages) — [Lightspeed: one-stop restaurant platform](https://www.lightspeedhq.com/pc/restaurant/one-stop-restaurant-platform/); [Lightspeed K-Series: offline POS functionality](https://k-series-support.lightspeedhq.com/hc/en-us/articles/53028167251867-Offline-POS-functionality)
- **Toast**: Toast Online Ordering described as commission-free and kitchen-native; KDS backup printing documented for outages. (Medium) — [Guideflow: restaurant online ordering software](https://www.guideflow.com/blog/restaurant-online-ordering-software); [Toast: KDS backup printing](https://support.toasttab.com/en/article/KDS-Backup-Printing)
- **Loyverse**: Kitchen Display and Customer Display included in the free tier; a review notes users requested a restaurant floor map. (Strong for KDS; Weak for floor-map request) — [Loyverse pricing](https://loyverse.com/pricing); [Capterra: Loyverse reviews](https://www.capterra.com/p/150632/Loyverse-POS/reviews/?page=2)
- **CeevTech**: vendor-supplied listing cites tables and orders, recipe costing, stock, delivery and loyalty. (Weak) — [G2: CeevTech](https://www.g2.com/sellers/ceevtech)
- Integration principle: direct order injection into POS/KDS avoids re-entry; any middleware or manual step is where integrations fail. Aggregator integration with real-time inventory sync is cited as the most-used feature by an Indian platform (Petpooja). (Weak/Medium, vendor blogs) — [Guideflow](https://www.guideflow.com/blog/restaurant-online-ordering-software); [Petpooja blog](https://blog.petpooja.com/industry-business-guides/advanced-ways-placing-orders-restaurant/)

### Inferences
- Table management + KDS + QR menu are table stakes for restaurant POS; QR pay-at-table depends on integrated online payments, which is weak in Lebanon, so QR **order** (and "call waiter") without pay is the realistic local variant.
- Delivery-aggregator integration is market-specific (Toters etc. in Lebanon); global vendors' aggregator integrations are irrelevant locally, which neutralises one of their advantages.

### Gaps
- Foodics, BIM POS, Omega QR/aggregator features: nothing surfaced.
- Waiter-call feature support by vendor: no source.
- Clover, Shopify, SumUp, Zettle, Epos Now restaurant features: not researched.

## 12. Retail / pharmacy: scale barcodes, batch/expiry, purchase orders, supplier credit, shelf labels

### Takeaway
Evidence here is thin: Odoo covers integrated scales (via IoT Box) but not standalone scale-printed weight/price barcodes natively, and batch/expiry at POS relies on third-party modules; a Loyverse reviewer asks for batch expiry dates. Supplier credit (accounts payable) at SMB-POS level was not evidenced for any vendor.

### Cited Findings
- **Odoo**: integrated scales require the IoT Box; an Odoo forum answer says standalone scales that print barcode labels with embedded weight/price are not natively supported; a community module can generate weighted barcodes; custom modules are not allowed on Odoo Online (needs Odoo.sh or on-premise). (Strong for hardware doc; Medium for forum answer) — [Odoo docs: POS hardware](https://www.odoo.com/documentation/18.0/applications/sales/point_of_sale/pos_hardware.html); [Odoo forum: standalone scales](https://www.odoo.com/forum/help-1/can-scales-work-stand-alone-with-odoo-when-they-are-not-connected-to-a-checkout-pos-and-print-a-label-that-is-scanned-later-at-the-checkout-281702)
- **Odoo**: showing batch/expiry inside POS at product selection is offered by a third-party module. (Medium) — [Odoo Apps: pos_stocks_expiry](https://apps.odoo.com/apps/modules/17.0/pos_stocks_expiry)
- **Loyverse**: a user review asks for a field recording expiry date per batch (implies not native); purchase orders etc. sit in the paid Advanced Inventory add-on. (Weak for expiry; Medium for add-on) — [App Store listing/reviews: Loyverse](https://apple.co/2SeQlrX); [Capterra: Loyverse Advanced Inventory](https://www.capterra.com/p/176837/Loyverse-Advanced-inventory/)
- **Lightspeed Retail (R-Series)**: purchase orders in vendor currencies with manually entered exchange rate. (Strong) — [Lightspeed Retail support](https://retail-support.lightspeedhq.com/hc/articles/1260804903129)
- **Rewaa**: payment methods mapped to accounting accounts (cash to fixed cash account; card/other to custom accounts). (Strong) — [Rewaa help: payment methods and default accounts](https://intercom.help/rewaa/en/articles/9888070-payment-methods-and-default-accounts)

### Inferences
- Scale-label (price/weight-embedded EAN-13) barcode parsing is a cheap, software-only feature that matters for Lebanese minimarkets/butchers/roasteries and is not well covered natively even by Odoo.
- Batch/expiry and supplier-credit ("we owe the distributor") tracking look like under-served needs in free/low-cost POS (weak evidence) — good candidates for a pharmacy/minimarket tier.

### Gaps
- Square for Retail, Lightspeed, Shopify, Clover support for scale barcodes, batch/expiry, shelf labels: not surfaced — unclear.
- Supplier credit / accounts payable inside POS for any vendor: no source found.
- Shelf-label printing: not researched.
- Pharmacy-specific features (e.g. controlled items) in Lebanese vendors: no source.

## 13. Compliance: e-invoicing / fiscalisation and tax-rate changes by date

### Takeaway
Fiscal compliance is a country-by-country moat: Gulf vendors (Foodics, Rewaa, Zoho POS KSA, Qoyod, Odoo localisation) document ZATCA support, and European mandates are expanding in 2026. No Lebanese fiscalisation requirement or vendor handling of dated tax-rate changes was evidenced in this session.

### Cited Findings
- **Foodics**: states full compliance with ZATCA e-invoicing; changelog adds export of invoices synced to ZATCA with success/failure status and console monitoring of activation status. (Medium, vendor) — [Foodics: ZATCA e-invoicing](https://www.foodics.com/zatca-einvoicing-ksa-digital/); [Foodics changelog](https://changelog.foodics.com/zatca-e-invoice-export-ksa-only-K5TH2)
- **Rewaa**: offline selling in compliance with ZATCA, but B2B taxable invoices cannot be issued offline. (Strong) — [Rewaa help](https://intercom.help/rewaa/en/articles/11426915-how-to-sell-offline-in-compliance-with-zatca)
- **Qoyod**: says invoices issued in offline mode include ZATCA-required elements (UUID, digital signature, QR code) and are sent on sync. (Medium, vendor marketing) — [Qoyod: offline mode](https://www.qoyod.com/en/point-of-sale/offline-mode/)
- **Odoo**: Saudi localisation docs note ZATCA Phase 2 uses a clearance model for B2B transactions. (Strong) — [Odoo docs: Saudi Arabia](https://www.odoo.com/documentation/19.0/ko/applications/finance/fiscal_localizations/saudi_arabia.html)
- **2026 mandates (context)**: Belgium B2B e-invoicing from 1 Jan 2026; Croatia mandatory e-invoicing/e-reporting from 1 Jan 2026 for VAT-registered businesses; Germany separates cash-register fiscalisation (KassenSichV) from B2B e-invoicing; Luxembourg requires no POS certification or mandatory hardware. (Medium — fiscal-middleware vendor and trackers) — [fiskaly: Belgium mandate](https://www.fiskaly.com/blog/belgium-b2b-e-invoicing-mandate-2026-peppol); [fiskaly: e-invoice Germany](https://www.fiskaly.com/e-invoice-germany); [fiscal-requirements.com: Luxembourg](https://www.fiscal-requirements.com/countries/46-luxembourg); [EY e-invoicing developments tracker (08/2026)](https://www.ey.com/content/dam/ey-unified-site/ey-com/en-gl/technical/tax-guides/documents/ey-gl-e-invoicing-developments-tracker-08-2026.pdf)
- **Lebanon context**: LBC reported Lebanon moving to allow card payments for taxes and fees; a US trade guide reported the official rate at 89,500 LBP/USD as of March 2024 (dated). (Medium) — [LBCI](https://www.lbcgroup.tv/news/news-bulletin-reports/878399/say-goodbye-to-cash-lebanon-to-allow-card-payments-for-taxes-and-fees/en); [trade.gov: Lebanon trade financing](https://trade.gov/country-commercial-guides/lebanon-trade-financing)

### Inferences
- Global leaders handle fiscalisation only where they operate; none of the Western leaders evidenced Lebanese support, and the Gulf vendors' ZATCA strength does not transfer. For Lebanon the practical compliance features are VAT in LBP at an official rate on the receipt and effective-dated tax/rate tables — to be confirmed against Lebanese Ministry of Finance rules (not researched here).

### Gaps
- Lebanese e-invoicing/fiscal-device requirements and VAT-in-LBP receipt rules: not researched in this session — no source.
- How any vendor handles tax-rate changes by effective date: no source found.
- Square/Lightspeed/Shopify fiscalisation coverage by country (TSE, NF525, etc.): not surfaced.
- Egypt ETA, UAE, Jordan e-invoicing support by vendor: not surfaced.

## 14. Summary: table stakes, differentiators, white space (with evidence strength)

### Takeaway
Globally standard: offline cash selling with queued cards, roles/manager PINs, BYO tablets, KDS/QR for restaurants, and now an AI assistant at the top end. The clearest white space for lebanon-POS is the combination nobody documents together: co-equal dual-currency till (incl. change and drawer counts), customer credit tabs that work offline with WhatsApp reminders, remote owner approvals, and Arabic RTL with reliable Arabic printing — sold self-serve at a public monthly price.

### Cited Findings
**Table stakes (nearly everyone documented has it)**
- Offline selling with cash and store-and-forward cards, with caps and merchant liability — Square, Toast, Shopify, Clover, Lightspeed, Loyverse (sales), Zettle, Epos Now, Rewaa. Evidence: Strong. — [Square](https://squareup.com/help/us/en/article/8106-offline-payments-time-limits); [Toast](https://support.toasttab.com/en/article/Using-Toast-in-Offline-Mode?lang=en_US); [Shopify](https://help.shopify.com/en/manual/sell-in-person/shopify-pos/selling-offline/offline-payments?r_done=1); [Clover](https://docs.clover.com/docs/handling-offline-payments); [Loyverse](https://help.loyverse.com/help/offline-work-of-pos)
- Third-party / BYO hardware with supported-printer lists — Loyverse, Square, Shopify, Lightspeed. Evidence: Strong. — [Loyverse](https://help.loyverse.com/help/supported-printers); [Square](https://square.com/help/us/en/article/6334); [Shopify](https://help.shopify.com/en/manual/sell-in-person/hardware/supported-hardware)
- Per-user payment/approval permissions — Toast, Rewaa, Vori. Evidence: Strong but narrow sample. — [Toast](https://support.toasttab.com/en/article/Identify-Offline-Payments-Canada-Ireland-the-U-K); [Rewaa](https://intercom.help/rewaa/en/articles/8717231-postpaid-payment-permission-for-users); [Vori](https://help.vori.com/streamline-pos-operations-with-new-till-and-manager-approval-settings)
- Kitchen display / QR ordering on restaurant platforms — Loyverse (KDS free), Lightspeed, Square, Toast. Evidence: Medium. — [Loyverse pricing](https://loyverse.com/pricing); [Lightspeed](https://www.lightspeedhq.com/pc/restaurant/one-stop-restaurant-platform/)

**Differentiators (some have it)**
- House accounts / customer credit with limits and statements — Toast, Square, Lightspeed Retail, Foodics, Rewaa, Odoo (core, limits via modules); not evidenced natively in Shopify POS (store credit only) or Loyverse (weak). Evidence: Strong. — [Toast](https://doc.toasttab.com/doc/platformguide/platformHouseAccountsOverview.html); [Square](https://squareup.com/help/us/en/article/8034); [Lightspeed](https://retail-support.lightspeedhq.com/hc/articles/20656766930459-Managing-customer-credit-accounts); [Foodics](https://help.foodics.com/hc/en-us/articles/4408281561490-Enabling-House-Accounts-for-Customers); [Rewaa](https://intercom.help/rewaa/en/articles/8717231-postpaid-payment-permission-for-users); [Odoo](https://www.odoo.com/documentation/master/applications/sales/point_of_sale/payment_methods/customer_credit.html)
- Foreign-currency tender with dual-currency receipt — Lightspeed K-Series, KORONA, enterprise (LS Central, Oracle Xstore, NCR Aloha), Elementary POS, Lebanese vendors (BIM, CeevTech — vendor claims); explicitly absent in Square and Shopify POS. Evidence: Strong for global vendors, Weak for Lebanese. — [Lightspeed K-Series](https://k-series-support.lightspeedhq.com/hc/articles/1260804656969); [Square](https://square.com/help/us/en/article/5415); [KORONA](https://manual.koronapos.com/currencies/)
- AI menu import from photo/PDF — Square (with up-to-24h turnaround). Evidence: Strong, single vendor. — [Square](https://squareup.com/help/us/en/article/6424-create-and-update-menus)
- AI assistants — Square, Toast, Shopify, Lightspeed, Clover; BIM POS promoting one. Evidence: Medium. — [Tech.co](https://tech.co/pos-system/integrate-ai-pos-system); [eMarketer](https://www.emarketer.com/content/fiserv-s-clover-joins-toast-square-selling-ai-time-saver-small-businesses)
- No-contract public pricing — Loyverse explicit; contrast Toast/Clover/Lightspeed fees and quote-only BIM POS. Evidence: Strong (Loyverse), Weak (others). — [Loyverse](https://loyverse.com/en-us/pricing); [NerdWallet](https://www.nerdwallet.com/business/software/reviews/toast-pos)
- Arabic RTL UI and Arabic receipts — Zoho POS KSA, LS Central, Oracle Simphony, Qoyod; not in Shopify POS. Evidence: Medium–Strong. — [Zoho](https://blog.zoho.com/pos/zoho-pos-for-saudi.html); [Shopify App Store (ar)](https://apps.shopify.com/shopify-pos?locale=ar)

**White space (clear demand, poor or no documented support)**
- Customer credit / house accounts usable **offline** — Toast and Rewaa explicitly disable it offline; Odoo needs a third-party module. Evidence: Strong. — [Toast](https://support.toasttab.com/en/article/Using-Toast-in-Offline-Mode?lang=en_US); [Rewaa](https://intercom.help/rewaa/en/articles/11426915-how-to-sell-offline-in-compliance-with-zatca); [Odoo Apps](https://apps.odoo.com/apps/modules/18.0/bi_pos_credit_payment_offline/)
- Co-equal dual-currency till in SMB cloud POS (mixed tender, change in either currency, dual-currency drawer count) — years-long Square feature-request thread; Shopify community requests; Odoo only via many paid modules. Evidence: Strong for demand, Medium for absence. — [Square community](https://community.squareup.com/t5/Payments-Troubleshooting/Feature-Request-Charge-customers-in-different-currencies-using/m-p/161970/highlight/true); [Shopify community](https://community.shopify.com/t/multi-currency-support-for-pos/576562); [Odoo Apps](https://apps.odoo.com/apps/modules/19.0/dps_aio_pos_dual_currency)
- Remote owner approve/deny from phone — only niche vendors (EmaginePOS, NRS, Paladin, STORIS, Vista, KwickPOS). Evidence: Strong that niche vendors have it; absence at leaders is unverified. — [NRS](https://nrsplus.com/rmo/); [EmaginePOS](https://apps.apple.com/us/app/id968079921)
- Native WhatsApp receipts / reminders — only Odoo third-party modules surfaced. Evidence: Medium (absence at leaders unverified). — [Odoo Apps](https://apps.odoo.com/apps/modules/19.0/pos_whatsapp_receipt)
- Correct Arabic thermal printing out of the box — recurring developer-forum problem. Evidence: Medium. — [B4X forum](https://www.b4x.com/android/forum/posts/914687)
- Scale-label barcodes and batch/expiry in low-cost POS — Odoo forum says standalone scale labels not native; Loyverse reviewer requests batch expiry. Evidence: Weak–Medium. — [Odoo forum](https://www.odoo.com/forum/help-1/can-scales-work-stand-alone-with-odoo-when-they-are-not-connected-to-a-checkout-pos-and-print-a-label-that-is-scanned-later-at-the-checkout-281702)

### Inferences
- **Have / don't-have positioning for lebanon-POS (inferred from the above; cells marked "unclear" must stay unclear in the matrix):**

| Feature | Square | Toast | Shopify POS | Lightspeed | Loyverse | Odoo POS | Foodics | Rewaa | Lebanese (BIM/CeevTech) | lebanon-POS target |
|---|---|---|---|---|---|---|---|---|---|---|
| Sell offline (cash) | Yes | Yes | Yes | Yes | Yes | unclear here | unclear | Yes | CeevTech claims yes | Yes |
| Offline window/cap | 24h/72h | per-txn limit | merchant-set total | not found | not found | – | unclear | – | unclear | no cap (cash) |
| Customer credit tab | Yes (house accounts; no instalments) | Yes | Store credit only | Yes (Retail) | unclear (requested) | Yes (limits via modules) | Yes | Yes (instalments) | unclear | Yes |
| Credit works offline | unclear (Invoices no) | **No** | n/a | unclear | n/a | via module | unclear | **No** | unclear | Yes |
| Second-currency tender | **No** | unclear | **No** | K-Series yes / Retail unclear | unclear (requested) | via modules | unclear | unclear | Claimed yes | Yes, co-equal |
| Arabic RTL UI | unclear (weak "no") | unclear | **No** (not translated) | unclear | unclear (weak "yes") | modules | expected, unverified | expected, unverified | CeevTech claims yes | Yes |
| WhatsApp receipts/reminders | unclear | unclear | unclear | unclear | unclear | via modules | unclear | unclear | unclear | Yes |
| Remote owner approval | unclear | unclear | unclear | unclear | unclear | unclear | unclear | unclear | unclear | Yes |
| Public price, no contract | (see pricing notes) | reports of multi-year + ETF | (see pricing notes) | ETF reported | Yes | (see pricing notes) | unclear | unclear | BIM quote-only | Yes |

- The strongest evidence-backed claims a new entrant can make: (1) "your customer tabs keep working when the internet is down" (Toast/Rewaa documented as not), (2) "USD and LBP in one sale, change in either" (Square/Shopify documented as not; Lightspeed only as occasional foreign tender), (3) "no contract, public price" (vs Toast/Clover fee reports and quote-only BIM).
- Claims that need more verification before being used in marketing: "no one offers WhatsApp reminders" and "no one offers remote approvals" — absence at the leaders was not proven, only not found.
- Risks for a web/PWA approach to disclose: iOS Safari hardware-API gaps and storage-eviction uncertainty; recommend Android/Windows Chrome as the supported baseline.

### Gaps
- All findings are from search-result summaries; none were verified by reading the full page. Highest-value pages to verify by direct read if access allows: Square 5415 (multi-currency), Toast offline article, Rewaa offline article, Lightspeed K-Series foreign-currency article, Loyverse feature list (customer credit / languages), Shopify POS language list.
- Vendors with little or no evidence gathered: SumUp, Zettle, Epos Now (beyond offline), Clover (beyond offline/contracts), Omega (Lebanon — nothing found at all), BIM POS (marketing only), Hike, Erply, Oracle Simphony multi-currency.
- G2/Capterra feature grids were not accessible as structured data; no quantitative "% of vendors with feature X" figure can be given.
- No Reddit threads were retrieved directly (one mirrored r/restaurant post only).
