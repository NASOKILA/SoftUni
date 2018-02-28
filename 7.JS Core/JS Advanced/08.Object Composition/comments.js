
/*
 Dneshnata tema povtarq nqkoi nesha ot predishnata

 Shte govorim za :
    01.Object composition - kak ot po malki chasti da zglobim po golqmi.
    02.Closures -
    03.Moduli s private case, module patterns - da ne zamursqvame globalni scoup
    04.Nasledqvane i prototypna veriga
    05.Objects interaction with DOM

V JS ima mnogo nachini da se napravi klas, obekt i nasledqvane

Imame otdelna tema za klasove i nasledqvane


01.Object Composition
    Ozn da kombinirame prosti obekti v po slojni obekti.
    EDIN OBEKT MOJE DA E PROPERTY NA DRUG OBEKT I MOJEM DA MU
    DOSTUPVAME NEGOVITE PROPERTITA.

    Moje da sudurjat funkcii koito da se izvikvat i
    da otgovarqt na kontexta na tozi obekt.

*/


//mojem da suzdadem onekt taka:
//Purvo promenlivite:
let name = "Sofia";
let population = 1325744;
let country = "Bulgaria";

//posle samo gi pishem vutre
let town = {name, population, country};
console.log(town);

//sega mu dobavqme obekt kato property
let location = {lat: 42.698, lng: 23.322};
town.location = location;
console.log(town);

//sega mojem da go dostupvame:
console.log(town.location.lat);
console.log(town.location.lng);

console.log();

//Mojem da imame i funkcii kato propertyta.
let rect = {
    width: 10,
    height: 4,
    grow: function (w,h) {
        this.width += w; this.height += h;
    },
    print: function () {
        console.log(`${this.width} x ${this.height}`);
    }
};

console.log(rect);
console.log(rect.print());

console.log();
rect.grow(5,11); // izvikvame grow() i shte uvelichi width i height s podadenite parametri
console.log(rect);

console.log();
//VAJNO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! :
//Ako zapishem funkciqta v promenliva i posle reshim da polzvame promenlivata
//funkciqta zapisana v promenlivata e otkachena ot obekta i nqma kontext

let f = rect.print;
f(); // vrushta 'undefined x undefined' zashtoto nqma kontext


/*
Ako izvikame funkciq ot click event primerno, THIS shte
sochi kum butona ili linka koito e suzdal tozi event.

*/


console.log();

/* VAJNOOOOOOOOOOOOOOOOOOOOOO !!!!!!!!!!!!!!!!!!!!!!!
 .toString();
    Moje da se izvikva i taka:*/
let arr = [1,2,3];
console.log('' + arr);
console.log(arr.toString());


//Ako imame funkciq v obekt i izvikame obekta taka '' + obj shte se izpulni funkciqta !!!
let obj2 = {
    name:'nasko',
    age: 25,
    toString:function () { //trqbva da s kazva toString i da VRUSHTA NESHtO
        return ('Hello my name is Atanas and I ...');
    }
};

console.log();
console.log(obj2);

//VAJNO E PROPERTITO NA FUNKCIQTA DA SE KAZVA toString
console.log('' + obj2);

//Mojem da promenim toString() funkciqta.
obj2.toString = function () {
    return 'This function has been overwritten ...';
};

console.log('' + obj2);

console.log();


//Mojem kato cqlo da promenim funkciqta toString()
Array.prototype.toString = function () {
    return this.join('  changed \n'); // this sochi kum obeta ot koito izvikvame funkciqta
};

console.log([5,6,7].toString());


console.log();

/*
Closures:
    Tova e zatvoreno sustoqnie,
    primerno imame kutiq sus zatvoreni v neq stoinosti.
    Stoinostite sa skriti ot vunchniq svqt

    Tova e kato inkapsilaciq na danni.

    Trqbva da returnem neshto inache nqma kak da dostpim stoinostite.
    TOVA VECHE GO VIDQHME !!!!!!!!!
    Primer:*/

function counterClosure() {

    // vurnatata funkciqta vijda countera zashtoto sa v sushtiq scoup
    let counter = 0; 

    return function getNextCount() {
        console.log(++counter);
    }
}

//Sega kolkoto i puti da vikame countera toi NQMA DA ZAPOCHVE OT 0 A SHTE PRODULJI DA BROI.

//VAJNO E DA Q SLOJIM V PROMENLIVA INACHE NQMA DA STANE.
let count = counterClosure();
count(); // 1
count(); // 2
count(); // 3

console.log();

let count2 = counterClosure(); //Suzdavame si nova referenciq s nov skoup
count2(); // 1
count2(); // 2
count2(); // 3


//MOJE I S IIFE DA ZAPISHEM FUNKCIQTA V PROMENLIVA.




/*
    Module and revealing, Module patterns:

    AKO ZAKACHAME ZA HTML MNOGO FUNKCII OT EDIN JS FAIL RANO ILI KUSNO
    TE MOJE DA SE ZASECHAT, ZATOVA SE PRAVI SLEDNOTO.
*/

//vajno e funkciite koito izprashtame da sa v iife funkciq.
let module2 = (function () {


    function funcOne() {

    }

    function funcTwo() {

    }

    //vrushtame obekt sudurjash dvete funkcii
    //Taka v brawsera v .window nqma da imame dve funkcii a edin obekt s dvete funkcii vutre.
    return {funcOne, funcTwo};

})();

console.log();

//Mojem da uvelichavame stoinost na dadeno property v daden obekt kato
//polzvame funkciite mu.
let obj3 = {
    count:0,
    increase: function(num) {this.count += num},
    decrease: function(num) {this.count -= num},
    value: () => this.count
};

console.log(obj3.count);
obj3.increase(5);
console.log(obj3.count);
obj3.decrease(3);
console.log(obj3.count);


console.log();



//Mojem i sus IIFE funkciq
let module3 = (function () {

    //TOVA E CLOSURE
    let count = 0; //tova e private I NE MOJEM DA GO DOSTUPIM
    return {
        increase: function(num) {count += num},
        decrease: function(num) {count -= num},
        value: () => count
    }

})();

console.log(module3.value());
module3.increase(55);
console.log(module3.value());


//VAJNO !!!!!!!!!!!
//V C#, private poletata pak moje da se dostupvat s reflection.




/*
Object inheritance: NASLEDQVANE NA OBEKTI
    Nqma da imame tochno nasledqvane na obekti
    Shte imame obekti koito polzvat propertitata na drugi obekti.

    Imame glaven obekt s funkcionalnosti.
    Posle imame drugi obekti koito nasledqvat tazi funkcionalnost i si
    imat oshte edna dopulnitelna funkcionalnost.

    GLAVNAta IDEQ E DA SE SPESti KOD.
*/

console.log();

let fatherCar = {
    brand: 'BMW',
    model: 'X5',
    color: 'blue',
    toString: function () {
        return `[brand: ${this.brand}, model: ${this.model}, color: ${this.color}]`;
    }
};

console.log('' + fatherCar);
//sushtoto e kato :
//console.log(fatherCar.toString());

//taka nasledqvame obekta fatherCar
let myCar = Object.create(fatherCar);
//posle  mu smenqme nqkoi stoinosti
    myCar.model = 'M4';
    myCar.color = 'red';
console.log('' + myCar);


//taka nasledqvame obekta fatherCar
let workCar = Object.create(fatherCar);
workCar.model = 'i3';
workCar.type = 'electric';
//Promenqme i toString funkciqta da printira neshto razlichno
workCar.toString = function() {return `[brand: ${this.brand}, model: ${this.model}, type: ${this.type}]`;};
console.log('' + workCar);


console.log();

//VAJNO !!!
//Ako sega dobavim oshte edno property kum FATHER obekta to shte se transferira kum
//vsichki obekti koito go nasledqvat
fatherCar.doors = 5;
console.log(myCar.doors); // 5
console.log(workCar.doors); // 5
//MOJEM I DA GO PROMENQME AKO ISKAME


//Sus Object.create() nie NE kopirame propertitata a pravim referenciq kum tqh.

//VAJNO !!!!!!!!!!!!!!
//VSEKI OBEKT IMA SKRITO PROPERTY _proto_ KOETO SOCHI KUM PROTOTYPA
//KATO NALEDIM GLAVNIQ OBEKT, _proto_ SOCHI KUM GLAVNIQ OBEKT.
//I AKO LIPSVA NQKAKVO PROPERTY GO TURSI V PROTOTYPA, T.E. V GLAVNIQ OBEKT.


console.log();
/*
 V JS NE MOJE EDIN OBEKT DA NASLEDI DVA OBEKTA, Object.create() PRIEMA SAMO EDIN PARAMETUR.
 No v JS ne ni e nujno tova da go pravim, mojem da polzvame funkcii kato :
 Object.assign(obj1, obj2);
        SLAGA PROPERTITATA OT obj2 v obj1
*/

let man = {gender:'male'};
let human = {human: true};

let nasko = {};
Object.assign(nasko,man);
Object.assign(nasko,human);

console.log(nasko); // { gender: 'male', human: true }
//sudurja i dvete propertita ot dvata razlichni onekta.
//Obache tova ne e nasledqvane zashtoto imame samo edin _proto_.
//Vtoriq koito vkarvame zamenq purviq.


console.log();

/*
Objects interaction with DOM.
    PRAVILI SME GO.


*/








/*
    Summary:
        01.Object composition: Ot po malki parcheto zglobqvame po slojen obekt
            kombinirame data i funkcii kato propertita v obekti i mojem
            s this da gi dostuvame.
        02.Module pattern : Skriva danni vuv vunkciq i vrushta obekti.
            MNOGO E POLZVANO ZASHTOTO NE ZAKACHAME MNOGO FUNKCII ZA
            window. Polzva se CLOSURE KOETO SKRIVA SAMITE DANNI.
        03 Revealing Module pattern : SUshtoto e samoche se delarira
            malko po razlichno.
        04.Object Inheritance: let man = Object.create(human)
            Taka obelta obj nasledqva obekta human i ima negovite propertita.

*/




