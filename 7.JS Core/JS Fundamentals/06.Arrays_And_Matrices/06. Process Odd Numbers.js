function solve(args) {

    let result = [];

    for(let i = 0; i <= args.length-1; i++)
    {
        if(i % 2 === 1)
        {
            result.push(args[i] * 2);
        }
    }

    result.reverse().forEach(e => console.log(e));
}


solve([10, 15, 20, 25]);















