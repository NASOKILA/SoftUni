

function solve(args) {

    let regex = /^([A-Z][a-zA-Z]*) - ([1-9]\d*) - ([a-zA-Z0-9 \-]+)$/;

    for(let elem of args)
    {
        let match = regex.exec(elem);

        if(match) // ako nqma match da produlji
        {

            console.log(`Name: ${match[1]}`);
            console.log(`Position: ${match[3]}`);
            console.log(`Salary: ${match[2]}`);
        }
    }
}


solve(['Isacc - 1000 - CEO',
       'Ivan - 500 - Employee',
       'Peter - 500 - Employee']);









