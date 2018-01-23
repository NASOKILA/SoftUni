
/*

VAJNO !!!
Vij https://playcanvas.com
TAM IMA MNOGO BRAWSERSK IGRI

* Shte Pravim IGRA.
* Shte prerabotvame elementi s JS, shte pravim event andeling
* shte rabotim i v HTML
*
* Shte polzvame Canvas 2D :
* S koeto mojem da risuvame, da pravim
* animacii, mause eventi, mojem da rabotim s figurki, textove,
* kartingi i dr.
*
* Igrata koqto shte pravim shte bude v brawsera.
*
* Canvas e chast ot HTML 5 poddurja i 3D mojem da pravim grafika
* v samiq browser.
*
*Predi HTML5 beshe po trudno da se pravqt teq igri.
*
* V HTML5 canva se definira s taga <canvas>
* V JS si go vzimame s document.getElementById();
*
* sus let ctx = canvas.getContext("2d");
* Tova ste ni dade platnoto s koeto mojem da risuvame.
*
* ctx.beginPath() - zapochvame nova forma
* ctx.moveTo(x,, y) - murdame kursora
* ctx.lineTo() - chertaem liniq ot kursora do koordinatite
* ctx.closePath() - chertae liniq ot poslednata tochka do purvata tochka i zatvarq formata
* ctx.stroke() - tova e za da mojem da vidim formichkata koqto sme suzdali.
* ctx.fill() -  s tova zapulvame formichkata s daden cvqt
*
* MOJEM DA PROMENQME CVETOVETE NA LINIITE, FIGURITE I VUTRESHNIQ CVQT
* NA FIGURITE.
*
* ctx.arc(75,75,50,0,Math.PI*2,true) - ni pravi krug s podadenite parametri
*
* ctx.drawImage(image, ...coordinates) - slagame snimka tam kudedo iskame
*
* Mojem da cropvame kartinki t.e. da gi cutvame.
*
*
*   Draw text:
*   Mojem i da chertaem text v dadena poziciq na kanvasa:
*   ctx.strokeText(text, x, y);
*
*   Mojem i da go ocvetqvame.
*   ctx.fillText(text, x, y);
*
*   Mojem da promenqme fonta i centrirovkata:
*   ctx.font();
*   ctx.textAlign();
*
*   MOJEM DA PRAVIM POCHTI VSICHKO !
* */


/*
*
* ANIMATIONS:
* Animaciite se pravqt po stariq nachin, kato postoqnno
* promenqme kontexta na kanvasa.
*
* Za Kartinkite mojem postoqnno da promenqme katrinkite
* za da se poluchi dvijenie.
*
* Ako imame obekt i iskame da go pomrudnem prosto mojem
 * da mu smenim poziciqta.
 * Vremeto v koeto se sluchva vsichko tova go opredelqme s
 * let timer = setInterval(func, t);
 * clarInterval(timer); - spira ni timera.
 *
 * MOJEM DA PRAVIM MNOGO NESHTA S ANIMACIITE V JS.
*
* */


/*
* Event Handling:
* Eventite sa neshta koito se sluchvat v brawsera,
* moje da e neshto koeto usera e napravil, moje da e
* otgovor ot server na napravena ot nas zaqvka.
*
* Po izvestnite eventi se suzdavat ot usera, t.e.
* natiskane na buton ot klavieturata, dvijenie na mishkata,
* clickvaniq i dr.
*
* SUS FUNKCIQTA target.addEventListener(type, function);
* Nie zakachame event na daden element i kazvame koq
* funkciq da go obraboti.
* VECHE GO ZNAEM TOVA !!!
*
* 'keyDown' eventa slusha za ako natinem kopche ot klavieturata
* i posle moje da vidi koe kopche sme natisnali i da napravi
* dadeno neshto v zavisimost ot koe kopche sme natisnali.
*
*
* Ako iskame da vzemem nqkakuv event ot mishkata imame
* event.clientX;  i  event.clientY;
* ili event.offsetX; i event.offsetY;
*
* */



/*
* Main Game Loop:
* Tova e nachina po koito rabotat mnogo igri.
* Ima start na igrata pravqt se nqkakvi neshta i nakraq
* se proverqva dali igrata vse oshte e aktivna.
* Ako e taka pak se vurti sushtiq cikul ako ne e aktivna
* prosto izlizame ot neq.
*
* Tova se pravi kato nakraq na funkciqta izviame
* requestAnimationFrame(ImetoNaFunkciqtaVKoqtoSme);
*
*
*
* */







