

/*
* Funkcii, izvikvane i deklarirane, parametri, lambda funkcii,
*   sukrateni funkcii i dr.
*
*   znaem kakvo e funkciq.
*   pishe se s camelCase
*
* Function overloading:
*   Moje da imame dve funkcii s ednakvi imena no s razlichen broi
*   parametri i shte trugne bez problem.
*   Pri izvikvaneto se razbira koq funkciq izkikvame.
*
*   S arguments.length mojem da vidim kolko parametura sme podali
*   na funkciqta.
*
*   ponqkoga funkciite vrushtat undefined ili NaN no
*   ne hvurlqt exception
*
*/

//Imame anonimni funkcii koito mojem da gi zapisvame v promenlivi.
//tezi funkcii NQMAT IMENA !!!
let f = function (a) {return a * 2};
console.log(f(2));


console.log();

/*
* IIFE  -  Immediately-invoked function expression
*
* Funkciq koqto se izvikva avtomatichno pri suzdavaneto i
* */
(function (count) {
    for(let i = 1; i <= count; i++)
        console.log(i);
})(4);

//MOJEM I TEH DA GI SLAGAME V PROMENLIVI I DA GI IZVIKVAME !!!


console.log();
/*
* LAMBDA FUNKCII:
*   Tova sa sukrateni zapisi na normalna funkciq !
*
* */

/*
let func = function increment(counter) {
    console.log(++counter);
}
*/

let func = counter => ++counter;
console.log(func(5));

console.log();

/*Imame i sukrashteniq za foreach cikul !*/
[10,20,30,40,50].forEach(e => console.log(e));

//SUKRASHTENIQTA I LAMBDA FUNKCIITE SA NAI UDOBNI ZA RABOTA !
//Lambda funkciite gi polzvame po princip za malki i edinichni operacii.

/*.filter() e za filtrirane a sort e za sortirovki.*/
