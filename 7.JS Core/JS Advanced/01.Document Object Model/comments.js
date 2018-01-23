

/*
* DOM tova e brawsera koito sme otvorili.
*
* Documenta e tova koeto sme otvorili
* a Object Model e nachina po koito sa predstaveni elementite
* v tova durvo.
*
*
* DOM API e neshto koeto ni pozvolqva da manipulirame DOM durvoto.
*
* Mojem da promenqme elementi ako sushtestvuvat, vzimame elementa
* s let d = document.getElementById("divOne"); zapisvame go v promenliva.
*
* Mojem i da suzdavame elementi
*
* S appendChld mojem da zakachame elementi za nqkoi drug element.
*
* S document.createElement('span'); suzdavame elementi, v sluchaq <span></span>
*
* let root = document.documentElement;  -  Ni vrushta cqloto durvo
*
* SELEKTIRANE:
*   Mojem da vzimame po :
*   1. document.getElementById('IdOfElement'); - vrushta purviq s tova ID.
*   2. ClasName
*   3. document.querySelektor('#main-nav'); koito raboti sus CSS, vrushta purviq.
*
*   KOLEKCII:
*   4. document.getElementsByTagName('li'); - vzima gi po samoto ime na elementa
*   5. document.getElementsByName('towns[]');
*   6. document.querySelektorAll('#main-nav');
*   KOLEKCIITE SE DURJAT KATO MASIVI.
*
*   VAJNO !!! :
*       let allLinks = document.links;
*           VRUSHTA NI KOLEKCIQ OT VSICHKI LINKOVE V NASHIQ KOD.
*
*       let textOfElement = element.textContent;
*           Vrushta ni celiq text v tozi element.
*           MOJEM I DA GO PROMENQME:
*
*           element.textContent = 'Something else !!!';
*
*           VAJNO:
*           AKO IMAME MNOGO CHILDS NA TOZI ELEMENT MOJE DA IZTRIE TEHNIQ TEXT !!!
*
*
* element.innerHTML; - ni pokazva kakvo ima kato HTML kod v dadeniq element
* MOJE DA BUDE PROMENQNO KAKTO SI ISKAME OBACHE PAK IZTRIVA KONTENTA VA VSICHKI CHILDOVE !!!
* VAJNO !!!
* ZATOVA VNIMAVAI ZA XSS ATAKI. !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
*
* element.outerHTML; - TOVA E SUSHTOTO SAMOCHE NI VRUSHTA I SAMIQ ELEMENT !!!!
*
* Ako imame input i iskame da mu vzemem kontenta
* polzvame lt val = inputName.value;
* MOJEM I DA GO PROMENQME OT KONZOLATA KOETO GO
* PROMENQ I V SAMATA FORMA.
*
* KAKUVTO I TIP FORMA DA IMAME DORI I DA NAPISHEM CHISLO TO
* SHte DOIDE KATO STRING TAKACHE TRQBVA DA GO PARSNEM ZADULJITELNO.
*
* VAJNO !!!
* AKO IMAME KLASS GO VZIMAME S element.className;
*
*
*
*
* CSS Selectors:
*   Chrez tqh mojem da namirame elementi.
*   document.querySelector(); - vrushta ni purviq element s takuv selektor.
*   document.querySelectorAll(); - vrushta ni kolekciq ot vsichki
*   MOJEM DA SELEKTIRAME PO KLAS, PO ID.
*   Primer '#Content div' VSICHKI DIVOVE V ELEMENTA S Id DIV.
*   PO POLZVANO E V JQUERY.
*
* */

/*
* BROWSER OBJECT MODEL ( BOM )
*
* Documenta e chast ot brawsera no toi ima i drugi instrumenti:
*       Window - [navigator, screen, document, history, location]
* MOJEM DA PROMENQME VSICHKO V TOZI window.
*
* Nie osnovno shte rabotim s document, v koito shte imame
* ostanaliq kod kato divove formichki i dr.
*
*
*   location otgovarq za tova kude se namirame
*   screen sudurja vsichko svurzano s nashiq ekran
*   history ni kazva koi stranici sme otvarqli.
*
*
*   navigator.language  -  kazva ni na kakuv ezik sme
*   window.navigator.userAgent  -  kazva ni versiqta na brawsera
*
*
*   TIMERS:
*       V js mojem da polzvame timeri sus setInterval(function(){
*       console.log("1 sec. passed");
*       }).
*
*
*
* Math.trunc() i Math.floor() sa podobni obache imat razlika pri
* izmervaneto na otricatelnite chisla, pri pozitivnite sa ednakvi.
*
*
* */


