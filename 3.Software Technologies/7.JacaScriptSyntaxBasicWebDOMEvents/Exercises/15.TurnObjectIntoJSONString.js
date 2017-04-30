
function solve(args){

    let studentData = args
        .map(studentString => studentString.split(' -> '));

    let student = {};

    studentData.forEach(tokens => {

            let key = tokens[0];
            let value = tokens[1];

            student[key] = value;


    });
            student.age = Number(student.age);
            student.grade = Number(student.grade);


        console.log(JSON.stringify(student));
      //  console.log(studentData);
    //SPLITNAHEM VSICHKI I GI SLAGAME V EDIN OBEKT


/*
    let students = args.forEach(object => {
            let student = JSON.stringify(object);
            console.log(student);
    });
*/


}

solve(['name -> Angel','surname -> Georgiev','age -> 20', 'grade -> 6.00',
        'date -> 23/05/1995','town -> Sofia']);





















