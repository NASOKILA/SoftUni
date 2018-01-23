
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
solve(['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4']);










