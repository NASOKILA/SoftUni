
function solve(args)
{
    let obj = {};
    for(let arg of args.slice(0, args.length - 1)) {
        // v sluchaq slice vzima vsichki elementi

        let tokens = arg.split(' ');

        let key = tokens[0];
        let value = tokens[1];

        if(obj[key]) // ako klucha ne prazen
            obj[key].push(value); // slagame value vutre
        else    // ako klucha e prazen
            obj[key] = [value]; // slagame masiv s  purvoto value vutre
    }

    let key = args[args.length - 1]; // taka vzimame klucha

    //PURVO PROVERQVAME DALI obj[key] SUDURJA TAKAVA FUNKCIQ join()
    //AKO Q IMA DA PRINTIRA TOVA obj[key].join('\n') , AKO NE   "None"
    console.log(obj[key] ? obj[key].join('\n') : "None"); // AKO EDNOTO E UNDEFINED POKAZVA DRUGOTO
}

solve(['key value','key eulav','test tset', 'key']);

