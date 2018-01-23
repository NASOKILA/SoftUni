
/*
*
*
* 1.Shte triem i suzdavame elementi
* 2.Shte gledame tehnite atributi
* 3.Shte slushame za eventi v brawsera
*
* let el = documnt.createElement("li");  -  suzdava elementi
* .append() / .appendChild() go zakacha za drugi elementi.
*
 let ul = document.createElement('ul');
 let li = document.createElement('li');
 li.textContent = 'Hello Firts Element';

 VAJNO !!!!!!  :
     sus li.appendChild(document.createTextNode(someText)); - taka dobavqme text
     kum tova li bez da triem stariq. !!!!!!!!!!!!!!!!

 ul.appendChild(li);

 VAJNOOOOOOO !!!!!!!!!!! :
 Sus ul.insertBefore(li);  -  dovabq li-to v nachaloto kato purvi element.

 Mojem da vkarvame cql HTML kod v daden element s innerHTML.

*/


/*
//KAK se triqt elementi:
//Vzimame elementa i GO OTKACHAME OT PARENTA MU s .removeChild():
    li.parentNode.removeChild(li);


VAJNOOOO !!!!!!!!!:
this sochi kum tova vurhu koeto sme kliknali.
*/

/*
*   EVENTS :
*     Sus event.target  VZIMAME ELEMENTA KOITO DURJI EVENTA.
*
*   MOUSE EVENTS:
*       click - kogato kliknem mishkata, tova e kombinaciq ot mouseDown  i mouseUp.
*       mouseOver - kogato hovernem dadeno neshto
*       mouseOut - kogato si mahnem mishkata ot tam
*       mouseDown - kogato leviq buton na mishkata e natisnat
*       mouseUp - kogato leviq buton na mishkata e otpusnat
*
*   KEY EVENTS:
*       keydown - kogato natisnem dadeno kopche
*       keyUp - kogato otpusnem dadeno kopche
*       keypress - kombinaciq ot dvete
*
*   TOUCH EVENTS: te sa za touchscreen aparati
*       touchstart
*       touchend
*       touchmove
*       touchcancel
*
*   FOCUS EVENTS: te sa za fokus na daden obekt
*       focus - pravi go po chisto
*       blur - pravi go po mrejavo
*
*   DOM EVENTS: te sa za DOM ELEMENTI
*       load(finished load)
*       unload(exit from page)
*       resize(window resized)
*       dragstart / drop

    FORM EVENTS: te za za formi
        input
        change
        submit
        reset




    KAK SE ZAKACHT EVENTI?
    Tova veche go znaem.
    Sus element.addEventListener('event', function);


*
*
*
*
* */










