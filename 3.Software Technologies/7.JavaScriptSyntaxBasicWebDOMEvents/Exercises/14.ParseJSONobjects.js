
function solve(args){

    let students = [];
    args.forEach(jsonString => { // jsonString e tova koeto poluchavame
        let student = JSON.parse(jsonString); // sega go parsvame i zapisvame v student

        students.push(student);
    });

    console.log(students);

    /*
    for(let str of args){

       // let obj = JSON.parse(str);

        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Date: ${obj.date}`);
    }
    */

}

solve(['{"name":"Gosho","age":10,"date":"19/06/2005"}','{"name":"Tosho","age":11,"date":"04/04/2005"}']);
//{"name":"Tosho","age":11,"date":"04/04/2005"}



















