
function solve(args) {

    let n = Number(args[args.length -1]);

    let result = [];
    for(let i = 0; i < args.length-1; i = i + n){
        result.push(args[i]);
    }

    for( let i = 0; i <= result.length-1; i++)
    {
        console.log(result[i]);
    }
}

//solve([5,20,31,4,20,2]);
/*
solve(['dsa',
    'asd',
    'test',
    'tset',
    '2']);

*/
function everyNElement(arr) {
    let step = Number(arr.pop());

    for(let i = 0; i < arr.length; i += step)
        console.log(arr[i]);
}

everyNElement([5,20,31,4,20,2]);
/*
everyNElement(['dsa',
    'asd',
    'test',
    'tset',
    '2']);
*/