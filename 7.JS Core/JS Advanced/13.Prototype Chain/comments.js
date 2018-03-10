






/*
    VAJNOOOOOO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    Pas by Reference vs Pass by Value:
        Kato govorim za 'Pass' imame v predvid podavaneto na parametriv dadena funkciq.

        PASS BY VALUE:

        Value tipes:
            01.int, 
            02.double, 
            03.decimal, 
            04.long, 
            05.byte, 
            ...     // IMA I OSHTE.

            AKO NATISNEM F12 NA GORNITE TIPOVE DANNI SHTE VIDIM CHE TE SA STRUKTURI, I 
            IMAT DUMATA 'struct'.
            VSICHKI STRUKTURI SA OT TIP VALUE.

            Primer:
                Ako imame :
                    int num = 0;     i funkciq koqto da uvelichava tazi promenliva s 1;
                    public static IncreaseNumByOne(int num){ num = num + 1};

                Kato izpulnim funkciqta tq NQMA DA MOJE DA PROMENI PROMENLIVATA 'num' 
                ZASHTOTO TQ E OT TIP 'Value' T.E. NIE PODAVAME 'KOPIE' NA SAMATA 
                PROMENLIVA KUM FUNKCIQTA A NE SAMATA PROMENLIVA ZATOVA FUNKCIQTA NE MOJE DA Q 
                PROMENI.

            PASS BY REFERENCE:
            Referent tipes:

                REFENTNITE TIPOVE NE PODAVAT 'STOINOST', TE PODAVAT MESTOPOLOJENIETO SI V 
                PAMETTA, SLED KOETO MOJEM DIREKTNO DA GI PROMENQME.

                01.All Classes : Array, List, 
                    everithing that uses the 'new' keyword.
                02.string TYPE
                    Ako Probvame predishniq primer S MASIV OT inttegeri:
                        Shte mojem realno da promenim samiq masiv i samite chisla v nego.

    
                
    VAJNOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!:
    PO STOINOST:
        PODAVA SE KOPIE NA PROMENLIVATA I 'NQMA DA PROMENIM SAMATA PROMENLIVA V PAMETTA'
    PO REFERENCIQ:
        PODAVA SE MESTOPOLOJENIETO V PAMETTA I 'MOJEM DA PRAVIM REALNI PROMENI';

*/


//NAI VAJNOTO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //KOGATO SUZDADEM OBEKT (INSTANCIQ NA DADEN KLAS) S KLUCHOVATA DUMA 'new' TOZI OBEKT SE 
    //SUHRANQVA S 'RAM' PAMETTA NA KOMPIUTURA NI.


//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //TUK KAKTO I V C# NIE NE MOJEM DA NASLEDQVAME DVA KLASA EDNOVREMENNO ! 
    //NQMA MNOJESTVENO NASLEDQVANE !!!!!!!!!


/*
    Simple inheritance:
        Normalno nasledqvane.
        Bazoviq (Parent) klas durji vsichko koeto e obshto za vsichki klasove.
        Celta e da ne go kopirame vuv vseki klas a da preizpolzvame tova v bazoviq klas

        Tozi koito nasledqva e Chiled (Derived) klas.
        I moje da polzva vsichko osven (private) metodite ot bazoviq klas,
        moje da prezapisva metodi i da si ima sobstveni metodi.
        
        VAJNOOOOO!!!!!!!!!!!!
            Nasledqva se s kluchovata dumichka 'extends' .
            V konstruktura na Deteto (Derived) Klasa izvikvame bazoviq konstruktor 
                sus 'super(..., ...);'
            BAZOVIQ KONSTRUKTOR VINAGI SE IZVIKVA NA PURVIQ RED V BODITO NA KLASA.
            Sus 'this.constructor.name;' SI VZIMME IMETO NA KLASA.



    Accessing Parent Members:
        Kak da dostupvame neshta ot roditelq ?
        STAVA S KLUCHOVATA DUMA 'super' !!!   MNOGO E LESNO !!!

*/
       
    class Person
    {
        constructor(name, email)
        {
            this.name = name;
            this.email = email;
        }

        //dobavqme si toString() metod
        //ZNAEM CHE PRI SUZDAVANETO NA KLAS TOI NASLEDQVA 'Object' KOITO SUDURJA toString() metoda
        toString(){

            //kak vzimame imeto na edin klas
            let className = this.constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person
    {
        //priemame i obekt
        constructor(name, email, subject)
        {
            //izvikvame bazoviq konstruktor:
            super(name, email);

            //i si setvame otdelnite neshta za tozi klas Teacher
            this.subject = subject;
        }

        toString(){

            //kak vzimame imeto na edin klas
            let parentResult = super.toString().slice(0, -1);
            return parentResult + `, subject: ${this.subject})`;
        }


        testFunc(){
            return "testFunc";
        }

    }

    let person = new Person("Asen", "asi@abv.bg");
    console.log(person.toString())

    //vijdame che mojem da printirame vsicho ot Tacher klasa
    let teacher = new Teacher("Atanas", "nasko@abv.bg", "Programming");
    console.log(teacher.toString());







    /*
        Tuk znaem che kakto v C# nqmame mnojestveno nasledqvane.
        No na momenti ni trqbva takova, v takava situaciq ako pishem na C#
        mojem da polzvame mnogo Interfeisi implementirani v edin bazol klas 
        koito polse vsichki go nasledqvat !!! 
    
        Obache v JavaScript nqmame Interfeisi a imame 'mixini', samo taka mojem da 
        dostignem do mnojestveno nasledqvane.


    */





 /*
    
    Prototype Chain :



//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //KOGATO NASLEDIM EDIN KLAS NQKUDE TRQBVA DA SE SKLADIRAT NESHTATA OT PARENT KLASA, TE SE SUHRANQVAT V PROTOTIPA
    //OBACHE TOI SUDURJA SAMO METODITE NA PARENT KLASA

    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        VSEKI KLAS I OBEKT V JS SI IMA PROTOTYP KOITO E PROSTO EDIN 'TEMPLATE'.
        IZVIKVA SE SUS '_proto_' ILI SUS 'Object.getPrototypeOf(objName)';
            'AKO E KLAS' - TOZI PROTOTIP E NASLEDEN OT EDNA FUNKCIQ S IME '_proto_' !
                TAZI FUNKCIQ SUSHTO IMA PROTOTIP KOITO E NASLEDQN OT GLAVNIQ OBEKT 'Object' !
            'AKO E PROSTO OBEKT' TAZI FUNKCIQ '_proto_' NE SUSHTESTVUVA 

    VAjnooooooooooooooooooooooooooooooooooooooooo!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Kogato tursim dadeno property v daden obekt i NE go namirame, to avtomatichno se 
        tursi i v PROTOTIPA NA TOZI OBEKT, I AKO NE SE NAMERI I TAM SE TURSI I V PROTOTIPA
        NA NASLEDQNIQ KLAS I TAKA GO TURSI NA GORE PO VERIGATA DOKATO NE GO NAMERI.
        AKO STIGNE DO GLAVNIQ KLAS 'Object' I TAM NE GO NAMERI ZNACHI N VRUSHTA 'undefined'! 



    Sus Object.getPrototypeOf(objName);  VZIMAME PROTOTIPA NA DADEN OBEKT ILI PROSTO 'objName._proto_'.   


        Veche vidqhme che s :
            let childObj = Object.Create(parenObj);    // che mojem da nasledqvame obekti v JS

        Pri nasledqvaneto na protoripi e mnogo podobno.
        
        VAJNOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!
            SUS '_proto_' DOSTUPVAME PROTOTIPA NA DADENIQ KLAS !!!!!!!!!!!!!!!!!!!!


        NAI VAJNOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!
        Kak Raboti cqlata veriga?
            PROTOTIPA NA CHILD (DERIVED) KLASOVETE SOCHI KUM TEHNIQ PARENT (SUPER) KLAS.
            A PROTOTIPA NA PARENT KLASA SOCHI KUM EDNA VAJNA FUNKCIQ '__proto_' KOQTO PUK SOCHI 
            KUM 'NAI' GLAVNIQ OBEKT 'Object' !!!

        VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Tazi funkciq '__proto_' STOI VINAGI MEJDU GLAVNIQ KLAS 'Object' I OSTANALITE KLASOVE.
            OBACHE AKO RABOTIM S OBIKNOVENNI OBEKTI VMESTO S KLASOVE 'TAZI FUNKCIQ Q NQMA' I
                NE OCHASTVA V IERARHIQTA NA PROTOTIPA.


*/

//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //KOGATO NASLEDIM EDIN KLAS NQKUDE TRQBVA DA SE SKLADIRAT NESHTATA OT PARENT KLASA, TE SE SUHRANQVAT V PROTOTIPA
    //OBACHE TOI SUDURJA SAMO METODITE NA PARENT KLASA

//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!
    //RAZLIKA MEJDU OBEKTA I KLASA  
    //Klasa polzva '__proto__' ZA DA SETVA METODI I PROPERTITA RAVNI NA GORNIQ KLAS (tozi koito nasledqva) !!!!
    //KLASA OBACHE ZA RAZLIKA OT OBEKTA IMA I 'POLE' 'prototype'
    

console.log();
console.log("WORKING WITH prototype AND __proto__ OF A CLASS !");
console.log("Teacher.__proto__ : ");
console.log(Object.getPrototypeOf(Teacher));  // VRUSHTA NI 'Person'
console.log("prototype: SUHRANQVA VSICHKI METODI OT TOZI KLAS ZA DA GI PODADE NA NQKOI KLAS KOITO GO NASLEDQVA !!!")
console.log(Teacher.prototype);

console.log();
console.log("Sus:  .__proto__  hodim nagore po ierarhiqta")
console.log(Teacher.__proto__); // 'Person'  
console.log(Teacher.__proto__.__proto__ + ' - FUNKCIQTA KOQTO SEDI MEJDU "GLAVNIQ OBEKT" I "PARENT KLASA"'); // 'Function __proto__'
console.log(Teacher.__proto__.__proto__.__proto__ + ' - GLAVEN OBEKT'); // 'GLAVNIQ OBEKT {}'
console.log(Teacher.__proto__.__proto__.__proto__.__proto__ + ' - PROTOTPA NA GLAVNIQ OBEKT E Null'); // 'GLAVNIQ OBEKT {}'


console.log();
console.log("IS Object.getPrototypeOf(Person) == Function.prototype ? ");
console.log(Object.getPrototypeOf(Person) == Function.prototype);  // true
  

console.log();
console.log("Kogato suzdadem obekt na daden klas, __ptoto__ na obekta sochi kum samiq klas !!!");
let kacarska = new Teacher("Kacarska", "ne znam", "Matematika");
console.log(kacarska.__proto__);


console.log();
console.log("VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!");
console.log("KOGATO VZEMEM __proto__ OT DADEN OBEKT, TOI SOCHI KUM prototype NA SAMIQ OBEKT !");
console.log("kacarska.__proto__ === Teacher.prototype");
console.log(kacarska.__proto__ === Teacher.prototype)

console.log("kacarska.__proto__.__proto__ === Person.prototype");
console.log(kacarska.__proto__.__proto__ === Person.prototype)


console.log();
console.log("Obektite nqmat 'prototype'");
console.log(kacarska.prototype);




console.log();
console.log("EXTENDING CLASS PROTOTYPE:");
//EXTENDING CLASS PROTOTYPE:
//Mojem da zakachame neshta za prototipa 'prototype' na daden klas sled koeto decata na toq klas sushto shte imat tezi promqni
//v tehnite prototipi.

Person.prototype.species = 'Human';
console.log(Person.prototype.species); //mojem da go izvikame i taka


let toni = new Person("Anton", 25);
console.log("Toni species is : " + toni.species); //vseki obekt na tozi klas go ima

let tonisTeacher = new Teacher("Angelo", 55);
console.log("Toni's teacher  species is : " + tonisTeacher.species);



console.log();
console.log("RABOTA S NORMALNI OBEKTI :");
/*
    Rabota samo s obekti:

*/

let dog = { "name": "Gafy", "age": 9 };
console.log(dog.prototype); //VRUSHTA undefined      VIJDAME CHE TE NQMAT prototype
console.log(dog.__proto__); //VRUSHTA {} SOCHI KUM PROTOTIPA NA GLAVNIQ OBEKT
console.log();
console.log("__ptoto__ VSEKI NORMALEN OBEKT SOCHI KUM .prototype NA GLAVNIQ OBEKT");
console.log(dog.__proto__ === Object.prototype);

console.log("ZAKACHAME neshta za __proto__ na nashiq normalen obekt:");
//ZAKACHAME NESHTO ZA __proto__
dog.__proto__.gender = "Female";
console.log(dog.gender);

dog.__proto__.toString = function(){return `Name: ${this.name}, Age: ${this.age}, Gender: ${this.gender}`};
console.log(dog.toString); // vijdame che e funkciq
console.log(dog.toString());  // Izvikvame q







console.log();
console.log();
console.log();
console.log("Abstract Classes And Mixins: ");

/*
    Abstract Classes And Mixins:

        Mxinite sa kato Interfeisite v C#

        Abstracten klas e takuv koito ne moje da se inicializira direktno.
        Toi durji obsha logika za negovite deca

        V JS nie nqmame kluchova dumichka 'abstract' i zatova prosto si pravim valicaciq 
        dali sme napravili instanciq na tozi klas sus 'new'.
        
*/ 

class Animal
{
    constructor(){
        if(new.target === Animal){
            //HVURLQME GRESHKA
           //throw new TypeError("Cannot initializa an abstract method !!!");
            console.log("Cannot initializa an abstract method !!!");
        }
    }
}

let animalClass = new Animal();


/*
    V C# abstractniq metod trqbva da go implementirame zaduljitelno v decata na nashiq abtracten klas.
    NO V JS NQMAME ABTRACTEN METOD, I KAKTO VIJDAME OTGORE NQMAME I ASTRAKTEN KLAS, NIE SI GO PRAVIM 
    ABSTRAKTEN SAMO S EDNA VALIDACIQ.    

*/


/*

    Mixins:
        Te ni pozvolqvat mnojestveno nasledqvane.
        Mojem da extendvame ( nasledqvame )  nqkolko klasa bez da gi promenqme direktno.     

    VAJNOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Nqkoi programiti kazvat che:
            Mixinite moje i da sa po dobur variant vmesto klasicheskoto nasledqvane ppisano po gore !!!
        Drug variant za nasledqvane e Object Composition kudeto imame obekti v obekti,
        Mojem sushtotaka da gi nasledqvqme INDIREKTNO sus Object.create(parentObj);


    MIXSINITE SA TOVA KOETO VIDQHME V TRETA ZADACHA:
        Te sa prosto funkcii koito priemat KLASS / OBEKT i zakachat neshto za nego ili za prototipa mu !!!!
        Obache moje i da ne PRIEMAT SAMOQ OBEKT A CHREZ objName.call(change this); DA IZVIKAME FUNKCIQTA KTO 
        I  SMENIM this-a. 


        AKO POLZVAME MIXINA SUS KLAS ZNAEM CHE I DECATA MU SHTE IMAT SUSHTITE PROMQNI ZASHTOTO GO NASLEDQVAT.

*/

//Primer

class Cat
{
    constructor(name, age)
    {
        this.name = name;
        this.age = age;
    }
}

class Frog
{ 
    constructor(name, age)
    {
        this.name = name;
        this.age = age;
    }
}
    


//Mixin dobavq meow property na kotkata 
function addMeow(obj)
{
    obj.meow = function()
    {
        return `${obj.name} is ${obj.age} years old and is a ${obj.constructor.name} who says Meow.`;
    }
}


//Mixin koito dobavq bark property na kucheto
function addRabbit(obj)
{
    obj.rabbit = function(){
        return `${obj.name} is ${obj.age} years old and is a ${obj.constructor.name} who says Rabbit.`;
    }
}

//Pravim si obekti i vijdame che te nqmat bark i meow funkcii
let cat = new Cat("Sisa", 7);
let frog = new Frog("Froggie", 20);

addMeow(cat);
addRabbit(frog);

console.log(cat.meow());
console.log(frog.rabbit());




//Kazahme che mojem da imame i MIXIN i da go izvikame bez da mu podavame obekta a da mu 
//smenim this-a

//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//MNOGO EXPERTI KAZVAT CHE KLASICHESKOTO NASEDQVANE E POSLEDNOTO NESHTO KOETO TRQBVA DA POLZVAME PRI NASLEDQVANE
//KAZVAT CHE MOJE DA SE POSTIGNE SUSHTOTO NESHTO I BEZ NASLEDQVANE, BEZ KLUCHOVATA DUMICHNA 'new'.
//MOJEM DA POLZVAME MIXINI, OBJEC COMPOSITION, I CHAK NAKRAQ DA PROBVAME S KLASOVE I 'extends' !!!




//VAJNOOOOOOOOOOO!!!!!!!!!!!!!!!
//Sus 'instanceof' mojem da proverim dali daden obekt e ot daden klas, vrushta ni true ili false !!!!

console.log()
console.log()
console.log("Sus 'instanceof' mojem da proverim dali daden obekt e ot daden klas, vrushta ni true ili false")
console.log(frog instanceof Frog);












