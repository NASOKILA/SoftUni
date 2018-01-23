


function solve(n1, n2, operator) {

    let result = '';

    if(operator === '+')
        result = n1 + n2;
    else if(operator === '-')
        result = n1 - n2;
    else if(operator === '*')
        result = n1 * n2;
    else if(operator === '/')
        result = n1 / n2;

    console.log(result);
}

solve(2, 4, '+');
solve(18, -1, '*');
solve(3, 3, '/');


