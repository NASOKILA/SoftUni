
function solve(args) {

    let result = {};

    for(let i = 0; i <= args.length-1; i = i + 2)
    {
        let key = args[i];
        let value = Number(args[i+1]);

        if(result.hasOwnProperty(key))
            value += result[key];

            result[key] = value;
    }

    console.log(JSON.stringify(result));
}

//solve(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);
//solve(['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4']);




function s(input) {

    let result = {};

    for (let i = 0; i < input.length-1; i+=2) {

        let town = input[i];
        let value = Number(input[i+1]);
        if(result.hasOwnProperty(town))
            value += Number(result[town]);

        result[town] = value;
    }

    console.log(JSON.stringify(result));
}

s(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);
s(['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4']);


