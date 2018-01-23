
function solve(a, b) {


    if(b === 0)
        return a;
    else
        return solve(b, a % b);
}

console.log(solve(252, 105));
