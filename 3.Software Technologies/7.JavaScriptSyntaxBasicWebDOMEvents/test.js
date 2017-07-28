console.log("TEST");
/*
* Javascript e netipiziran ezik. Toest tam nqma intove stringove i dr.
*
* T.E. Imame gi no sa kriti. NQMAME RESTRIKCII .   Edim masiv moje da sdurja mnogo tipove.
*  vsichko e dinamichno toest nqma da ni kazva kade imame tupi greshki.
*
*  v javascript po dobre da polzvame ===
*  tam pochti vsichko e SVOBODA no pok trqbva da se vnimava
*
*  let   E za suzdavane na promenliva KATO var E NO IMA MALKA RAZLIKA MEJDU DVETE
*
*  ZA STRINGOVETE MOJEM DA GI PISHEM S EDINICHNI I S DVOINI KAVICHKI
*  I AKO SE KOMBINIRAT NQMA NUJDA DA ESKEIPVANE SIVOLI
*
*  ako napishem v konzolata "test" + 1 shte ni vurna "test 1" inta shte go napravi na sring i shte gi konkatenira.
*
*
* */

/*
*
* Imame for of   i   for in
*
*for(let i in arr)   // ako primerno obhojdame nqkoi masiv
*{
*   console.log(i)       //for in she ni izvede samo INDEXITE A NE STOINOSTITE
* }
*
* for of E SUSHTOTO NO VRUSHTA STOINOSTITE A NE INDECITE KATO FOREACH V C#
*
*
*
* Imame new Date() ot koeto mojem da vzemem den, chas, minuta, sekunda i dr !!!
* */

/*
* array operations
*
* imame arr.push() koeto dabavq elementi na edin masiv kato vus spisuk
*
* arr.pop() vadi ot zad t.e. pravi obratnoto na push !!!
*
* V JS MASIVUT E KOMBINACIQ OT RECHNIK, SPISUK I MASIV
*
* IMAME arr.unshift()    i     arr.shift()  koito vadat nai otpred i slagat nai otpred
*
* imame oshte mnogo opreacii kato join, split splice i dr.
* Join go znaem i split go znaem
*
* Splice() ni pozvolqva da iztriem element i da dobavim drug ednovremeno v dadena poziciq
*
*
*
* */

/*

    stringovete moje da se pishat s edinichni ili s dvoini kavichki.



 */



let  a = 100;

// nqma nujda da slagame ; nakraq na kakvoto i da e, JS go slaga avtomatihno
let first = 100
let second = 200

let sum = first + second
console.log(sum)

console.log(Math.min(5,6,2));

/*
    Vajno e da e se znae che s document.getElementById("name").value se vzima stoinostta na html element.
    Switch case , for, while, do while,
    e edin i susht kato v c#

    v JS mojem da pishem:
    a = a || 1;  // tova e: a e ravno na a ili e ravno na 1
    Ako a e undefined go vzima za edinica !!!!!!
    NO MOJE I DA E VURNEM STOINOST PAK SHTE RABOTI !!!

    MOJEM DA ZAPAZVAME CELI FUNKCII V PROMENLIVI !

    SLED KATO E PODADENA V PROMENLIVA MOJEM DA Q IZPRATIM KATO
    PARAMETUR NA DRUGA FUNKCIQ. TOVA SE NARICHA CALLBACK FUNKCIQ !!!!

*/
/*
*   IMAME I ANONIMNI FUNKCII:
*
*
* */
[1, 2 ,3].forEach(x => console.log(x));
//imame masivche na koeto sme zakachili foreach koito printira vsichki elementi na masiva
// izpolzvame foreach kato lambda funkciq !


//map e kato select v C# !!!  where e filter !!!
let result = [1, 2 ,3]
    .filter(function(x){ // TOVA SA ANONIMNI FUNKCII
      return x > 1; // vrushtame vsichki po golemi ot 10
    })
    .map(x => + 10);// MOGAT DA BUDAT I LAMBDA FUNKCII
console.log(result);



// Callback funkciq e kogato podavame funkciq na druga funkciq

/*
 IFIE Funkciq  OZNACHAVA Immediatelly Invoked Function Expression
 Mojem da suzdadem anonimna funkciq koqto vednaga da nazovem!
 */

(function (){
    console.log(5);
})();
// TOVA E IFIE FUNKCIQ KOQTO VEDNAGA SHTE SE IZVIKA BEZ NUJDA NIE DA Q VIKAME
// SMISULUT E DA SE SKRIQT PROMENLIVITE OT GLOBLNATA FUNKCIQ



/*
* BLOCK SCOPE I FUNCTION SCOPE
* let raboti v taka narecheniq block scope koeto oznachava che dadena promenliva
* raboti v skobite i ne e validna otvun
*
* primerno ako imame for cikul s promenliva "i" suzdadena s let, tazi promenliva
* shte e dostupna samo za tozi for cikul, t.e. NQMA DA MOJEM DA Q IZVIKAME OTVUN.
*   sushtoto e i pri if i drugi !!!
*
* NO AKO NIE SUZDADEM DADENATA PROMENLIVA SUS var SHTE MOJEM DA Q POLZVAME OTVUN
* NO I VAR JIVEE VUV FUNKCIQ TOQ TRQBVA DA E DEFINIRAN VUV FUNKCIQ
*
* JAVASCRIPT NI IZNASQ VSICHKI PROMENLIVI NAI OTGORE KUDETO DA MOJE DA GI PROCHETE PURVI
* var i ifie se izpolzvat postoqnno
*
*/

/*
*JSON obekti sa tekst ili string koito raprezentira obekti
* mojem da stringosvame sus JSON.stringify(obj);
* mojem i da parsvame sus JSON.parse(obj);
*
*
* */







