

//DEKLARACII NA FUNKCIQ

//First Order Functions NORMALNA FUNKCIQ

//taka mojem da q izvikame predi deklaraciqta
a()
function a(){console.log("Hello")}


//ako e vuv promenliva NE mojem da q izvikame predi deklaraciqta
//a2();    //TUK GURMI
let a2 = function a2(){console.log("Hello2")}
a2();


//Hier order functions
//Te priemat ILI vrushtat drugi funkcii !!!
//Moje da priemat i masiv ot funkcii


//Partial Application Function
//Tova e funkciq koqto priema parametur i vrushta druga funkciq koqto moje da polzva tozi podaden parametur.
//Po nqkoga koda e po malko i ne se povtarq 



//FUNCTION CURYING NA HASKELL CURRY:
//TOVA SAM GO NAPRAVIH, NARICHA  'function currying'  METOD NA Haskell Curry 
function squareNumber(str, num){
    return (str + ' ' + (num * num));
}

function square(func)
{
    return function(num){
        return func('The number squared is :', num)
    }
}

//Zapisvame vutreshnata funkciq v promenlivata squareNum
let squareNum = square(squareNumber);

//I sega mojem da i podavame nomera kato parametri i tq she izpulni squareNumber() ZASHTOTO MOJE !!!
console.log(squareNum(5));
console.log(squareNum(10));
console.log(squareNum(2));



console.log();

//Moje da se napravi i taka kato polzvame prazna promenliva i q setvame na dadena funkciq:

function AddOneToNumber(str, num){
    return (str + ' ' + (num+1));
}

let variable;
function AddNum(func){

    variable = function(num)
    {
        return func('We add one to the number', num);
    }
    return variable;
}

//Kato izvikame AddNum(AddOneToNumber); Veche setvame promenlivata 'variable' i mojem da q polzvame kato funkciq 
let setVariable = AddNum(AddOneToNumber);

console.log(variable(0));
console.log(variable(4));
console.log(variable(9));



console.log();

//outer() i inner()  SUS .caller VIJDAME KOI E IZVIKAL TAZI FUNKCIQ    
function inner(){ 
    console.log(inner.caller + ' Called me !!!');
}

function outer(){ inner(); }

outer();



console.log();

//IIFE Znaem kakvo e !!!
//Samoizvikva se pri deklarirane
//Te sa anonimni
//SLED IZPULNENIETO SI TE SE SAMOIZTRIVAT

//Nachini na izvikvane !!!
(function(){console.log('IIFE was called like this(...)()!!!')})();
(function(){console.log('IIFE was called like this(...())!!!')}());

let iife = function(){
    console.log('IIFE was called like by being assinged to a variable with () at the end !!!')
}();


//VAJNO!!! POLZVAT SE ZA DA PRIDURJAT GLOBALNI SCOUP CHIST. 
//SLED IZCHISTVAETO SE IZTRIVAT NISHTO NE OSTAVA V GLOBALNIQ SKOUP !!!

//AKO POLZVAME var VINAGI TOVA OSTAVA V GLOBALNIQ SKOUP OSVEN AKO NE GO IZCHISTIM 


console.log();

//Closures:  INCAPSULIRAME DANNI POLZVAIKI IIFE CHIETO RESULTAT SE ZAPISVA V PROMENLIVA
//A RESULTATA E DRUGA FUNKCIQ !!!!!

let f = (function(){

    //Kountera se vijda samo ot tazi funkciq koqto se zapisva v f(), TOI OSTAVA SKRIT. 
    let counter = 0;

    return function(){
        console.log(counter++);
    }

}());

//Kountera ne zapochva ot 0, zapazvat se promenite mu 
f(); // 0
f(); // 1
f(); // 2
f(); // 3



//KAKVO e 'this' ?

/*
    V JS na momenti 'this' se durji razlichno i sochi kum razlichni neshta !!!
    ZAVISI OT SITUACIQTA.
    
    'this' MOJE D SE MANIPULIRA OT FUNKCIITE: this, call, apply, bind MOJEM DA 
    PROMENQME KONTEXTA KUM KOITO SOCHI 'this' !!!!!!!!!!!

    VSICHKO ZAVISI OT KUDE Se IZVIKVA !!!!
*/

console.log();


console.log(this);  // TAKA NE SOCHI KUM NISHTO


//AKO E VUV FUNKCIQ SOCHI KUM GLOBALNIQ SKOUP !!!!
//AKO SME V BRAWSERA SOCHI KUM WINDOWS ZASHTOTO TOI E GLOBALNIQ SKOUP TAM !!!
(function(){
    console.log(this);
})();



console.log();
//AKO POLZVAME 'use strict'; THIS STAWA UNDEFINED !!!
(function(){
    'use strict';
    console.log(this);
})();



//TOI DURJI KONTEXTA NA DADENATA FUNKCIQ T.E. KUM KAKVO E ZAKACHENA TAZI FUNKCIQ!

/*
    V zavisimost ot KAK IZVIKAME funkciqta 'this' se durji razlichno !!!!! 
    
    AKO PRIMERNO ZAKACHAME EVENT NA DADEN BUTON VUTRE 'THIS' SOCHI KUM SAMIQ BUTON !!!!  
    
*/


//AKO IMAME FUNKCIQ VUV 'obekt' TOGAVA THIS SOCHI KUM PURVATA OBEKTA ZASHTOTO TAM
// E ZAKACHENA VTORATA:
console.log();

let obj = {
    name: 'nasko',
    f: function() {console.log(this)}
}

obj.f(); // sochi kum obekta zashtoto tam e zakachena funkciqta !!!





console.log();
//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!
    //THIS SOCHI KUM OBEKTA DORI I FUNKCIQTA DA E DEKLARIRANA IZVUN NEGO !!!!

function fu(){
    console.log(this.name);
}

let obj2 = {
    name: 'Asi',
    f:fu              
};

//TUK THIS PAK SOCHI KUM OBEKTA ZASHTOTO OT TAM Q IZVIVAME
obj2.f(); // Asi             ZASHTOTO IZVIKVAME this.name T.E. imeto na obekta


//Ako go izvikame taka veche si sochi kum globalniq obekt
//fu();



/*
    'this' SE POLZVA NAI MNOGO S KLASOVETE !!!

    SUS call(), apply()  i  bind()  mojem da promenqme kontexta na 'this'.
    


    VAJNOOOOOOOOOOOOOOOOOOOOOOOOO !!!!!!!!!!!!!
            Mojem da gi polzvame kogato 'this' ni oburkva zashtoto naistina na momenti se 
            durji mnogo stranno !!!!!!!
            
            

    SUS call() - MOJEM DA IZVIKAME DADENA FUNKCIQ I DA I PODADEM NOV 'THIS'.
    
    apply() - E SUSHTOTO KATO call() SAMOCHE IZVIKVAME FUNKCIQTA S MASIV OT PARAMETRI
    DOKATO call() SE IZVIKVA S NQKOLKO PARAMETURA KOITO NE SA V MASIV !!!!!!!!!

    bind() - VURSHI NESHTO PODOBNO KATO call() i apply() MOJEM PRIMERNO NA DADEN OBEKT DA
    MU SMENIM 'THIS' !!!!!!!!!!!!   


*/

console.log()


//V stariq JS  KLASOVETE SA BILI FUNKCII !!!
function CatClass(name, age){
    this.name = name;
    this.age = age;
}

let sisa = new CatClass('Sisa', 15);
console.log(sisa); 



console.log();
//NOVIQ NACHIN E S 'class' !!!!!!!!
class Cat {
    constructor(name, age, weight){
        this.name = name;
        this.age = age;
        this.weight = weight;
    }

    print() {
        return 'Name: ' + this.name + '; ' 
        + 'Age: ' +  this.age + '; ' 
        + 'Weight: ' + this.weight + '; '; 
    }
}



let garfield = new Cat('Garfield', 5, 20);
console.log(garfield);

//mojem da izvikvame i funkciqta koqto printira !!!
console.log();
console.log(garfield.print());





console.log();

/*
    VAJNOOO !!!!
    Ako izvikvame 'this' ot ARROW FUNKCIQ toi se durji razlichno !!!

*/

let obj3 = {
    name: 'Petruci',
    f: () => {console.log(this)}   // {}  -  SOCHI PROSTO KUM PRAZEN OBEKT
}

obj3.f();


console.log();
//AKO PROSTO PRINTIRAME ARROW FUNKCIQ

console.log(() => {console.log(this)});  //[Function]



//V RAZLICHEN SLUCHAI 'this' SE DURJI RAZLICHNO !



console.log();
//call() apply() bind()  S TEZI FUNKCII MOJEM DA PROMENIM 'this'-a NA DADENA FUNKCIQ
//call()  -  raboti s parametri a apply() s masiv ot parametri.


//pravim obekt mariq
let maria = {
    name: 'Maria',
    hello: function(arg){
        console.log(this.name + ' says hello ' + arg + '.');
    }
};

maria.hello('world'); //Maria says hello world.

//obekt ivancho
let ivancho = {name: 'Ivan' }; //Ivan says hello now.

//s .call() promenqme 'this' sus tozi na ivancho
maria.hello.call(ivancho, 'now'); //Ivan says hello again.

//Pravim sushtoto s .apply();
maria.hello.apply(ivancho, ['again']); //Ivan says hello again.


console.log();
//oshte edin primer :
function ff(){
    console.log(this);
}
let replaceThisObj = {name: 'Tako'};

//promenqme 'this' s tozi na replaceThisObj
ff.call(replaceThisObj);  //ako imame drugi parametri gi izbroqvame !!!  
ff.apply(replaceThisObj)    //ako imame drugi parametri te sa v masiv !!!




/*

Bind  -  Tova e podobno na call i apply.
RAZLIKATA E V SINTAKSISA
*/ 

let helloIvancho = maria.hello.bind(ivancho);
helloIvancho('World'); //Ivan says hello World.

//VIJDAME CHE PRAVI SUSHTOTO NESHTO


/*

    SUMMARY:
        01.First class functions - sa si obiknovenite funkcii
        02.Higher class functions - sa takiva koito ili proemat ili vrusthat 
            druga funkciq.
        03.IIFE - samoizvikva se sled koeto se samoiztriva i durji globalniq 
            skoup chist
        04.Malko klasove vidqhme
        05.CLOSURE e neshto do koeto samo dadenata funkciq ima dostup.
        06.'this' na momenti se durji stranno
            AKO SME V OBEKT 'this' SOCHI KUM OBEKTA, AKO SME VUV FUNKCIQ
            'this' SOCHI KUM GLOBALNIQ OBEKT, V ARROW FUNKCIQ SE DURJI RAZLICHNO
            I VUV DADEN CLICK EVENT SOCHI KUM ELEMENTA NA KOITO SME KLIKNALI.
        07.Sus .call() .apply() .bind() MOJEM DA SMENQVAME 'this' na dadena
            funkciq ili obekt    
         
*/







