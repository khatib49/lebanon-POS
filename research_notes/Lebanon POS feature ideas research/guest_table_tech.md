# Guest-facing restaurant technology: QR ordering, pay-at-table, call-waiter, 3D/AR menus (2024-2026)

> **Method note (read first).** This session's network blocked direct page fetches (pos.toasttab.com, news.wsu.edu, repository.tudelft.nl all failed to resolve; fetching was then stopped as instructed). **Every finding below comes from web-search result summaries, not from reading the full page.** Numbers are quoted as the search summaries gave them; sample sizes, dates and wording should be re-checked against the linked source before being printed in a report. Each finding is tagged **[Independent]**, **[Vendor]** (marketing / self-reported) or **[Academic]**. Older evidence is marked with its year.

## 1. QR table ordering and pay-at-table: adoption, measured effects, guest backlash, hybrid best practice

### Takeaway
Guests clearly accept QR for *paying* far more than for *reading the menu*: independent surveys show a large majority prefer a physical menu, with rejection concentrated among older diners, while vendor data (not independently audited) consistently shows roughly +10-12% ticket size, higher tips and several minutes saved per table when QR is used for order/pay. The safe design is hybrid: paper/waiter by default, QR as an optional fast lane for reorders and payment.

### Cited Findings

**Guest preference and backlash**
- [Independent, cited in 2024 press] Technomic survey (cited by the Wall Street Journal): 88% of diners would rather be given a paper menu than a QR code; a later write-up says QR codes made people less likely to dine at a restaurant. — [Food Network](https://www.foodnetwork.com/fn-dish/news/paper-menu-qr-code)
- [Independent, 2024] PYMNTS Intelligence / Paytronix, about 2,400 US consumers: only 31% of diners had positive feelings about viewing menus via QR codes. Reported in the search summary of 2024 coverage; the exact page carrying the figure was not confirmed. — [Eat Your Books, May 2024](https://wp.eatyourbooks.com/blog/2024/05/31/have-we-seen-the-last-of-qr-code-menus); see also [PYMNTS Digital Transformation Tracker, July 2024](https://americanexpress.com/content/dam/amex/us/merchant/pdf/bcfm/PYMNTS-Why-Restaurants-Need-Digital-Transformation-Tracker-July-2024.pdf)
- [Independent, OLDER: June 2023] YouGov via Statista: the majority of US adults preferred traditional paper menus; 15% preferred QR codes. — [Statista](https://statista.com/statistics/1446535/preferred-menu-access-method-us)
- [Vendor survey] Toast survey of 850 adults: 81% prefer a physical menu; 90% of guests aged 55+ prefer traditional menus; about 23% feel neutral about QR menu access and 21% find it "somewhat easy". Publication date unclear (the page text refers to 2026). — [Toast](https://pos.toasttab.com/blog/on-the-line/qr-code-menu-insights)
- [Independent, 2024] National Restaurant Association 2024 Technology Landscape Report, base = consumers who used a sit-down restaurant in the past 6 months: would likely access the menu via QR 59%; place an order via QR 48%; pay the check via QR 46%. Tableside tablets score higher: 60% would order and 65% would pay on one. — [NRA 2024 Technology Landscape Report (PDF)](https://go.restaurant.org/rs/078-ZLA-461/images/NatRestAssoc_TechLandscapeReport_2024.pdf?version=0)
- [Independent, 2024] Same NRA report, age gap on paying the check by QR: overall 46%, millennials 65%, baby boomers 16%. — [NRA 2024 Technology Landscape Report (PDF)](https://go.restaurant.org/rs/078-ZLA-461/images/NatRestAssoc_TechLandscapeReport_2024.pdf?version=0)
- [Independent, 2024] Same NRA source: consumers are more comfortable ordering by smartphone app (70% limited-service, 63% full-service) than by QR (52% limited-service, 48% table-service). — [Restaurant Business](https://www.restaurantbusinessonline.com/technology/restaurants-want-give-customers-more-tech)
- Note on conflict: the surveys are not directly comparable. "Prefer paper" figures range from a "majority" (YouGov) to 81% (Toast) to 88% (Technomic) depending on question wording, while NRA shows 59% are *willing* to use a QR menu. Preference and willingness are different questions.

**Measured effects (all vendor-reported)**
- [Vendor] Toast Pay (QR pay at end of meal): guests tip 3.8 percentage points more than with traditional checkout, and checkout saves servers 2.5 minutes per table; Toast internal data June-August 2026, about 15,000 restaurants, single-check orders. — [Toast support: Get Started With Toast Pay](https://support.toasttab.com/en/article/Get-Started-with-Toast-Pay)
- [Vendor] Toast Mobile Order & Pay: average ticket around 12% larger than traditional service ("select Toast customers"); in quick-service, guests tip on 18% more transactions. — [Toast Mobile Order & Pay overview](https://support.toasttab.com/en/article/Mobile-Order-and-Pay-Overview)
- [Vendor, OLDER: 2022] Toast press release: 10-12% average increase in Toast processing volume from Mobile Order & Pay, based on at least 12 months of internal data. — [Toast news](https://pos.toasttab.com/news/toast-enhances-mobile-order-and-pay-solutions-to-help-restaurants-increase-sales-collect-guest-data-and-navigate-labor-challenges)
- [Vendor] sunday (QR pay-at-table): 10% higher tips and 12% higher check sizes, tip lift attributed to pre-set tip amounts; "up to 15 minutes" saved per table. No methodology given. — [Toast partner directory: sunday](https://pos.toasttab.com/partners/directory/sunday)
- [Vendor] sunday's own site cites one named restaurant (Jack's Wife Freda, NYC) at 10 minutes saved per table and says its restaurants land tip rates of 20-22%. — [sunday](https://sundayapp.com/en-gb/?p=142588)
- [Trade media] sunday closed a $21 million Series B in November 2025 aimed at US expansion; an earlier Series A was reported at $100M. — [Restaurant Technology News, Dec 2025](https://restauranttechnologynews.com/2025/12/sundays-21-million-funding-round-highlights-intensifying-competition-to-modernize-restaurant-payments/); [CB Insights](https://www.cbinsights.com/company/sunday-2)
- [Vendor claim, reported by analyst blog] me&u: "customers spend 30% more on average"; Mr Yum: spend per head +33%, 3x guest data captured, 41% more return visits. Unaudited marketing claims. — [Overnight Success](https://www.overnightsuccess.vc/p/friendly-rivalry-a-deep-dive-on-mr-yum-and-me-u)
- [Trade media, OLDER: late 2023] Mr Yum and me&u merged (me&u brand kept, Mr Yum co-founder Kim Teo as CEO); the combined company was reported to process $2 billion in dining transactions a year for more than 6,000 food brands. — [SmartCompany](https://www.smartcompany.com.au/industries/hospitality/mr-yum-meu-merger-restaurant-tech/)
- [Vendor] Qlub (Dubai-headquartered QR pay-at-table): tips "up to 100% higher" (2022 Foodics press release) and a "300% increase in tips" versus manual payment in a later case study, attributed to suggested-tip prompts. See section 7. — [Foodics press](https://www.foodics.com/press/foodics-partners-with-qlub-to-bring-fastest-table-self-checkout-experience-to-its-dine-in-restaurants/); [Qlub case study](https://qlub.io/ae/en/success-stories/LaPetite)

**Vendor pricing found**
- [Vendor] Menu Tiger plans: free tier, $17/month entry, $46/month mid-tier, $119/month premium, priced per restaurant and order volume. — [Menu Tiger pricing](https://www.menutiger.com/pricing); [Menu Tiger vs UpMenu](https://www.menutiger.com/blog/menu-tiger-vs-upmenu)
- [Third-party listings, conflicting] FineDine starting price is reported as $58/month (SaaSworthy), $26/month (Capterra), and $36/month Starter with an $85/month tier (Listicler). — [SaaSworthy](https://www.saasworthy.com/product/finedine-tablet-menu/pricing); [Capterra](https://www.capterra.com/p/154023/FineDine-Tablet-Menu/); [Listicler](https://listicler.com/tools/finedine)

### Inferences
- The evidence splits cleanly by function: QR as a *menu replacement* is disliked; QR as a *payment shortcut* is the least contested use (it removes the wait for the bill and card machine, and the guest has already been served by a human). For a new POS, pay-at-table and "reorder / add a round" are lower-risk than forcing QR ordering.
- Tip uplift is driven by pre-selected tip prompts, not by the QR itself (sunday and Qlub both attribute it to suggested amounts). This matters for Lebanon, where tipping is customary and often cash: a suggested-tip screen is likely the highest-value single feature for staff buy-in.
- Vendor uplift numbers cluster at +10-12% ticket (Toast, sunday) with outliers at +30-33% (me&u, Mr Yum). The higher numbers come from pub/bar-heavy Australian venues where QR ordering replaces queueing at a bar; they should not be assumed for seated Lebanese restaurants.
- Because older diners reject QR most strongly (boomers 16% vs millennials 65% on QR pay), venues with family/older clientele need a paper menu and waiter ordering as the default, with QR optional. A POS that lets the venue set QR mode per venue (menu-only / order / pay-only) covers all cases.
- NRA data showing tableside tablets beating QR on willingness suggests the "phone friction" (own device, data, battery, small screen) is part of the objection, not digital ordering as such.

### Gaps
- No independent (non-vendor) measurement of QR ordering's effect on average order value, table turnover or labour was found; all quantitative effect sizes are vendor-reported.
- No NRA 2025 or 2026 technology survey figures were found; the 2024 report is the latest located.
- Reasons guests dislike QR menus (small screen, poor signal, loss of hospitality, phone at the table) are widely reported but no survey breakdown of reasons was retrievable; the Toast survey page that likely contains it could not be fetched.
- No data found for Bbot (acquired by DoorDash in 2022) or on William Blair research.
- No post-merger me&u performance data, and no restaurant count for sunday.
- No adoption-rate time series (share of restaurants using QR ordering after COVID) was found.

## 2. Call-waiter / service-request buttons

### Takeaway
Service-request buttons are a common, cheap feature (hardware bells and QR-menu "call waiter / request bill" buttons), but no independent study measuring their effect on service speed or satisfaction was found; the only solid academic point is that faster service raises satisfaction only up to a point.

### Cited Findings
- [Vendor] Flic (physical smart buttons) says operators "report immediate improvements in service speed and customer satisfaction" but gives no figures. — [Flic](https://flic.io/blog/restaurant-service-buttons-for-enhanced-sales-and-customer-satisfaction)
- [Vendor] Petpooja (Indian POS, also sells in the UAE) describes waiter-calling systems and claims reduced delay between a guest pressing "Bill" and the bill arriving, without numbers. — [Petpooja blog](https://blog.petpooja.com/industry-business-guides/waiter-calling-systems-indian-restaurants/)
- [Vendor-cited, unverified] Petpooja cites an IIM Ahmedabad study of 94,404 customers finding that eliminating wait time could raise restaurant revenue by nearly 15%; this concerns wait time generally, not call buttons, and the original was not checked. — [Petpooja blog](https://blog.petpooja.com/industry-business-guides/waiter-calling-systems-indian-restaurants/)
- [Trade media, OLDER: 2018] Tablee's call-button system records the time between a button press and staff attending, letting operators audit their own service standards. — [PYMNTS, 2018](https://www.pymnts.com/news/retail/2018/restaurants-hospitality-service-call-buttons-restech/)
- [Academic, OLDER] Noone & Kimes (Cornell-hosted) on restaurant service pace: satisfaction rises as perceived pace increases, but only up to a point. Not a call-button study. — [Cornell eCommons](https://ecommons.cornell.edu/server/api/core/bitstreams/34490a85-6a11-48de-8972-b3bd530fbddf/content)
- [Vendor docs] UK order-and-pay vendor Dines lists guest-facing features of this type on its features page. — [Dines features](https://www.dines.co.uk/dines-features)

### Inferences
- The measurable value of a call button for a POS vendor is the timestamp: press-to-acknowledge time per waiter/section is a management KPI that paper service cannot produce (the Tablee idea from 2018). Build the button with typed reasons (water, bill, coal, waiter) and log response times.
- Typed requests ("bill", "coal change", "cutlery") are more useful than a generic bell because the waiter can arrive with the item and save a trip.
- Since the Noone & Kimes finding shows faster is not always better, the button should be guest-initiated only; it should not be used to rush tables.

### Gaps
- No independent or academic study on call buttons' effect on response time, satisfaction or sales was found. This is a real evidence gap, not a search failure on one site.
- No pricing collected for hardware bell systems.

## 3. 3D and AR menus: vendors, claimed uplift, independent evidence, production cost, technical constraints

### Takeaway
Academic studies consistently show AR/3D food visuals raise desire, purchase intent and visit intent, but the one restaurant field study that tracked actual spend found no increase in order value, and all sales-uplift numbers (roughly +20-26%) are vendor or anecdotal claims, several of them from 2017-2019. Technically, 3D dishes are deliverable in a mobile browser with no app (model-viewer with GLB plus USDZ for iOS), but model size on slow mobile data and per-dish production effort are the real costs.

### Cited Findings

**Vendors**
- Kabaq rebranded as QReal; it is the AR subsidiary of The Glimpse Group. — [FSR Magazine](https://www.fsrmagazine.com/content/kabaq-rebrands-qreal)
- [Trade media, 2023] QReal built Denny's 70th-anniversary AR menu using photogrammetry. — [ARPost](https://arpost.co/2023/04/07/dennys-70th-anniversary-ar-food-menu/)
- [Trade media] Replate offers interactive 3D menus built with Gaussian splatting, opened as a web app from a QR code with no download; no pricing published in the article. — [radiancefields.com](https://radiancefields.com/replate-serves-up-interactive-3d-menus-with-gaussian-splatting)
- [OLDER pricing] Kabaq was reported to charge $99-$199 per month (subscription, not per-dish). — [Martech](https://martech.org/how-ar-is-whetting-restaurant-patrons-appetites/)

**Claimed uplift (vendor / anecdotal)**
- [Anecdotal, OLDER] "Some restaurants have reported a 20 percent boost in sales when desserts are presented in AR"; one restaurant reported overall sales up about 22% after adopting Kabaq. — [Martech](https://martech.org/how-ar-is-whetting-restaurant-patrons-appetites/)
- [Vendor claim via secondary blog] Kabaq reports average order value increases of 20-26% within the first 90 days across its operator network. — [dev.family](https://dev.family/blog/article/augmented-reality-in-restaurants-use-cases-revenue)
- [Trade media, OLDER: 2018] Bareburger saw a 3% increase in burgers sold, and the same article notes there were no statistics yet showing Kabaq helps make the sale. — [FoodNavigator, 2018](https://www.foodnavigator.com/Article/2018/10/09/Augmented-reality-and-the-future-of-food-There-are-many-opportunities)
- [Vendor] A QReal executive states that 3D/AR food increasing craveability "has been demonstrated in multiple studies, including one by Oxford University in conjunction with QReal". — [ARPost](https://arpost.co/2023/04/07/dennys-70th-anniversary-ar-food-menu/)

**Independent / academic evidence**
- [Academic, OLDER: 2022] Fritz, Hadi & Stephen, Journal of the Academy of Marketing Science: two field studies with real choice/purchase data plus two lab studies; AR increases consumers' ability to mentally simulate eating a pictured food, which raises desire and purchase likelihood. About food AR generally, not restaurant menus specifically. — [Springer](https://link.springer.com/article/10.1007/s11747-022-00919-x)
- [Academic, 2026] Washington State University study in the International Journal of Hospitality Management: participants reported higher intention to visit a restaurant and greater likelihood of sharing after viewing menus in AR, compared with printed or QR-code menus. Measures intent, not sales. — [WSU news, Feb 2026](https://news.wsu.edu/press-release/2026/02/18/augmented-reality-menus-may-help-restaurants-attract-customers/); [EurekAlert](https://www.eurekalert.org/news-releases/1116819)
- [Academic thesis, null result] TU Delft master's thesis, field experiment in a Dutch restaurant: the AR menu made dishes and portions look more representative, but this "did not translate into an increased order value or NPS score". — [TU Delft repository](https://repository.tudelft.nl/record/uuid:0a814007-0d67-4ec0-9a7c-f789e8d80e1e)
- [Academic thesis, small] Taiwanese master's thesis: 360-degree 3D dish displays in a digital menu at one Taipei restaurant, random assignment vs paper menu, improved revisit intention. — [NTNU thesis record](https://etds.lib.ntnu.edu.tw/thesis/detail/7e9f4ba1ba25b76836363cb87d4336f6)

**Production cost and method**
- [Academic thesis, OLDER: 2018] A TU Delft thesis estimated about EUR 150 per month per restaurant for a leased automatic scanner plus app licence, plus EUR 15 per tablet per month, and judged mobile photogrammetry immature at that time. — [TU Delft repository file](https://repository.tudelft.nl/file/File_b0fd7a17-302a-4e21-9514-eec09dedc82f)
- [Developer docs] Apple Object Capture (RealityKit photogrammetry) outputs at detail levels preview, reduced, medium, full and raw; "reduced" and "medium" are optimised for viewing in AR Quick Look on iOS. — [Apple: Creating 3D objects from photographs](https://developer.apple.com/documentation/realitykit/creating-3d-objects-from-photographs.md); [WWDC21 session 10076](https://developer.apple.com/videos/play/wwdc2021/10076/?time=416)
- [Developer forums] On iOS only the reduced detail level is available on-device (preview, medium, full, raw are marked unavailable), so higher-quality reconstruction needs a Mac. — [Apple Developer Forums](https://developer.apple.com/forums/thread/734811)
- [Vendor blog] Gaussian splatting is described as needing lighter computation than photogrammetry or NeRF. Vendor source. — [Varjo Teleport](https://teleport.varjo.com/blog/photogrammetry-vs-nerfs-gaussian-splatting-pros-and-cons)

**Browser / device support and file size**
- [Developer docs] Google's model-viewer web component `ar-modes` default is `webxr scene-viewer quick-look fallback`: WebXR in supporting browsers, Scene Viewer on Android, AR Quick Look on iOS. — [modelviewer.dev AR examples](https://modelviewer.dev/examples/augmentedreality)
- [Developer docs] Android AR needs an ARCore-supported device with Google Play Services for AR installed. — [Google ARCore: model-viewer](https://developers.google.com/ar/develop/webxr/model-viewer?hl=en)
- [Developer docs / tutorial] iOS AR Quick Look only accepts USDZ; if `ios-src` is omitted model-viewer generates a USDZ on the fly, which "might not produce desired results". — [Brown Institute tutorial](https://browninstitute.github.io/ar-for-everyone/tutorials/modelViewer.html)
- [Third-party guideline, not an official limit] KeyShot's web-AR guidance: GLB 15 MB maximum, 10 MB recommended, 100,000 triangles maximum; USDZ under 50 MB. — [KeyShot manual](https://manual.keyshot.com/?p=15938)
- [Independent dev blog] Draco compression shrinks GLB dramatically: example coffee mug 7.3 MB as USDZ versus 416 KB as Draco GLB; auto-generated USDZ is roughly the size of the uncompressed GLB. — [Cloud Four](https://cloudfour.com/thinks/how-to-embed-3d-models-on-the-web/)

### Inferences
- Strongest honest framing for a product decision: AR/3D improves *appeal and intent* (multiple academic studies) but there is no independent proof it raises restaurant *spend*; the only in-restaurant spend test was null. Treat 3D as a marketing/differentiation and expectation-setting feature (portion size, what the dish looks like, useful for tourists and unfamiliar dishes), not as a proven revenue lever.
- "View in 3D" in the browser (rotatable model, no camera/AR) covers most of the benefit with none of the device constraints; true AR placement is a bonus where the phone supports it. model-viewer's fallback chain gives exactly this behaviour with one HTML element.
- On slow or metered Lebanese mobile data, a 10 MB model per dish is unusable for a whole menu. A practical budget is Draco-compressed GLB in the hundreds of KB to low single-digit MB, lazy-loaded only when the guest taps a dish, with a normal photo as poster. iOS still needs a separate USDZ, which will be several times larger than the Draco GLB (per the Cloud Four example), so AR on iPhone should be an explicit opt-in tap.
- Capture is feasible in-house with a phone (Object Capture, or Gaussian-splat apps), which suggests a POS vendor could offer "we scan your top 10 dishes" as an onboarding service rather than a self-serve tool. Food is a hard subject (glossy sauces, steam, melting, translucent drinks), so quality will vary by dish.
- Limit 3D to hero items (signature dishes, desserts, shisha/cocktail presentations): vendor anecdotes concentrate on desserts, and per-dish production cost makes full-menu coverage uneconomic.

### Gaps
- No current (2024-2026) per-dish price or turnaround time for professional 3D food capture was found; no pricing for QReal, Replate, FineDine AR, Menu AR, FoodAR or Bitebuddy.
- No source found for Polycam, Luma AI or KIRI Engine pricing, photo counts or processing times; Apple documentation located does not state photo counts, processing time or per-detail-level file sizes in the retrievable summaries.
- No official Google or Apple maximum file size for Scene Viewer / AR Quick Look was found; the 10-15 MB figure is one vendor's rule of thumb.
- No measured data on load time of 3D menus over 3G/slow 4G.
- WSU study sample size, design and effect sizes, and the TU Delft thesis sample size and year, could not be retrieved (both hosts blocked).
- The "Oxford University with QReal" study cited by the vendor was not located.
- Current WebXR support status on iOS Safari was not verified in this session.

## 4. "4D" / dynamic menu features: dayparting, real-time 86, dynamic pricing, recommendations and upsell

### Takeaway
Upsell/recommendation engines have modest but real-looking effects (about +3-8% average check in the more credible figures, up to +17-25% in vendor claims), while demand-based dynamic pricing triggers strong consumer and operator resistance; time-of-day menus and happy-hour pricing are accepted and already standard.

### Cited Findings
- [Trade media reporting a vendor pilot] Toast's AI-powered menu upsell tool raised average order volume by 6% in a pilot restaurant. — [PYMNTS](https://www.pymnts.com/?p=2698584)
- [Vendor blog citing chain data] Digital menu board rollouts produce a 3-8% increase in average check; McDonald's cited at 3-5% across US locations; operators who actively managed placement of high-margin items saw upsell rates improve 10-15% within 90 days (attributed to QSR Magazine). — [Evergreen](https://www.evergreenhq.com/?p=22784)
- [Vendor] Qu claims customers see check averages up to 22% higher from kiosk cross-sell alone. — [Qu](https://www.qubeyond.com/resource-center/qus-sales-driven-innovations-help-qsr-fast-casual-restaurants-navigate-market-headwinds)
- [Vendor] Checkmate: well-run digital upsell can lift average check by as much as 17%; a separate post cites an unnamed chain at +25% from pairing suggestions (unverifiable). — [Checkmate](https://itsacheckmate.com/blog/10-restaurant-upselling-tactics-that-increase-sales-without-being-pushy); [Checkmate AI upsell](https://www.itsacheckmate.com/blog/how-to-increase-revenue-with-ai-for-upselling-in-restaurants)
- [Independent press, Feb 2024] Wendy's faced a public backlash after its CEO mentioned dynamic pricing on an earnings call and media framed it as "surge pricing"; Wendy's denied plans to raise prices at peak times and described AI-enabled menu changes and suggestive selling instead. — [Axios](https://www.axios.com/2024/02/29/wendys-surge-pricing-ai-backlash-internet); [QSR Magazine](https://www.qsrmagazine.com/story/where-wendys-went-wrong-in-its-communication-of-dynamic-pricing/)
- [Independent survey, OLDER: 2023] Capterra survey of 900 US restaurant-goers: over half called dynamic pricing the same as price gouging; 65% said it makes it harder to decide where to eat. — [Restaurant Dive](https://www.restaurantdive.com/news/dynamic-pricing-customer-restaurant-dining-experience/713418/)
- [Vendor-commissioned survey] HungerRush / Dynata, 1,000 US adults: nearly two-thirds of consumers react negatively to dynamic pricing. — [Restaurant Business](https://www.restaurantbusinessonline.com/financing/reaction-wendys-dynamic-pricing-test-reveals-its-risks)
- [Independent, conflicting] A National Restaurant Association finding reported that more than two-thirds of adults would be OK with "variable pricing"; Technomic found more than two-thirds of operators would not implement dynamic pricing. Wording ("variable" vs "dynamic"/"surge") likely explains the contradiction. — [Restaurant Business](https://www.restaurantbusinessonline.com/financing/reaction-wendys-dynamic-pricing-test-reveals-its-risks)
- [Vendor] Hookah-lounge POS RPOWER supports happy-hour pricing by day and time (dayparted pricing as a standard POS feature). — [RPOWER Hookah POS](https://www.rpowerpos.com/Home/Market-Vertical/Hookah-POS)

### Inferences
- Framing decides acceptance: discounts at quiet times (happy hour, lunch menu, early-bird) are accepted; price rises at busy times are read as gouging. A POS should ship scheduled price lists and time-boxed promotions, and should not market "dynamic pricing".
- Lebanon-specific note (inference, no source found): menus there have already had to cope with frequent price changes and dual USD/LBP display since the currency crisis, so instant price update across QR menu, POS and printed tickets is a practical need separate from "dynamic pricing".
- Real-time sold-out (86) sync is a correctness feature rather than an uplift feature: its value is avoiding the guest ordering something unavailable via QR, which is one of the easiest ways for QR ordering to cause a bad experience. No measured impact was found, but it is a precondition for guest self-ordering.
- Credible upsell uplift is single-digit percent (6% Toast pilot, 3-5% McDonald's boards). Plan on that range, not the 20%+ vendor headlines. Simple rule-based pairings (add a drink, add a side, dessert prompt at a set time after mains) are likely to capture most of it without ML.

### Gaps
- No quantitative evidence found on the impact of real-time 86/out-of-stock sync or of dayparting itself.
- No independent (non-vendor) controlled study of personalised recommendation engines in table-service restaurants was found.
- No evidence from the Middle East on consumer attitudes to dynamic pricing.
- The term "4D menu" has no established industry meaning in the sources found; it appears to be marketing shorthand for time-varying menu content.

## 5. Security and abuse of table QR codes

### Takeaway
Static table QR codes have two documented abuse modes: remote prank/fraud orders from a photographed code, and fake QR stickers ("quishing") that send guests to a phishing payment page. The standard mitigations are short-lived session tokens, staff approval to open a table session, location limits, and visibly branded, regularly inspected codes.

### Cited Findings
- [Independent press, OLDER: Dec 2023] Kunming, China: a diner's social-media photo showed her table's ordering QR code; strangers scanned it and kept placing orders to her table even after the post was deleted. The restaurant responded by limiting the distance from which orders can be placed. A lawyer quoted suggested requiring pre-payment before orders are accepted. — [China Daily](https://www.chinadaily.com.cn/a/202312/04/WS656dd404a31090682a5f15f7.html); related coverage: [Market Realist](https://marketrealist.com/why-should-you-not-share-photos-from-a-restaurant-on-social-media)
- [Vendor blog citing FBI warning] Criminals tamper with physical and digital QR codes to replace legitimate ones with malicious codes; recommended controls are testing every displayed code and printing codes with the business name/logo. — [SpotOn](https://www.spoton.com/blog/tips-for-restaurants-avoid-qr-code-fraud/)
- [Independent press, UK] "Quishing" warnings for pubs and restaurants: guests are advised to check whether a fake code has been stuck over the original. — [The Scotsman](https://www.scotsman.com/news/crime/quishing-qr-code-scam-pub-warning-4696309)
- [Vendor docs] One open ordering platform (RestAI) creates a table session in "pending" status on scan; the guest sees a waiting screen and cannot order until staff approve the session from the dashboard/POS. — [RestAI docs](https://www.mintlify.com/EijunnN/restai/features/qr-ordering)
- [Academic paper, low-tier journal, no field test seen] Proposes replacing static table codes with time-based dynamic QR verification using cryptographic tokens, time-based expiry and session locking, explicitly to stop remote orders from shared photos. — [IJRASET](https://www.ijraset.com/research-paper/enhancing-user-experience-in-qr-based-restaurant-ordering-systems)
- [Vendor] SOLUM (electronic shelf label maker) markets e-paper table displays with periodically rotating dynamic QR codes to prevent phishing. — [SOLUM QR Order](https://www.solum-group.com/esl-n-iot/fnb-solution/qr-order)
- [Vendor blog] For online-order payment fraud, SpotOn describes using a third-party fraud service and requiring CVV on every order. — [SpotOn](https://www.spoton.com/blog/prevent-online-ordering-fraud/)

### Inferences
- A sensible layered design for a new POS: (1) the printed QR identifies only the table; (2) scanning creates a session that is valid only while the POS has that table open (waiter opens table = session allowed; bill closed = all tokens for that table die); (3) first order of a session, or any order from a new device, needs waiter confirmation on the handheld; (4) optional short PIN shown on the waiter's device or receipt for high-risk venues; (5) rate limits and item-count caps per session.
- Tying QR validity to an open POS table is cheaper than rotating e-paper codes and defeats the Kunming-style attack, because a photographed code is useless once the table is closed and visible to staff while it is open.
- Geofencing by browser location is weak on its own (permission prompts, indoor GPS error, spoofing) and adds friction; it is better as an optional extra than as the main control. Restricting ordering to the venue's Wi-Fi is a simpler variant but fails for guests on mobile data.
- Pay-at-table has less prank risk than order-at-table (a stranger paying someone's bill is not an attack), which is another reason to launch pay-first. The quishing risk is higher for payment, so the payment page must be on a recognisable domain and codes should be printed into branded table hardware rather than loose stickers.
- Waiter confirmation of orders also solves a service problem: staff stay aware of what each table ordered, which supports the hybrid model in section 1.

### Gaps
- No statistics on how often QR prank orders or restaurant quishing actually occur were found; evidence is anecdotal incidents and general warnings.
- No independent security audit or threat model of any commercial QR ordering product was found.
- No evidence found of incidents in Lebanon or the wider Middle East.

## 6. Shisha / hookah (argileh) lounge-specific technology

### Takeaway
Hookah-specific POS products exist but cover inventory, flavour-mix recipes, happy-hour pricing and age checks; no product found offers a guest-facing coal-change request or a per-hookah session timer, so this looks like an open niche.

### Cited Findings
- [Vendor] RPOWER Hookah POS: happy-hour pricing by day and time, and recipe/instruction text for house-mixed shisha flavour blends. — [RPOWER](https://www.rpowerpos.com/Home/Market-Vertical/Hookah-POS)
- [Vendor] Kavapp "hookah lounge automation": tracks tobacco/ingredient stock in the lounge and warehouse per operation, records staff work stages, QR menu with instant price and composition changes. — [Kavapp](https://kavapp.com/for-whom/hookah-lounge)
- [Vendor] POS Nation lists age verification and inventory management for hookah shops. — [POS Nation](https://posnation.com/blog/manage-hookah-shop)
- [Vendor] Other hookah-vertical POS pages: SalesVu and Bepoz. — [SalesVu](https://www.salesvu.com/blog/learn-more-about-salesvu-hookah-pos-system-and-their-integrated-modules/); [Bepoz](https://bepoz.com/restaurant-pos/hookah-bar-point-sale)
- [Vendor] Noctura (a Rivio product) advertises "streamlined hookah ordering" with table and booth management, with a "Puff+" package at EUR 299 per month; no coal or timer features mentioned. — [Noctura / Rivio](https://rivio-web.nuxt.dev/)
- [Vendor / app store] Generic time-based tools exist: Odoo "POS Time Based Order Management" module gives each order its own timer and shows a "Timer Over" popup prompting staff to bill or extend; a separate Odoo table time-counter module also exists. Not hookah-specific. — [Odoo Apps: table time counter](https://apps.odoo.com/apps/modules/19.0/cst_pos_table_time_counter); [Odoo Apps: gaming zone management](https://apps.odoo.com/apps/modules/19.0/pos_gaming_zone_management)
- [Vendor case studies] Hookah lounges already put the hookah menu on the same table QR as food: Menu Tiger's Haze Hookah Lounge case and an Otter case study of a Houston venue. — [Menu Tiger](https://www.menutiger.com/blog/haze-hookah-lounge); [Otter](https://www.tryotter.com/blog/case-study/houstons-ador-kitchen-cocktail-turns-tables-faster-with-otter)

### Inferences
- Two searches specifically targeting coal-change requests and hookah timers returned no product with those features. For a Lebanon-focused POS, where argileh is a core revenue line in cafes and restaurants, this is a plausible differentiator: (a) a "coal change" button on the table QR page routed to the argileh attendant's device, not the waiter; (b) a per-argileh timer started when the head is served, with staff prompts at a set interval for coal refresh and a "head finished, offer a new one" upsell prompt; (c) flavour-mix modifiers and per-head stock depletion.
- The timer doubles as an upsell and table-turn tool: a prompt when a head is likely spent is the natural moment to offer a replacement, analogous to the dessert prompt in section 4.
- Response-time logging on coal requests (section 2 logic) would give owners a service KPI for a role that is otherwise unmeasured.

### Gaps
- Absence of evidence is not proof of absence: Russian-, German-, Turkish- and Arabic-language hookah lounge software was not searched in those languages, and those are the largest lounge markets.
- No data on how argileh attendants are currently dispatched in Lebanese venues, or on argileh's share of venue revenue.
- No evidence on guest demand for a coal-request button.

## 7. Middle East / Lebanon specifics

### Takeaway
Qlub is the dominant regional pay-at-table brand (Dubai HQ, integrated with Foodics) but no evidence was found that it operates in Lebanon; the clearest local QR-menu evidence is Lebanese POS vendor BIM POS shipping an integrated QR-code menu, which means QR menus are table stakes locally rather than a differentiator.

### Cited Findings
- [Vendor] Qlub is headquartered in Dubai; diners scan a table QR, see the bill and pay with no app or registration; it integrates with Foodics POS. — [Foodics press, 2022](https://www.foodics.com/press/foodics-partners-with-qlub-to-bring-fastest-table-self-checkout-experience-to-its-dine-in-restaurants/)
- [Trade media, OLDER: Jan 2022] Qlub launched with a $17M seed round from Cherry Ventures and Point Nine, positioned as a competitor to sunday. — [TechCrunch](https://techcrunch.com/2022/01/31/sunday-competitor-qlub-emerges-with-17m-seed-round-from-cherry-and-point-nine/)
- [Trade media] Qlub later raised a further round reported as $30 million (Series B). — [Finextra](https://www.finextra.com/pressarticle/106410/restaurant-payments-app-qlub-raises-30-million); [MENAbytes](https://www.menabytes.com/qlub-series-b/)
- [Vendor] Qlub now markets pay-at-table, order-and-pay and a "qlub+ Rewards" programme, with country sites for the UAE, Australia and Brazil among others. — [Qlub UAE pay-at-table](https://qlub.io/ae/en/pay-at-table); [Qlub order and pay](https://qlub.io/ae/en/order-and-pay)
- [Vendor case study] In a Middle East case, tipping was not always customary and staff were uncomfortable asking; Qlub's pre-selected tip/service option raised tips "300%" versus manual payment. — [Qlub case study](https://qlub.io/ae/en/success-stories/LaPetite)
- [Vendor] Qlub uses Stripe for payments (Stripe customer story). — [Stripe](https://stripe.com/au/customers/qlub)
- [Vendor] Lebanese POS vendor BIM POS offers QR-code menus integrated with its POS; it showcased mobile QR menus at a Ramadan event in Lebanon in April 2024 where guests could order from more than 35 restaurants. — [BIM POS blog](https://bimpos.com/blog/what-are-the-benefits-of-the-integrated-qr-code-menu-for-restaurants); [BIM POS QR code menus](https://bimpos.com/node/1962)
- [Independent] A World Bank publication profiles a Beirut-founded software company whose contactless QR digital menu serves thousands of clients in MENA including Lebanon; the company name was not visible in the search summary. — [World Bank publication on Issuu](https://issuu.com/world.bank.publications/docs/9781464817359/s/16154782)
- [Marketplace listing] Freelancers on OLX Lebanon sell custom online/QR restaurant menus, indicating a low-cost commodity tier. — [OLX Lebanon](https://www.olx.com.lb/ad/online-restaurant-menu-ID116417850.html)
- [Vendor] Petpooja markets cafe POS in Dubai/UAE, an example of Indian low-cost POS vendors entering the Gulf. — [Petpooja UAE](https://www.petpooja.com/ae/poss/cafe-and-coffee-shop-pos-software)

### Inferences
- Qlub and sunday depend on card acquiring (Qlub on Stripe). Stripe does not serve Lebanese merchants and Lebanon's dining economy is heavily cash and USD based, so a Qlub-style card pay-at-table product probably cannot simply be switched on in Lebanon. This is an inference from general knowledge, not from a source found here, and should be verified. If correct, pay-at-table in Lebanon needs local rails (local wallets/acquirers) or a "request the bill / choose cash or card / split the bill on the phone, settle with the waiter" flow.
- Because a local competitor (BIM POS) already bundles a QR menu, a plain QR menu is baseline. Differentiation has to come from what the QR does after the menu: reorder, call-waiter/coal request, bill split, bilingual Arabic/English/French menus, dual-currency display, and optional 3D hero dishes.
- The Qlub tipping case (tips rose once the prompt removed the awkward ask) is the most transferable regional evidence for a suggested-tip screen, though the 300% figure is a single vendor case.

### Gaps
- No source found confirming Qlub operating in Lebanon, or its presence in Saudi Arabia beyond the Foodics partnership (Foodics is Saudi-based).
- No data on QR menu or QR ordering adoption rates among Lebanese restaurants, on Lebanese diners' attitudes to QR menus, or on mobile data speed/cost as a constraint.
- Other Lebanese POS vendors' guest-facing features (for example Omega) were searched for and nothing was returned.
- Which payment providers can support in-browser pay-at-table for Lebanese merchants was not researched here.
- The Beirut-founded QR menu company in the World Bank publication is unidentified.
