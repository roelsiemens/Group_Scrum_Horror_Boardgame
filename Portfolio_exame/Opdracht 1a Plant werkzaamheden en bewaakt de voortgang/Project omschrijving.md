# Algemene informatie project

**Naam opdrachtgever:** Arjen de Haan

**Scrum master:** Roël Siemens **Teamleden:** Barrie Doornbos, Cameron Luttje, Lisa Werner

**Naam project:** Still down here

## Introductie

**Still down here** is een first-person survival horror game waarin de speler gevangen zit in
een dungeon en genoeg schatten moet verzamelen om te ontsnappen. Hoe dichter de
speler bij de vrijheid komt, hoe zwaarder de buit word en hoe moeilijker het wordt om de
monsters uit het diepe te onsnappen.

## Eisen/Wensen

'Horror Bordspel'

Er bestaan veel klassieke bordspellen, van dammen tot schaken, van Monopoly tot Mens Erger Je Niet. Je hebt natuurlijk ook tientallen leuke kaartspellen. Het doel van dit project is om één van die klassiekers nieuw leven in te blazen door er een horror game van te maken. Een aantal randvoorwaarden:

- De game is speelbaar op PC. Het mag bestuurd worden met muis en toetsenbord of een gamepad.
- De game is gebaseerd op een bord-of-kaartspel dat minstens 50 jaar oud is. Jullie mogen zelf kiezen welke.
- De game hoeft niet letterlijk een bord-of-kaartspel te zijn, maar moet wel duidelijk gebaseerd zijn op jullie gekozen spel - en niet alleen visueel. Ik verwacht niet "Slenderman maar je wordt achtervolgd door een schaakstuk." Denk goed na over hoe jullie gekozen game werkt en hoe je dat kunt vertalen naar een horrorgame. 
- In dit project maken jullie een 'vertical slice.' De game heeft een start en einde en daar tussenin bestaat een korte maar complete demonstratie van hoe de game speelt.
- De game is zo gebouwd dat ik na de tijd eventueel extra levels of onderdelen kan toevoegen om het verder uit te breiden.


<details>
<summary>Feedback pitch 1</summary>
<img src="img/Screenshot 2026-04-14 134335.png" alt="Mail 1" width="500">
</details>
<details>
<summary>Feedback pitch 2</summary>
<img src="img/Screenshot 2026-04-14 135504.png" alt="Mail 1" width="500">
</details>
<details>
<summary>Feedback e-mail</summary>
<img src="img/Screenshot 2026-04-14 135716.png" alt="Mail 1" width="500">
</details>

<br>
Na alle pitches en besprekingen kwamen we met de opdrachtgever overeen en hebben daar alle eisen en wensen onderbouwd.

<br>

**De game is speelbaar op PC. Het mag bestuurd worden met muis en toetsenbord of een gamepad.**

In onze game gaan we een spelercontroller maken die door toetsenbord en muis is te besturen. Deze keuze hebben we gemaakt, omdat dit de meest gebruikte controller is voor pc games. 

Dit is de bijbehorende Userstory.
* Als speler wil ik kunnen rondlopen en verstoppen, zodat ik rond de map kan komen en me kan verstoppen voor de monsters
    
    Done wanneer:
    * De speler met zijn toetsenbord kan lopen
    * De speler met zijn toetsenbord kan bukken
    * De speler kan rondkijken met zijn muis

<br>


**De game is gebaseerd op een bord-of-kaartspel dat minstens 50 jaar oud is. Jullie mogen zelf kiezen welke.**

We hebben hiervoor gekozen voor het bordspel Dungeon (Uileg over borspel:https://boardgamegeek.com/boardgame/1339/dungeon). We hebben gekozen om ons spel een dungeon crawler te maken en hierbij hebben we dan een dungeon map waar meerdere monsters rondlopen die je willen pakken. 

Dit zijn de bijbehorende Userstory's:

* Als speler wil ik een enge map hebben waar kamers met loot in zitten
    
    Done wanneer:
    * Er een volledige map is waar de speler zich in verdwaalt kan raken
    * Er prefabs zijn gemaakt, zodat de map makkelijk uit te breiden is
    * Er kamers zijn met loot

* Als speler wil ik een enge ai monster hebben die rondjes om de map loopt

    Done wanneer:
    * Er een AI is die random punten pakt uit de map om heen te lopen
    * De AI de speler detecteert en achter hem aan gaat
    * De speler kan vangen en laat teleporten naar een Random kamer zonder loot
    * Alle bijbehorende functies aanpasbaar zijn in de game engine

**De game hoeft niet letterlijk een bord-of-kaartspel te zijn, maar moet wel duidelijk gebaseerd zijn op jullie gekozen spel - en niet alleen visueel. Ik verwacht niet "Slenderman maar je wordt achtervolgd door een schaakstuk." Denk goed na over hoe jullie gekozen game werkt en hoe je dat kunt vertalen naar een horrorgame.**

We hebben hier goed overna gedacht en kwamen tot het volgende: De speler zit in een dungeon net als in het bordspel. De speler gaat kamers verkennen om loot te verzamelen. Dit hebben we iets veranderd, omdat hierdoor het spel spannender is om te spelen anders moest je dobbelen en was het helemaal geen horror. Daarom hebben we een sanity meter gemaakt die je forceert om te ontsnappen van de monsters. En als laatst moet je de aangewezen loot aantal verzamelen en terug gaan naar start. Dit hebben we overgenomen van het bordspel met een kleine twist. In ons spel weet je niet hoeveel loot je uiteindelijk nodig hebt, waardoor het enger en spannender word om te exploren.

Dit zijn de bijbehorende Userstory's:

* Als speler wil ik een sanity meter die mijn visie gekker maakt als me sanity 0 is

    Done wanneer:
    * De sanity meter van 100 naar 0 kan dalen
    * De speler gold laat vallen en dat er enge geluiden worden afgespeelt als de sanity 0 is
    

**In dit project maken jullie een 'vertical slice.' De game heeft een start en einde en daar tussenin bestaat een korte maar complete demonstratie van hoe de game speelt.**

In ons spel gaan wij dit verwerken door tijdens het spelen simpele instructies te laten zien, zodat de speler tijdens het spelen het spel begint te begrijpen en dan in 1 keer door kan. 

* Als speler wil ik een simpele tutorial hebben die me het spel goed uitlegt

    Done wanneer:
    * De speler simpele instructies kan volgen
    * De game start wanneer de tutorial voltooid is

**De game is zo gebouwd dat ik na de tijd eventueel extra levels of onderdelen kan toevoegen om het verder uit te breiden.**

Om het spel verder uitbrijkbaar te laten maken hebben gaan we tijdens het maken van het spel als voorbeeld de map maken met prefabs, zodat je de map steeds verder kan door bouwen. Met de monsters gaan we een script maken die je via de Game software(Unity) in de inspector de waardes zoals: Snelheid, detectie afstand en kijkhoek kan aanpassen.

* Als speler wil ik een enge ai monster hebben die rondjes om de map loopt

    Done wanneer:
    * Er een AI is die random punten pakt uit de map om heen te lopen
    * De AI de speler detecteert en achter hem aan gaat
    * De speler kan vangen en laat teleporten naar een Random kamer zonder loot
    * Alle bijbehorende functies aanpasbaar zijn in de game engine

* Als speler wil ik een enge map hebben waar kamers met loot in zitten
    
    Done wanneer:
    * Er een volledige map is waar de speler zich in verdwaalt kan raken
    * Er prefabs zijn gemaakt, zodat de map makkelijk uit te breiden is
    * Er kamers zijn met loot

## Gebruikte technieken

We hebben gekozen om de game te maken in unity, omdat iederen in onze groep hier het bekendste mee is. 

Wij gaan gebruik maken van de volgende Technieken/Softwares:

- **Unity:** Unity is de software waar onze game in gemaakt word. in Unity gaan we onder andere alle game mechanics maken zoals: Spelercontroller/camera, vijanden en random loot drops.

- **Blender:** Blender gaan we vooral gebruiken voor 3d modellen die worden geplaatst in onze game zoals: vijanden modellen, chest model, item modellen exc.

- **Github:** Github gebruiken we zodat we samen kunnen werken aan één project. Door commits (het verzenden van de veranderingen) kunnen we elkaar hun veranderingen gebruiken en mergen (het mengen van twee apparte branches) in één grote branch (een tak waar apparte veranderingen komen en die later gemerged kunnen worden met andere takken) en zo een afgeronde spel opleveren. Github projects gebruiken we ook voor het plannen van alle taken en het overzichtelijk maken, zodat alles soepel verloopt.