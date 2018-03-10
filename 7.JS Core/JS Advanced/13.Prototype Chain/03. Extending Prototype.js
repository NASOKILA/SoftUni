



class Person
{
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    toString()
    {
        return `[name: ${this.name}, age = ${this.age}, species = ${this.species}]`;
    }
}


function extendClass(classToExtend)
{
    //Zakachame species pole za prototipa na podadeniq klas
    classToExtend.prototype.species = "Human";

    //zakachame i funkcq za tozi prototip na podadeniq klas
    classToExtend.prototype.toSpeciesString =   function(){
            return `I am a ${this.species}. ${this.toString()}`;
        }
    
}

extendClass(Person);

let nasko = new Person("Atanas", 25);

//extendvame si go SAMATA FUNKCIQ IZVIKVA .toString METODA !!!
console.log(nasko.toSpeciesString());


console.log();
//SEGA ZAKACHIHME NESHOT KUM PROTOTIPA NA KLASA Human VIJDAME CHE IMAME species i toSpeciesString v Animal.prototipe !!!
console.log(Person.prototype.species);
console.log(Person.prototype.toSpeciesString);




















