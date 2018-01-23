
function solve(args) {

    let result = [];

    for(let elem of args)
    {
        if(elem < 0)
            result.unshift(elem);
        else
            result.push(elem);
    }

    result.forEach(e => console.log(e));
}

//solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);















