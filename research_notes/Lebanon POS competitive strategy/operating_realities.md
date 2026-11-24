# Operating Realities of Lebanese Shops and Restaurants (POS Implications)

Research note: Two hosts I needed (today.lorientlejour.com and www.forvismazars.com) are blocked by this session's network settings, so I could not open the full articles. Findings attributed to L'Orient-Le Jour (L'Orient Today) and Forvis Mazars come from search-result summaries of those articles, not from reading them in full. Treat exact figures from them as needing verification.

## Payments: cash vs card, fresh vs lollar, acquirers, fees, wallets

### Takeaway
Lebanon is still mostly a cash economy, but card use is rising fast in 2025–2026, pushed by BDL (the central bank) through fee caps and a ban on card surcharges. Wallets such as Whish and OMT Pay can already pay by QR at Areeba POS terminals. A POS for this market must handle cash first, record split payments by tender type (cash USD, cash LBP, card, wallet), and plan for card/QR integration through acquirers such as Areeba, not through each wallet separately.

### Cited Findings
- The World Bank put Lebanon's cash economy at about $9.9bn, or 45.7% of GDP, in 2022, up from 26.2% in 2021 (2022 data, older than the focus period). — [The New Arab](https://newarab.com/news/lebanons-tanking-economy-cash-based-world-bank); [Al-Monitor](https://al-monitor.com/originals/2023/05/lebanons-tanking-economy-increasingly-cash-based-world-bank); [Al Arabiya](https://english.alarabiya.net/News/middle-east/2023/05/17/Lebanon-economy-now-increasingly-cash-based-over-lack-of-trust-over-banks-World-Bank)
- BDL reported that card transactions rose about 130% in the first eight months of 2026 compared with the same period of 2025. The card share at restaurants reportedly went from 15% to 35%. Fresh-dollar check value rose from about $500m to more than $1bn over the same period. (Search summary only; article not opened.) — [L'Orient Today: card payments surge 130%](https://today.lorientlejour.com/article/1547050/card-payments-surge-130-in-lebanon-bdl-outlines-measures-to-curb-cash-economy.html)
- The US Commercial Service says "fresh dollar" cards linked to fresh accounts have worked again since 2022, but cash remains the main payment method. Online purchases are paid by cash on delivery or by fresh-dollar and international cards. — [trade.gov Lebanon trade financing](https://trade.gov/country-commercial-guides/lebanon-trade-financing); [trade.gov Lebanon eCommerce](https://www.trade.gov/knowledge-product/lebanon-ecommerce)
- In 2022, supermarkets accepted cards for only up to 50% of a bill (older data, from the crisis era). — [Scripps News / AP](https://scrippsnews.com/stories/lebanon-adopts-dollarization-as-currency-economy-crumble)
- BDL capped the merchant discount rate on locally issued cards at 1.25% for supermarkets, mini-markets, bakeries, gas stations, pharmacies and hospitals, effective June 15. Banks may not add other merchant charges in those sectors. Restaurants were not on the reported list. Merchants may not surcharge consumers, yet some still add 2–3% for card payments. (Search summary.) — [L'Orient Today: BDL caps merchant fees at 1.25%](https://today.lorientlejour.com/article/1505868/bdl-caps-merchant-fees-on-local-card-payments-at-125-in-various-sectors.html); a 2026 regulatory alert from Forvis Mazars covers the same rule — [Forvis Mazars FS Alert 05-2026](https://www.forvismazars.com/lb/fr/content/download/1294066/file/FS%20Alert%2005-2026%20-%20fees%20regulation%20on%20electronic%20card%20payments%20.pdf). Conflicting figure: a startup digest headline says the cap is 1.2%, and that electronic payments are 51% of online purchases — [MENA Startup Digest](https://menastartupdigest.com/?p=51325)
- Card acceptance is uneven. Terminals are at about 1,100 of 3,200 petrol stations and about 1,000 of 3,600 pharmacies. Large supermarkets and restaurants have wider coverage. Visa reportedly plans more than $400k of initiatives to support POS rollout. (Search summary.) — [L'Orient Today fee-cap article](https://today.lorientlejour.com/article/1505868/bdl-caps-merchant-fees-on-local-card-payments-at-125-in-various-sectors.html)
- BDL basic circulars on electronic payments were issued in 2026. — [BLOMInvest: Central Bank Issues Basic Circulars](https://blog.blominvestbank.com/wp-content/uploads/2026/05/Central-Bank-Issues-Basic-Circulars-173-1.pdf); LBC reports measures to promote e-payments and allow card payment of taxes and fees — [LBC](https://www.lbcgroup.tv/news/economy/767035/bdl-initiates-measures-to-promote-electronic-payments-and-reduce-cash/en); [LBC taxes by card](https://www.lbcgroup.tv/news/economy/878399/say-goodbye-to-cash-lebanon-to-allow-card-payments-for-taxes-and-fees/en)
- **Areeba (acquirer):** Areeba is based in Beirut and offers merchant acquiring, card issuing, POS terminal management and an API gateway with sandbox and webhooks (per an aggregator). One vendor profile mentions softPOS (tap-on-phone). — [paymentproviders.io](https://paymentproviders.io/providers/areeba.md); [Akurateco](https://akurateco.com/payment-methods/areeba). Areeba reportedly owns more than 14,000 POS terminals, over 50% of those in Lebanon. — [L'Orient Today: digital wallets](https://today.lorientlejour.com/article/1339336/digital-wallets-a-new-way-to-bypass-banks-in-lebanon.html). Areeba enabled Google Pay for Lebanese issuers in September 2025 — [Entrust](https://www.entrust.com/ko/company/newsroom/areeba-partners-with-entrust-to-become-first-to-market-with-google-pay-enablement-in-lebanon). It has a Mastercard partnership for fintech platforms (Nov 2023) — [Mastercard](https://mastercard.com/news/eemea/en/newsroom/press-releases/en/2023/november/mastercard-partners-with-areeba-to-enable-modern-payment-platforms-for-fintechs-in-the-middle-east)
- **Wallet QR at the POS:** Since 2023, Areeba POS terminals print a QR code on the receipt that users of Whish, WeePay and zaky can scan to pay. Merchants need no extra device and pay no sign-up fee. The scheme is described as easy to extend to other wallets. — [FF News: Areeba rolls out QR payments](https://ffnews.com/newsarticle/areeba-rolls-out-qr-code-payments-in-lebanon/). Whish's App Store listing claims "Scan to Pay" works at more than 10,000 POS terminals. — [Whish Money App Store](https://apps.apple.com/lb/app/whish-money/id1284243483). Wallet platforms reportedly charge merchants about 2% commission. — [L'Orient Today: digital wallets](https://today.lorientlejour.com/article/1339336/digital-wallets-a-new-way-to-bypass-banks-in-lebanon.html). Whish publishes a fees page — [Whish fees](https://whish.money/fees-commissions)
- **OMT Pay** lets users pay by QR "in stores using authorized POS machines" with no extra fees, and earns loyalty points. OMT has more than 1,400 cash-out locations. The wallet can be funded in both LBP and USD. — [OMT news: Pay with QR](https://informative.omt.com.lb/en/news/pay-with-qr-on-omt-pay-app-and-turn-your-points-into-cash); [OMT payroll solutions](https://www.omt.com.lb/en/payroll-solutions); [OMT Pay App Store](https://apps.apple.com/lb/app/omt-pay/id1401392516)

### Inferences
- Card payments are rising quickly from a low base. Restaurants' card share (~35% in 2026) suggests most tickets are still cash. The POS should make cash the fastest flow, while one-tap card/QR keeps getting more important.
- Wallet QR in Lebanon runs through the acquirer's terminal (Areeba), not merchant-facing wallet APIs. The realistic integration path is one acquirer (Areeba softPOS or ECR link to its terminal) rather than separate Whish and OMT APIs. A cheap first step is to record "Whish/OMT transfer" as a manual tender with a reference number.
- Because surcharges are banned, the POS should not offer an automatic "card fee" line. Fee caps by sector mean margin reports should track card fees by tender.
- Cards and accounts are split into fresh and lollar (legacy dollars trapped in banks). Merchants may need to tag card payments as fresh vs local/legacy, but I found no source on how this is handled at the counter today.

### Gaps
- I found no reliable 2024–2026 percentage for cash vs card share of retail transactions overall.
- I found no source on merchants accepting or refusing lollar-linked cards at the counter in 2025–2026.
- Whish, OMT and BOB Finance merchant APIs: I found no public developer documentation for merchant collection APIs. BOB Finance did not appear in any result.
- I could not verify the full list of other acquirers (bank-run acquiring such as BLOM, Bank Audi, Fransabank, CSC/Credit Libanais) or their MDRs for restaurants.

## Mixed-currency cash handling

### Takeaway
Since 2023, prices are mostly in USD. Shops must show the rate they apply, and customers keep the right to pay in LBP. Change is often given in LBP at a rate the merchant sets. The rate has been stable at about LBP 89,500 per USD since 2023–2024. A POS needs dual-currency pricing, a posted daily rate, mixed-tender payment and change calculation in both currencies with rounding.

### Cited Findings
- Supermarkets began pricing in USD on March 1, 2023. The rate is shown at the store entrance. — [The National, 2023](https://www.thenationalnews.com/mena/lebanon/2023/03/01/dollars-or-pounds-lebanons-supermarkets-begin-pricing-goods-in-dollars); [Al-Monitor](https://www.al-monitor.com/originals/2023/03/lebanese-supermarkets-mark-prices-dollars-local-currency-tanks)
- An economy ministry decision (2023) allowed USD pricing as an "exceptional and temporary" measure. The approved rate must be shown on shelves, at the entrance and at payment counters, and the customer's choice to pay in LBP or USD must be kept at the register. — [LBC: Minister of Economy dollar-pricing decision](https://www.lbcgroup.tv/news/economy/690020/minister-of-economy-issues-dollar-pricing-decision/en)
- In May 2024, the lira was described as stable at 89,500/USD since the end of March 2023, and most shops, restaurants and service providers ask for payment in USD. — [The National, May 2024](https://thenationalnews.com/news/mena/2024/05/29/lebanon-dollar-price-cost-of-living)
- Merchants tend to give change in lira at a rate they set themselves. Shoppers carry $10 and $20 bills, and the lira serves as small change for the dollar. — [Middle East Eye](https://www.middleeasteye.net/news/lebanon-dollar-replaced-disappearing-lira-how); [L'Orient Today: Should you pay in dollars or lira?](https://today.lorientlejour.com/article/1334524/should-you-pay-in-dollars-or-in-lebanese-lira.html)
- Shopkeepers made change with a mix of dollars and pounds (2019 crisis era, older). — [Star Tribune](https://www.startribune.com/in-lebanon-residents-line-up-for-u-s-dollars-at-banks-but-find-few/562466582)
- Some sellers prefer LBP because the rate spread is profitable on larger amounts. — [Middle East Eye](https://www.middleeasteye.net/news/lebanon-dollar-replaced-disappearing-lira-how)

### Inferences
- Must-have features:
  - Configurable store rate, shown on screen and on receipts (a ministry requirement).
  - Base-currency choice (USD) with LBP shown alongside.
  - Split tender: USD cash + LBP cash + card.
  - Change suggested as whole USD plus the LBP remainder, rounded to a practical note size such as LBP 5,000/10,000. That note size is my assumption; I found no source for it.
  - Separate USD and LBP cash drawers in end-of-day counts.
  - Separate buy/sell rates if the merchant uses a spread.
- Cashing up must reconcile two currencies per shift.

### Gaps
- I found no 2025–2026 source on rounding conventions for LBP, or on which LBP note sizes are in practical use.
- I did not confirm that the rate is still 89,500 as of Nov 2026.

## Electricity and internet

### Takeaway
State power from EDL is a few hours a day (about 4–6 typically, 8–10 at best). Businesses depend on costly private generators, and outages and switchovers are routine. Internet goes down too, often when Ogero's network or its backup diesel fails, and that takes Alfa and Touch mobile data with it. Offline-first POS with local storage and low-power, battery-backed hardware (Android tablets and terminals) is essential.

### Cited Findings
- EDL's typical average supply is about 4–6 hours a day (late 2025). — [L'Orient Today: fuel delivery delay](https://today.lorientlejour.com/article/1488062/following-a-fuel-delivery-delay-edl-to-reduce-its-output.html)
- The energy minister said current capacity can provide 8–10 hours a day at best, while demand is nearly three times higher (late 2025). — [Energy & Water Ministry](https://energyandwater.gov.lb/ar/details/101089/minister-joe-saddi-s-power-sector-reset-energy-minister-joe-saddi-lays-out-a-hard-line-reform-roadmap-to-rescue-lebanon-s-electricity-sector-from-debt-decay-and-dysfunction-1768810589)
- In November 2026, the state sector could still generate only a few hours a day, and power to public institutions was cut over unpaid bills. — [The National, Nov 2026](https://thenationalnews.com/news/mena/2026/11/03/lebanon-cuts-electricity-to-public-institutions-over-unpaid-bills)
- Generator bills reach about $300 a month. In one Beirut area, a 25-amp subscription cost as much as $750 in August 2026. Generator tariffs are metered per kWh and set monthly by the ministry, and they swing with fuel prices (for example, a 63% jump in two months during the Iran war). — [The National, Oct 2026](https://www.thenationalnews.com/news/mena/2026/10/14/wake-up-and-smell-the-diesel-multibillion-dollar-generators-industry-fuelling-lebanons-corruption/); [L'Orient Today: generator rates jumped 63%](https://today.lorientlejour.com/article/1505310/generator-rates-in-lebanon-have-jumped-63-in-two-months.html); [L'Orient Today: tariffs drop ~10%](https://today.lorientlejour.com/article/1539683/generator-tariffs-drop-by-nearly-10-in-lebanon.html)
- Until 2021, EDL supplied 12–21 hours a day (historic baseline). — [HRW 2023](https://www.hrw.org/report/2023/03/09/cut-life-itself/lebanons-failure-right-electricity)
- Alfa's data services stopped because of Ogero network outages (for example, April 2025). — [NNA, Apr 2025](https://nna-leb.gov.lb/en/economy/561763/alfa-internet-service-has-stopped-due-to-ogero-tel); [Alfa press release](https://alfa.com.lb/en/media-center/press-releases/alfa-data-services-stoppage-due-to-ogero-outages-)
- Root causes of outages include unstable power, the cost of diesel for Ogero's backup generators, and staff strikes. — [SMEX](https://smex.org/ogero-enacts-increases-in-fixed-internet-subscription-rates-in-lebanon-exploring-sustainable-solutions/); [LBC: Ogero employees announce outages/strike](https://www.lbcgroup.tv/news/lebanon-news/762557/ogero-employees-announce-continued-service-outages-and-potential-strik/en); [Internet Society Pulse: cost of outages](https://pulse.internetsociety.org/blog/counting-the-cost-of-internet-outages-in-lebanon)
- Telecom tariffs were re-priced at the Sayrafa rate in 2022, which roughly quadrupled mobile data prices (about $3/GB). Starlink is noted as an emerging option. (A secondary blog, July 2025.) — [ts2.tech](https://ts2.tech/en/state-of-internet-access-in-lebanon-from-fiber-optics-to-starlink-skies/)
- War-related outages in South Lebanon. — [SMEX: South Lebanon](https://smex.org/south-lebanon-we-are-at-risk-of-being-disconnected-from-the-world/)

### Inferences
- The POS must keep selling, printing and closing shifts with no internet, then sync later without conflicts. Card and QR payments will fail during outages, so cash fallback and "pay later / mark as pending" flows matter.
- Hardware with batteries (tablets, handheld Android terminals) rides through generator switchovers. A desktop PC without a UPS will reboot. Low power draw also matters because generator kWh is expensive.
- Data costs per GB favour lean sync traffic: deltas, compressed payloads, no heavy media.

### Gaps
- I found no current official Alfa/Touch business data rate card, and no Ogero outage frequency statistics for 2025–2026.
- I found no survey of the share of businesses with UPS or solar.

## Customer credit (dayn / deftar)

### Takeaway
Credit from neighbourhood grocers is widely reported as a lifeline since the 2019 crisis, and shopkeepers extend more and more of it. I found no source describing how these tabs are tracked; the paper notebook ("daftar") is anecdotal. A customer-account and tab feature (in both USD and LBP, with WhatsApp reminders) looks like a real differentiator, but it needs field validation.

### Cited Findings
- A Tripoli resident relies on credit from the local grocer to feed his family. A shopkeeper struggles to keep her store open as she extends more and more credit (2021). — [Asharq Al-Awsat / Reuters](https://english.aawsat.com/home/article/2368861/falling-cliff-lebanons-poor-borrow-buy-bread)
- Three-quarters of Lebanon's 6 million people fell into poverty after 2019 (AP, 2023). — [PBS / AP](https://www.pbs.org/newshour/world/lebanon-leans-on-u-s-dollar-as-economy-tanks)

### Inferences
- Credit tabs must record the currency they were denominated in, because a tab opened in LBP loses value if the rate moves. USD-denominated tabs are probably the default today.
- Credit customers are a known group of regulars, so customer lookup by phone number fits.

### Gaps
- I found no 2023–2026 data on how widespread shop credit is, and no source on whether it is tracked in a notebook, an app or Excel. A search in Arabic ("دفتر الدين", "دين الدكانة") or interviews are needed.

## Languages

### Takeaway
Lebanon is trilingual: Arabic, English and French. Shop signs mix all three. Arabizi (Arabic in Latin letters) is common in informal digital text among young people. A POS should support Arabic (RTL) and English UI with French as an option, product names in two languages, and receipts in either script.

### Cited Findings
- An AUB master's thesis (2023) studies English, French and Arabic on private shop signs in Ras Beirut, Ashrafieh and Ghazieh. — [AUB ScholarWorks](https://scholarworks.aub.edu.lb/items/6caca12d-5613-4283-9fda-d729d6a8fab4)
- A study from Université Saint-Joseph (2017, older) analyses the language functions of store signs in Greater Beirut. — [Érudit](https://www.erudit.org/fr/livres/serie-monographique-en-sciences-humaines/les-langues-et-leurs-territoires-entre-conflit-et-cohabitation/5411co.pdf)
- Arabizi is used especially by young people on social media and SMS. A 2012 study found it more common than Arabic script for writing Levantine on Facebook in Lebanon (older). — [Wikipedia: Languages of Lebanon](https://en.wikipedia.org/wiki/Languages_of_Lebanon)
- A 2026 arXiv survey across dialects, including Lebanon, finds mixed attitudes and a trend toward less Arabizi use. — [arXiv 2608.02555](https://arxiv.org/pdf/2608.02555)
- L'Orient Today covers Lebanon's trilingual shift, with English gaining against French. — [L'Orient Today](https://today.lorientlejour.com/article/1414580/lebanons-tri-lingual-evolution-in-arabic-french-english.html)

### Inferences
- Item search should match Latin and Arabic spellings, and ideally Arabizi spellings (for example "shawarma", "chawarma", "شاورما").
- Arabic receipts need printers that can render Arabic. Many cheap ESC/POS printers need bitmap rendering for Arabic, so the POS should render Arabic text as an image before printing.

### Gaps
- I found no study of which language staff prefer for POS screens, or of the language mix on menus and receipts.

## Hardware realities

### Takeaway
Cheap thermal printers (Xprinter at about $18 and up, Epson TM-T20III at about $216) are sold locally with delivery across Lebanon. Sunmi is distributed in the region by Partner Tech, but I found no Lebanese Sunmi price. Android-first, standard ESC/POS hardware that can be bought locally is the safe target.

### Cited Findings
- Epson TM-T20III Ethernet receipt printer, $216, delivered across Lebanon. — [961Souq](https://www.961souq.com/products/epson-tm-t20iii-012a0-ethernet-pos-thermal-receipt-printer); 961Souq also lists an iMachine AP02 mobile POS terminal — [961Souq](https://www.961souq.com/products/imachine-ap02-mobile-pos-terminal-black) and an Xprinter XP-365B label printer — [961Souq](https://www.961souq.com/products/xprinter-xp-365b-thermal-barcode-label-printer)
- Xprinter XP-P501A 58mm Bluetooth/USB portable printer, $18, at Ayoub Computers (Lebanon). — [Ayoub Computers](https://ayoubcomputers.com/xprinter-xp-p501a-58mm-mobile-thermal-receipt-printer-usb-bluetooth-70mm-s/)
- A used/unbranded thermal printer listed on OLX in Beirut for $150. — [OLX Lebanon](https://olx.com.lb/ar/ad/thermal-printer-ID117177355.html)
- Partner Tech is an authorized Sunmi distributor in the Middle East (T2s desktop POS with an 80mm printer). — [Partner Tech](https://www.partnertechcorp.com/me/authorized-distributor/sunmi). Saudi reference prices: Sunmi D3 Pro SAR 1,459 incl. VAT, Sunmi 80mm kitchen printer SAR 747.5 (not Lebanon). — [Qoyod](https://www.qoyod.com/en/knowledge-base/pos-device-images-and-specifications/)
- MediaTech LB in Downtown Beirut sells POS printers. — [MediaTech LB](https://mediatechlb.com/?p=36450)

### Inferences
- Supporting generic Bluetooth, USB and LAN ESC/POS printers (58mm and 80mm) covers most of the local market. Built-in printers on Sunmi-type terminals are a plus.
- Prices are quoted in USD, and hardware is mostly imported through small resellers. A BYO-device (bring your own Android phone or tablet) model lowers adoption cost.

### Gaps
- I found no Lebanese prices for Sunmi, scales or barcode scanners, and no data on import duties or customs constraints.

## Delivery and ordering platforms

### Takeaway
Toters, founded in Beirut, is the dominant delivery app, with more than 2,000 partner stores. Talabat reportedly returned in 2024, but that claim comes from a weak source. Zomato's exit is not confirmed by anything I found. Order aggregation (manual entry or an integration) and WhatsApp ordering are relevant to restaurants.

### Cited Findings
- Toters is Beirut-based, works with more than 2,000 partner stores, operates in 10 cities across Lebanon and Iraq, and has raised $8.4m. — [Forbes Middle East](https://www.forbesmiddleeast.com/lists/the-middle-easts-50-most-funded-startups/toters/)
- Sensor Tower publishes top food-delivery app rankings for Lebanon (Q2 2023, Q4 2024). — [Sensor Tower Q4 2024](https://sensortower.com/blog/2024-q4-unified-top-5-food%20delivery%20services-units-lb-63da96fbe1714cfff1c1e5a1); [Sensor Tower Q2 2023](https://sensortower.com/blog/2023-q2-ios-top-5-food%20delivery%20services-units-lb-63da96fbe1714cfff1c1e5a1)
- Statista projects Lebanon restaurant-delivery revenue of about $30.7m in 2025. — [Statista](https://statista.com/outlook/dmo/online-food-delivery/meal-delivery/restaurant-delivery/lebanon)
- Unverified: Talabat returned to Lebanon in 2024. Commissions are 18–35% (Toters and Talabat at about 22–30%). — [voxire blog (anonymous, low reliability)](https://voxire.pages.dev/blog/delivery-apps-lebanese-stores-2026/)
- An Everand item titled "Toters–Zomato" suggests past competition between the two (not opened). — [Everand](https://www.everand.com/article/562442606/Toters-Zomato)

### Inferences
- High commissions push restaurants toward direct ordering (WhatsApp or their own link). A POS with a WhatsApp order intake, a menu link and a delivery-driver cash-collection flow fits the market. A Toters integration is the most valuable third-party connector if an API is available.

### Gaps
- I did not confirm whether Toters or Talabat offer POS integration APIs, Talabat's current status, or Zomato's exit date.
- I found no source quantifying WhatsApp ordering prevalence (likely widespread anecdotally).
