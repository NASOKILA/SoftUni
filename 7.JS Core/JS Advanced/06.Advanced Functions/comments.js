

/*

First-Class Functions in JS:
Tova sa tova sa normalnite funkcii koito polzvam az.
Te se darjat kato obekti i mojem da gi zapisvame v promenlivi.
I mojem za tqh da zakachame propertita.
*/
function hello() {
    console.log('Function hello() invoked.');
}
hello.speed = 200;

console.log(hello.name + ' ' + hello.speed);
//Funkciqta se durji kato obekt i ima propertita.
//hello.name si go ima avtomatichno i pokzva s kakvo ime e zapisana v pametta.


/*Imame i anonimni funkcii koito sa bez ime
  i pak mojem da gi zapisvame v promenlivi.
  i polse da gi izvikvame.*/


/*Higher-Order funkcions:
Te ili priemat funkciq kato argument ili vrushtat
funkciq koqto vrushta rezultat ili i dvete.*/
let parsedArr = ['1','2','3'].map(Number);
console.log(parsedArr);
//V sluchaq .map() e funkciq koqto priema kato parametur nova funkciq 'Number'

//.addEventListener('click', function(){...}); - pak priema funkciq kato parametur.


//funkciq koqto vrushta funkciq rezultat :
//priema masiv ot funkcii koito gi izpulnqva.
function invokeAll(funcArr) {
    for(let func of funcArr) func();
    //s func() gi izpulnqva.
}

//funkciq koqto vrushta 'last'.
let last = function () {console.log('last');};

//izvikvame si invokeAll s masiv ot funkcii
invokeAll([
    () => console.info('first'), //anonimna funkciq koqto vrushta 'first'
    () => console.info('second'), //anonimna funkciq koqto vrushta 'second'
    last //funkciqta last
]);
//VSICHKO SI MINAVA DOBRE



/*
Reducer funkcii:
    Tezi funkcii izpulnqvat dadena funkciq na mnojestvo elementi.
    Priema kato parametur masiv i funkciq kato vtori param
*/
function reduce(arr, func) {

    //vzimame purviq element
    let result = arr[0];

    //obhojdame ostanalite elementi
    for(let nextElement of arr.splice(1))
        result = func(result, nextElement);
    //prilagame funkciqta kato podavame purviq element i sledvahtiq
    //kato promenqme purviq element, i posle produljavame napred

    //vrushtame rezultata
    return result;
}


console.log(reduce([5,10,20], (a, b) => a + b));
console.log(reduce([5,10,20], (a, b) => a * b));


/*
Partial Applivation: CHASTICHNO PROLAGANE.

01.Priema nqkolko parametura i FIKSIRA NQKOLKO OT TQH NA
   PREDVARITELNO ZADADENA STOINOST.

02.I vrushta resultat sus ostanalite parametri.

03.Mojem da q polzvame mnogo puti s razlichni masivi.
*/

/*
FUNKCIITE IMAT I DOPULNITELNI PROPERTITA KATO:
.length; - vrushta nomera na argumentiti
.name; - imeto v pametta
FuncName.caller; - kazva ni koi q e izvikal
I DR.
*/

function test (a,b,c) {return a + b + c;}
console.log(test.length);
console.log(test.name);
console.log(test.caller); // v momena nikoi ne q izvikva



/*
 IIFE - Immediatelly Invoked Function Expression:
    Izvikva se pri samote deklarirane !!!
    Polzva se mnogo, chesto za pravene na cikul !!!

    Funkciqta trqbva da e anonimna

    PO PRINCIP VSQKA FUNKCIQ E ZAKACHENA ZA 'window'
    I OT KONZOLATA NA BRAWSERA MOJEM DA Q IZVIKAME.
    NO AKO E IIFE NQMA DA MOJEM DA Q IZVIKAME ZASHTOTO
    NE SE ZAKACHA I NISHTE V NEQ NE SE ZAKACHA.
*/

(function () {
    for(var i = 0; i <= 10; i++) {}
    //Mojem da q polzvame samo v tazi funkciq, nqma znachenie che e var.
    console.log(i);
})();


//console.log(i); - tuk ne mojem da polzvame i



//Moje po nqkolko nachina da se deklarira:
(function () {console.log('I am IIFE');}());
(function () {console.log('I am IIFE')})();
let iife = function () {console.log('I am IIFE')}();


//VAJNO !!!!!!!!!!
//IIFE funkciqta ne ostavq nishto v tekushtiq skoup sled
// izpulnqvaneto im ZASHTOTO TE IZCHEZVAT AVTOMATICHNO.
// I NE MOJEM DA POLZVAME NESHTATA V NEQ IZVUN SKOUPA I !!!



console.log();

/*
    Funkcii koito vrushtat drugi funkcii.
*/

let f = (function () {
    let counter = 0;

    //vrushta druga funkciq.
    return function () {
        console.log(++counter);
    }
})();

//izvikvame f() funkciqta
f(); //1
f(); //2
f(); //3


//Po nqkoga IIFE funkciite stavat kato statichni promenlivi.
//statichni promenlivi sa SPODELENI OT VSICHKI INSTANCII NA KLASA V KOTI SA SUZDADENI !!!

//VAJNO : window  v Node.js se kazva global


//VAJNO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//EDNA FUNKCIQ VIJDA VSICHKO KOETO E V SKOUP NAD NEQ





/*
 THIS:
    this = function context that owns the current excecuted code.
    this - e tekushtiq obekt

 KAKVO E KONTEXT ?   LESNO E :
 Primer 1: console.log()
 na funkciqta .log() kontexta e 'console'

 Primer 2: text.slice()
 na funkciqta .slice() kontexta e 'text'


 THIS sochi kum razlichni neshta v zavisimost ot kak e izvikana
 funkciqta:

 VAJNO !!! :
 Edna funkciq moje da se izvika po razlichni nachini.
 func() - global invoke
 object.function()
 domElement.event();  -  invoked by an event function

*/

console.log();

function ff() {
    console.log(this);
}
ff();


console.log();
//VAJNO :
//Ako imame use strict globalniq scoup izchezva !!!!!!!!
function fff() {
    "use strict";
    console.log(this); //vrishta ni undefined
}
fff();

//THIS sochi kum tekushtiq obekt, na momenti kum tova koeto go durji
let obj =
    {
        name: 'Naso',
        age: 21,
        sayHello: function(){
            //this sochi kum imeto na obekta 'Naso' !
            console.log(this.name  + ' says hello!');
        }
    };

obj.sayHello();

//Nie mojem da q otkachim ot obekta 'obj' obache this nqma da sochi sushtoto neshto !
let fu = obj.sayHello;
fu(); // this e undefined.

//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOO !!!!!!!!!!!!!!!!!!
//Za da mu zakachim obratno kontexsta polzvame .bind(ObjName);

fu = obj.sayHello.bind(obj);
fu(); //sega this si sochi pak kum Naso




//VAJNOOOOOOOOOO !!!!!!!!!!!!!!!!!!!!!
//Mojem da q izvikame ot drugo obekt s razlichno ime.
let asi = {
        name:'Asen',
        age: 27
};

//Izvikvame funkciqta ot drug obekt s negoviq kontext
obj.sayHello.call(asi); // sega this sochi kum 'Asen' !!!


//.call() izvikva funkciqta ot lqvo s kontexta na podadeniq obekt.


//ARROW FUNKCII :
//Te sa Anonimni.

console.log();

//Nai golqma stoinost ov masiv sus .apply()
//.apply() vzima ot elementite ot masiv i gi prilaga na dadeno neshto edin sled drug
console.log(Math.max.apply(null, [5, 88, 23]));
//null oznachava che nqma kontext

console.log(Math.min.apply(null, [5, 88, 23]));

console.log();

//Math.min ili .max rabott no ne sus maiv
console.log(Math.min(1, 66, -44));
console.log(Math.max(1, 66, -44));







//VAJNO !!!!!!!!!!!!! :
//ANONIMNITE FUNKCII NE VIJDAT SCOUP.




/*
Vzimaneto na elementi ot DOM e baven proces, po dobre ako mojem
 da go pravim samo vednij.
*/




/*

Summary:

    01.Funkciq ot purvi red: normalna funkciq koqto se durji kato obekt
        moje da se prenasq v romenliva i moje da bude parametur na dr funkciq.

    02.Funkciq ot po visok red e funkciq koqto ili priema dr funkciq kato
        parametur ili vruhta druga funkciq kato rezultat.

    03.IIFE e funkciq koqto se izpulnqva pri deklariraneto, nqma nujda ot
        izvikvane i ni pozvolqva da skrivame danni v neq.
        FUNKCIQ KOQTO E VURNATA OT DRUGA FUNKCIQ VIJDA VSICHKO NAD NEQ.

    04.Kontexta na funkciqta = this, koeto zavisi ot kak izvikvame funkciqta,
        Ako e izvikana ot obekt 'this' sochi kum obekta.
        Ako e izvikana globalno this sochi kum window.
        Ako e izvikana ot click event 'this' sochi kum butona ili linka koito e izvikal funkciqta.


*/
