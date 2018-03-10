



function personAndTeacher() {


    class Person {

        constructor(name, email) {
            this.setName = name;
            this.setEmail = email;
        }

        get getName() {
            return this.name;
        }
        set setName(newName) {
            this.name = newName;
        }

        get getEmail() {
            return this.email;
        }
        set setEmail(newEmail) {
            this.email = newEmail;
        }

    }


    class Teacher extends Person {

        constructor(name, email, subject) {

            super(name, email);
             
            this.setSubject = subject;
        }

        get getSubject() {
            return this.subject;
        }
        set setSubject(newSubject) {
            this.subject = newSubject;
        }

    }

    return {Person, Teacher};
}


// Testvame si programata

    //purvo si vzimame tova koeto vrushta nashata funkciq, tq vrushta obekt s dvata klasa 
    let classes = personAndTeacher();

    let person = new classes.Person("Atanas", "naso@abv.bg");
    console.log(person.getName);
    console.log(person.getEmail);

    console.log();
    let teacher = new classes.Teacher("Asen", "asi@abv.bg", "Design");
    console.log(teacher.getName);
    console.log(teacher.getEmail);
    console.log(teacher.getSubject);









