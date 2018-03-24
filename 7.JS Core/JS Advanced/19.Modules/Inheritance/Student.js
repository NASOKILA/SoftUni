




let Dog = require('./Dog');
let Person = require('./Person');

class Student extends Person
{
    constructor(name, phase, dog, id)    {  
        super(name, phase, dog);      
        this.id = id;
    }
    saySomething(){
        return `Id: ${this.id} ${this.name} says: ${this.phrase}${this.dog.name} barks!`;
    }
}

/*
let d = new Dog('Gafi');
let student = new Student(1, "Nasko", 'My dog ', d);
console.log(student.saySomething());
*/

module.exports = Student;



