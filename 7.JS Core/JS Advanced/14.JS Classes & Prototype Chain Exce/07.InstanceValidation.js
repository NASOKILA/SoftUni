




class CheckingAccount {

    constructor(clientId, email, firstName, lastName) {

        this.setClientId = clientId;
        this.setEmail = email;
        this.setFirstName = firstName;
        this.setLastName = lastName;
        this.products = [];
    }


    get getClientId() {
        return this.clientId;
    }
    set setClientId(newClientId) {
        let type = typeof newClientId;
        let length = newClientId.length;
        let numbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

        let areAllNumbers = newClientId
            .split('')
            .every(ch => numbers.includes(ch))

        if (type !== "string" || length !== 6 || !areAllNumbers) {
            throw new TypeError("Client ID must be a 6-digit number");
        }

        this.clientId = newClientId;
    }


    get getEmail() {
        return this.email;
    }
    set setEmail(newEmail) {
        let type = typeof newEmail;
        let validEmailPattern = /^[a-zA-Z0-9]+\@[a-zA-Z0-9]+\.[a-zA-Z0-9.]+$/gm;
        let isItValid = validEmailPattern.test(newEmail);

        if (type !== "string" || !isItValid) {
            throw new TypeError("Invalid e-mail");
        }

        this.email = newEmail;
    }


    get getFistName() {
        return this.firstName;
    }
    set setFirstName(newFistName) {
        //let type = typeof newFistName;
        let length = newFistName.length;

        if (length < 3 || length > 20) 
            throw new TypeError('First name must be between 3 and 20 characters long');
        

        let onlyLatinLetters = /^[a-zA-Z]+$/gm.test(newFistName);
        if (!onlyLatinLetters) 
            throw new TypeError('First name must contain only Latin characters');
        

        this.fistName = newFistName;
    }


    get getLastName() {
        return this.lastName;
    }
    set setLastName(newLastName) {

        //let type = typeof newFistName;
        let length = newLastName.length;

        if (length < 3 || length > 20) 
            throw new TypeError('Last name must be between 3 and 20 characters long');
        

        let onlyLatinLetters = /^[a-zA-Z]+$/gm.test(newLastName);
        
        if (!onlyLatinLetters) 
            throw new TypeError('Last name must contain only Latin characters');
        


        this.lastName = newLastName;
    }

}




try {
    //let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov');

    //let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov')

    //let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov')

    //let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivаn', 'P3trov')

    let acc = new CheckingAccount('4234145', 'petkan@another.co.uk', 'Petkan', 'Draganov');

}
catch (ex) {
    console.log(ex.message);
}







