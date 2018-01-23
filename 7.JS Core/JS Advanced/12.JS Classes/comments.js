
/*

Klasa e neshto novo v JS.

Shte govorim za:
    Definiciq,
    Konstrukturi i metodi,
    Propertita,
    statichni chlenove,
    legacy klasove.

*/


/*
 Klasovete sa shablona na obekta te sa primeren obekt.
 Edin klas moje da ima Danni i Deistviq.
 Imat propertita i svoistva,
 mogat da imat i funkcii,

*/


/*
Kak se pravi:
Po princip se slaga v otdelen fail.
SAMOIQ class E FUNKCIQ

KLASOVETE SE PISHAT S GLAVNA BUKVA.
*/

class Rectangle {

    //vsichko tuka e funkciq ne e nujno da pishem function.

    //Konstruktura se izvikva s dumata constructor()
    //MOJEM DA VZIMAME PARAMETRITE I CHREZ argumnts[...] VAJNO!!!!!
    constructor(width, height, color = 'white'){
        //slagame color da e po default 'white'
        //ako ne podadem cvqt shte go napravi da e white
        this.width = width;
        this.height = height || 0; //Moje i taka da slagame default, ili podadenoto ili 0
        this.color = color;
    }

    //Mojem da dobvqme funkcii
    calcArea(){
        return this.width * this.height;
    }
}

//SAMOIQ class E FUNKCIQ
console.log(Rectangle);


let rect = {
    width:5,
    height:4,
    color:'red'
};
console.log(rect);

//kak se polzva ?
let rect2 = new Rectangle(2,66,'green');
console.log(rect2);
console.log(rect2.calcArea());


let rect3 = new Rectangle(22,16);
console.log(rect3); // po default cveta mu e 'white' inache shte e undefined

let rect4 = new Rectangle(555);
console.log(rect4); // po default cveta mu e 'white' i height e 0

//KLASA RABOTI KATO OBEKT MOJE DA MU DOBAVQME PROPERTITA.
rect4.name = 'Rectangle 4';
console.log(rect4);


//VAJNO !!!!! :
//Ako vmesto let napishem const ne mojem da promenqme neshtata v klasa
const rect5 = new Rectangle(11,88,'blue');
rect5.width = 99;
rect5.name = 'rect 5';
console.log(rect5);






//Kakvo BESHE CLOSURE ?
function solve() {

    let counter = 0;

    //samo tazi funkciq vijda scoupa
    return function countdown() {
        counter++;
        return counter;
    }
}

//MOJE I DA E S IIFE.

let counting = solve();

//countera ne zapochva ot 0, toi si ostava sushtiq kolkoto puti i da izvikvame tazi funkciq
console.log(counting()); //1
console.log(counting()); //2
console.log(counting()); //3

console.log();

let counting2 = solve();
console.log(counting2()); //1
console.log(counting2()); //2
console.log(counting2()); //3








/*
Accessors Properties:
    Tova sa dopulnitelni speciqlni funkcii(){...}

*/

console.log();

class Circle {

    /*
        Mnogo vajno :
        Konstruktura minava prez settera koito minava prez gettera.
    */

    constructor(radius){
        this._radius = radius;
    }

    //Tova si e funkciq
    diameter2(){
        return this._radius  * 2;
    }

    //get ozn che stawa na properti i veche ne e funkciq
    //ne mojem da go setnem zashtoto ne e 'set'.
    //dostupva se s .diameter vmesto sus .diameter()
    get diameter(){
        return this._radius  * 2;
    }

    //podavame get propertito i go setvame
    set diameter(diameter){
        this._radius  = diameter / 2;
    }

    //set ni pozvolqva da setvame kakto si iskame kakto v C#

    get area(){
        //r na kvadrat * PI(3.14)
        return Math.pow(this._radius,2) *  Math.PI;
    }


    get radius(){
        return this._radius;
    }

    set radius(radius){
        this._radius = radius;
    }

    //GETTERITE I SETTERITE MOGAT DA SA FUNKCII VMESTO PROPERTITA.
    //KOITO PRAVAT SUSGTOTO NESHTO.
}


let circle1 = new Circle(5);
console.log(circle1);
console.log(circle1.diameter2());
console.log(circle1.diameter); //vikame go kato property

console.log('Area: ' + circle1.area);

//BEZ set propertito ne mojem da go setvame pak si e 5 !!!!!
circle1.diameter = 12;
console.log(circle1.diameter);

console.log(circle1.radius);


/*
 MNOOOOOOOOGO VAJNOOOOOOOOOOOOOOOOOOO !!!!!!!!!!!!!!!! :
    Konstruktura minava prez settera koito minava prez gettera
    ako mu go podadem.
*/




console.log();


/*
    Statichni metodi:   LESNO E  !!!!!!!!!!!!!
        Te sa danni ili povedeniq koito sa spodeleni sus vsichki
        chlenove na toq klas.

*/


class Point {
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    //sega tazi funkciq e zakachena za SAMIQ KLAS
    static distance(a, b) {
        //const ne mojem da go promenqme
        const dx = a.x - b.x;
        const dy = a.y - b.y;
        return Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2));
    }
}

//STATICHNATA FUNKCIQ E VUTRE V KLASA NO NIE MOJEM PROSTO DA SI Q NAPRAVIM
//OTVUN KLASA I PAK DA Q POLZVAME.


let pointOne = new Point(-2, 5);
let pointTwo = new Point(22, 15);

//SEGA ZA DA IZVIKAME STATICHNIQ METOD PROSTO PISHEM;
console.log(Point.distance(pointOne, pointTwo));

//NE MOJEM DA GO IZPOLZVAME OT INSTANCII:
console.log(pointOne.distance); // dava undefined





console.log();

/*

LEGACY CLASSES: (Klasove po stariq nachin)

TOVA E VAJNO AKO SE RABOTI VURHU PO STARI PROEKTI,
NO ZA NAPRED SHTE SE PISHAT PO RAZLICHEN NACHIN.

    Predi vreme klasovete sa se pravili ruchno
    bili konstrukturi.
    Funkciite sa se zakachali direktno i ruchno za prototipite.
*/

function OldRectangles(width, height) {
    this.width = width;
    this.height = height;
}

//Metodite sa se zakachali direktno za prototipa
OldRectangles.prototype.area = function () {
    return this.width * this.height;
};

let oldRectOne = new OldRectangles(3, 5);
console.log(oldRectOne);


//Ne vijdame funkciqta area() zashtoto e zakachena za prototipa, za da q izvikame.
console.log(oldRectOne.area());





/*
    Protecting Class Data:
        Trqbva da pazim sustoqnieto da e korektno.
*/



/*
    SUMMARY:
    Klasa e strukturata na obekta.
    S new suzdavame abstrakciq na toq klas
    construktor(){...} e vajna funkciq
    Accessor Propertita sa funkcii za validaciq, getteri i setteri
    

*/