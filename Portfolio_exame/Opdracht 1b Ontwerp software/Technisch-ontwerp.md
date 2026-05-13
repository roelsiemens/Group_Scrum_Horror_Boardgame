# Technisch ontwerp

## classes opbouw

<details>
<summary>Class diagram</summary>
<img src="img/Still Down Here - class diagram.png" alt="Class diagram" width="100%">
</details>

### Uitleg class diagram

De class diagram is gemaakt voordat we met de game zijn begonnen, dus dit waren de classes, variablen en methodes waarvan we hadden bedacht dat ze nodig waren in Still down here.

De <b>player</b> class heeft als variablen de BaseSpeed en CurrentSpeed, omdat we het idee hadden om de player langzamer te laten bewegen als hij meer coins op zak zou hebben, en de UpdateSpeed methode om die logica toe te passen.

De <b>inventory</b> class is afhankelijk van de player, want zonder player is er geen inventory.
De variablen LeftHand en RightHand zijn je inventory 'slots' en de GoldPouch is om het gold uit de chests in te doen en mee te nemen. De methodes zijn voor het oppakken en neerleggen van items, en het vullen en leeghalen van de gold pouch.

De <b>escapeAltar</b> class gaat voor het altar bij de ingang waar je je gold inlevert. Deze heeft de variablen GoldNeeded voor de totale gold coins die je moet inleveren, en GoldDelivered voor de totale hoeveelheid die is ingeleverd door de speler. De methode DespositAmount laat de player een bepaald aantal coins neerleggen. De IsComplete methode controleert of de hoeveelheid coins die ingeleverd zijn genoeg zijn om de deur te openen.

De <b>sanity</b> class is voor de sanity meter. We wisten nog niet precies wat we wilden doen bij verschillende levels van sanity, maar wel dat we het gingen gebruiken. De variable RegenerateAmount is voor de hoeveelheid sanity dat je terugkrijgt als je 'veilig' bent. De methode LossOverTime zorgt ervoor dat je na bepaalde tijd een beetje sanity verliest.

De <b>monster</b> class gaat voor het monster dat door de dungeon heen loopt. Hij heeft de variablen MovementSpeed om zijn snelheid in te stellen en de PlayerDetected bool om te controleren of de player in zijn zicht is. De methodes patrol en followPlayer zijn de 2 states waarin de enemy zich verkeert. Hij patroulleert de dungeon of als hij de player ziet volgt hij de player.

De <b>torch</b> class is voor de torch die in de dungeon hangt. Met de torch kan je meer zien in de dungeon, maar het monster detecteert jou ook sneller. De variablen zijn voor de hoeveelheid extra zicht die je hebt, hoelang de torch brandt totdat hij opgebrand is en de monster detection. De methode isBurntOut is om te controleren of de torch is uitgebrand of niet. De use methode kijkt of de player de torch vasthoudt en hem daarmee in gebruik heeft.

De <b>spell</b> class gaat voor de spell die je kan gebruiken om een monster te stunnen. De variable gaat voor de tijd dat het monster gestunt is. De methode gaat voor het gebruiken van de spell.

De <b>goldcoins</b> class is voor de gold coins die je in de treasure chest kan vinden. De variable gaat voor de hoeveelheid coins in de chest. De methode gaat voor het ophalen van deze hoeveelheid om dit in de pouch te kunnen toevoegen.

De <b>jumpscare</b> class is voor de jumpscare die in een chest kan zitten. Als je dit krijgt gaat je sanity naar beneden. Daar zijn de variable en de methode ook voor.

De <b>treasureChest</b> class is voor de chest die je kan vinden in de dungeon. De methode open is voor het openen van de chest. De methode getContents is voor het genereren van de loot in de chest. dit is 1 van de items, zonder de Torch, of de chest kan leeg zijn. In een treasure chest kan maximaal 1 spell of jumpscare zitten (0..1) of gold coins (0..*). Als dit er allemaal niet in zit is de chest leeg en moet je verder zoeken.

## Gameplay loop

<details>
<summary>Class diagram</summary>
<img src="img/Still Down Here - activity diagram.png" alt="Class diagram" width="100%">
</details>

### Gameplay logica

In het bovenstaande diagram is de gameplay loop van Still down here te zien.
Je start aan het begin van de dungeon en gaat op zoek naar kisten met geld of items. Als je een kist hebt gevonden kan je hem openen en heb je kans op een willekeurig item. Als je tijdens je zoektocht een monster tegenkomt moet je hem zien kwijt te raken. Als je een spell hebt kan je deze gebruiken om het monster te 'stunnen' zodat je makkelijker weg kan komen. Als je geen spell hebt moet je op andere manieren proberen het monster kwijt te raken. Als dit niet lukt en het monster pakt je word je in een willekeurige lege kamer in de dungeon neergezet en raak je een gedeelte van je geld kwijt. Als je de weg terug naar de ingang hebt gevonden kan je je geld op het altaar neerleggen. Als er genoeg geld op het altaar ligt gaat de deur open en ben je vrij. Als dit nog niet het geval is moet je terug de dungeon in om meer geld te verzamelen.

## Ethiek, Privacy en Security

### Ethiek

Tijdens het ontwerpen van de game is rekening gehouden met de ervaring van de speler. Hoewel de game horror-elementen bevat, zoals jumpscares en een sanity-systeem, zijn deze bedoeld om spanning toe te voegen en niet om kwetsende of discriminerende inhoud te tonen.

De game bevat:

- geen geweld tegen echte personen;
- geen discriminerende of beledigende content;
- geen microtransacties of verslavende betaalsystemen;
- geen manipulatieve systemen voor persoonsgegevens of advertenties.

Het doel van de game is om een spannende maar leuke gameplay-ervaring te bieden.

### Privacy

Still Down Here is een singleplayer game die volledig lokaal draait op de computer van de gebruiker. De game maakt geen verbinding met externe servers of online diensten. Er worden geen persoonsgegevens verzameld, opgeslagen of gedeeld. Hierdoor zijn er geen privacyrisico’s binnen het project.

### Security

Omdat de game offline draait, zijn de beveiligingsrisico’s beperkt. Er is geen online functionaliteit aanwezig waardoor gebruikersgegevens onderschept of misbruikt kunnen worden.

Binnen de code is wel rekening gehouden met eenvoudige validatie en foutafhandeling, zoals:

- controleren of een inventory-slot leeg is voordat een item wordt toegevoegd
- voorkomen dat treasure chests meerdere keren geopend kunnen worden
- controleren of sanity niet onder de minimale waarde komt

Hierdoor blijft de gameplay stabiel en worden onverwachte fouten verminderd.