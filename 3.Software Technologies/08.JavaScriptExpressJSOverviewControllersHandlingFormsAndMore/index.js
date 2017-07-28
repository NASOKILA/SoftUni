/**
 * Created by nasko on 30/04/2017.
 */

const cat = require('C:/xampp/htdocs/JavaScriptExpressJSOverviewControllersHandlingFormsAndMore/cat.js');


//CONST E PROMENLIVA KOQTO EN SE PROMENQ
//REQUARE IZPULNQVA DADEN FAIL NO TRQBVA DA NAPISHEM CELIQ PUT DO NEGO


console.log('dog');// PURVO IZPULNQVA cat i posle dog ako v cat imame samo console.log



 //      console.log(cat.name);           TOVA NI DAVA GRESHKA
// ZASHTOTO NIE TRQBVA DA KAJEM NA KOI MODUL KOE NESHTO MOJE DA SE IZPOLZVA OT DRUGITE FAILOVE


//SLED ATO SME GO EXPORTNALI S module.exports = cat; vuv cat.js SHTE STANE
//SAMOCHE TRQBVA GORE IMETO NA KONSTANTATA DA SUVPADA !!!
console.log(cat.catobj.name); // V SLUCHAQ EXPORTVAME OBEKT V DRUG OBEKT ZA TOVA E TAKA


// MOJEM DA EXPORTVAME I FUNKCII I DRUGI RABOTI !
//MOJEM DA EXPORTVAME OBEKTI KOITO UDURJAT DRUGI OBEKTI FUNKCII I DR !


console.log(cat.func());




/*Mojem v cat veche da imame drug zreden fail primerno mouse koito shte vidim pri
izpulnqvaneto na cat v dog !!!*/





// MOJEM DA INZTALIRAME GOTOVI KODOVE I BIBLIOTEKI V NASHIQ PROEKT CHREZ npm, IMA SI WEBSAIT !
// npm e instaliran zaedno s node.js VSICHKI PAKETI S BIBLIOTEKI GI IMA V SAITA NA npm


/*
const express = require('express');
console.log(express);

TAKA MOJEM DA GO IZVIKAME NO IMAME PROBLEM S INSTALACIQTA NA EXPreSS; DAVA NI GRESHKA




MNOGO MODULI KOItO IDVAT ZAEDNO S INSTALACIQTA NA Node.js PRIMERNO http KOITO NI POZVOLQVA DA
STARTIRAME SERVER.
*/



const http = require('http');
console.log(http);

http
    .createServer((req, res) => {
        // nie davame na tozi surver dadeni funkcii koito sa request i response, req i res


        res.write('Hi from Atanas Kambitov');
        res.end();
    })
    .listen(1234); // s listen mu kazvame na koi port da raboti servera
// VECHE SI IMAME NASH SERVER
// AKO OTIDEM NA LOKALHOST:1234 SHTE GO VIDIM T.E. NQMA DA NI KAJE CHE NE SUSHTESTVUVA TAKAVA STRANICA !

// AKO NASHIQ SERVER NE PRAVI NISHTO NQMA DA ZAREJDA NISHTO NO TOI SUSHTESTVUVA !

// NO VSICHKO TOVA E NO MNOGO NISKO NIVO, S PHP GO PRAVEHME NA 1 RED




/* Hubavoto na node.js e che mojem imame routing koeto ni pozvolqva ako usera vleze v
*  daden url da se izpulnqva dadena funkciq.
*  TOVA STAVA S app.get('stranicata', function(req, res){...})
*
*   req e request obekta koito dava informaciq za vsichko koeto usera e izpratil
*   S res e response, s nego nie vruhtame obratno informaciq kum survera
*
*  get oznachava da vzemem daden request ot brausera  no e samo za prochitane
*  a post e za izprashtane na informaciqkum survera i go promenqme .
*  */


/*
* Model - Mongoose :
* Kak se opisvat modelite v bloga.
* modelite sa neshtata koito ni opisvat dannite v bazata
* */

/*
*
* View-to koeto e html i css, za renderirane imame {{imeNaObekt.property}}
* TOVA SE NARICHA HANDLER
*
*
*Controlera e tozi koito pravi vruzkata mejdu dvete
*
* S MONGO DB NIE TURSIM V BAZATA; NE E MNOGO SLOJNO
*
*
* */







