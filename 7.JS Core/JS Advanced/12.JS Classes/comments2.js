

//KLASA E OBEKT SAMOCHE NIE MU DAVAME TIP t.e. kato zaglavie
console.log("CLASS RECTANGLE");
class Rectangle {

//V konstruktura si definirame propertitata
    constructor(width, height, color = "Red") //taka ako ne podaden 'color' shte go setne avtomatichno na 'Red' 
    {
        this._width = width;
        this._height = height || 0;
        this._color = color;
    }

    //get property koeto ne mojem da promenqme
    get area() {
        return this._width * this._height;
    }

    //Tova veche e metod
    calcArea(){
        return this._width * this._height;
    }

}


let defaultRect = new Rectangle(5);     
console.log(defaultRect);      //Vijdame che po default color = "Red"; i height = 0;
console.log();

//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!
    //S DUMICHKATA 'new' IZVIKVAME KONSTRUKTURA
    //I V KONSTRUKTURA 'this' SOCHI KUM TEKUSHTIQ OBEKT T.E. V GORNIQ SLUCHAI 'defaultRect'.


let rect = new Rectangle(5, 5, "White");

//Propertitata v konstruktura VECHE IMAT GETTERI I SETTERI TAKACHE MOJEM DA GI PROMENQME
rect._width = 10;
console.log(rect._width);
console.log();

//Mojem da si dobavqme propertita:
rect.hahaha = "HAHAHA";
console.log(rect.hahaha);
console.log();

console.log(rect.area); //NE E METOD A 'get' PROPERTY ZATOVA SE VIKA KATO PROPERTY
console.log();

//GET PROPERTITATA NE MOJE DA SE PROMENQT
rect.area = 10;
console.log(rect.area); //NQMA PROMQNA EDNO  I SUSHTO SI E
console.log();

//Tova veche e metod i se izvikva kato takuv :
console.log(rect.calcArea());
console.log();






/*
VAJNO !!!
    Kakuvto i klas da suzdadem v JS toi PROIZLIZA OT KLASA Object

VAJNO !!!

    V JS FUNKCIITE SE HOISTVAT T.E. NIE MOJEM DA SI GI SLOJIM NAI OT DOLO NA FAILA I DA GI POLZVAME.
    OBACHE KLASOVETE V JS NE SE HOISTVAT T.E. NE MOJEM DA SUZDADEM OBEKT OT DADEN KLAS 
    PREDI DA SME GO DEFINIRALI !!!!!!!!!!!!!!!!!!!!!!!!!!!!!


    V klasovete ne mojem da pravim promeivi, funkcii i dr.
    OBACHE V KONSTRUKTURA MOJE.
*/

console.log("CLASS PERSON: ");
class Person{
    
    //V tqloto na klasa ne moga da definiram promenlivi, funkcii i dr.
    //NO V KONSTRUKTURA MI E POZVOLENO
    
    constructor(name, age)
    {
        this._name = name;
        this._age = age;

        //mojem da setnem neshto na funkciq
        this._something = function(){
            return "I am Function";
        }
        //tik moga da si rabota normalno
        let friend = "Petre";        
        let arr = [];
        let obj = {};

        //this sochi kum tekushtata instanciq na klasa:
        //OBACHE VUV FUNKCIQ 'this' VECHE NE RABOTI
        //OBACHE NIE UK MOJEM DA GO SEIVAME V PROMENLIVA I DA SI GO POLZVAME
        let tekushObekt = this; 
        console.log(tekushObekt); //Person { _name: 'Atanas', _age: 25 }


        function printThis() {
            console.log(this);  // undefined
            console.log(tekushObekt); //Person { _name: 'Atanas', _age: 25 }
        }
        printThis();     // VAJNO!!! : Sus printThis.call(this); PROMENQME THIS-a DA SI SOCHI KUM OBEKTA KAKTO PREDI
    }



}

//V KONSTRUKTURA 'this' SOCHI KUM  OBEKTA 'nasko' OBACHE VUV FUNKCIQ NE RABOTI 
//OBACHE NIE MOJE DA SI GO IZVEDEM V PROMENLIVA I DA SI GO POLZVAME 
let nasko = new Person("Atanas", 25);
//Pri praveneto na obekt ot tip Person ot konstruktura shte se 
//izvika funkciqta printThis() 


/*
VAJNO !!!
    POMNI CHE SUS .call() .apply() i .bind()  NIE MOJEM DA PROMENQME POVEDENIETO NA 'this' !!!
*/



/*
VAJNOOOOO !!!!!!
    V SETERITE MOJEM DA SI PRAVIM VALIDACII NA PODADENITE PROPERTITA ZASHTOTO NE MOJEM DA 
    ZNAEM DALI PODADENOTO OT POTREBITELA E VALIDNO.

    I POSLE V KONTRUKTURA NE SETVAME DIREKTNO A POLZVAME SETERA ZA DA SETNEM POLETATA.
*/





/*
    Klasa e SHABLON koito si ima tip, ima propertita, funkcii i dr.
    
    VAJNOOOOOOOOOOOO!!!!!!!
        V JS MOJEM DA IMAME SAMO EDIN KONSTRUKTOR.

        V KONSTRUKTURA MOJEM DA POLZVAME DESTRUKTURIRANE.


*/



/*
    GETTERI I SETTERI:
        
        Getter: Toi e za da ne vzimame direktno propertito no mojem da si pravim i
            specialni geteri za kakvoto si iskame, TOI PROSTO VRUSHTA NESHTO
        Setter: Toi trqbva da priema parametur i PROMENQ STOINOSTA na dadeno neshto.
         

    MNOOOOOOOGOOOOO VAJJJJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!
        GETERA I SETERA NE MOJE DA SE SUS SUSHTITE IMENA KAKTO POLETATA

    VAJNOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        NE MOJEM DA PROPUSKAMME this. ZASHTOTO NQMA DA SE USETI SAMO KAKVO ISKAME DA VZEMEM I SHTE GRUMNE !!!


    CELTA E DA IMAME VALIDACIQ V SETTERA VMESTO V KONSTRUKTURA A GETERA E PROSTO ZA DA NE 
    VZIMAME DIREKTNO POLETO.


*/


/*
    Statichni metodi v klasovete:
        Imame 'static' samo za metodi no ne i za promenlivi.
        Pravi se sus dumata 'static' metod

        STATICHNIQ METOD E OBSHT ZA KLASUT V KOITO SA SUZDADENI I NE ZAVISQT OT INSTANCIITE NA KLASA.
        STATICHNITE METODI NE MOJE DA SE IZVIKAT OT INSTANCIQ NA KLASA, TE SE IZVIKVAT OT 
        SAMIQ KLAS: 
        ClassName.staticMethodName(param1, param2);

    VIJ PETA ZADACHA.
*/


/*

LEGACY CLASSES: (Klasove po stariq nachin)

TOVA E VAJNO AKO SE RABOTI VURHU PO STARI PROEKTI,
NO ZA NAPRED SHTE SE PISHAT PO RAZLICHEN NACHIN.

    Predi vreme klasovete sa se pravili ruchno
    bili konstrukturi.
    Funkciite sa se zakachali direktno i ruchno za prototipite.
*/

//konstruktura e bil prosta funkciq koqto suzdava propertita na obekta i gi setva na podadenite parametri
function OldRectangles(width, height) {
    this.width = width;
    this.height = height;
}

//Metodite sa se zakachali direktno za prototipa na funciqta
OldRectangles.prototype.area = function () {
    return this.width * this.height;
};

//Za instanciqta prosto si izvikvame funkciqta sus 'new'
let oldRectOne = new OldRectangles(3, 5);
console.log(oldRectOne);


//Vijdame funkciqta area() zashtoto e zakachena za prototipa, za da q izvikame.
console.log(oldRectOne.area());

//OldRectangles.area();     //.area() NE E STATICHEN METOD ZATOVA NE MOJEM DA GO IZVIKVAME DIREKTNO OT KLASA!!!

//STARITE METODI OSHTE RABOTAT MOJE DA NI SE NALOJI DA GI PRILAGAME VURHU STARI PROEKTI



/*
    Konstrukturite izvikvat seterite.
    Setterute pravat validaciq i setvat propertitata na podadenoto v konstruktura
    Getterite s samo za izvikvane na propertita.

*/

/*

    Incapsulaciq :
        Tuk nqmame dumichkta 'private' NO IMA NACHINI KAK DA SI NAPRAVIM PRIVATE POLETA !!! 
        Za da skriem dadeni danni MOJEM DA POLZVAME 'CLOSURE' OT IIFE Funkciq

*/



















