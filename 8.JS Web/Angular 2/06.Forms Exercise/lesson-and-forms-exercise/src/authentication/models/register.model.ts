//username, password, first name, last name, email and age

export class RegisterModel {

    constructor(
    public username : String,
    public password : String,
    public firstName : String,
    public lastName : String,
    public email : String,
    public age? : Number, //age is optional
    ){}
}