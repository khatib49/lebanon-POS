# Payments, gifting, top-ups, loyalty and recharge resale: feasibility for a POS startup in Lebanon (state as of Nov 2026)

> **Method caveat (read first).** This session's network blocked direct page fetches for every site tried (bdl.gov.lb, whish.money, melkilawfirm.com, regalert.today, legal500.com, kataeb.org, blominvestbank.com, leb.business, voxire.com, developers.facebook.com, libnanews.com, lorientlejour.com). **Every finding below comes from search-engine result summaries of the linked pages, not from reading the pages themselves.** Figures and legal characterisations must be re-checked against the primary text (especially BDL Decision 13790 / Basic Circular No. 1 to Electronic Payment Services Providers, and provider rate cards) before any go/no-go decision. Items marked **[UNVERIFIED]** come from vendor blogs, forums or single commentary pieces. Nothing here is legal advice.

## 1. Online card acceptance: gateways, fees, fresh-USD settlement, diaspora cards, Apple Pay / Google Pay

### Takeaway
Lebanese merchants can accept cards online only through local acquirers/gateways (Areeba, NetCommerce via partner banks, bank gateways, MontyPay, Whish Pay); no published rate card was found for any of them except Whish (1% websites / 2% Shopify / 3% payment link), and global PSPs (Stripe, PayPal; Tap for new merchants) do not onboard Lebanon-based merchants. Google Pay is live in Lebanon since June 2025; Apple Pay was not found to be available.

### Cited Findings
- Whish's official fee page (as summarised by search) lists Whish Pay for Shopify at 2%, Whish Pay for merchants/all other websites at 1%, "send payment link" at 3%, and wallet cash-out at 1%. — [Whish Fees & Commissions](https://whish.money/fees-commissions)
- A Lebanese business site states Whish Pay charges 1%–2% as a single published fee with no separate cash-out fee on top, while OMT quotes merchant pricing privately ("any specific OMT merchant rate ... should be treated as reported until OMT confirms it"). **[UNVERIFIED secondary]** — [leb.business](https://leb.business/en/article/whish-money-vs-omt-which-pays-better-for-lebanese-merchants)
- Areeba: aggregator lists pricing as "custom" and settlement at 1–2 business days (no confirmed source); a vendor comparison puts Areeba at roughly 2–3%, negotiable on volume, with settlement depending on the bank, and says onboarding is slower and more paperwork-heavy than Tap. **[UNVERIFIED]** — [paymentproviders.io Areeba](https://paymentproviders.io/providers/areeba); [Voxire](https://voxire.com/blog/payment-gateways-lebanon-ecommerce-2026/)
- Areeba is listed as offering an e-commerce gateway, pay-by-link, tokenisation and Google Pay enablement. — [bankstore.ai Areeba](https://bankstore.ai/banklist/areeba)
- Forum users say a card gateway generally requires a Lebanon-registered business entity (one estimate: USD 700–2,000 in legal/accounting set-up for an Areeba integration; old and anecdotal). **[UNVERIFIED]** — [Shopify Community](https://community.shopify.com/t/what-payment-methods-can-i-use-for-my-store-in-lebanon/292169)
- NetCommerce was founded in 1999 by Credit Libanais, Fransabank and Teleinvest; it supports cards in LBP and USD; access is reportedly via the partner bank. No fees found. **[UNVERIFIED forum]** — [Shopify Community](https://community.shopify.com/t/payment-gateways-for-lebanon/373716)
- MontyPay: described by a vendor-style blog as BDL-authorised, with Shopify app and WooCommerce plugin, settlement "often about 48 hours", no fee figures; a forum user reports poor reviews/customer service. **[UNVERIFIED]** — [webvue](https://webvue.com.lb/best-payment-gateway-in-lebanon-why-montypay-is-the-1-choice-for-lebanese-businesses/); [Shopify Community](https://community.shopify.com/t/what-payment-methods-can-i-use-for-my-store-in-lebanon/292169)
- Bank Audi e-payment gateway and Bank of Beirut e-commerce gateway are mentioned only as names, with no fees/settlement terms. — [Shopify Community](https://community.shopify.com/t/what-payment-methods-can-i-use-for-my-store-in-lebanon/292169); [steptomedia](https://steptomedia.com/payment-gateway-lebanon-websites-apps-2026/)
- Generic PSP guide benchmark for Lebanon: 2.5%–4.0% per card transaction, USD 5–20 per payout, USD 100–500 one-off set-up. **[UNVERIFIED, generic]** — [payatlas](https://payatlas.com/countries/lebanon-lb)
- Stripe and PayPal do not accept merchants in Lebanon (forum statement). — [Webflow forum](https://discourse.webflow.com/t/country-not-found-in-country-list-for-business-address/118410)
- Tap Payments: a Shopify thread lists it as usable in Lebanon; a 2026 vendor article says Tap stopped accepting new merchants from Egypt, Jordan and Lebanon as of 2025. Conflict. **[UNVERIFIED]** — [Shopify Community](https://community.shopify.com/t/payment-gateways-for-lebanon/373716); contradicted by [Dodo Payments](https://dodopayments.com/blogs/tap-payments-alternatives)
- PayTabs / 2Checkout: one forum reply says "not right now" for Lebanon; another thread describes PayTabs as serving Lebanon. Conflict. — [Webflow forum](https://discourse.webflow.com/t/country-not-found-in-country-list-for-business-address/118410); [Shopify Community](https://community.shopify.com/t/what-payment-methods-can-i-use-for-my-store-in-lebanon/292169)
- Google Pay launched in Lebanon with Visa on 24 June 2025; Bank Audi and Neo digital bank were first, with more banks to follow. — [Visa press release](https://km.visamiddleeast.com/en_KM/about-visa/newsroom/press-releases/prl-24062025.html)
- Apple Pay remained unsupported by Lebanese banks at the time of the Google Pay launch (mid-2025 reporting); Apple's participating-bank list for the Middle East, as surfaced in search, does not include Lebanon. — [Inside Telecom](https://insidetelecom.com/google-pay-goes-live-in-lebanon-while-apple-pay-leaves-users); [Apple Support](https://support.apple.com/HT206637)
- BDL Basic Decision 13810 (28 April 2026, Basic Circular 173) caps the merchant discount rate at 1.25% on locally issued cards (of which up to 0.9% interchange) for gas stations, hospitals, pharmacies, supermarkets and large bakeries, effective 15 June 2026. Restaurants/general retail are not in the listed sectors. — [L'Orient Today](https://today.lorientlejour.com/article/1505876/bdl-caps-commissions-on-certain-bank-payments-imposed-on-merchants.html); [Credit Libanais](https://economics.creditlibanais.com/Article/213241)
- BDL official (press conference): card transactions up 130% y/y in the first eight months of 2026, value up >50%; electronic payment share at restaurants reportedly rose from 15% to 35%, pharmacies 16%→23%, fuel stations 8%→12%. — [L'Orient Today](https://today.lorientlejour.com/article/1547050/card-payments-surge-130-in-lebanon-bdl-outlines-measures-to-curb-cash-economy.html); [Enmaeya](https://enmaeya.com/en/news/6aa25ed40e4b35adb974075e)
- Areeba (older statement, crisis era) attributed 15–30% surcharges some merchants applied to foreign cardholders to FX-liquidity and bank fees on dollar accounts rather than to its own commission. *Older; likely superseded by the 2026 surcharge prohibition.* — [Economy Middle East](https://economymiddleeast.com/news/areeba-we-do-not-have-a-monopoly-on-the-electronic-payment-sector-in-lebanon)

### Inferences
- "Pay at table by phone" is buildable now as a payment link / QR that opens a licensed gateway's hosted checkout (Areeba pay-by-link, Whish Pay, MontyPay) with funds settling to the merchant; the POS is a technical integrator only.
- Google Pay can probably be offered through a gateway that supports it (Areeba is listed); Apple Pay should be assumed unavailable for Lebanese-issued cards and unconfirmed for Lebanese merchants accepting foreign Apple Pay cards.
- Diaspora (foreign-issued) cards are technically acceptable via local acquirers (the Areeba statement about foreign cardholders implies acceptance), but pricing for international cards is not published and is likely higher than domestic; the 1.25% cap applies only to locally issued cards in named sectors.
- Because Stripe/PayPal (and probably Tap) are closed, there is no self-serve global PSP; every merchant needs its own local merchant agreement, or the POS vendor must work under a licensed Category E payment facilitator (see section 3).

### Gaps
- No official rate card for Areeba, NetCommerce, MontyPay, Bank Audi or BOB Finance; no source confirming "fresh USD" settlement mechanics, payout timing or reserve/rolling-hold terms for any gateway.
- Checkout.com, 2Checkout and PayTabs status for Lebanon-domiciled merchants is unconfirmed (conflicting forum posts only).
- Whether a Lebanese gateway can accept foreign-wallet Apple Pay tokens is unknown.
- Onboarding document lists (commercial register, MoF number, bank account type) were not found in a primary source.

## 2. Wallets and transfer companies: merchant products, QR, APIs, fees, users, inbound from abroad

### Takeaway
Whish and OMT Pay are the practical wallet rails for merchant QR/payment-link acceptance; Whish has a merchant collect API (docs circulated to merchants rather than published) and published fees, OMT prices privately. Whish and Suyool can receive money from abroad straight into a wallet, but BDL caps wallet balances (USD 3,000 individuals / USD 30,000 companies) and monthly movement.

### Cited Findings
- Whish wallet reportedly has more than 2 million users and a network of over 1,400 locations. **[UNVERIFIED secondary; no dated Whish source]** — [leb.business](https://leb.business/en/article/whish-money-vs-omt-which-pays-better-for-lebanese-merchants)
- Whish app supports paying merchants by QR scan from wallet balance; a merchant gateway lets merchants accept payment directly from a customer's Whish balance. — [waradana](https://waradana.com/english/article/272243-revolutionizing-payments-in-lebanon-a-comprehensive-look-at-whish-money-app); [linkmahal](https://linkmahal.com/whish-omt-payments-lebanon)
- A "Whish Collect Web Service Technical Specification" PDF (hosted by a third party) describes a REST API over HTTPS with live and testing base URLs and channel/secret/website-URL credentials issued by Whish. — [lebsol.com copy](https://lebsol.com/4del/Whish-Collect-Web-Service-Technical-Specification.pdf)
- An unofficial TypeScript SDK for "Whish Pay API (v2)" exposes payment creation, status, refund and callback verification; merchant credentials required. A community project notes there is no documented endpoint to push money out to a wallet (no payout API in public material). — [whishpay-sdk](https://github.com/omarzeineddine-ai/whishpay-sdk); [crowdship](https://github.com/malialloul/crowdship)
- OMT Pay is a dual-currency (LBP/USD) wallet with wallet-to-wallet transfers, payment links and QR payments at stores; wallet-to-wallet and cash-in at OMT locations are described as free. **[UNVERIFIED secondary]** — [leb.business](https://leb.business/en/article/whish-money-vs-omt-which-pays-better-for-lebanese-merchants); [shyphan](https://www.shyphan.com/blog/delivery-payments-app-lebanon-omt-whish.html)
- OMT told AFP (2022) it operates 1,200+ branches and handles ~80% of transfers outside the banking sector. *Older (2022).* — [Asharq Al-Awsat/AFP](https://english.aawsat.com/node/3853876)
- Whish announced a collaboration with Mastercard Move for cross-border payments to Lebanon (press release, August 2025). — [Mastercard newsroom](https://www.mastercard.com/news/eemea/en/newsroom/press-releases/en/2025-1/august/whish-money-collaborates-with-mastercard-move-to-bring-seamless-cross-border-payments-to-lebanon)
- Whish FAQ: international transfers can be collected in cash at a branch/agent or received directly in the Whish wallet. — [Whish FAQ](https://www.whish.money/faq)
- Suyool markets a Lebanese IBAN (partner: BSL Bank), card-to-wallet payment links and Visa Direct as inbound routes; bank transfers land in 1–3 business days, funds arrive in the Suyool wallet. (Provider marketing.) — [Suyool international transfers](https://suyool.com/international-transfers); [Suyool receive money](https://suyool.com/receive-money)
- Wallet caps: e-wallet balances capped at USD 3,000 for natural persons and USD 30,000 for commercial companies; monthly transfers capped at USD 10,000 (individuals) and USD 50,000 (companies), non-revolving within a month (per law-firm summary of Decision 13790; same ceilings appeared earlier in Intermediate Circular 735, which let BDL exceptionally approve a higher corporate ceiling on justified request). — [Melki Law Firm](https://melkilawfirm.com/article/lebanons-central-bank-issues-first-comprehensive-fintech-regulation/); [BLOMINVEST on Circular 735](https://blog.blominvestbank.com/bdl-issues-intermediate-circular-735-regarding-operations-of-e-wallets-providers/)
- PinPay is described as a mobile payments service backed by Bank Audi and BankMed and licensed by BDL. *Forum; status today unverified.* — [Shopify Community](https://community.shopify.com/t/payment-gateways-for-lebanon/373716)

### Inferences
- Wallet QR at the till / on the bill is buildable now with Whish (API exists) and likely OMT Pay (commercial negotiation needed).
- The USD 30,000 corporate wallet balance cap and USD 50,000 monthly movement cap make wallets unsuitable as the sole settlement account for busy merchants; merchants must sweep to bank/cash frequently, and a POS vendor should never pool merchant funds in its own wallet.
- Absence of a documented Whish payout API means automated refunds-to-wallet may work (refund endpoint) but arbitrary disbursements (e.g. paying out gift value to a third party) likely need a bespoke agreement.

### Gaps
- No user numbers, merchant fees or API information found for OMT Pay, BOB Finance, Zaky, WeePay, Purpl or PinPay; no confirmation that Zaky/WeePay/Purpl/PinPay are still operating in 2026.
- No official, public Whish developer portal found; the spec above is a third-party copy and may be outdated.
- BOB Finance e-commerce/collection API: nothing found.

## 3. Regulation: BDL e-money rules, licences, 2023–2026 circulars, FATF, and what a software company can do unlicensed

### Takeaway
Since 9 January 2026 Lebanon has a dedicated licensing regime (BDL Basic Decision 13790 / Basic Circular No. 1 to Electronic Payment Services Providers) with five categories, including Category A e-money and Category E payment facilitators/gateways; holding or moving customer funds, or collecting on behalf of merchants, is a licensed activity. No source was found that addresses closed-loop gift cards or store credit, so their status is legally unresolved and is the key question for counsel.

### Cited Findings
- Law 81/2018 (Electronic Transactions and Personal Data) defines electronic money as "electronic monetary units stored in electronic form" and gives BDL broad authority over issuing and regulating electronic and digital money. — [Law 81 text](https://tahseen.ae/media/3197/e-transaction-law-lebanon-official.pdf); [The Badil policy paper](https://thebadil.com/policy/policy-papers/catch-up-time-reforming-electronic-money-transfers-in-lebanon-2/)
- Basic Circular 69 (Decision 7548 of 30 March 2000, as amended): e-money service may be provided by financial institutions registered with BDL (not banks) with a prior BDL licence. *Older framework, repeatedly amended; now coexists with the 2026 regime.* — [BDL Basic Circular 69 (SIC copy)](https://sic.gov.lb/sites/default/files/laws-regulations/BDL%20Basic%20Circular%20No.%2069.pdf)
- In 2023 BDL amended Circular 69 and licensed several e-wallets meeting its requirements; the individual balance ceiling rose to USD 3,000 from USD 1,000. — [MTV Lebanon](https://mtv.com.lb/en/News/Local/1439700/lebanon-s-central-bank-acts-to-boost-electronic-payments--curb-cash-usage); [L'Orient Today (search summary)](https://today.lorientlejour.com/article/1339336/digital-wallets-a-new-way-to-bypass-banks-in-lebanon.html)
- Decision 13718 (23 May 2025), amending Decision 7548: licensing timelines, segregated fund management, transaction caps, IT-system and insurance requirements for operational/cyber risk, non-revolving fund-movement limits. — [regalert summary](https://regalert.today/document/dc7df5f6-6877-4920-8d35-5f5437e88774)
- Intermediate Circular 735: monthly transaction limits and balance ceilings for e-wallets (USD 3,000 / USD 30,000), with BDL able to exceptionally allow a higher corporate ceiling. — [BLOMINVEST](https://blog.blominvestbank.com/bdl-issues-intermediate-circular-735-regarding-operations-of-e-wallets-providers/); [Credit Libanais](https://economics.creditlibanais.com/Article/212709)
- Basic Decision 13790 (9 Jan 2026), "Basic Circular No. 1 to Electronic Payment Services Providers": first comprehensive framework; five categories — A (E-money), B (local money transfer), C (cross-border money transfer), D (money collection and payment), E (payment facilitators: e-technology services facilitating electronic payment, including payment-gateway services for collecting electronic payments and disbursing them to beneficiaries). It excludes banks, financial institutions and exchange institutions from its scope. — [BDL Decision 13790 (EN PDF)](https://www.bdl.gov.lb/CB%20Com/Laws%20And%20Regulations/Basic%20Circulars/Decision_13790_EN%C2%A711334_3.pdf); [Melki Law Firm](https://melkilawfirm.com/article/lebanons-central-bank-issues-first-comprehensive-fintech-regulation/)
- Capital: LBP 50 billion (not less than USD 558,660) for each of Categories A–D; LBP 25 billion for Category E, 15% of it frozen at BDL; requirements are cumulative across categories (Art. 4(2)). — [Melki Law Firm](https://melkilawfirm.com/article/lebanons-central-bank-issues-first-comprehensive-fintech-regulation/); a different figure (LBP 2 billion deposited at BDL) appears in [worldwatch.global](https://worldwatch.global/lebanon/fintech) — conflict, treat Melki/BDL text as more reliable
- Safeguarding for e-money: 90% of users' wallet funds in a special independent bank account in Lebanon, of which 50% moved to a non-interest-bearing BDL account; no lending or investing of those funds. Another summary line says a ratio of at least 100% of wallet balances must be held in bank accounts and/or cash. (Two statements, not reconciled.) — [Melki Law Firm](https://melkilawfirm.com/article/lebanons-central-bank-issues-first-comprehensive-fintech-regulation/)
- Decision 13790 prohibits collecting money for unregistered commercial companies, individuals or unlicensed associations, and bars retaining collected funds, under penalty of suspension of the service; a licence lapses after six consecutive months of inactivity. — [BDL Decision 13790 (EN PDF)](https://www.bdl.gov.lb/CB%20Com/Laws%20And%20Regulations/Basic%20Circulars/Decision_13790_EN%C2%A711334_3.pdf)
- A fragment of the Decision 13790 text says something relating to "categories A, B, C, and D, shall be suspended until further notice"; the surrounding sentence was not retrievable. **[CRITICAL TO VERIFY]** — it could mean new licence applications in those categories are frozen. — [BDL Decision 13790 (EN PDF)](https://www.bdl.gov.lb/CB%20Com/Laws%20And%20Regulations/Basic%20Circulars/Decision_13790_EN%C2%A711334_3.pdf)
- Intermediate Circular 750 (Decision 13791, 9 Jan 2026) amends Decision 7548 / Basic Circular 69 on the same date. — [BDL Intermediate Circular 750](https://bdl.gov.lb/intermediatecirc_detail.php?id=11335&langid=EN)
- FATF placed Lebanon on its grey list in October 2024; after the 28–30 October 2026 plenary Lebanon was still on the list (four other jurisdictions removed, 18 remain). — [ComplyAdvantage](https://complyadvantage.com/insights/fatf-plenary-october-2026-four-grey-list-exits-a-virtual-asset-review-and-a-new-focus-on-scam-compounds/); [financialcrime.lu](https://financialcrime.lu/2026/10/30/FATF-Outcomes-FATF-Plenary-28-30-October-2026/)
- BDL measures of 14 November 2025 (reported as "Circular No. 3" to non-bank institutions): money-transfer firms, exchange offices, e-wallet providers and other non-banks must collect KYC data for cash, FX and transfer transactions of USD 1,000 or more and send it encrypted to BDL within two business days; effective 1 December 2025; presented as the first of a series of steps to exit the grey list; a court appeal was filed against it. — [Arab News/AFP](https://www.arabnews.com/node/2622607/amp); [Al Arabiya](https://english.alarabiya.net/News/middle-east/2025/11/14/under-us-pressure-lebanon-tightens-rules-on-money-transfers-exchange-companies); [L'Orient Today (search summary)](https://today.lorientlejour.com/article/1494099/court-appeal-filed-against-bdl-circular-on-transactions-over-1000.html)
- Circular 69 reportedly formalises the sub-agent model with a "Know Your Agent" approach placing AML/CFT responsibility on the licensed firm. **[UNVERIFIED commentary]** — [Middle East Transparent](https://middleeasttransparent.com/banking-without-bankers-why-lebanon-must-end-the-sub-agent-experiment/)

### Inferences
- **Buildable without a licence (most defensible reading, to be confirmed by counsel):** software that only *initiates* payments through a licensed gateway/wallet with funds flowing directly from payer to the merchant's own merchant account, where the POS company never receives, holds or disburses funds. Category E's wording ("collecting electronic payments and disbursing them to beneficiaries") suggests that the moment the POS company sits in the flow of funds (aggregated merchant account, split payouts, marketplace-style gift platform), it needs a Category E licence (LBP 25bn capital) or must operate under a licensed partner.
- **Merchant-issued single-merchant vouchers/store credit** (merchant sells its own prepaid value, redeemable only at that merchant, money paid straight to the merchant) resemble a prepayment for goods rather than transferable "electronic monetary units"; many jurisdictions exempt such limited-network instruments, but **no Lebanese source was found confirming any exemption**. Law 81's definition is broad enough that a regulator could argue otherwise. Treat as "probably fine, unconfirmed".
- **Multi-merchant vouchers, a cross-shop stored-value balance, or loyalty points redeemable for value at unrelated shops** look much closer to e-money (Category A) if the value is purchased or redeemable like cash; pure earned-reward points that cannot be bought, transferred or cashed out are lower risk, but again no Lebanese authority found.
- **Top-up of a customer's "tab" by a relative abroad:** if the money is paid by card directly to the specific shop as a prepayment/settlement of that customer's account, it is the same pattern as a single-merchant voucher. If the value sits in a POS-vendor ledger usable across shops, it is e-money-like and also resembles cross-border transfer (Category C).
- With Lebanon still grey-listed and BDL in an active tightening cycle (Nov 2025, Jan 2026, further steps announced), expect partners to demand KYC on merchants and scrutiny of any product that looks like stored value or remittance.

### Gaps
- No law-firm or BDL source on whether closed-loop gift cards, vouchers, store credit or loyalty points are within or outside the e-money definition; exclusions section of Decision 13790 could not be read.
- The exact meaning of the "categories A, B, C and D shall be suspended until further notice" fragment.
- Transition deadlines for existing providers under Decision 13790, and which existing wallets/gateways hold which category.
- Whether technical service providers (pure software/PSP integrators) are explicitly carved out.
- Consumer-protection rules on voucher expiry/refunds (Consumer Protection Law 659/2005) were not researched.

## 4. Sanctions/AML for receiving payments from abroad; which global providers refuse Lebanon

### Takeaway
Receiving card payments from the diaspora is legal and common, but Lebanon is on both the FATF grey list (since Oct 2024, still listed after Oct 2026) and the EU high-risk third-country list (since 5 Aug 2025), so foreign institutions apply enhanced due diligence, and major global PSPs do not onboard Lebanese merchants.

### Cited Findings
- EU Delegated Regulation 2025/1184 added Lebanon to the EU list of high-risk third countries, in force 5 August 2025; EU obliged entities must apply enhanced due diligence to relationships and transactions involving Lebanon (not a ban). — [EUR-Lex](https://eur-lex.europa.eu/eli/reg_del/2025/1184/oj/eng); [European Commission](https://finance.ec.europa.eu/news/commission-updates-list-high-risk-countries-strengthen-international-fight-against-financial-crime-2025-06-10_en)
- Reported practical effects of the listing: delayed transactions, rising banking costs and extra compliance burdens. — [Hivos EU SEE alert](https://eusee.hivos.org/alert/civil-society-funding-affected-as-lebanon-responds-to-eu-high-risk-listing/); [ReliefWeb](https://reliefweb.int/report/lebanon/lebanons-fatf-grey-listing-money-transfers-aid-disruptions-how-lebanons-financial-blacklisting-hampers-international-business-and-humanitarian-operations-june-12-2025)
- BDL's Nov 2025 measures came under heavy US pressure to regulate the cash economy and cut Hezbollah funding; BDL also banned dealings with Hezbollah's finance arm. — [The New Arab](https://www.newarab.com/news/under-us-pressure-lebanon-tightens-screws-money-transfers); [The New Arab](https://www.newarab.com/news/lebanons-central-bank-bans-dealings-hezbollah-finance-arm)
- A report alleges Hezbollah-linked groups have turned to digital payments (wallets) for fundraising. **[Single outlet, UNVERIFIED]** — [Middle East Transparent](https://middleeasttransparent.com/hizbollah-linked-groups-turn-to-digital-payments-for-fundraising/)
- Stripe and PayPal do not accept Lebanon-based merchants (forum). — [Webflow forum](https://discourse.webflow.com/t/country-not-found-in-country-list-for-business-address/118410)
- Many Lebanese freelancers get paid via OMT cash, Whish or USDT with no bank account. **[UNVERIFIED blog]** — [furrsati](https://furrsati.com/blog/receive-money-without-bank-account-lebanon-freelancer)

### Inferences
- The safest inbound route for diaspora purchases is a card payment acquired by a Lebanese licensed acquirer (Areeba / bank gateway / Whish Pay); screening sits with the acquirer and card schemes. Expect higher decline/fraud-review rates on foreign cards and possible rolling reserves.
- Using an offshore entity (e.g. UAE/EU/US company on Stripe) to collect diaspora gift payments and then remitting to Lebanese merchants would turn the startup into a cross-border money mover (Category C-like in Lebanon, plus money-transmission exposure abroad and a breach of most PSP terms on undisclosed high-risk-country payouts). Treat as blocked unless structured with counsel and a licensed remitter.
- Any feature must screen out sanctioned parties; the merchant-KYC burden will be pushed down to the POS vendor by partners.

### Gaps
- No primary confirmation of PayPal/Wise/Stripe/Checkout.com current Lebanon policies (only forum evidence); no data on foreign-card decline rates or chargeback rules at Lebanese acquirers.
- OFAC-specific guidance for Lebanese merchant acquiring not researched.

## 5. Existing Lebanese examples: gift platforms, diaspora-pays-for-family, loyalty coalitions

### Takeaway
Diaspora gifting to Lebanon exists mainly as *physical* gift/flower delivery (Presentail, Gift On Click) paid by card online; no evidence was found of an established multi-merchant restaurant/shop e-voucher platform or a shared loyalty coalition, so this is either a genuine gap or simply under-documented.

### Cited Findings
- Presentail (Beirut, founded 2018): gift and flower platform aimed at Lebanese expats, same-day delivery, offers gift cards, positions itself as a channel for local retailers and restaurants to reach Lebanese abroad; later expanded to Cyprus. — [Gulf News](https://gulfnews.com/business/corporate-news/presentail-a-gift-and-flower-platform-for-lebanese-expats-1.1638792238169); [CB Insights](https://www.cbinsights.com/company/presentail/)
- Gift On Click targets expats sending gifts to Lebanon with same-day delivery and online card payment. — [Gift On Click](https://giftonclick.com/en-lb)
- BuyLebanese.com is a Beirut-based e-commerce exporter serving diaspora customers (goods, not vouchers). — [BuyLebanese](https://www.buylebanese.com/about.asp)
- Digital gift cards sold in Lebanon are largely third-party global codes (PlayStation, Netflix, Apple, Shahid, etc.) via resellers. — [MobileLeb](https://mobileleb.com/collections/gift-cards-digital-currency-subscription); [Ding](https://www.ding.com/gift-cards/lebanon)
- Toters accepts cards, mobile wallets and cash on delivery (coupon aggregator; no gift-card feature confirmed). — [CouponAnnie](https://www.couponannie.com/stores/toters-lebanon)

### Inferences
- The proven diaspora pattern is "pay by international card on a Lebanese site, fulfilment is a delivered good" — which avoids stored value entirely. A POS feature shaped as "pre-pay a specific order/meal/basket for someone at merchant X" follows that pattern more closely than an open-ended voucher balance.

### Gaps
- Could not confirm Toters gift cards, ABC/mall gift cards, supermarket (Spinneys/Carrefour) order-from-abroad flows, bill-payment-for-relatives services, or any Lebanese loyalty coalition; searches returned nothing reliable. Absence of evidence is not evidence of absence — needs on-the-ground checking.
- How Presentail/Gift On Click acquire cards (which gateway, which entity) not found.

## 6. Mobile recharge and bill-payment resale at the till

### Takeaway
Shops resell recharges and take bill payments today as sub-agents of OMT/Whish/BOB or via distributor apps; a POS can most safely integrate by partnering with a licensed network/distributor. International airtime APIs covering Alfa and Touch exist (Reloadly), but operators/regulators appear to be moving against the parallel recharge market.

### Cited Findings
- Sub-agent counts (commentary): OMT ~1,200, Whish ~900, Cash United ~200, Masry Money ~200, MTM ~150; sub-agents typically earn 10–15% of the transaction fee. **[UNVERIFIED single commentary]** — [Middle East Transparent](https://middleeasttransparent.com/banking-without-bankers-why-lebanon-must-end-the-sub-agent-experiment/)
- Whish's fee page lists bill-payment fees (e.g. flat LBP 50,000 for Ogero bills; tiered formula for others). — [Whish Fees & Commissions](https://www.whish.money/fees-commissions)
- Reloadly offers an airtime API for Touch and Alfa with instant top-ups, success/failure notifications and a discount on each transaction (page is old; verify). — [Reloadly](https://operators.reloadly.com/touch-alfa-lebanon-airtime-api/)
- Alfa/Touch recharges are sold via operator shops, licensed distributors, apps, online services, banks and outlets; an article reports a move to shut down a parallel recharge market (not yet definitive regulation) and warns intermediary margins are a problem when based on opaque pricing or activity outside authorised-distributor rules. — [Libnanews](https://en.libnanews.com/alfa-touch-what-s-behind-the-recharges/)
- Amhaz is an independent app for customers and resellers to top up Alfa/Touch lines, not endorsed by the operators. — [App Store](https://apps.apple.com/us/app/amhaz-app/id6743801169)

### Inferences
- Buildable with a partner: embed a licensed distributor's/agent network's recharge and bill-pay catalogue in the POS, with the shop acting as that partner's sub-agent (the partner carries the licence and "Know Your Agent" duty). Bill collection on behalf of third parties is Category D-type activity, so the POS vendor should not collect in its own name.
- Margin for the shop is thin (a fraction of the agent fee or a small airtime discount), so the feature is a footfall/retention play rather than a revenue line.

### Gaps
- No official Alfa/Touch distributor commission rates, no official OMT/Whish/BOB agent requirements or agent APIs found.
- Whether Reloadly's Lebanon discount is still live and compliant with operator distribution rules is unknown.

## 7. Tipping, service charge and card surcharges

### Takeaway
Surcharging customers for paying by card is prohibited (BDL Decision 13810 of April 2026 plus Ministry of Economy position), so a POS must not add a "card fee" line; nothing was found on rules for tips or service charge on card/wallet payments.

### Cited Findings
- BDL Decision 13810 (28 April 2026) requires banks to stop merchants accepting POS/electronic payments from adding fees of any kind for customers paying by bank card. — [L'Orient Today](https://today.lorientlejour.com/article/1505876/bdl-caps-commissions-on-certain-bank-payments-imposed-on-merchants.html); [BDL Basic Circular 173 PDF](https://www.bdl.gov.lb/CB%20Com/Laws%20And%20Regulations/Basic%20Circulars/Decision_13810_EN%C2%A711670_3.pdf)
- BDL says some merchants still add 2–3% for card payments; the Economy Ministry says the practice is banned and takes complaints via its MoET Digital Services app. — [L'Orient Today](https://today.lorientlejour.com/article/1547050/card-payments-surge-130-in-lebanon-bdl-outlines-measures-to-curb-cash-economy.html); [Enmaeya](https://enmaeya.com/en/news/6aa25ed40e4b35adb974075e)

### Inferences
- A tip line on a card/wallet payment is technically just a larger authorised amount; the open issues are operational (acquirer fee is taken on the tip, staff payout is delayed until settlement, payroll/tax treatment) rather than a known prohibition.
- Offering a *cash discount* instead of a card surcharge is economically equivalent and may attract the same regulatory objection; ask counsel.

### Gaps
- No source on legal treatment of tips or the customary service charge (tax, distribution to staff) when paid electronically; no source on whether wallet (non-card) payments are covered by the surcharge prohibition.

## 8. SMS / WhatsApp Business messaging costs for Lebanon

### Takeaway
WhatsApp is far cheaper than SMS for Lebanon: roughly USD 0.039 per marketing template and USD 0.009 per utility template (Rest of Middle East rate, Oct 2026) versus roughly USD 0.23–0.36 per SMS through international CPaaS providers.

### Cited Findings
- Meta charges per delivered template message by category and recipient market; a country in a "Rest of ..." region is charged that region's rate. — [Meta WhatsApp pricing docs](https://developers.facebook.com/docs/whatsapp/pricing)
- Rest of Middle East marketing rate rose from USD 0.0341 (July 2026) to USD 0.0392 (October 2026). — [Gupshup changelog Oct 2026](https://partner-docs.gupshup.io/changelog/october-2026)
- Rest of Middle East from 1 Oct 2026: marketing USD 0.0392; utility USD 0.0091; authentication USD 0.0091 (earlier 2025 table: marketing 0.04508, utility 0.01047). — [SleekFlow pricing](https://sleekflow.io/blog/whatsapp-business-price)
- Plivo outbound SMS to Lebanon: Alfa USD 0.3154/SMS, MTC Touch USD 0.3522/SMS (undated page). — [Plivo](https://www.plivo.com/sms/pricing/lb/)
- Third-party comparison (Jan 2025): international providers range ~USD 0.23–0.36 per SMS to Lebanon; Twilio quoted at USD 0.3619. **[UNVERIFIED vendor blog]** — [sent.dm](https://www.sent.dm/en/resources/sms-pricing/lebanon-sms-pricing)
- SMS.to calculator shows USD 0.023/SMS for Lebanon — an outlier an order of magnitude lower; route quality/terms unknown. **[UNVERIFIED]** — [SMS.to](https://sms.to/?p=3050)

### Inferences
- Lebanon is assumed to fall under "Rest of Middle East" (it is not known to have its own Meta rate line); confirm on Meta's rate card.
- Receipts, reminders and gift-delivery messages should default to WhatsApp utility templates (~1 US cent) with SMS as fallback only; replies inside the 24-hour customer service window are free under Meta's model (standard Meta policy; not re-verified this session).
- BSP mark-ups (Twilio, 360dialog, etc.) come on top of Meta's rates.

### Gaps
- No verified local bulk-SMS price from Alfa/Touch or Lebanese aggregators; Meta's own rate card could not be opened to confirm Lebanon's region mapping.

## Feasibility summary (inference, for the report writer — not a legal opinion)

### Takeaway
Buildable now: pay-at-table via gateway link/wallet QR, single-merchant prepaid orders/vouchers paid directly to the merchant, WhatsApp receipts. Needs a licensed partner: recharge/bill-pay resale, anything where the startup would collect or split funds, diaspora top-ups of a tab. Blocked or high-risk without a BDL licence: multi-merchant stored value, purchasable cross-shop loyalty balance, offshore collection and remittance.

### Cited Findings
- Category E (payment facilitators/gateways) and Category A (e-money) are licensed activities under BDL Decision 13790 of 9 Jan 2026, with LBP 25bn and LBP 50bn minimum capital respectively. — [Melki Law Firm](https://melkilawfirm.com/article/lebanons-central-bank-issues-first-comprehensive-fintech-regulation/)
- Card surcharges are prohibited (Decision 13810, April 2026). — [L'Orient Today](https://today.lorientlejour.com/article/1505876/bdl-caps-commissions-on-certain-bank-payments-imposed-on-merchants.html)

### Inferences
| Feature | Assessment | Route / constraint |
|---|---|---|
| Pay at table by phone (card) | Buildable now | Hosted checkout / pay-by-link of merchant's own gateway (Areeba, bank gateway, MontyPay, Whish Pay). Google Pay possible; Apple Pay assume no. No card surcharge. |
| Pay at table by wallet QR | Buildable now | Whish collect API (credentials from Whish; 1% published); OMT Pay by negotiation. |
| Gift voucher for ONE merchant, funds direct to that merchant | Probably buildable; legal status unconfirmed | Merchant is issuer and merchant of record; POS only records the liability. Counsel to confirm not e-money. |
| Diaspora buys that voucher with foreign card | Buildable if merchant's gateway accepts international cards | Fees unpublished; EDD/declines likely; do not route through an offshore entity. |
| Relative abroad tops up a customer's tab at one shop | Same as above | Structure as payment to the shop against that customer's account; no cash-out, no transfer between shops. |
| Multi-merchant voucher / marketplace gift platform | Needs licence or licensed partner | Startup would collect and disburse = Category E at minimum; stored balance = Category A risk. |
| Shared loyalty points across shops | Earn-only points: likely feasible; purchasable/cash-like points: e-money risk | No Lebanese authority found either way; inter-merchant settlement of points also needs a compliant funds flow. |
| Recharge / bill-pay at till | Needs partner | Sub-agent of OMT/Whish/BOB or licensed distributor; thin margins; parallel recharge market under scrutiny. |
| Tips on card | Buildable; operational questions | No rule found; acquirer fee applies to tip. |

### Gaps
- Every row marked "probably" depends on the unread exclusions/scope articles of Decision 13790 and on counsel's view of Law 81's e-money definition.
