function solve(args)
{
    let obj = {};
    for(let arg of args.slice(0, args.length - 1)) {
        // v sluchaq slice vzima vsichki elementi

        let tokens = arg.split(' ');

        let key = tokens[0];
        let value = tokens[1];

        obj[key] = value;
    }

    let key = args[args.length - 1]; // taka vzimame klucha

            console.log(obj[key] || "None"); // AKO EDNOTO E UNDEFINED POKAZVA DRUGOTO
}

solve(['key value','key eulav','test tset', 'key']);







