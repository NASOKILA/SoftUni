
/*
*
 Comments:
 SHte polzvame WebStorm ili browser Google Chrome
 JavaScript e dinamichen ezik a ne statichen
 Nqma konpiaciq ne e kato Java ili C#.
 Polzva interpretator, i hvurlq runtime errors.
 Trqbva ni node.js TOVA E SERVEREN INTERPRETATOR koito ni pozvolqva
 da izpulnqvame JS kod i da vijdame
 rezultata ot nego bez da go izpulnqvame v brawsera.
 TRQBVA NI NPM koeto e package manager, chrez nego mojem da svalqme
 JavaScript paketi.
 S npm shte se zanimavame v sledvashtiq kurs.

 Mojem da polzvame i drugi ezici chrez node.js, kato LESS, SASS,
 TypeScript koeto e razshirenie na JavaScript suzdadeno ot Microsoft
 i dr.

 VAJNO !!!
 V WEBSTORM PUSKAME PROGRAMATA S CTRL + SHIFT + F10
 Debugera raboti podobna kakto v Visual Studio 2017
*/

function Hi() {
    console.log('Hello!');
}

Hi();


/*
* Ima cikli(for i while), funkcii, masivi i asociativni masivi,
* promenlivi BEZ TIP !!!
* VSICHKO V JS E OBEKT
*
*VAJNO !!! MASIVA KATO E PRAZEN GO PRIEMA KATO PRAZEN STRING !
* Operatori: + * = !=  && ++  ...
*
* */

let a = 5;
let b = 15;
let sum = a + b;
console.log(sum);

// ';' e preporuchitelno po dobre da se slaga!!!
// PO DOBRE === OT ==


/*
* V JS imame Math BIBLIOTAKATA koqti ima .Round() metoda
* koito zakruglq drobno chislo do nai blizkoto cqlo chislo
*
* .Random() dava random chislo ot 0 do 100 znaem kakvo e
*
*/

//VAJNO !!!
//vsichki chisla v JS sa s plavashta zapetaq !!!!!!!

//typeOf() ni dava tiput na stoinostta s koqto rabotim


/*
 // .toFixed() gi prevrushta v string do
 // podadenite znachi sled desetichnata zapetaq
 // Loshoto na tova e che stava na string
 */




console.log();
console.log("STRINGOVE:");
/*
//STRINGS:

*/

//Na momenti se durjat kato masivi

let str = "nasko";
console.log(str[1]); // 'a'

//Nqma znachenie koi kavichki shte izpolzvame no se preporuchva ""
//Ako trqbva da konkatenirame polzvame ''  i plusove ILI  ``

//NE mojem da go promenqme
str[1] = "A";
console.log(str); // VIJDAME CHE NE STAVA

//VAJNO ! Ako go napravim da polzva avtomatichno  'strict' !!!
//TOGAVA TAZI OPERACIQ SHTE HVURLI GRESHKA!


/*
MASIVI:
    V masivite mojem da si ravim kakvoto si iskame.
*/


console.log();
console.log("MASIVI:");

let masiv = [1,2,3];
masiv[5] = true;
masiv[8] = 5.555;
masiv[10] = "deset"; // mojem da dobavqme kakvoto si iskame, NQMA TIPIZIRANE
console.log(masiv); //[ 1, 2, 3, , , true, , , 5.555, , 'deset' ]
console.log(masiv.length); // 11



console.log();
console.log("Obekti:");

/*
* Obektite durjat Key Value Pairs
* */
let obj = {name:"Nasko",age:24}
console.log(obj.name);
console.log(obj.age);

obj.name = "Atanas Kambitov";

obj.color = "red";
obj.rect = undefined;

console.log(obj);
//mojem da romenqme dobavqme triem, izobshto da pravim kakvoto si iskame



console.log();
console.log("Destructuring:");

let arr = ["Nasko", "Eimi", "Gafy"];
console.log(arr);

let [man, woman, dog] = arr;  // setvame stoinostite na masiva v tri razlichni promenlivi
console.log(man);
console.log(woman);
console.log(dog);


console.log();
console.log("var vs let  -  function scope vs block scope");
//var i let
//var ima function scope a let imat block scope
//ZNAEM GI.
//var vaji navsqkude PO DOBRE DA POLZVAME let PO BEZOPASNO E !!!


console.log();
console.log("Contant variables: ");
/*
* Edin put kato gi inicializirame ne mojem da gi promenim,
* ako opitame ni hvurlq exception.
* */

const name = "Atanas";
//name = "Nasko";

//Ako imame const obekt mojem da mu promenqme propertitata no ne i samiq obekt.


/*
* VAJNO !!! :
*/
console.log();
console.warn("Warning example");  //pechata warning na konzolta
console.error("Error Example"); //pechata greshka na konzolata
//SAMOCHE TOVA RABOTI SAMO V BRAWSERA !!!


//Tuk tova nqma da proraboti no mojem da polzvame Alert("Suobshtenie !");
//alert("Suobshtenie !");


//Confirm podobno na alert obache ima  butoni OK i CANCEL
//Po princip zadava VUPROS !!!
//confirm("Are you sure ?");


/*VAJNOOOO !!!! :
*
* Ako prosto napishem   debugger; VSE EDNO SME SLOJILI CHERVENA
* TOCHKA TOEST PROGRAMATA SHTE SPRE TAM VSE EDNO DEBUGVAME !!!
*
*/


/*
*   JS e dinamichen ezik, promenlivite nqmat tip
*   node.js e ni pozvolqva da si pishem backenda
*   Mojem da manipulirame HTML s <script>
*   razlika mejdu var i let   function i block scope !
*   ´${}´  -   Taka mojem da vmukvame promenlivi.
*/

