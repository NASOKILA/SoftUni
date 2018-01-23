
function solve(args) {

    let n = args[args.length -1];

    let result = [];
    for(let i = 0; i <= args.length-1; i = i + n)
    {
        result.push(args[i]);
    }

    for( let i = 0; i <= result.length-1; i++)
    {
        console.log(result[i]);
    }
}

solve([5,20,31,4,20,2]);










