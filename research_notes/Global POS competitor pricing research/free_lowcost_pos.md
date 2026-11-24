# Free and low-cost self-serve POS / shop-management apps (worldwide, 2025–2026) as competitors to lebanon-POS

> **Method and reliability note (read first).** This session's network blocked every direct page fetch attempted (loyverse.com, help.loyverse.com, play.google.com, elementarypos.com, daftra.com, voxire.pages.dev all failed DNS resolution). **Every fact below therefore comes from web-search result summaries, not from pages I read in full.** The linked URL is the page the search engine attributed the fact to. The shared web-search budget for the session was also exhausted before the last batch of queries ran, so several vendors in the brief have **no data** (listed under Gaps, never guessed). Where sources conflict, both figures are shown side by side. Research date: 24 Nov 2026.

## 1. Loyverse (the likely default free choice): price, limits, add-on cost, what Arab/Lebanese users say

### Takeaway
Loyverse's core (POS, Back Office, Dashboard, KDS, Customer Display) is permanently free, but the official price of its add-ons is published in two conflicting models (per store vs per employee), so a 1-store/3-employee shop pays roughly $40–$55+/month once Employee Management and Advanced Inventory are on. It has no documented dual-currency tender, offline mode excludes refunds/new customers/new items, and I found no Lebanon- or Arabic-specific user commentary beyond one Lebanese vendor blog.

### Cited Findings
- **Free core:** "Core products (POS, Back Office, Dashboard, KDS, CDS) are permanently free with no subscription required" (search summary of official/aggregator pages) — [Loyverse pricing](https://loyverse.com/pricing); [apis.io plan listing](https://apis.io/plans/loyverse/loyverse-plans-pricing/)
- **Add-on prices, official US page:** Employee management $25/mo or $250/yr **per store**; Advanced inventory $25/mo or $250/yr per store; Unlimited sales history $5/mo or $50/yr per store; "no per-employee or per-device charges" — [Loyverse US pricing](https://loyverse.com/en-us/pricing)
- **Add-on prices, conflicting official source:** Employee Management €5/month or €50/year **per employee**; Advanced Inventory €25/month per store — [Loyverse llms.txt](https://loyverse.com/llms.txt). TechnologyAdvice also lists Employee management at $5/month/employee — [TechnologyAdvice](https://technologyadvice.com/products/loyverse-pos-reviews/)
- **Integrations add-on:** Merchant Maverick lists Integrations at $9/month alongside $25/store for the other two add-ons; this $9 figure did not appear on the official pages returned, so it is unverified. Another third-party review instead gives "Unlimited sales history: $9/mo per store" — [Merchant Maverick](https://www.merchantmaverick.com/reviews/loyverse-review/)
- **Trial:** every add-on has a 14-day free trial started from the Back Office, no credit card — [Loyverse pricing](https://loyverse.com/pricing)
- **KDS:** Loyverse KDS (kitchen display app) is free — [Merchant Maverick](https://www.merchantmaverick.com/reviews/loyverse-review/)
- **Offline limits (official help page):** the app works offline but "not all functions are supported offline; such as refunds, new customer registration, adding items, and a few other restrictions"; offline sales are held on the device marked unsynced and are not visible in Back Office until sync; open tickets work offline "but without synchronization with other devices" — [Loyverse help: Offline use](https://help.loyverse.com/help/offline-work-of-pos)
- **Sync complaints:** "offline mode syncs back inconsistently after spotty connection drops" — [SoftwareWorld](https://www.softwareworld.co/software/loyverse-pos-reviews/); a Capterra reviewer said it "may take a few hours after the close of the day before all the sales are synced and shown in the back office" — [Capterra reviews](https://www.capterra.com/p/150632/Loyverse-POS/reviews/?page=7)
- **Accounting/report complaints:** "accounting integration was not ideal"; "when using discounts and promotions the totals don't necessarily add up correctly" — [Capterra reviews](https://www.capterra.com/p/150632/Loyverse-POS/reviews); "some reports don't sync properly with other 3rd party software requiring manual intervention" — [G2](https://www.g2.com/products/loyverse-free-pos/reviews)
- **Other listed weaknesses:** basic reporting, no built-in payment processor, no table management (worked around with predefined tickets), printer setup described as the hardest part — [Merchant Maverick](https://www.merchantmaverick.com/reviews/loyverse-review/); [ConnectPOS review, 14 Jan 2026](https://www.connectpos.com/?p=105240)
- **Currency handling:** account currency is set by country of registration; the owner can change it, and must sign out/in on each device afterwards. No help page returned describes accepting a second currency at checkout — [Loyverse help: How to set the currency](https://help.loyverse.com/help/how-set-currency)
- **Currency display:** a reviewer notes "no currency is shown in the app or reports, because the software is country-agnostic" — [MobileTransaction (AU)](https://www.mobiletransaction.org/au/loyverse-pos-review/)
- **Lebanon-specific (single vendor blog, not independent):** Loyverse has "no native dual-currency LBP handling (workaround exists but adds complexity)"; the blog still recommends Loyverse's free tier for a single Lebanese cafe under $20K/month revenue, and says Lebanese power/internet means at least 2–5 hours downtime per month so offline matters — [Voxire blog, "Best POS systems for Lebanese restaurants 2026"](https://voxire.pages.dev/blog/best-pos-systems-lebanese-restaurants-2026/)
- **Arabic:** GetApp lists Arabic among Loyverse POS supported languages; the Loyverse Dashboard App Store listing includes Arabic, Hebrew and Urdu; one aggregator's visible language list omits Arabic (conflict) — [GetApp UK](https://www.getapp.co.uk/software/106663/loyverse-pos); [App Store: Loyverse Dashboard](https://apps.apple.com/us/app/loyverse-dashboard-for-pos/id1046519533?uo=4); [zoftwarehub](https://zoftwarehub.com/products/loyverse/plans)
- **Ratings:** G2 4.7/5, Capterra 4.8/5 (as summarised) — [G2](https://www.g2.com/products/loyverse-free-pos/reviews); [Capterra](https://www.capterra.com/p/150632/Loyverse-POS/)
- **Install counts:** only the companion *Dashboard* app was found: ~604K–619K installs, 4.34 stars, ~1.5K ratings (tracker data) — [AppGoblin](https://appgoblin.info/apps/com.loyverse.dashboard)

### Inferences
- **Monthly cost, 1 store / 3 employees (my arithmetic on the cited prices, not a vendor quote):**
  - Per-store model (US page): $25 (employees) + $25 (inventory) = **$50/mo**; + $5 history = **$55/mo**; + $9 integrations if that price is real = **$64/mo**. Annual: $250 + $250 (+$50) = $500–$550/yr ≈ $42–$46/mo.
  - Per-employee model (llms.txt, euro): 3 × €5 + €25 = **€40/mo** (+ history, price in € not found).
  - Either way, a "free" Loyverse shop that wants staff permissions/timecards and purchase orders pays more than lebanon-POS's planned $15–35 per till. The free tier is the real competitor; the paid Loyverse is not cheap.
- Loyverse's offline gaps (no refunds, no new customers, no new items offline; no cross-device ticket sync) are a concrete wedge for an offline-first product in a country with daily outages.
- No evidence was found that Loyverse supports customer debt/credit tabs; the one search on this returned only other vendors (Square, Shopify, Lightspeed, Odoo). Treat "Loyverse lacks credit tabs" as *unconfirmed*, not as established.

### Gaps
- Google Play install count/rating for the Loyverse POS app itself, and Arabic-language Play reviews: play.google.com unreachable; not found in summaries.
- Arabic YouTube tutorials, Facebook groups, r/lebanon discussion of Loyverse: the Arabic query returned only English review sites; no Arabic community sources found.
- RTL receipt printing quality in Arabic: no source found.
- Whether Loyverse has any credit-sale/debt feature, audit trail, or supported dual-tender workaround: no source found (search budget ran out before the follow-up query).
- Which add-on pricing model applies to an account registered in Lebanon (per store vs per employee): unresolved conflict between two official Loyverse sources.

## 2. Other free/cheap self-serve POS apps: price, limits, platforms, multi-currency, credit

### Takeaway
Most "free" POS tiers are capped hard (one register/user, 30–1,000 products, 100–300 transactions/month) and paid tiers cluster at $10–$30 per store per month; only Elementary POS was found to have a native "price in base currency, take cash in other currencies at a rate you set" feature. Published prices for nearly every vendor conflict between sources.

### Cited Findings

**Square (free plan)**
- The Square POS app is free to download "in most countries", but card acceptance works only in the US, Canada, Australia, Japan, UK, Ireland, France and Spain; card transactions only work in the country where the account was activated — [Square help: International availability](https://square.com/help/us/en/article/4956); [Square developer docs](https://developer.squareup.com/docs/international-development)
- Square sellers have asked for customer store credit for years ("three years later we are still waiting") — [Square community](https://community.squareup.com/t5/Payments-Troubleshooting/FEATURE-REQUEST-adding-STORE-CREDIT-to-a-customers-account/m-p/851555)

**Elementary POS (Android)**
- Free plan: simple register on any Android phone/tablet, unlimited receipts, unlimited items, sales history in Back Office, card payments via SumUp/Sunmi/myPOS terminals — [Elementary POS plans](https://elementarypos.com/?p=72)
- Prices conflict: Basic $0 / Premium $25/mo / Business $58/mo — [Capterra](https://www.capterra.com/p/10006451/Elementary-POS/); vs Premium $5.99 / Business $12.99 (data last updated Jan 2024) — [SaaSworthy](https://www.saasworthy.com/product/elementary-pos/pricing); vs paid tiers shown as "Contact sales" in a May 2026 snapshot — [xpay](https://www.xpay.sh/saas-pricing/elementary-pos/)
- **Multi-currency cash:** accepted currencies and exchange rates are set in Company Settings → Cash Currencies; account and product prices stay in the base currency; cash only, not cards; which plan it requires is not stated — [Elementary POS blog](https://elementarypos.com/en/new-feature-payments-in-multiple-currencies/)

**Aronium (Windows desktop)**
- Aronium Lite is free with no time limit ("You can use free Aronium version as long as you like") — [Aronium FAQ](https://www.aronium.com/en/faq)
- Pro: $10 USD/month per store, 30-day trial; $100 USD if paid annually; no lifetime licences ("All licenses are subscription based", support reply 2022) — [Aronium download page](https://www.aronium.com/en/download); [Aronium community](https://help.aronium.com/hc/en-us/community/posts/4414568507538-Is-it-possible-to-buy-NETWORKING-VERSION-Forever)
- Price-lists plugin is a separate $5/month or $50/year — [Aronium price lists plugin](https://www.aronium.com/en/plugins/price-lists)
- Free edition limited to one register; Windows only — [TrustRadius](https://www.trustradius.com/buyer-blog/top-free-point-of-sale-software)
- Conflict: SaaSWorthy says Aronium has no free plan — [SaaSWorthy](https://www.saasworthy.com/product/aronium/pricing)

**Zobaze POS (Android)**
- Free plan with a 100-item inventory limit, premium custom-priced, 15-day trial — [Software Finder](https://softwarefinder.com/retail/zobaze-pos); conflict: ITQlick says no free version and no public pricing — [ITQlick](https://www.itqlick.com/zobaze-pos/pricing); Capterra lists a free version — [Capterra](https://www.capterra.com/p/183696/Zobaze-POS/)
- India starting price ₹239 excl. GST (plan unspecified) — [Techjockey](https://www.techjockey.com/detail/zobaze-pos)

**Kyte (Android/iOS/web)**
- Free plan after a 7-day GROW trial; free tier limited to 1 user, 1 photo per product, short cash-flow view — [Kyte pricing](https://kyteapp.com/pricing)
- USD: PRO $19.99/mo ($199.99/yr), GROW $29.99/mo ($299.99/yr), PRIME $39.99/mo ($399.99/yr) — [TrustRadius](https://www.trustradius.com/products/kyte-pos/pricing); [App Store](https://apps.apple.com/app/id1345983058)
- Conflict: Kyte's regional pricing page shows PRO $5.99/mo, GROW $8.99/mo — [Kyte pricing](https://kyteapp.com/pricing); euro listing PRO €9.99, GROW €13.99, PRIME €20.99 — [Gappsy](https://www.gappsy.com/tools/kyte/). Prices vary by country.
- GROW adds Kyte Web (computer version) and up to 10 users — [Kyte global subscription](https://www.kyteapp.com/subscription/global)

**Imonggo (web)**
- Free $0; Premium $30/month per branch — [Imonggo pricing](https://imonggo.com/pricing/)
- Free limits conflict between two Imonggo help pages: single user, 1,000 products and 1,000 transaction lines/month — [Imonggo help (GitBook)](https://imonggo.gitbook.io/imonggo-help-center/frequently-asked-questions/does-imonggo-support-multiple-users); vs 30 products and 300 invoices/month — [Imonggo help](https://help.imonggo.com/en/articles/5376353-does-imonggo-support-multiple-users)

**eHopper**
- Free "Essential" plan: one POS, 50 products, 300 transactions/month — [The Retail Exec](https://theretailexec.com/pt/tools/analise-do-pos-ehopper-vantagens-desvantagens-funcionalidades-e-guia-de-precos/); eHopper's own knowledge base says Essential is changing to 50 products and **100** transactions/month (undated) — [eHopper KB](https://portal.ehopper.com/portal/en/kb/articles/essential-plan-changes)
- Paid from $14.99/mo ($10/mo annual) for Essential Plus, up to $39.99/mo (May 2026 snapshot) — [xpay](https://www.xpay.sh/saas-pricing/ehopper-pos/); a "Freedom" plan at $24.99/mo appears in one source only — [TrustRadius](https://www.trustradius.com/products/ehopper-pos/pricing)

**Nextar / Nex (Windows only)**
- Free plan with no time limit: POS, product and customer registration, supplier management, sales app, online catalog; Premium USD 19/month or USD 190/year, 14-day trial — [Nextar pricing](https://www.nextar.com/pricing)
- "No usage time limit, product registration limit, or customer registration limit" on free — [HashMicro review](https://www.hashmicro.com/ph/blog/nextar-pos-reviews/)

**Vyapar (India; Android/iOS/Windows)**
- Mobile app "free for lifetime use of core features"; desktop has a 7-day free period — [Vyapar llms.txt](https://vyaparapp.in/llms.txt); [Vyapar desktop](https://vyaparapp.in/desktop)
- Desktop Gold ₹3,399/year, ₹8,848 for 3 years (third-party citation) — [Petpooja blog](https://blog.petpooja.com/industry-business-guides/retail-billing-software-price-india/); third-party USD conversion Gold $7.5/mo, Platinum $10.83/mo; official page described as sales-led as of 6 May 2026 — [PricingSaaS](https://pricingsaas.com/companies/vyapar)

**Khatabook / OkCredit (credit ledgers, India)**
- OkCredit: free Basic plan with unlimited customers, entries, reminders and online backup; paid Premium adds ad-free, multi-device, GST billing, unlimited SMS; 11 Indian-market languages, **no Arabic** — [OkCredit llms.txt](https://okcredit.in/llms.txt)
- Khatabook: downloads reported from Pakistan, Nepal and Bangladesh but company focused solely on India (article c. 2019) — [Entrepreneur India](https://www.entrepreneur.com/en-in/finance/these-fintech-apps-are-digitizing-the-book-keeping-for/342364)

**Odoo**
- One App Free: $0, one app, unlimited users, Odoo Online; adding Studio or companies moves the account to Custom — [Odoo pricing](https://www.odoo.com/pricing)
- Standard US$31.10 (annual) / US$38.90 (monthly) per user/month; Custom US$46.70 / US$58.40 in one snapshot and US$61.00 / US$76.20 in another (a LinkedIn post reports a 20% Custom increase) — [Odoo pricing](https://www.odoo.com/pricing); [Capterra](https://capterra.com/p/135618/Odoo/pricing/). Older third-party figures: Standard $24.90, Custom $37.40 — [G2](https://www.g2.com/products/odoo-odoo-erp/pricing)
- Odoo POS has a "customer account" payment method that records the purchase as debt until paid — [Odoo docs](https://www.odoo.com/documentation/master/applications/sales/point_of_sale/payment_methods/customer_credit.html)
- Multi-currency POS payment exists as third-party app-store modules (assign a different currency per payment line), for Odoo 17–19 — [Odoo Apps: pos_multiple_currency](https://apps.odoo.com/apps/modules/17.0/pos_multiple_currency); [eg_pos_multi_currency_payment_line](https://apps.odoo.com/apps/modules/19.0/eg_pos_multi_currency_payment_line)

**Zoho POS (formerly Zakya)**
- Free plan "indefinitely free" with feature limits; Standard about $15/location/month billed annually, $20 monthly (US page; layout ambiguous); India ₹649 annual / ₹799 monthly per location — [Zoho POS US pricing](https://www.zoho.com/en-us/pos/pricing.html); [Zoho POS India features](https://www.zoho.com/en-in/pos/features-list.html)
- Users have requested collecting payments/partial payments for outstanding credit invoices from the POS billing app (implying it is missing) — [Zoho community](https://help.zoho.com/portal/en/community/topic/enhancement-request-%e2%80%93-allow-cashiers-to-collect-payments-and-partial-payments-for-outstanding-credit-invoices-directly-from-zoho-pos-billing-app)

**Shopify POS**
- POS Lite included with every Shopify plan; POS Pro $89/location/month ($79 annual), billed per location not per register — [Style Factory](https://www.stylefactoryproductions.com/blog/shopify-pos-pricing); [Qualimero](https://qualimero.com/en/blog/shopify-pos-pricing)
- Store credit is tracked per customer account; charge-account ("net 30") needs a third-party app — [Shopify community](https://community.shopify.com/t/does-shopify-pos-allow-purchases-made-on-account-or-with-store-credit/16015)

**StoreHub (SE Asia)**
- Starter from PHP 2,249 (period not stated) — [StoreHub PH pricing](https://www.storehub.com/ph/pricing); RM 99/month per a competitor's comparison — [Klikit](https://klikit.io/en/learn/qashier-vs-storehub-malaysia); $39/user/month per Capterra (market unspecified) — [Capterra](https://www.capterra.com/p/146620/StoreHub)

**Open-source / one-time-licence desktop**
- uniCenta oPOS: free under GPL3 with paid support tiers; latest release cited as 5.4.0 with WooCommerce integration; 5.0 dated December 2023 — [SourceForge news](https://sourceforge.net/p/unicentaopos/news); [LinuxLinks](https://www.linuxlinks.com/unicenta-open-source-point-sale/)
- Chromis POS: fork of Openbravo POS, completely free, Windows and Linux — [LinuxLinks](https://www.linuxlinks.com/chromis-pos-commercial-grade-free-open-source-point-sale-software/)
- Floreant POS: base version free; Floreant Plus / ORO POS is the paid per-terminal version — [Fit Small Business](https://fitsmallbusiness.com/best-open-source-pos-software/); [AlternativeTo](https://alternativeto.net/software/floreant-pos)
- SambaPOS 5: paid one-time licence; prices conflict: $339 one-time (lifetime V5) — [FitGap](https://us.fitgap.com/products/sambapos); ~$99 at V5 launch (old forum posts) — [SambaPOS forum](https://forum.sambapos.com/t/sambapos-v5-license-costing-99-245/6857); "$500 one-time" starting price — [Capterra](https://www.capterra.com/p/161780/SambaPOS/); Mobile Client add-on $67/year per device — [FitGap](https://us.fitgap.com/products/sambapos). SambaPOS users discuss settling in base currency and giving change in another currency — [SambaPOS forum](https://forum.sambapos.com/t/rounding-and-issuing-change-in-multiple-currencies/13051)

### Inferences
- Free-tier caps that competitors use as the upgrade trigger: number of products (30/50/100/1,000), transactions per month (100/300/1,000 lines), single user/register, and sales-history length (Loyverse sells unlimited history for $5). A lebanon-POS free plan with no product or transaction cap on one till would be more generous than Imonggo, eHopper and Zobaze, and equal to Loyverse, Elementary, Nextar and Aronium Lite.
- The $10–$30 per store/month band (Aronium $10, Zoho $15–20, Nextar $19, Kyte $20–30, Loyverse $25 per add-on, Imonggo $30) brackets lebanon-POS's planned $15–35 per till; note most of these charge per store/location, not per till.
- Dual-currency tender at a user-set rate is rare: found natively only in Elementary POS (cash only), via paid third-party modules in Odoo, and via configuration in SambaPOS. This supports dual currency as a differentiator, but Elementary POS is a free Android app that already does the cash case and should be tested hands-on.
- Square is not a practical competitor in Lebanon: the app may install, but Lebanon is not among the eight card-processing countries.

### Gaps
- **No data gathered (search budget exhausted before these queries ran):** Hike POS, ERPLY, iReap POS, Qasir, Moka, Pawoon, W&O POS, Oscar POS, Wave, WhatsApp Business catalog limits, Excel/Google Sheets templates, "Smart POS", iCashier, Ezdan, and Arabic-named Google Play cashier apps ("كاشير", "نقطة بيع"). None of these should be assumed free or paid from these notes.
- Google Play install counts and ratings for every app: not found (Play Store unreachable).
- Arabic UI / RTL receipt support per app: found only for Loyverse (partially). Not found for Zobaze, Kyte, Elementary, Aronium, Imonggo, eHopper, Nextar.
- Offline behaviour, customer-credit tracking, printer/scanner support, data export and support channels per app: not found except where cited above.
- Odoo POS native (non-module) multi-currency support in current versions, and practical cost of self-hosting Odoo Community: not found.
- Aronium multi-currency and customer-credit capability: not found.

## 3. Arabic cloud accounting/POS (Daftra, Qoyod, Wafeq, SMACC) and legacy Arabic desktop packages; piracy

### Takeaway
Arabic cloud suites are priced for Gulf SMEs ($20–$100/month, or SAR 99–199/month) and mostly lack a permanent free POS tier, so they are not the price floor in Lebanon. I found no reliable prices for Al-Ameen, Al-Mohaseb, Yemen Soft or Al-Motammem, and no source documenting cracked-POS usage; the only hard piracy figure is Lebanon's 69% unlicensed-software rate from 2017.

### Cited Findings
- **Daftra:** prices conflict. Starting at $9.99/month flat — [GetApp](https://www.getapp.com/operations-management-software/a/daftra); [Capterra](https://www.capterra.com/p/244865/Daftra/). Basic $30/mo ($20 annual), Advanced $55 ($41.25 annual), Premium $70 ($50 annual), plus add-ons for extra users/branches — [FitGap](https://us.fitgap.com/products/011484/daftra). A Daftra-hosted comparison lists Basic $20.25/mo and Advanced $32.13/mo, both including POS (undated) — [Daftra hub](https://www.daftra.com/en/hub/best-pos-software?change_lang=en). 14-day free trial, no card — [Daftra plans](https://www.daftra.com/en/plans)
- **Qoyod:** no permanent free plan; Basic SAR 1,200/year — [MakerStack review 2026](https://makerstack.co/reviews/qoyod-review/); conflicting: single plan at SAR 199/month (per competitor Wafeq) — [Wafeq guide](https://www.wafeq.com/en-sa/business-hub/for-business/the-ultimate-guide-to-accounting-software-pricing-in-saudi-arabia). Qoyod says detailed pricing is shown only after signup; POS and payroll are extra-cost add-ons; 14-day trial — [Qoyod knowledge base](https://www.qoyod.com/en/knowledge-base/qoyod-plans-and-pricing-subscription-tiers-features-add-ons/); [Qoyod POS](https://www.qoyod.com/en/pos)
- **Wafeq:** plans from SAR 99/month, with a "free start" / Basic Free package for small businesses (vendor marketing); no POS-specific pricing found — [Wafeq vs Qoyod](https://www.wafeq.com/en/wafeq-vs-qoyod); [Wafeq guide](https://www.wafeq.com/en-sa/business-hub/for-business/the-ultimate-guide-to-accounting-software-pricing-in-saudi-arabia)
- **SMACC:** $99/month for 2 users (third-party listings), free trial; G2 says pricing unpublished; vendor bills in SAR, AED, EGP, USD with a 14-day trial; first released 1988 by Arabian Sea Company — [Capterra](https://www.capterra.com/p/169873/SMACC/); [SoftwareSuggest](https://www.softwaresuggest.com/smacc); [SMACC llms.txt](https://smacc.com/llms.txt)
- **Al-Ameen (الأمين):** a Daftra price-comparison page lists Al-Ameen among Arabic accounting programs and says it offers only two plans; amounts were not visible in the summary. The vendor's site targets Saudi Arabia and promotes ZATCA compliance — [Daftra hub (Arabic)](https://www.daftra.com/hub/أسعار-برامج-المحاسبة); [Al-Ameen Soft](https://alameensoft.com/sa/en/?p=2788)
- **Piracy rate:** Lebanon's unlicensed-software rate was 69% in 2017 (BSA data), versus 37% globally and 56% for Middle East & Africa; 37th highest globally and sixth among Arab countries — [Byblos Bank, Lebanon This Week](https://byblosbank.com/common/economic-research-new/lebanon-this-week/lebanon-this-week-540/lebanons-piracy-rate-at-69-in-2017-37th-highest-globally-and-sixth-highest-among-arab-countries). Earlier: 93% in 1994, 73% in 2006 — [Asharq Al-Awsat, 2006](https://en-archive.aawsat.com/2006/05/29/software-piracy-down-in-lebanon/); about 70% in 2015 — [Al Bawaba](https://www.albawaba.net/business/lebanons-software-piracy-rate-high-chinas-us-report-846208)
- A free open-source Arabic accounting program ("المحاسب السريع", GPLv3: journal, ledger, trial balance, income statement, balance sheet) exists on SourceForge — [SourceForge: fastaccountant](https://sourceforge.net/projects/fastaccountant/)

### Inferences
- With roughly two-thirds of software in Lebanon unlicensed (2017, dated), the effective price of legacy desktop POS/accounting for many small shops is likely zero or a one-off installer fee to a local technician. This is inference from the general piracy rate; no source found documents cracked Al-Ameen/SMACC/Easy Soft specifically.
- Against pirated desktop software, a subscription cannot win on price; the plausible advantages are things a crack cannot provide (cloud backup, phone access for the owner, updates, support, multi-device sync).
- Gulf cloud suites (Daftra, Qoyod, Wafeq, SMACC) are built around ZATCA e-invoicing and SAR pricing, which is irrelevant in Lebanon; they compete on Arabic UI but not on price or dual currency.

### Gaps
- Prices (one-time licence or otherwise) for Al-Ameen in Syria/Lebanon, Al-Mohaseb, Yemen Soft, Al-Motammem, Al-Mizan, Easy Soft, Bi-Lateral: **not found**. The Daftra comparison page that reportedly lists some could not be opened.
- Evidence of cracked desktop POS/accounting distribution in the Arab world (forums, download sites, Facebook groups): not found; the one search returned only legitimate vendor pages.
- Piracy rates for Syria, Iraq, Egypt and any Lebanon figure newer than 2017: not found.
- Whether Daftra/Qoyod/Wafeq support multi-currency at the POS or customer credit tabs: not found.

## 4. What a free plan must include to beat these, and what users demonstrably pay for

### Takeaway
The free benchmark is Loyverse: unlimited items and sales on the core POS with free KDS and customer display; the features vendors successfully charge for are staff management, advanced inventory, extra users/registers/locations, long sales history, web/desktop access and integrations. These conclusions are largely inference from competitor price lists, not from user surveys.

### Cited Findings
- Loyverse monetises exactly four things on top of a free core: employee management, advanced inventory, unlimited sales history ($5/store) and integrations — [Loyverse US pricing](https://loyverse.com/en-us/pricing); [Merchant Maverick](https://www.merchantmaverick.com/reviews/loyverse-review/)
- Kyte's paid tiers sell additional users (up to 10) and the web/computer version; its free tier is capped at 1 user — [Kyte global subscription](https://www.kyteapp.com/subscription/global); [Kyte pricing](https://kyteapp.com/pricing)
- Imonggo and eHopper gate on products and monthly transactions and on single user — [Imonggo help](https://imonggo.gitbook.io/imonggo-help-center/frequently-asked-questions/does-imonggo-support-multiple-users); [eHopper KB](https://portal.ehopper.com/portal/en/kb/articles/essential-plan-changes)
- Aronium charges $10/store/month for Pro and sells price lists as a separate $5/month plugin; users repeatedly ask how to run multiple registers/computers on one store profile — [Aronium download](https://www.aronium.com/en/download); [Aronium community](https://help.aronium.com/hc/en-us/community/posts/17635397622546-Multiple-Cash-registers-Configuration)
- OkCredit keeps the ledger itself free (unlimited customers and entries) and charges for ad-free use, multi-device access, tax billing and unlimited SMS reminders — [OkCredit llms.txt](https://okcredit.in/llms.txt)
- Customer credit/charge accounts are a long-standing unmet request on Square, Shopify POS and Zoho POS — [Square community](https://community.squareup.com/t5/Payments-Troubleshooting/FEATURE-REQUEST-adding-STORE-CREDIT-to-a-customers-account/m-p/851555); [Shopify community](https://community.shopify.com/t/how-can-i-implement-a-net-30-charge-account-feature-in-pos/5047); [Zoho community](https://help.zoho.com/portal/en/community/topic/enhancement-request-%e2%80%93-allow-cashiers-to-collect-payments-and-partial-payments-for-outstanding-credit-invoices-directly-from-zoho-pos-billing-app)

### Inferences
- **Free plan needed to match or beat the field (inference):** one till, unlimited products and sales, basic inventory, receipts/printing, Arabic and English, full offline selling including refunds and new customers (where Loyverse falls short), USD+LBP tender at a daily rate (found elsewhere only in Elementary POS for cash), and a basic customer credit tab (free in OkCredit/Khatabook-style ledgers, and requested-but-missing in several POS products).
- **Features with evidence of willingness to pay (inferred from what competitors charge for):** staff accounts/permissions/timecards; purchase orders and advanced stock; additional tills, users and branches; unlimited history and richer reports; web/desktop back office; integrations; SMS/WhatsApp debt reminders; multi-device sync.
- Giving credit tabs and dual currency away free would make the free tier distinctive, but the same two features are the most Lebanon-specific value; an alternative is free basic versions (single rate, simple tab) with paid depth (rate history, statements, reminders, limits). This is a judgement call for the report writer, not a sourced finding.
- lebanon-POS's per-till pricing differs from the per-store norm; a two-till shop at $15–35/till pays $30–70, versus $10 (Aronium), $15–20 (Zoho) or $50 (Loyverse with two add-ons) per store.

### Gaps
- No direct evidence (surveys, review text, conversion data) of what small shops in Lebanon or the Arab world actually pay for; all conclusions here derive from competitor packaging.
- No user review text in Arabic was retrieved for any product.
- Conversion rates from free to paid for Loyverse or peers: not found.
