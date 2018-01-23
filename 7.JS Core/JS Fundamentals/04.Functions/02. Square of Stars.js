

function solve(n) {
    let simbol = '';
    for(let i = 1; i <= n; i++)
        simbol += '* ';

    for(let i = 1; i <= n; i++)
        console.log(simbol);
}

solve(5);
solve(1);
solve(2);


