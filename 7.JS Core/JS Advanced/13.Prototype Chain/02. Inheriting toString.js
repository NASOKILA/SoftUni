





function PersonAndTeacher(){

    class Person
    {
        constructor(name, email){
            this.setName = name;
            this.setEmail = email;
        }

        get getName(){
            return this.name;
        }
        set setName(newName)
        {
            this.name = newName;
        }

        get getEmail(){
            return this.email;
        }
        set setEmail(newEmail)
        {
            this.email = newEmail;
        }


        //dobavqme si toString() metod
        //ZNAEM CHE PRI SUZDAVANETO NA KLAS TOI NASLEDQVA 'Object' KOITO SUDURJA toString() metoda
        toString(){

            //kak vzimame imeto na edin klas
            let className = this.constructor.name;

            return `${className} (name: ${this.getName}, email: ${this.getEmail})`;
        }

    }


    class Teacher extends Person
    {
        constructor(name, email, subject)
        {
            super(name, email);

            this.setSubject = subject;
        }
    
        get getSubject(){
            return this.subject;
        }
        set setSubject(newSubject){
            this.subject = newSubject;
        }


        //Teacher obache ima i Subject, KAK SHTE GO PRINTIRAME ???
        toString(){

            //Vzimame resultata ot gornoto i sus slice mahame zatvarqshtat askoba
            let baseStr = super.toString().slice(0,-1);
            return baseStr + `, subject: ${this.getSubject})`; //nakraq si doavqme i ztvarqshtata skoba
        }

    }


    class Student extends Person
    {
        constructor(name, email, course)
        {
            super(name, email);

            this.setCourse = course;
        }

        get getCourse(){
            return this.course;
        }
        set setCourse(newCourse){
            this.course = newCourse;
        }

        toString(){
            let baseResult = super.toString().slice(0, -1);
            return baseResult + `, course: ${this.getCourse})`;
        }

    }


    let result = 
    {
        "Person":Person,
        "Teacher":Teacher,
        "Student":Student
    }

    return result;

}


//Funkciqta vrustha dvata klasa zapisvame gi v 'obj' !!!
let obj =  PersonAndTeacher();

//Zapisvame si klasovete v otdelni promenlivi
let Person = obj.Person;
let Teacher = obj.Teacher;
let Student = obj.Student;

//suzdavame instancii
let person = new Person("Toni", "toni@abv.bg");
let teacher = new Teacher("Nasko", "atanas@abv.bg", "Programming");
let student = new Student("Asen", "asi@abv.bg", "Basic");

//izvikvame toString() na vsqka edna suzdadena instanciq
console.log(person.toString());
console.log();
console.log(teacher.toString());
console.log();
console.log(student.toString());


