
function solve(n) {

    let feet = Math.floor(n / 12);
    let rest = n % 12;

    let result = feet + "'-" + rest + '"';
    console.log(result);
}

solve(36);
solve(55);
solve(11);










