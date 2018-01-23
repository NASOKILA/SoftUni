
function solve(str, times) {

    let result = '';
    for(let i = 1; i <= times; i++)
    {
        result += str;
    }

    console.log(result);
}


solve('repeat', 5);