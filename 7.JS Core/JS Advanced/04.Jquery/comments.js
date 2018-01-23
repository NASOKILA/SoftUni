
/*

JQUERY:
Tova e biblioteka na JS.
VKLUCHVA SE TAKA:
<script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
Ili moje da se iztegli lesno ot neta

Jquery pravi poveche s po malko kod,
ima poveche funkcii,
i ni ulesnqva mnogo rabotata s JS.
Ima i dopulnitelni neshta, naricha se VANILA JS.

uprostqva ni manipulaciqta na DOM durvoto
MOJEM DA IZPRASHTAME AJAX ZAQVKI KOETO E ZAQVKA KUM SERVER.

Nehstata se dostupvat s :
$('li')  -  primerno s li element.
$('li')[0] ako imame mnogo lita se durji kato masiv, vzimame purviq.
$('li').css('background','red')  -  taka promenqme css-a.

JQUERY SE POLZVA NAI MNOGO, 85% ot top saitove ZASHTOTO E
MNOGO LEKA, PO LEKA E OT Angular 1 I SE UCHI MNOGO LESNO.
PODDURJA SE POSTOQNNO I SE RAZVIVA.
RAVBOTI PO VSICHKI BRAWSERI.

V skobite mojem da slagame i samite elementi.

$(document).ready(function(){});  -  tova ozn kogato e gotov elementa

.click() zakachame click event na daden dokument.




SELEKTORI:  Ima mnogo

 $('*')  -  selektira vsichko
 $("body *") - selektirai vsichko v body-to

 $('div') - po element
 $('#SomeId') - po id
 $('.SomeClass') - po klas

AKO IMAME POVECHE PAK VRUSHTA KOLEKCIQ.

 $('li:even') - hvashta vsichki chetni li-ta
 $('li:odd') - hvashta vsichki NEchetni li-ta
 $('li:first') - purvoto li
 $('li:last') - poslednoto li

 $('li:nth-child(2)') - vtoroto li
 $('li:eq(2)') - sushtoto e kato nth-child OBCHE ZAPOCHVA OT 0

 $('ul.menu li') - vuv vsichki spsuci s klas .menu tursi vsichki li elementi.

VAJNO !!!!! :
sus :not obrushtame funkciqta.
 $('li:not(:checked)') - obrushtame funkciqta.


VAJNOOOOOOOOOOOOOO !!!!!!!!!!!!!!!!
    AKO IMAME ul s li-ta i v tqh imame pa ul s li-ta :

$('ul>li') - hvashta litata OBACHE BEZ NESTNATITE
$('ul li') - HVASHTA I NESTNATITE LI-ta



KAK DA PROVERIM DALI GO IMA ?

 $('li').has('p')  -  Proverqvame dali sudurja 'p' element.
 $('li').contains('SomeText')  -  Proverqvame dali sudurja daden text.

AKO ELEMENTA E OT TIP Jquery
ZA DA VZEMEM TETA POLZVAME .text()
A AKO I DADEM PARAMETUR SHTE ZAMESTI CELIQ TEKST S PARAMETURA.

Tuk imame .each()  KOETO E KATO foreach
.toArray() go prevrushtame v masiv.

MOJEM DA POLZVAME INTERPOLACIQ:
let res = 'li';
$(`#ul ${res}`) - edno i sushto e kato $('ul li')

VAJNO !!!!!!!!!!!!!!!!!! :
.toString() - znaem q, TUK NIE MOJEM DA SI Q PREDEFINIRAME KAKTO SI ISKAME !!!


S .val vzimame stoinost ot input pole


FUNKCII ZA ZAKACHANE I RAZKACHANE NA ELEMENTI
.append() / .appendTo()  -  vkarva gi na posledna poziciq
.prepend() / .prependTo()  - ako e v spisuk gi vkarva na purva poziciq

TRIENE NA ELEMENTI:
$('...').remove()


NAI VAJNOTO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!:
Ne mojem da izvikvae jquery funkcii vurhu JQUERY elementi.
Trqbva purvo da gi prevurnem v jquery elementi sus $('...');


.insertBefore()  i  .insertAfter() v JQUERY SE POLZVAT MNOGO.
S tqh mojem da slagame elementi predi i sled drugi elementi.


.show() pokazva elementa t.e. slaga display: block;
.hide() skrivame elementa t.e. slaga display: none;
.fadeIn() bavno skrivame elementa.
.fadeOut() bavno se poqvqva elementa.


QUERY EVENTS :
.click() ili .on('click', function)  -  a klick event
    ZA PREMAHVANE NA EVENT KAZVAME .off('click', function);


VAJNO !!!!!!!!!!!!!!!!!!!!!!!!! :
.on() PRIEMA I VTORI PARAMETUR KOITO MOJE DA NI SLUJI ZA :

Example:
    ul.on('click', 'li', function(){...});
VTORIQ PARAMETUR E VURHU KAKVO V TOZI UL DA VAJI KLIK EVENTA
V SLUCHAQ NA 'li' ELEMENTITE.



JQuery Plugins:
    Jquery e dosta poddurjano i  ima gotovi za polzvane plugini koito
    niulesnqvat rabotata oshte poveche.

    Primerno :
    01.Tabs - $('...').tabs(); gi prevrushta v tabove
    02.Sort by dragging and dropping  -  $('...').sortable();

Tova sa plugini koito mojem da svalim i da polzvame.






VAJNOOOOOOOOOOOO !!!!!!!!!!!!!:
JQuery = $
Hover event v JQUERY e mouseover



SUMMARY:
    JQUERY e nai populqrnata JS biblioteka.
    01.selektirane i editvane na DOM elementi,
    02.create, delete and manipulate elements,
    03.Event handling: click(), on('click', ... , ...)








*/



