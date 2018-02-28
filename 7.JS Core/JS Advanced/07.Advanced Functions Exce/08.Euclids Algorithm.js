
function solve(a, b){

    if (b) {
        return solve(b, a % b);
    } else {
        return Math.abs(a);
    }

}

console.log(solve(252, 105));
