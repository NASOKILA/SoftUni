
class Person
{

    constructor(firstName, lastName, age, email) {

        //izvikva se konstrukra
        this.setFirstName = firstName;
        this.setLastName = lastName;
        this.setAge = age;
        this.setEmail = email;
    }

    //vrushta propertito
    get getFirstName(){
        return this.firstName;
    }
    //setva propertito na podadenoto v konstruktura
    set setFirstName(fName){
        //validacii
        return this.firstName = fName;
    }
    
    get getLastName(){
        return this.lastName;
    }
    set setLastName(lName){
        //validacii
        this.lastName = lName;
    }

    get getAge(){
        return this.age;
    }
    set setAge(Age){
        //validacii
        return this.age = Age;
    }
    
    get getEmail(){
        return this.email;
    }
    set setEmail(Email){
        //validacii
        this.email = Email;
    }

    toString(){
        return `${this.getFirstName} ${this.getLastName} (age: ${this.getAge}, email: ${this.getEmail})`;
    }

}

let person = new Person('Maria', 'Petrova', 22, 'mp@yahoo.com');


console.log(person.toString());





