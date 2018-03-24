


let Entity = require('./Entity');

class Dog extends Entity
{
    constructor(name)
    {
        super(name);
    }

    saySomething()
    {
        return `${this.name} barks!`;
    }

}

/*
let dog = new Dog('gafy');
console.log(dog.saySomething());
*/

module.exports = Dog;



