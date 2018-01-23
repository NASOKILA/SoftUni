
function solve(n) {

    let simbol = '';
    for(let i = 0; i < n; i++)
    {
        for(let j = 0; j <= i; j++)
        {
            simbol += '$';
        }
        simbol += "\n"
    }
    console.log(simbol);
}

solve(3);










