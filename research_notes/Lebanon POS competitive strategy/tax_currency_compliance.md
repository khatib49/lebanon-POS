# Lebanese Tax, Invoicing and Currency Compliance for POS Systems (as of late 2026)

> Method note: This session could not fetch pages. Direct fetches of taxsummaries.pwc.com, vatupdate.com and today.lorientlejour.com failed because those hosts are not allowed on the session network. All findings below come from search-result extracts (titles, snippets and the search tool's summaries of them). Treat exact numbers as "verify against primary text before shipping." No Official Gazette or MoF decision text was read in full. Secondary vendor guides (Staks, productivelevant, dddinvoices, openaccountants, balancebrightness, trykintsugi) are low-authority and some may be machine-generated. They are flagged where used.

## 1. VAT: rate, proposed changes, exemptions, threshold, who must invoice

### Takeaway
The standard VAT rate is still **11%**, with 0% for exports and international transport. In February 2026 the Cabinet approved a rise to **12%**. It needs a law from Parliament, and as of the latest sources (IMF, September 2026) it had **not been enacted**. Basic foodstuffs (bread, flour, meat, fish, milk, rice, sugar, oil, pasta, baby food) and raw agricultural produce are exempt under Art. 17 of the VAT Law. Mandatory registration reportedly starts at **LBP 5 billion** turnover (2024 Budget Law), and importers and exporters must register whatever their turnover. The POS must support configurable rates per item, including 11%, 0% and exempt, and a future 12%.

### Cited Findings
- Standard VAT rate is 11%. PwC Worldwide Tax Summaries for Lebanon (reviewed January 2026) still lists 11% — [PwC Other taxes](https://taxsummaries.pwc.com/Lebanon/Corporate/Other-taxes); Moore Global lists 11% standard and 0% reduced — [Moore Global](https://www.moore-global.com/services/tax/international-corporate-tax/lebanon/)
- February 2026: the Cabinet approved raising VAT from 11% to 12%, alongside higher petrol prices, to fund public-sector pay rises. The package targets about $200M a year in revenue. Finance Minister Yassine Jaber said the increase needs legislation — [The National, 17 Feb 2026](https://www.thenationalnews.com/news/mena/2026/02/17/anger-in-lebanon-as-government-raises-vat-and-petrol-prices/); [Lexis Middle East, 17 Feb 2026](https://www.lexismiddleeast.com/news/2026-02-17_23/en); [Beirut.com](https://www.beirut.com/en/770834/12-vat-new-fuel-taxes-what-the-lebanese-govt-just-approved/)
- An IMF statement from September 2026 says the Cabinet-approved VAT rise had yet to be implemented and urges Parliament to enact it — [ANND summary of IMF mission, Sept 2026](https://annd.org/en/publications/details/imf-lebanon-september-2026-reform-recovery1); a vendor guide says it was not enacted as of July 2026 and that 11% remains the rate to charge — [Staks](https://www.staksai.com/blog/accounting-software-lebanon)
- CONFLICT / SUSPECT: an August 2026 VATupdate headline says "Mikati Rules Out VAT Increase" and refers to a 10%→12% proposal rejected in January. This does not fit the facts. Nawaf Salam's cabinet is in office in 2026, and the rate is 11%, not 10%. The item is probably misdated or recycled from an older article. Disregard it unless verified — [VATupdate](https://www.vatupdate.com/2026/08/14/mikati-rules-out-vat-increase-ahead-of-tax-reform-talks/); [Wikipedia: Cabinet of Nawaf Salam](https://en.wikipedia.org/wiki/Cabinet_of_Nawaf_Salam)
- 2026 draft and enacted Budget measures reported for VAT: limits on input-VAT deduction (e.g. passenger cars over $25,000, except rental and taxi businesses). PwC reports that VAT on customs duties is non-deductible under the 2026 Budget Law. The draft also includes "expanded digital enforcement measures" — [VATupdate on 2026 draft budget](https://www.vatupdate.com/2025/09/23/lebanons-2026-budget-proposal-vat-deduction-limits-and-expanded-digital-enforcement-measures/); [PwC](https://taxsummaries.pwc.com/lebanon/corporate/other-taxes)
- Exempt goods (VAT Law No. 379 of 14 Dec 2001, Art. 17). Item (a): livestock, poultry, live fish and raw agricultural products. Item (b): bread, flour, meat and fish, milk and yogurt, rice, borghol, sugar, cooking salt, vegetable oil, macaroni and pasta, baby food. Exempt activities are in Art. 16 — [English translation of VAT Law 2001](https://eduart0.tripod.com/sitebuildercontent/sitebuilderfiles/vatlaw_e02.pdf); [Lex Mundi guide](https://www.lexmundi.com/CountryGuides/PDF/Guide_Lebanon.pdf)
- Medicines: the 2001 draft listed "books, magazines, newspapers, medicines and drugs, and butane for household consumption" as exempt in item (c). I could not confirm the enacted wording from the extracts. The 2020 Budget Law exempted imports of raw materials used to make medicines — [VAT draft law May 2001](https://taxesinlebanon.tripod.com/VAT/VATEnglish/vatdl_e.pdf); [ALDIC 2020 Budget summary](https://www.aldic.net/summary-of-the-budget-law-2020/)
- Exempt services (secondary, unverified list): financial and banking, insurance, medical, education, residential rent, public transport, unprocessed agricultural goods and books. 0% applies to exports and international transport — [balancebrightness](https://balancebrightness.com/blog/vat-in-lebanon)
- Registration threshold: LBP 5 billion of taxable turnover over 1–4 consecutive quarters, set by the 2024 Budget Law (about USD 55,900 at 89,500). Importers and exporters must register regardless of turnover — [Staks](https://www.staksai.com/blog/accounting-software-lebanon); [productivelevant](https://productivelevant.com/en/lebanon-vat-number-registration/)
- SUPERSEDED thresholds still quoted in older guides: LBP 500 million mandatory and LBP 100 million optional — [Moore Global](https://www.moore-global.com/services/tax/international-corporate-tax/lebanon/). An even older figure of 10% VAT appears on the Beirut Traders page, also superseded — [Beirut Traders Association](https://www.beiruttraders.org/index.php/doing-business-in-lebanon/taxation/value-added-tax-vat)
- 2024 Budget Law (Law 324/2024) was ratified 12 Feb 2024 and published in Official Gazette No. 7 on 15 Feb 2024 — [Institut des Finances, Citizen Budget 2024](https://www.institutdesfinances.gov.lb/sites/default/files/2024-10/Citizen%20Budget%202024-ENG_1.pdf)
- 2025 Budget was issued by Decree No. 56 (11 Mar 2025), approved as submitted rather than voted by Parliament — [PwC Doing Business in Lebanon 2025](https://www.pwc.com/m1/en/tax/documents/doing-business-guides/dbilb.pdf)
- 2025 Budget stamp duty: receipts issued in USD carry USD 2 stamp duty and receipts in EUR carry EUR 2. PwC's wording suggests this applies to government receipts. The draft version was LBP 100,000 per state receipt — [PwC Other taxes](https://taxsummaries.pwc.com/lebanon/corporate/other-taxes); [Credit Libanais](https://economics.creditlibanais.com/Article/212296)

### Inferences
- The rate engine should take an effective-dated VAT rate table, so a switch from 11% to 12% is a config change on the effective date set by the law. Do not hard-code 11%.
- Items need a tax category of standard, zero-rated or exempt. Supermarket POS needs Art. 17 staples mapped to exempt by default, with an option to override.
- A turnover-threshold indicator (LBP 5bn, rolling 4 quarters) is a useful feature for small merchants who are not yet registered. Non-registered merchants should not show VAT on receipts.
- Whether the USD 2 stamp applies to private-sector commercial receipts is unclear. Do not build stamp-duty logic until that is confirmed.

### Gaps
- No official MoF/Gazette text read to confirm the LBP 5bn threshold, the enacted Art. 17 medicines item, or the 2026 Budget VAT changes.
- Status of the 12% bill in Parliament after September 2026 is unknown.

## 2. What a valid Lebanese tax invoice must contain (including currency and exchange rate)

### Takeaway
Art. 38 of VAT Law 379/2001 requires a tax invoice to show the supplier's name, address and MoF registration (VAT) number, the customer's name and address, a serial number and date, a description of goods or services, the amount, the VAT rate and the VAT amount. The MoF has said that invoices to end consumers must be issued in Lebanese pounds including VAT. For goods or services priced in foreign currency, VAT is converted at rates set by joint MoF/BDL decision. Since BDL unified the official, Sayrafa and market rates at **LBP 89,500/USD** in early 2024, that is the rate in practice. The POS must print an invoice that shows VAT in LBP at 89,500, even when the sale is priced in USD.

### Cited Findings
- Art. 38 requires the taxable person to issue an invoice, or a document serving as one, that states at least the following: name and address of the person invoiced, description of goods or services, serial number and date of the invoice, the amount due, and the tax charged with the rate applied. It also requires the supplier's name, address and MoF registration number — [VAT Law 2001 (English)](https://eduart0.tripod.com/sitebuildercontent/sitebuilderfiles/vatlaw_e02.pdf); [VAT draft law 2001](https://taxesinlebanon.tripod.com/VAT/VATEnglish/vatdl_e.pdf); [dddinvoices](https://dddinvoices.com/learn/e-invoicing-in-lebanon)
- Art. 37 governs retention of records, invoices and accounting documents — [dddinvoices](https://dddinvoices.com/learn/e-invoicing-in-lebanon)
- MoF enforcement (2015): VAT deductions and refund claims are refused without an invoice containing the Art. 38 details — [BusinessNews.com.lb](https://www.businessnews.com.lb/cms/Story/StoryDetails/4460/The-Ministry-of-Finance-gets-tough-on-VAT)
- MoF said that invoices to end consumers must be issued in lira, including VAT, and handed to customers ("End Consumers To Be Invoiced In Lira") — [Everand / Lebanon Opportunities article](https://www.everand.com/article/536761741/End-Consumers-To-Be-Invoiced-In-Lira)
- Decree 11230 (2023) replaced Art. 18 of the VAT Law, which had required VAT to be calculated at the official exchange rate. For goods and services priced in foreign currency, and until a unified rate is set, conversion uses rates set by joint decision of the Finance Minister and the BDL Governor — [PwC](https://taxsummaries.pwc.com/lebanon/corporate/other-taxes); [L'Orient Today](https://today.lorientlejour.com/article/1335987/vat-will-now-be-calculated-at-three-different-rates-close-to-the-market.html)
- SUPERSEDED (2023) three-rate regime: imports used the customs dollar, B2B invoices used the Sayrafa rate and B2C invoices used the parallel-market rate — [L'Orient Today](https://today.lorientlejour.com/article/1335987/vat-will-now-be-calculated-at-three-different-rates-close-to-the-market.html); [RDCL](https://rdcl.org.lb/experts-sceptical-about-lebanons-attempt-to-adjust-vat-and-customs-amid-currency-collapse/)
- Sayrafa was fixed at LBP 89,500 on 19 Dec 2023, up from 85,500 — [This is Beirut](https://thisisbeirut.com.lb/articles/1209723/sayrafa-rate-fixed-at-lbp-89500-whats-changing); [Wikipedia: Lebanese pound](https://en.wikipedia.org/wiki/Lebanese_pound)
- A vendor guide says amounts are converted at 89,500 for VAT purposes — [productivelevant](https://productivelevant.com/en/lebanon-vat-number-registration/)
- Arabic language: no source in the extracts states an explicit Arabic-only requirement for invoices. Practitioner advice is to confirm required fields against current MoF texts — [balancebrightness](https://balancebrightness.com/blog/vat-in-lebanon)

### Inferences
- Receipt or invoice template fields: seller legal name, address, MoF/VAT number, sequential and gap-free serial number, date and time, customer name and address (needed for B2B; optional for walk-in B2C), line descriptions, quantity, unit price, net amount, VAT rate per line, VAT amount, gross total. For USD-priced sales, also print the exchange rate used (89,500) and the LBP equivalents of the totals and VAT.
- Store the exchange rate on every transaction (rate value, source and timestamp) so that the LBP VAT can be reproduced for audits even if the rate changes later.
- Bilingual Arabic/English templates are a safe default. Arabic is the official language and the norm on MoF forms, but no mandate was found.

### Gaps
- The exact current MoF decision fixing the VAT conversion rate after unification (decision number and date) was not found.
- No confirmation of an Arabic-language mandate, or whether simplified receipts are allowed for small B2C sales.
- Date of the "End consumers invoiced in lira" MoF statement is unclear (likely 2021–2023). It may conflict with later dollar-pricing practice; verify.

## 3. E-invoicing, fiscal printers, electronic reporting, and restaurant/tourism charges

### Takeaway
As of late 2026 there is **no e-invoicing mandate, no fiscal-printer requirement and no real-time POS reporting** in Lebanon. The MoF has announced plans for electronic invoicing and an invoice-linked lottery (with the National Lottery), tied to the 2027 budget push. A World Bank-funded Fiscal Management Project (P181155) is upgrading MoF IT. I found no confirmed restaurant-specific municipal or tourism levy on bills. Service-charge lines are common on bills, but I found no legal basis for them in the sources.

### Cited Findings
- "Lebanon has no e-invoicing mandate, platform or start date". There is no cash-register or real-time receipt-reporting duty, and invoices follow the 2001 VAT law — [dddinvoices (Nov 2026)](https://dddinvoices.com/learn/e-invoicing-in-lebanon)
- The MoF's 2027 budget agenda includes introducing electronic invoicing and incentives, including a lottery linked to invoices, to push consumers and businesses to request official receipts — [The Beiruter](https://www.thebeiruter.com/articledetails/2571)
- Preparations are under way for a "lottery invoice" initiative with the National Lottery (reported about September 2026) — [Daily Beirut](https://dailybeirut.com/en/lebanon-news/technical-meetings-continue-between-ministry-of-finance-and-imf/)
- The Finance Minister is working on electronic invoicing and cross-checking of tax data (described as ongoing) — [Libnanews](https://en.libnanews.com/taxation-in-lebanon-collecting-without-curbing-activity)
- World Bank Fiscal Management Project P181155 (about $41.2M) funds MoF ICT and software upgrades and data consolidation — [World Bank doc, Jun 2026](https://documents1.worldbank.org/curated/en/099061026153065058/pdf/P181155-bf95a328-e262-4162-b3c6-55ee0d406f3c.pdf); [MoF procurement notice, Feb 2025](https://finance.gov.lb/en-us/Our_Latest/Latest%20News/English/SPD-RFP-Single%20stage%20Information%20Systems%20-%20Feb%2010%202025.pdf)
- MoF now accepts electronic and card tax payments — [This is Beirut](https://thisisbeirut.com.lb/articles/1213459/finance-it-is-now-possible-to-make-electronic-payments); [LBCI](https://www.lbcgroup.tv/news/economy/878399/say-goodbye-to-cash-lebanon-to-allow-card-payments-for-taxes-and-fees/en)
- 2026 draft budget includes "expanded digital enforcement measures" (details not retrieved) — [VATupdate](https://www.vatupdate.com/2025/09/23/lebanons-2026-budget-proposal-vat-deduction-limits-and-expanded-digital-enforcement-measures/)
- Restaurant bills in Beirut commonly carry a service line plus VAT. This comes from a travel guide, not a legal source — [onmetravel](https://onmetravel.com/tipping-etiquette-in-lebanon)
- Ministry of Tourism circular (June 2022, Minister Walid Nassar): tourist establishments, including restaurants, could optionally and exceptionally price in USD from 2 June to end of September 2022. The final invoice had to be issued in LBP and USD, and prices had to stay "competitive" — [MTV Lebanon](https://www.mtv.com.lb/en/News/Local/1287434/ministry-of-tourism-authorizes-tourist-establishments-to-display-prices-in-usd); [L'Orient Today](https://today.lorientlejour.com/article/1301521/tourism-establishments-allowed-to-price-their-bills-in-us-dollars-for-summer-season.html); [LBCI](https://www.lbcgroup.tv/news/lebanon-news/649066/ministry-of-tourism-establishments-allowed-to-set/en)
- By January 2023 restaurants had broadly dollarized menus, citing that circular — [The National, Jan 2023](https://www.thenationalnews.com/mena/lebanon/2023/01/24/lebanons-restaurants-charge-in-scarce-dollars-as-pound-sinks-to-new-low/); [L'Orient Today](https://today.lorientlejour.com/article/1325107/with-the-crisis-here-to-stay-lebanons-restaurants-dollarize-menus.html)

### Inferences
- Build the POS "e-invoicing-ready" but do not block launch on it: keep an immutable invoice log, unique IDs, and export (JSON/XML/CSV), plus an optional QR code on the receipt. That positions the product for a future MoF mandate or lottery scheme, which would likely require scannable invoice IDs.
- Restaurant module: a configurable service-charge line (percentage or fixed, taxable or not) and dual-currency final bill (USD + LBP), following the 2022 tourism circular practice.

### Gaps
- No source confirms or denies a municipal or tourism tax on restaurant bills. The VAT treatment of service charges was not established.
- The text of the 2026 Budget's digital enforcement measures was not retrieved.
- Whether the tourism USD-pricing circular was renewed or made permanent after 2022 was not found.

## 4. Currency rules after the 2019 crisis

### Takeaway
The official rate moved from the 1,507.5 peg to LBP 15,000 (2023). In early 2024 BDL unified it at **LBP 89,500/USD**, which in practice is both the official and the market rate through 2026. In March 2023 the Ministry of Economy allowed shops and supermarkets, "exceptionally and temporarily", to price in USD. Conditions: clear USD shelf prices, a **posted daily exchange rate**, and the customer's right to **pay in LBP or USD at the till** at a rate no higher than the market rate. Produce and tobacco were excluded. I found no 2024–2026 decision that changes those conditions. The POS must support dual-currency pricing, split and mixed-currency tender, change in either currency, and a posted, timestamped store rate.

### Cited Findings
- March 2023 MoET decision (caretaker minister Amin Salam): shops and supermarkets may price in USD "exceptionally and temporarily". Prices must be clear to consumers. The exchange rate at payment must not exceed the market rate at the time of purchase. "The consumer's option to pay in Lebanese lira or US dollars must be preserved on the cash register" — [LBCI](https://www.lbcgroup.tv/news/economy/690020/minister-of-economy-issues-dollar-pricing-decision/en)
- Supermarket USD pricing started 1 March 2023, at the parallel (market) rate. Supermarkets must announce the daily exchange rate. Vegetables, fruits and tobacco were excluded. Imported and dollar-invoiced goods were priced in USD, and locally produced goods stayed in LBP — [The National, 1 Mar 2023](https://www.thenationalnews.com/mena/lebanon/2023/03/01/dollars-or-pounds-lebanons-supermarkets-begin-pricing-goods-in-dollars); [L'Orient Today](https://today.lorientlejour.com/article/1329814/lebanons-supermarkets-to-price-their-items-in-dollars-starting-wednesday.html); [NNA](https://www.nna-leb.gov.lb/en/economy/595207/salam-supermarkets-will-be-allowed-to-price-goods)
- The ministry still called the market rate "unofficial". March 2023 raids found many supermarkets not displaying the USD rate "as required by law", and tougher penalties were proposed — [Al-Monitor](https://www.al-monitor.com/originals/2023/03/lebanese-supermarkets-mark-prices-dollars-local-currency-tanks); [LBCI crackdown](https://www.lbcgroup.tv/news/news-bulletin-reports/692961/ministry-of-economy-cracks-down-on-price-gouging-b/en)
- BDL official rate raised to 89,500 from 15,000 to unify multiple rates, an IMF prerequisite. Reported date is 15 Feb 2024 — [Credit Libanais](https://economics.creditlibanais.com/Article/212041); another source says it applied from 31 Jan 2024 for BDL balance sheets — [aitimeline](https://aitimeline.in/lebanon-financial-collapse-currency-devaluation-timeline-16513/) (dates conflict slightly; the rate itself is consistent). The US Commercial Service gives 89,500 as the official rate as of March 2024 — [trade.gov](https://trade.gov/country-commercial-guides/lebanon-trade-financing); see also [L'Orient Today explainer](https://today.lorientlejour.com/article/1361826/bdl-exchange-rate-becomes-ll-89500-to-the-dollar-what-does-this-mean.html)
- In 2026, 89,500 serves as both the official and parallel rate — [Middle East Insider, Apr 2026](https://themiddleeastinsider.com/2026/04/28/lebanon-currency-collapse-april-2026-update/). A May 2026 Turkish trade-office report gives a market rate of about 89,700 — [ticaret.gov.tr](https://ticaret.gov.tr/data/5b8a43345c7495406a226d0d/L%C3%9CBNANIN%20SON%20EKONOM%C4%B0K%20G%C3%96R%C3%9CN%C3%9CM%C3%9C%20(May%C4%B1s%202026).pdf)
- The MoET still fixes some prices in LBP. For example, a medium bread bundle costs LBP 80,000, effective 17 Sep 2026 — [Libnanews](https://en.libnanews.com/the-price-of-bread-rises-to-80-000-pounds-in-lebanon/)
- The 2024 decision converts foreign-currency salaries at the highest official BDL rate (89,500) for payroll tax — [PwC](https://taxsummaries.pwc.com/lebanon/individual/other-taxes)

### Inferences
- Product requirements: a per-store or per-company exchange rate with a history (effective-from timestamp and the user who set it). A rate cap or alert if the set rate is above the reference rate (89,500), since the 2023 rule limits the till rate to no more than the market rate. An on-screen and printed "posted rate". Items priced in USD or LBP, with dual display. Mixed tender (USD cash + LBP cash + card), with change calculated in either currency.
- Price-regulated items (bread) must support LBP-native pricing.
- Because the 2023 decision was "temporary" and no later decision was found, keep the pricing currency configurable per item and per store.

### Gaps
- No 2024–2026 MoET decision was found that confirms, renews or replaces the 2023 dollar-pricing decision. Its current legal status and penalty amounts are unknown.
- The decision number of the March 2023 MoET decision was not retrieved.
- Exact date of the 1,507.5 → 15,000 official-rate change (reported as 1 Feb 2023 in general coverage) was not confirmed from retrieved sources.

## 5. Record keeping and accounting obligations

### Takeaway
Keep books and supporting documents (including invoices and POS records) for **10 years** (Code of Commerce Art. 19). Statutory books and tax reporting are in **LBP**, even when most transactions are in USD. Law 126/2019 allows digital record-keeping in a secure application, and reportedly makes it mandatory for VAT-registered traders two years after the law was promulgated.

### Cited Findings
- Code of Commerce (Legislative Decree 304 of 24 Dec 1942), Art. 19: books must be kept for 10 years after closure — [Code of Commerce PDF](http://data.infopro.com.lb/file/CodeofCommerce.pdf); the OECD peer review also says every company must keep records for 10 years — [OECD Global Forum, Lebanon 2019](https://www.oecd.org/content/dam/oecd/en/publications/reports/2019/07/global-forum-on-transparency-and-exchange-of-information-for-tax-purposes-lebanon-2019-second-round_0f2c4964/939f334e-en.pdf)
- Companies keep books and supporting documents for 10 years, and reporting is in LBP even when most invoices and salaries are in USD — [Azkatech](https://azka.tech/blog/lebanese-accounting/)
- Law 126/2019, amending the Code of Commerce, allows records to be kept physically or in a secure digital application. It makes the digital application mandatory for all traders with a VAT number two years after promulgation — [Lebanese Code of Commerce amendments guide 2019](https://www.slideshare.net/slideshow/lebanese-code-of-commerce-guide-to-amendments-2019-144133928/144133928)
- VAT Law Art. 37 requires retention of records, invoices and accounting documents — [dddinvoices](https://dddinvoices.com/learn/e-invoicing-in-lebanon)

### Inferences
- The POS must keep transaction data that cannot be altered (void and credit-note flows only, no deletes) for at least 10 years, with backup and export.
- Reports must give LBP totals (sales, VAT output by rate, exempt and zero-rated sales) at the stored transaction rate for the VAT return, alongside USD totals for management.

### Gaps
- No confirmation of whether the Law 126/2019 "digital application" requirement was implemented, or what technical standard it set.
- No source found on the VAT return filing frequency (generally quarterly in Lebanon) or whether returns or payments may be made in USD after the 2024 Budget.
