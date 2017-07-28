



function solve(args){


    let studentData = args
        .map(studentString => studentString.split(' -> '))
        .map(tokens => {

            return {
                name: tokens[0],
                age: Number(tokens[1]),
                grade: Number(tokens[2])
            };

        });

    studentData.forEach(student => {

       console.log(`Name: ${student.name}`);
       console.log(`Age: ${student.age}`);
       console.log(`Grade: ${student.grade.toFixed(2)}`);

    });




    //MAP V JS E KATO SELECT V C#



    /*
    for(arg of args){

        arg = arg.split('->');

        let name = arg[0];
        let age = arg[1];
        let grade = arg[2];

        console.log("Name: " + name + "\n" + "Age:" + age + "\n" + "Grade:" + grade);
    }
    */


/*

        for(arg of args){

            arg = arg.split('->');

            let name = arg[0];
            let age = Number(arg[1]);
            let grade = Number(arg[2]);


            console.log(`Name: ${name}`);
            console.log(`Age: ${age}`);
            console.log(`Grade: ${grade.toFixed(2)}`);

        }
*/
}

solve(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);















