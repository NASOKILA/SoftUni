
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

/*
solve(['Banana',
        'Orange',
        'Coconut',
        'Apple',
        '15']);
*/

//1 2 3 4
//2 3 4 1
//3 4 1 2




function rotate(arr) {

    let n = Number(arr.pop());


    // 15 % 4 = 3   TAKA E !!!
    // 2 % 4 =
    n = n % arr.length;

    for(let i = 0; i < n; i++){

        //take lastElement
        const currentElement = arr.pop();

        //push it in the begining of the array
        arr.unshift(currentElement);
    }

    console.log(arr.join(" "));
}

rotate(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']);



rotate([1,2,3,4,2]);





