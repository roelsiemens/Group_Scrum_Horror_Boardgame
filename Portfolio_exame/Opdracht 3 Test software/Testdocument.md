# <center>Still down here
<font color= grey> <center> By Roël Siemens, Barrie Doornbos, Lisa Werner, Cameron Luttje.</center> </font>

### <center>Inleiding
<center>Dit is het testplan voor Still down here, gemaakt door Roël Siemens,Barrie Doornbos,Lisa Werner en Cameron Luttje. Hierin staan onze testcases en testresultaten</center>

### <center>Doel van de test</center>
<center>Het doel van de test is om de userstory's te testen voor hun funcionaliteit.</center>


## <center>Testers
### test 1
|Tester|Userstory's|Wanneer|Doorlooptijd test|Test omgeving|
|-|-|-|-|-
|Hedin|1/6/10|8/04/2026|11:30 tot 11:40|AVO les lokaal 1150, Muntinglaan 3
|Zoë|7|8/04/2026|11:40 tot 11:50|AVO les lokaal 1150, Muntinglaan 3
|Sven|3|8/04/2026|11:50 tot 12:00|AVO les lokaal 1150, Muntinglaan 3


|volgnmr/beschrijving|Userstory|Testscenario|Test input|Verwachte uitkomst| Werkelijke uitkomst| Conclusie test
|-|-|-|-|-|-|-
|1.Lopen/Camera |Us-1: Als een speler wil ik kunnen rondlopen en verstoppen, zodat ik rond de map kan komen en me kan verstoppen voor de monsters|De speler staat in scene met een kleine ruimte om in te bewegen|De speler start de scene en klikt op w,a,s,d|Je karakter beweegt rond met de juiste input|De speler loopt en kan rondkijken met camera|De speler loopt goed en kan soepel rondkijken, maar de speler was iets te snel voor een horror game
|2.Verstoppen |Us-1: Als een speler wil ik kunnen rondlopen en verstoppen, zodat ik rond de map kan komen en me kan verstoppen voor de monsters|De speler staat in een scene met een verstop plek|De speler loopt in een verstop plek|De karakter kan zich verstoppen in een verstop plek|2|2
|3.AI Pathfinding |Us-2: Als speler wil ik een enge ai monster hebben die rondjes om de map loopt|De speler start een scene met een ai monster|De speler start de scene en ziet de monster rondlopen|De ai monster loopt rond de map|De ai loopt rond de map via willekeirige punten|De ai werkt zoals die hoort te werken.
|4.Map |Us-3: Als speler wil ik een enge map hebben waar kamers met loot in zitten|De Speler staat in een scene met een map|De speler start de scene en loopt rond de map|De map is mooi|4|4
|5.Kamers|Us-3: Als speler wil ik een enge map hebben waar kamers met loot in zitten|De speler staat in een scene met 1 van de kamers|De speler start de scene en staat in een kamer|De speler staat in een kamer|5|5
|6.chest systeem|Us-4: Als speler wil ik een chest hebben met een random reward|De speler staat in een kamer met een chest|De speler start de scene en open de chest met E|De speler ontvangt een random reward na het openen van de chest|De speler kan de chest openen en ontvangt een random reward|De chest systeem werkt goed alleen de uitleg tekst was door de visuele effecten niet te lezen
|7.Sanity meter|Us-5: Als speler wil ik een sanity meter die mijn visie gekker maakt als me sanity 0 is|De speler staat in een scene met een werkende sanity meter|De speler start de scene en de  sanity meter loopt naar beneden loopt|De speler krijgt een gekkere visie als de sanity meter op 0 staat|De speler zijn sanity gaat langzaam omlaag, maar er gebeurt nog niks met je scherm|De sanity meter wat viseuler maken zodat het wat beter bij een horror game past.
|8.Vfx/Sound effects| Us-6: Als speler wil ik meesleepende visuals/jumpscares hebben en zenuwslopende sound effects hebben|De speler staat in een scene met de visuele effecten en werkende sound effects|De speler start de scene en ziet de visuele effecten en een aangewezen developer speelt de sound effects af|De speler ziet de visuele effecten en kan de sound effecten goed en duidelijk horen|8|8
|9.Jumpscares|Us-6: Als speler wil ik meesleepende visuals/jumpscares hebben en zenuwslopende sound effects hebben|De speler staat in een scene met een werkende jumpscare| De speler start de scene en triggert de jumpscare via de chest met de toets E| De speler krijgt een jumpscare als die de chest opent|9|9
|10.Inventory|Us-7: Als speler wil ik items kunnen oppakken en meenemen met een beperkte inventory systeem|De speler staat in een scene met items die hij/zij kan oppakken|De speler start de scene en pakt de items op met de linker muisknop voor de linkerhand en de rechter muisknop voor de rechterhand, De speler kan de linker item droppen door linker muisknop in te huiden en rechter item door de rechter muisknop in te houden|De speler kan de items oppakken en loslaten|De speler kan de items oppakken en droppen|De speler kan alle items oppakken, maar he oppakken is niet accuraat en daardoor kan je dingen achter je ook oppakken.
|11. Enemy Design(asset)|Us-8: Als speler wil ik enemy en item designs hebben voor een betere spel beleving|De speler staat in een scene met een enemy design|De speler start de scene en ziet voor zich een enemy design|De speler ziet de enemy design|11|11
|12. Item designs(assets)|Us-8: Als speler wil ik enemy en item designs hebben voor een betere spel beleving|De speler staat in een scene met item designs| De speler start de scene en ziet voor zich een paar item designs|De speler ziet de item designs|12|12
|13. Spellcasting|Us-9: Als speler wil ik een Spell hebben die de enge monster kan paralyzeren voor een bepaalde tijd| De speler staat in een scene met een spell in zijn hand en een enemy die hem volgt|De speler start de scene en schiet met de toets spatie om de enemy te paralyzeren|De speler paralyzeert de enemy|13|13 

## Test 1 conclusie

Na alle testen was duidelijk dat de mechanics goed werkte, maar niet alles was perfect. Een voorbeeld is bijvoorbeeld de inventory systeem waar je dingen die je niet zag ook zomaar kon oppakken. Dat hoort niet te kloppen. De rest van de verbeter punten die we hebben ontdekt schrijven we op en verbeteren we. Voor de rest was de test succesvol, want we kregen veel positieve feedback. 