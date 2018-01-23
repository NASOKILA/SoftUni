

function solve(n)
{
    if(n < 0)
        n = Math.abs(n);

    if(n % 2 === 0)
        console.log("even");
    else if(n % 2 === 1)
        console.log("odd");
    else
        console.log("invalid");
}

solve(5);
solve(8);
solve(1.5);
solve(-3);





