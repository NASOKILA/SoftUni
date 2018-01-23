
function solve(args) {

    let sum = 0;
    for(let i = 0; i <= args.length-1; i++)
         sum += args[i];

    console.log(sum);

    let inverseSum = 0;
    for(let i = 0; i <= args.length-1; i++)
        inverseSum += 1 / args[i];

    console.log(inverseSum);

    let concat = '';
    for(let i = 0; i <= args.length-1; i++)
        concat += args[i];

    console.log(concat);
}

solve([1,2,3]);
solve([2,4,8,16]);





