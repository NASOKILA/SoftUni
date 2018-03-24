

let Entity = require('./Entity');
let Dog = require('./Dog');


class Person extends Entity
{
    constructor(name, phrase, dog) 
    {
        super(name);

        this.phrase = phrase;
        this.dog = dog;
    }

    saySomething(){
        return `${this.name} says: ${this.phrase}${this.dog.name} barks!`;
    }
}

/*
let d = new Dog('Gafi');
let person = new Person("Nasko", 'My dog', d);

console.log(person.saySomething())
*/

module.exports = Person;





