# Emerging-market shop apps and POS: which features drove adoption, which failed (lessons for a Lebanon POS)

> Method note (read first): this session's research relied on web-search result summaries; no full article was fetched and read end to end. Figures below are therefore as reported in search summaries of the linked pages, and should be spot-checked before being quoted in anything external. Each finding is labelled **[Hard]** (regulatory filing, audited/listed-company results, independent press reporting of filings), **[Press]** (independent reporting, not filings), **[Company claim]** (self-reported, unaudited), or **[Vendor/blog]** (marketing or low-authority source).

## 1. Digital credit-ledger ("bahi khata") apps: what hooked users, effect on repayment, monetisation, pivots

### Takeaway
A free ledger with SMS/WhatsApp payment reminders is a proven acquisition hook (millions of merchants in every market) but has almost never been a business on its own: every well-funded ledger app either died (Lummo/BukuKas liquidated), pivoted away (Kippa), or is still loss-making while trying to monetise through lending, payments and paid SaaS tiers (Khatabook, OkCredit, BukuWarung). The only clearly subscription-funded player found is Vyapar, which charges for billing/inventory/desktop rather than for the ledger. No independent study measuring the effect of ledger reminders on repayment speed was found; the "3x faster" figure is marketing copy.

### Cited Findings
**Hook features and usage**
- [Company claim] OkCredit described its model as "record, remind and payments" and said merchants sent 40,000+ SMS reminders and 250,000 WhatsApp reminders per day; it also wrote that reminders are only "a bridge" and that an in-app way to collect the money matters as well. — [OkCredit on Medium](https://medium.com/okcredit/record-remind-and-payments-a-full-stack-model-that-ticks-all-the-right-boxes-for-merchants-7a465b01f418)
- [Company claim] Khatabook's blog and site claim merchants "collect payments 3X faster" by setting a collection date and sending a reminder the day before; no baseline, sample or methodology is given. — [Khatabook blog](https://khatabook.com/blog/use-khatabook-for-faster-returns)
- [Company claim] Khatabook added automated bot-call reminders followed by an SMS with a payment-collection link, citing internal insight that ~30% of a merchant's customers need an extra nudge. — [VARINDIA](https://varindia.com/public/index.php/news/khatabook-launches-automated-bot-call-reminder-feature)
- [Vendor/blog] For comparison, Razorpay claims 30-40% faster collection after automated reminders (also self-reported, different customer segment). — [Razorpay blog](https://razorpay.com/blog/automated-payment-reminders)
- [Company claim] Khatabook said in 2021 it had 10M+ monthly active users. — [Entrepreneur India](https://india.entrepreneur.com/?p=20462)
- [Company claim / third-party profile] CreditBook (Pakistan) offers lending/borrowing tracking with SMS and WhatsApp reminders and is described as serving nearly one million active users, later adding a banking-as-a-service platform; it raised $1.5M seed then an $11M round. — [CB Insights profile](https://www.cbinsights.com/company/creditbook); [Dawn](https://www.dawn.com/news/amp/1664450)
- [Press / company claim] Udhaar Book (Pakistan, YC) launched 2020 as a digital khata, raised $6M in Nov 2021 "to scale as a super app for merchants"; its listing still presents it mainly as a free ledger, reminder and invoicing tool. — [Profit Pakistan](https://profit.pakistantoday.com.pk/2021/11/08/pakistans-yc-backed-udhaar-book-raises-6mn-to-scale-as-super-app-for-merchants); [App Store listing](https://apps.apple.com/app/1542333203)
- [Press] Morocco: Chari bought the credit/bookkeeping app Karny.ma (~40,000 merchants) in 2021 specifically for the data on how shoppers take and repay shop credit, to underwrite its own lending. — [TechCrunch](https://techcrunch.com/2022/01/20/moroccos-chari-valued-at-100m-in-bridge-round-as-it-looks-to-pilot-bnpl-services)
- [Press, anecdotal] Rwanda's "Trust Me" app targets customer defaults on shop credit; 650+ shops reported, evidence limited to developer claims and one shopkeeper's testimony. — [The New Times](https://www.newtimes.co.rw/article/29297/news/technology/trust-me-how-locally-developed-app-could-curb-debt-defaults-in-small-retail-businesses)

**Measured evidence (independent)**
- [Hard, academic, indirect] A field experiment with ~34,000 small-firm users of a payments technology in Mexico found that reminders raised take-up of a profitable (lower-fee) offer by about 15%, while deadlines had no effect. This shows reminders move small-merchant behaviour, but the outcome was not debt collection. — [J-PAL paper](https://www.povertyactionlab.org/media/file-research-paper/why-small-firms-fail-adopt-profitable-opportunities)
- [Hard, academic pilot] A Berkeley CEGA pilot using digital sales/inventory data for credit assessment found only about half of micro-entrepreneurs kept using the recording technology through the pilot, i.e. sustained data entry is the binding constraint. — [CEGA](https://cega.berkeley.edu/collection/digital-sales-and-inventory-data-to-assess-creditworthiness/)

**Monetisation outcomes**
- [Press of filings] OkCredit: FY24 revenue Rs 14.3 crore (+72%), from ads, subscriptions and service fees; FY25 loss narrowed 34% to Rs 23 crore; Inc42 notes both OkCredit and Khatabook are cutting losses ahead of possible sector consolidation. — [YourStory](https://yourstory.com/2024/10/okcredit-reports-72-percent-rise-annual-revenue-rs-14-cr); [Inc42](https://inc42.com/buzz/tiger-global-backed-okcredit-narrows-fy25-loss-by-34-to-inr-23-cr/)
- [Low-authority aggregator; unverified] Khatabook FY24 operating revenue ~Rs 102.7 crore with a net loss of ~Rs 116 crore; the ledger stays free and revenue is meant to come from lending and paid SaaS. — [Indian Startup Times](https://www.indianstartuptimes.com/?p=24718)
- [Press, headline only] The Morning Context ran an analysis titled "Khatabook can't lend enough to justify its valuation" (paywalled; body not read). — [The Morning Context](https://themorningcontext.com/internet/khatabook-cant-lend-enough-to-justify-its-valuation)
- [Press] Failed adjacency: Khatabook shut its MyStore digital-storefront app (Nov 2021) within a year of launch; OkCredit also shut its e-commerce enablement app. — [Inc42](https://inc42.com/buzz/khatabook-pulls-the-plug-on-digital-shopfront-platform-mystore-within-a-year-of-its-launch)
- [Hard] Lummo (formerly BukuKas, Indonesia) entered voluntary liquidation per Singapore ACRA filings. — [DealStreetAsia](https://media.dealstreetasia.com/stories/indonesia-lummo-liquidation-360554)
- [Press] Reported reasons: after 3+ years building software for MSMEs its revenue stayed small; it tried B2B commerce for warungs around 2021, laid off staff in 2022-23, and returned remaining cash to investors rather than pivot again. — [DailySocial](https://en.dailysocial.id/post/Lummo-Saas-layoffs-2023); [Akurat](https://www.akurat.co/riil/729344/ini-alasan-2-startup-ri-bekingan-bezos-gulung-tikar); [Capital Edge (Korean newsletter, unverified figures)](https://maily.so/capitaledge/posts/92zeeyn7zep)
- [Press of filings] BukuWarung cut its loss to $6.3M in FY2023 from $25.2M in 2022; still loss-making, no source found showing profitability. — [DealStreetAsia](https://dealstreetasia.com/stories/bukuwarung-earnings-2023-408041)
- [Press] Kippa (Nigeria): added agency banking/POS payments (KippaPay) on top of its bookkeeping app, shut it on 15 Nov 2023 with 40 layoffs citing profitability and the naira devaluation, then discovered ~N30M of internal fraud tied to KippaPay; by early 2024 a co-founder left and the company was reported to be pivoting to AI edtech. — [Techpoint](https://techpoint.africa/news/nigerian-fintech-startup-kippa-to-shut-down-offline-payment-product-to-lay-off-employees-in-december/); [TechCabal on fraud](https://techcabal.com/2024/01/15/kippa-loses-millions-to-fraud/); [TechCabal on exit/pivot](https://techcabal.com/2024/02/01/exclusive-kippa-cofounder-duke-ekezie-exits-after-agency-banking-shutdown-embarks-on-new-venture/)
- [Company claim / secondary] Vyapar (India): subscription model, paid yearly; free Android tier, paid desktop with 30-day trial; founder said in 2020 that the main revenue comes when users graduate to desktop and that monthly revenue had grown from Rs 30-35 lakh to Rs 90 lakh in a year. — [Livemint via IndiaMART](https://corporate.indiamart.com/2020/07/27/an-app-to-turn-the-khata-digital-for-small-businesses-livemint); [YourStory](https://yourstory.com/smbstory/msme-accounting-software-gst-bengaluru-vyapar/amp)
- [Unverified student case study] Vyapar: 10M+ registered, ~900k MAU, ~600k mobile paid and ~300k desktop paid users (undated, not from the company). — [GrowthX](https://growthx.club/proof-of-work/fintech/vyapar-apps/acquisition-project---vyapar-apps|66041c4327a88450aaf4bc93)

### Inferences
- The ledger + reminder is a cheap, sticky acquisition feature but merchants do not pay for it; in a Lebanon POS it belongs in the base product (customer debt book, WhatsApp reminder with balance, optional payment link to Whish/OMT), not as a paid module.
- The pattern "free ledger, monetise with lending" has not yet produced a profitable company in the evidence found; the pattern "charge a small annual fee for billing + inventory + printing, with ledger included" (Vyapar) is the one that visibly generated subscription revenue.
- Adding cash-handling agency services to a software company brought fraud and FX exposure that killed the product at Kippa; a POS vendor should partner with licensed operators rather than hold float itself.
- Since OkCredit itself says reminders need a payment channel to close the loop, the reminder message is most useful when it carries the exact balance and a way to pay or confirm.
- Sustained manual data entry is the weak point (CEGA: half dropped out). A ledger that fills itself from POS sales ("sell on credit" as a tender type) avoids the double entry that standalone khata apps require.

### Gaps
- No randomised or quasi-experimental study measuring the effect of ledger-app reminders on repayment speed or default was found. All "X times faster" numbers are vendor claims.
- Nothing was found on Konnash (Morocco) or on Egyptian consumer-facing ledger apps (the brief mentions Lucky, which is a consumer rewards/credit app; not researched). Kudi (now Nomba) was not researched.
- No confirmed consolidated FY25 Khatabook numbers; no current user counts for Khatabook, OkCredit, BukuWarung.
- Whether Kippa's bookkeeping app is still live was not confirmed. The timing of CreditBook's move into embedded finance was not confirmed.

## 2. B2B ordering/restocking platforms: what merchants valued and what happened by 2024-2026

### Takeaway
Asset-heavy app-based restocking (own warehouses and trucks) largely failed or consolidated between 2022 and 2025: Capiter collapsed, MarketForce closed its B2B arm, Sabi pivoted, MaxAB and Wasoko merged then bought Fatura, Sary merged into SILQ, Udaan shrank from 1,000+ cities to 16. Survivors moved to asset-light marketplaces and to financial services (BNPL for stock, payments), with Chari's CEO calling B2B commerce "a terrible business, but a fantastic Trojan Horse".

### Cited Findings
- [Press] Capiter (Egypt): raised $33M Series A in Sept 2021, hired ~500 people in six months; layoffs and unpaid salaries from mid-2022; board fired the CEO and COO founders in Sept 2022 citing failure to fulfil duties; founders denied mismanagement and sued; company left in arrears to employees and creditors. Investors had wanted a sale to a Saudi player, which the founders refused. — [TechCrunch](https://techcrunch.com/2022/10/27/dispute-between-founders-and-board-leaves-capiter-in-arrears-to-employees-and-creditors); [EnterpriseAM](https://enterpriseam.com/egypt/2022/09/11/capiter-board-fires-ceo-coo-as-company-looks-set-to-become-first-casualty-of-slowdown-on-planet-startup/)
- [Press] MaxAB and Wasoko merged in 2024; in May 2025 MaxAB-Wasoko acquired Fatura from EFG Finance (which took equity and a board seat). Fatura is an asset-light marketplace linking 626 wholesalers to retailers in 16 cities and was projected (company forecast) to provide 25% of Egypt revenue by end-2025. — [TechCabal](https://techcabal.com/2025/05/19/maxab-wasoko-acquires-egypts-fatura/); [Wamda](https://www.wamda.com/2025/05/maxab-wasoko-acquires-fatura-efg-finance-joins-board)
- [Press analysis] WeeTracker (July 2025): Africa's full-stack B2B model "largely crumbled"; Alerzo closed 14 warehouses and cut 400 staff in one round; Twiga, Copia, Wasoko and MaxAB all made large layoffs and warehouse closures; survivors are trading "trucks for transactions" (fintech). Chari's CEO Ismael Belkhayat is quoted calling African B2B commerce "a terrible business, but a fantastic Trojan Horse". — [WeeTracker](https://weetracker.com/2025/07/15/african-b2b-ecommerce-fintech-pivot/)
- [Press] MarketForce (Kenya) wound down its RejaReja B2B arm in 2024 and moved to social commerce; Sabi (Nigeria) cut ~20% of staff in June 2025 and pivoted to commodity traceability after raising $38M. — [TechCrunch MarketForce](https://techcrunch.com/2024/04/19/marketforce-winds-down-its-b2b-e-commerce-arm/); [TechCrunch Sabi](https://techcrunch.com/2025/06/20/after-raising-38m-african-e-commerce-startup-sabi-lays-off-20-pivots-to-traceable-exports)
- [Press] Pakistan: by Feb 2024 B2B restocking startups had "shut shop or scaled down", with Bazaar also struggling. — [Profit Pakistan](https://profit.pakistantoday.com.pk/2024/02/12/b2b-startups-shut-shop-or-iscale-down-bazaar-too-struggles-to-tide-over-current-crisis)
- [Press / company claim] Sary (KSA) merged with Bangladesh's ShopUp in April 2025 to form SILQ Group with $110M (equity plus a financing facility for SILQ Financial, i.e. merchant credit); combined they claim 600,000+ retailers/HoReCa/wholesalers served. — [Wamda](https://www.wamda.com/en/2025/04/sary-shopup-join-forces-create-silq-fuelled-110-million-investment); [EnterpriseAM](https://enterpriseam.com/ksa/2025/04/10/sary-merges-with-bangladeshs-shopup-to-launch-new-b2b-platform-raising-usd-110-mn/)
- [Press / company claim] Chari (Morocco): valued at $100M in a 2022 bridge to pilot BNPL; bought Axa Credit Maroc for $22M for a credit licence; in Oct 2025 closed a $12M Series A and obtained a Bank Al-Maghrib payment-institution licence (IBANs, cards, transfers, micro-insurance) to "turn shops into financial hubs". One profile dates the licence to Nov 2022, conflicting with the 2025 press releases. — [Wamda](https://www.wamda.com/en/2025/10/chari-secures-12-million-series-payment-licence-bank-al-maghrib); [TechCabal on Axa Credit](https://techcabal.com/?p=89822); [How We Made It In Africa](https://www.howwemadeitinafrica.com/how-a-moroccan-groceries-supplier-became-something-that-looks-more-like-a-bank/182527/)
- [Press / company statements] Udaan (India): operated in 1,000+ cities at its 2021-22 peak, cut to 16 cities by FY26; fixed costs cut 20% and EBITDA burn 40% in 2024; acquired ShopKirana in July 2025 in an all-stock deal (~$88.5M) partly for its staples private label; Inc42 headline reports FY26 revenue Rs 5,134 crore (+13%) with a loss of Rs 852 crore (headline only, not verified). — [Business Standard](https://www.business-standard.com/industry/news/udaan-acquires-shopkirana-ahead-of-ipo-125071800825_1.html); [Inc42](https://inc42.com/features/how-high-can-udaan-fly-blueprint-revival/)
- [Press] Jumbotail acquired Solv India and raised a $120M Series D in 2025 (from the search summary of the Udaan/ShopKirana coverage). — [YourStory](https://yourstory.com/2025/07/udaan-acquires-shopkirana-in-all-stock-deal)
- [Hard, listed company] Fawry's B2B "Buy Now, Pay Later for business" serves 120,000 merchants with EGP 5bn purchase volume, and Fawry piloted "Ordarak Fawry", a retailer-supplier marketplace, i.e. the payments incumbent is entering restocking from the finance side. — [Fawry FY2025 results via Zawya](https://www.zawya.com/en/press-release/companies-news/fawry-releases-fy2025-results-qwuzfh7k)

### Inferences
- The features merchants are documented to keep using are the financial ones attached to restocking (stock on credit / BNPL) and marketplace access to many wholesalers; owning the delivery is what destroyed the economics.
- For a Lebanon POS the transferable idea is asset-light: a reorder list generated from POS sales and sent to the shop's existing distributors (WhatsApp/PDF order), supplier price lists, and supplier-credit tracking, without operating logistics.
- Stock-financing only works with a licensed lending partner and reliable sales data; POS data is the asset, which is why Chari bought a ledger app and Fawry lends to its terminal merchants.
- Macroeconomic shocks (Egyptian devaluation, naira devaluation) were repeatedly cited in failures; Lebanon's currency risk makes holding inventory or extending LBP credit especially dangerous.

### Gaps
- No direct evidence (surveys, usage data) was found ranking which app features retailers valued most (one-tap reorder vs price transparency vs BNPL); the inference above rests on what survivors kept and built.
- TradeDepot: only an acquisition of Ghana's Green Lion and its asset-heavy classification surfaced; no 2024-2026 status found. No post-merger financial results for MaxAB-Wasoko found. Jumbotail detail is thin.

## 3. Offline / low-connectivity, low-end Android, SMS/USSD fallbacks, cheap Bluetooth printing

### Takeaway
Offline-first operation and thermal/Bluetooth printing are standard, expected features in products that small shops actually pay for (Vyapar, mPharma's Bloom POS), but the evidence for this is product listings and vendor material rather than adoption studies; academic work points to infrastructure reliability, cost, trust and fear of tax exposure as the real adoption barriers.

### Cited Findings
- [Company listing] Vyapar works online and offline and includes printing on regular and thermal printers (and PDF sharing) as a standard feature, not a paid add-on. — [Vyapar pricing detail](https://vyaparapp.in/pricing-detail); [GetApp listing](https://www.getapp.com/accounting-software/a/vyapar)
- [Press] mPharma's "Bloom PoS mobile" for African pharmacies captures sales offline so pharmacies keep operating without reliable power or internet, and targets Android 8+ devices used by counter assistants. — [BusinessDay](https://businessday.ng/?p=712120)
- [Hard, academic] A 2018 IIM Bangalore study (technology-organisation-environment framework) of small Indian retailers and digital payments found the key barriers were tax and security implications, bureaucracy, lack of trust in the regulatory environment, poor physical/digital infrastructure, unreliable technology, and cost. — [IIMB repository](https://repository.iimb.ac.in/bitstream/2074/13997/1/Diatha_ACIS_2018.pdf)
- [Vendor/blog] Ginesys argues a rural-retail POS must record sales, print invoices and update inventory offline and sync later; Policy Circle argues "utility, not flashiness" drives kirana adoption, that laptops/desktops are impractical versus Android phones/tablets, and that adoption depends on user confidence. — [Ginesys](https://www.ginesys.in/blog/pos-for-rural-retail-bridging-the-digital-divide-with-affordable-offline-capable-systems); [Policy Circle](https://www.policycircle.org/opinion/kirana-stores-online-retail/)
- [Company claim] Khatabook/OkCredit reminders run over SMS and WhatsApp, and Khatabook added voice (bot-call) reminders, i.e. the debtor needs no app or data. — [VARINDIA](https://varindia.com/public/index.php/news/khatabook-launches-automated-bot-call-reminder-feature)

### Inferences
- Offline-first with later sync, receipt printing on cheap ESC/POS Bluetooth printers, and WhatsApp/PDF receipt as a no-printer fallback should be treated as table stakes for Lebanon (power cuts, generator switching, patchy data).
- The tax-exposure fear documented in India is likely to apply in Lebanon's informal sector: local-first data storage and clear messaging about who can see the data are adoption features, not just engineering choices.
- Customer-facing messages should not require the shopper to install anything (WhatsApp first in Lebanon, SMS as fallback).

### Gaps
- No evidence found on USSD-based shop tools, battery/data-saving modes, or measured APK size/low-RAM performance effects on adoption. No independent study on Bluetooth printer use in small shops. This section is the weakest-evidenced in these notes.

## 4. Multi-currency / high-inflation markets

### Takeaway
In dual-currency economies the real-world practice is messy and regulated: shops price in hard currency, convert at a rate that may differ from the official one, give change in local currency at another rate, and sometimes run two or three prices per item by payment method. Software support found is mostly a rate feed plus bulk repricing; governments (Zimbabwe, Venezuela) actively inspect and fine the rate used, so the rate setting is a compliance-sensitive control.

### Cited Findings
- [Press] Venezuela: most small shops (abastos, bodegas) price in dollars at the parallel rate while giving change in bolivars at the official BCV rate; card payments can carry surcharges (reports of up to 10%); some shops price in euros using the BCV euro rate; merchants "improvise" to avoid losses from the official/parallel gap. — [Voz de America](https://www.vozdeamerica.com/a/comerciantes-venezolanos-se-las-ingenian-para-evitar-perdidas-brecha-entre-dolar-oficial-y-paralelo-/7979129.html); [La Patilla](https://lapatilla.com/2022/09/30/asi-cotiza-el-dolar-propatria-en-caracas/)
- [Press] Venezuelan authorities inspect shops to verify use of the official dollar rate. — [Portafolio](https://www.portafolio.co/internacional/autoridades-en-venezuela-inspeccionan-comercios-para-verificar-el-uso-del-dolar-oficial-626850)
- [Press] Zimbabwe (2024): some major chains displayed both USD and ZiG prices at the official rate while others pegged prices to unofficial rates; by Oct 2024 retailers used "three-tier pricing", three prices for the same product depending on payment method; retailers said pricing at the official rate caused "massive losses". — [Pindula](https://news.pindula.co.zw/2024/10/15/retailers-persist-with-three-tier-pricing-as-zig-falters); [NewsDay](https://www.newsday.co.zw/local-news/article/200032140/prices-gallop-as-zig-loses-grip)
- [Press] Zimbabwe planned fines for companies not using the official ZiG rate. — [Bloomberg](https://www.bloomberg.com/news/articles/2024-05-09/zimbabwe-to-fine-companies-not-using-the-official-zig-fx-rate)
- [Product listing] Argentina: an Odoo module pulls official, blue, MEP and other dollar rates in real time from DolarApi, i.e. several named rates selectable per business. — [Odoo Apps](https://apps.odoo.com/apps/modules/19.0/currency_DolarApi)
- [Product listing] Argentine POS bcnsoft offers bulk ("massive") price updates for chains alongside AFIP/ARCA e-invoicing; the listing does not say updates are FX-linked. — [Capterra](https://www.capterra.co.za/software/1096473/bcnsoft)
- [Low-authority] An open-source small-shop POS (Posmex) lets product prices move with the dollar's value "if required". — [SourceForge](https://sourceforge.net/p/posmex/discussion)

### Inferences
- Features implied by observed merchant behaviour: (a) store cost and price in a base hard currency and display/collect in either; (b) a shop-set rate (not only an official feed), changeable in one tap with a timestamped history; (c) separate rate for giving change; (d) price tiers or surcharge by payment method (cash USD, cash local, card); (e) bulk repricing and reprint of shelf labels after a rate change; (f) mixed-tender sales with change in the other currency.
- Because authorities elsewhere fine merchants over the rate used, the POS should record which rate was applied to each sale and let the owner choose/declare the reference rate, rather than hard-coding one.
- Lebanon's own practice (USD pricing, LBP at a market rate, post-2023 official dual-pricing rules) should be checked against local regulation by the Lebanon-specific researcher; nothing here is Lebanon-sourced.

### Gaps
- No sources found for Turkey, Nigeria, Syria or Iraq POS practice. No evidence on electronic shelf labels in small shops, or on measured benefit of auto-repricing. Argentina evidence is product listings only; no mainstream Argentine kiosk POS was confirmed to do FX-indexed repricing.

## 5. Pharmacy and grocery specifics

### Takeaway
For pharmacies, batch-level expiry tracking and offline operation are the differentiators, and the most scaled African models (mPharma, Field Intelligence) bundle software with inventory supply/financing rather than selling software alone. For groceries, no solid evidence on weighing-scale barcodes or loose-item handling was found.

### Cited Findings
- [Vendor/blog] Most pharmacy systems track stock levels; fewer track batch number and expiry per batch (supplier batch, manufacture date, expiry date per unit), which is what solves the expired-stock problem. — [AVIXA Xchange vendor overview](https://xchange.avixa.org/posts/7-pharmacy-pos-software-studios-solving-the-inventory-expiry-problem)
- [Press] Field Intelligence's "Shelf Life" takes over a pharmacy's supply chain and inventory management (pay-as-you-sell style service rather than a POS); it had 700+ pharmacies in 2021 and targeted 12,000 by 2025 (target attainment not confirmed). — [TechCrunch](https://techcrunch.com/2021/07/28/field-intelligence-targets-11-african-cities-to-expand-its-pharmacy-inventory-management-service/)
- [Press] mPharma's Bloom POS mobile works offline on Android 8+ for counter assistants. — [BusinessDay](https://businessday.ng/?p=712120)
- [Opinion] A TechCabal op-ed (Feb 2025) argues pharmacy health-tech in Africa needs several changes to "truly work" (content not read in full). — [TechCabal](https://techcabal.com/2025/02/08/op-ed-pharmacy-health-tech-in-africa/)
- [User review, weak] Reviewers note most pharmacy software available regionally was designed for hospital chains or foreign markets, not small local pharmacies. — [G2](https://www.g2.com/products/hcue-pharmacy/reviews)

### Inferences
- A pharmacy mode should include batch + expiry capture at goods-in, FEFO selling, near-expiry alerts and supplier-return lists; the commercial lesson from mPharma/Field Intelligence is that pharmacies adopt software more readily when it comes with a tangible stock or cash-flow benefit.
- In Lebanon drug prices are set by the Ministry of Public Health, so an importable regulated price list would be the local equivalent of "regulated prices" support (needs local verification; not sourced here).

### Gaps
- No evidence found on regulated-price handling in emerging-market pharmacy POS, on Chefaa or other MENA pharmacy software, or on adoption numbers for pharmacy POS. No evidence on grocery weighing-scale (price-embedded) barcodes, loose items, or supplier-credit features; these remain unresearched rather than disproven.

## 6. Value-added services that earn shops extra income (bills, top-ups, transfers, loans) and feasibility in Lebanon

### Takeaway
This is the best-evidenced route to merchant loyalty and to a sustainable business: Fawry (listed, profitable, ~377k terminals) and Moniepoint/OPay (1M+ terminals each) built on bill payment, top-ups and cash services through small shops, then layered lending on transaction data. But per-agent commission income erodes as networks saturate (M-Pesa average agent commission hit a record low in FY2026). In Lebanon the rails already exist through OMT and Whish, so a POS would be an integrator/reseller, not a network builder.

### Cited Findings
- [Hard, listed company] Fawry FY2025: ~376.6k POS terminals (372.4k in FY2024), 354k acceptance-enabled (+5.5%); boilerplate cites 377k agents, 36 member banks, ~54.8M monthly users. — [Fawry FY2025 results via Zawya](https://www.zawya.com/en/press-release/companies-news/fawry-releases-fy2025-results-qwuzfh7k)
- [Press] Fawry's core engine: a small cut each time a customer pays a bill or tops up a phone through a shop; described as a profitable ~$1bn business. — [TechCabal](https://techcabal.com/2026/04/20/how-fawry-built-a-profitable-fintech/)
- [Hard, listed company] Fawry's merchant BNPL-for-business serves 120,000 merchants, EGP 5bn purchase volume. — [Zawya](https://www.zawya.com/en/press-release/companies-news/fawry-releases-fy2025-results-qwuzfh7k)
- [Press] Nigeria had 5.9M+ active POS terminals in March 2025; Moniepoint and OPay each report 1M+ merchant terminals. — [BusinessDay](https://businessday.ng/technology/article/moniepoint-opay-eye-expansion-as-market-booms/)
- [Company claim] Moniepoint says it disbursed $700M+ in MSME loans in 2025, ~75% of borrowers had never had a business loan, and borrowers' average transaction value rose 36%. — [The Guardian Nigeria](https://guardian.ng/?p=2884068)
- [Press / company claim] FairMoney deployed 100,000 POS terminals explicitly to use merchant payment data to underwrite business loans. — [Legit.ng](https://www.legit.ng/business-economy/industry/1721705-fairmoney-deploys-100000-pos-terminals-uses-merchant-payment-data-unlock-business-loans/)
- [Press] Kenya: average annual M-Pesa agent commission fell to a record low of Sh112,244 in the year to March 2026 as agent numbers rose; airtime commission per agent followed the same trend. — [Business Daily Africa](https://www.businessdailyafrica.com/bd/economy/rising-agent-numbers-cut-average-m-pesa-commissions-5536894)
- [Industry body] GSMA: airtime is often a higher-margin line for agents per transaction, but mobile-money agents handle far more volume, which offsets lower margin. — [GSMA](https://www.gsma.com/solutions-and-impact/connectivity-for-good/mobile-for-development/programme/mobile-money/why-do-mobile-money-agents-get-paid-less-than-airtime-retailers/)
- [Company claim] Morocco's WafR turns corner stores into "digital finance hubs" (mobile top-ups, bill payments): ~20,000 active merchants, 100k+ Play Store downloads but a 2.8 rating; raised $4M seed in Feb 2026; aims for 100,000 shops plus micro-insurance and credit scoring. It began as a brand-promotions app for grocers. — [We Are Tech Africa](https://www.wearetech.africa/en/fils-uk/solutions/moroccan-fintech-wafr-turns-corner-stores-into-digital-finance-hubs); [AllAfrica](https://allafrica.com/stories/202602260018.html)
- [Press] Counter-example: Kippa's agency-banking add-on was closed within about a year over profitability, devaluation and fraud. — [Techpoint](https://techpoint.africa/news/nigerian-fintech-startup-kippa-to-shut-down-offline-payment-product-to-lay-off-employees-in-december/)
- [Company claim] Lebanon: OMT says it has 1,400+ locations and takes Alfa, Touch and Ogero bill payments at any agent or in its app. — [OMT LinkedIn](https://www.linkedin.com/company/omtleb); [OMT news](https://omt.com.lb/en/news/mobile-lines-monthly-bills-in-lbp-through-omt-at-the-official-exchange-rate-1515-lbp)
- [Company listing] Lebanon: Whish Money's app lists Alfa and Touch top-ups and credit transfers; Whish has an agent programme and a 2025 Mastercard Move cross-border partnership. — [App Store](https://apps.apple.com/us/app/whish/id1284243483); [Mastercard](https://www.mastercard.com/news/eemea/en/newsroom/press-releases/en/2025-1/august/whish-money-collaborates-with-mastercard-move-to-bring-seamless-cross-border-payments-to-lebanon)

### Inferences
- The durable model is: terminal/app in the shop -> high-frequency small-commission services -> transaction data -> lending. Software-only players that tried to bolt on agency services without licences and controls (Kippa) failed; licensed networks (Fawry, Moniepoint) succeeded.
- In Lebanon comparable services look feasible only as a partnership layer: recording and reconciling recharge-card/top-up sales and agent commissions inside the POS, and, if OMT/Whish offer reseller APIs, selling top-ups and bill payments from the POS screen. Whether such APIs and commission shares are available is not established here.
- Commission income should be pitched as a modest extra, not a headline promise, given documented commission erosion as networks densify.
- POS-data-based working-capital loans need a licensed Lebanese lender; with the banking sector impaired since 2019 this is a longer-term option (inference; verify locally).

### Gaps
- No figures found for Whish agent counts, OMT/Whish agent commission rates, Alfa/Touch recharge resale margins, or the existence of reseller APIs. No published Fawry or M-Pesa bill-payment commission rates. No OPay lending figures. Paytm and micro-insurance through shops were not researched.

## 7. Community/network features: shared loyalty, group buying, supplier marketplaces

### Takeaway
Little evidence of success was found for neighbourhood-level community features. The supplier-marketplace idea survives mainly in asset-light form (Fatura inside MaxAB-Wasoko, Fawry's Ordarak pilot); merchant-facing storefront/e-commerce add-ons from ledger apps were shut down quickly.

### Cited Findings
- [Press] Fatura's asset-light wholesaler marketplace (626 wholesalers, 16 cities) was valuable enough to be acquired by MaxAB-Wasoko in 2025. — [TechCabal](https://techcabal.com/2025/05/19/maxab-wasoko-acquires-egypts-fatura/)
- [Hard, listed company] Fawry pilot-launched "Ordarak Fawry", a retailer-supplier marketplace, on top of its terminal network. — [Zawya](https://www.zawya.com/en/press-release/companies-news/fawry-releases-fy2025-results-qwuzfh7k)
- [Press] WafR started (2022) as a brand-funded promotions/loyalty app letting grocers pass on promotions at the point of sale to steer purchases to a brand, then repositioned toward top-ups and bill payments by 2026. — [Wamda](https://www.wamda.com/en/2022/09/moroccan-startup-helping-grocers-improve-customer-loyalty); [We Are Tech Africa](https://www.wearetech.africa/en/fils-uk/solutions/moroccan-fintech-wafr-turns-corner-stores-into-digital-finance-hubs)
- [Press] Khatabook's MyStore and OkCredit's e-commerce enablement app (online storefronts for small shops) were both discontinued. — [Inc42](https://inc42.com/buzz/khatabook-pulls-the-plug-on-digital-shopfront-platform-mystore-within-a-year-of-its-launch)

### Inferences
- Brand-funded promotions redeemed at the till (FMCG pays, shop and shopper benefit) appear more viable than shop-funded shared loyalty, but WafR's shift toward financial services suggests promotions alone were not enough.
- Online-storefront features for corner shops have a poor record; they should be low priority.

### Gaps
- No evidence found, positive or negative, on shared loyalty schemes among neighbourhood shops or on group buying by small retailers. Treat these as unproven ideas.

## 8. Pricing models that worked for such merchants

### Takeaway
Three models have visible traction: (1) free core + low annual subscription for billing/inventory/desktop (Vyapar, roughly Rs 700-800/year mobile and Rs 3,400-4,400/year desktop); (2) free or subsidised terminal monetised by per-transaction commissions and float (Fawry, Moniepoint, OPay); (3) free software monetised by merchant credit (Chari, SILQ, Fawry BNPL; Khatabook still unproven). Pure free ledgers funded by venture capital did not work.

### Cited Findings
- [Listings; may be outdated] Vyapar: Capterra lists plans from Rs 3,399/year; another listing gives Android Silver Rs 699 and Gold Rs 799 per year, Desktop Silver Rs 3,799/year, Desktop+Mobile Silver Rs 4,399/year; free Android tier and 30-day desktop trial. — [Capterra](https://www.capterra.com/p/180579/Vyapar/pricing/); [Vyapar pricing detail](https://vyaparapp.in/pricing-detail)
- [Company claim] Vyapar's founder said the main revenue arrives when users graduate to the paid desktop version. — [Livemint via IndiaMART](https://corporate.indiamart.com/2020/07/27/an-app-to-turn-the-khata-digital-for-small-businesses-livemint)
- [Press of filings] OkCredit's revenue mix is ads + subscriptions + service fees, totalling only Rs 14.3 crore in FY24 after years of scale, still loss-making in FY25. — [YourStory](https://yourstory.com/2024/10/okcredit-reports-72-percent-rise-annual-revenue-rs-14-cr); [Inc42](https://inc42.com/buzz/tiger-global-backed-okcredit-narrows-fy25-loss-by-34-to-inr-23-cr/)
- [Press] Fawry earns a small cut per bill payment/top-up across ~377k terminals and is profitable. — [TechCabal](https://techcabal.com/2026/04/20/how-fawry-built-a-profitable-fintech/)
- [Press] TechCabal describes Moniepoint moving "from PoS scale to full-stack lock-in in two years" (terminals first, then banking, credit and business tools). — [TechCabal](https://techcabal.com/?p=180023)
- [Hard] Lummo/BukuKas: revenue from MSME software stayed small after 3+ years, ending in liquidation. — [DealStreetAsia](https://media.dealstreetasia.com/stories/indonesia-lummo-liquidation-360554)

### Inferences
- For Lebanon, a low flat annual/monthly price in USD with a genuinely useful free tier, paid upgrades tied to things owners recognise as "serious" (multi-device/desktop, inventory, reports, printing templates, multi-user), mirrors the only subscription model shown to work at this merchant size.
- Transaction-fee and lending revenue depend on licensed partners and should be treated as later-stage upside, not the launch business model.
- Hardware (printer, scanner) bundles and instalment financing are plausible but no evidence on them was found in this research.

### Gaps
- No verified data on conversion rates from free to paid, churn, or willingness-to-pay among micro-retailers. No evidence found on hardware-bundle or device-financing outcomes. Vyapar's current paid-user and revenue figures are unverified.
