
/*
function solve(args) {

    let min = args.reduce(function (a,b) {
        return Math.min(a, b);
    });
    console.log(min);

    let indexOfMin = args.indexOf(min);

    if(indexOfMin >= 0)
        args.splice(indexOfMin, 1);

    if(args.length >= 1)
    {
        let secondMin = args.reduce(function (a,b) {
            return Math.min(a, b);
        });

        console.log(secondMin);
    }
}
*/


function solve(args) {

    args.sort((a, b) => (a - b));

    if(args.length > 1)
        console.log(args[0] + ' ' + args[1]);
    else
        console.log(args[0])
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);
solve([1]);













