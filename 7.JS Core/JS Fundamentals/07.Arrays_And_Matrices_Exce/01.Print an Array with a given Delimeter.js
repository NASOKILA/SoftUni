



function solve(args) {

    let simbol = args[args.length-1];

    let result = args.join(simbol);

    console.log(result.substring(0, result.length-2));
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']);










