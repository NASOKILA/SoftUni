
function solve(args) {

    let rowSum = 0;
    let colSum = 0;

    for(let r of args)
        r.forEach(e => rowSum += e);

    for(let i = 0; i <= args.length-1; i++)
    {
        for(let c of args)
            colSum += c[0];
    }

    if(rowSum === colSum)
        console.log(true);
    else
        console.log(false);

}
/*
solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);
*/

/*
solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]);
*/

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]);


