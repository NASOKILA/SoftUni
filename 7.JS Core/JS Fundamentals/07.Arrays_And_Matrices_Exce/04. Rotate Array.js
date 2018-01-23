
function solve(args) {

    let timesToRotate = Number(args[args.length-1]);
    args.pop();
    let arr = args;

    timesToRotate %= arr.length;


    for(let i = 0; i < timesToRotate; i++)
    {
        let lastElem = arr.pop();
        arr.unshift(lastElem);
    }

    console.log(arr.join(' '));

}

//solve(['1','2','3','4','2']);
solve(['Banana',
        'Orange',
        'Coconut',
        'Apple',
        '15']);

//1 2 3 4
//2 3 4 1
//3 4 1 2





