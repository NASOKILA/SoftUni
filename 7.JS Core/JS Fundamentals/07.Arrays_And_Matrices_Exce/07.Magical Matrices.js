
function solve(args) {

    let rowSum = 0;
    let colSum = 0;

    for(let r of args)
        r.forEach(e => rowSum += e);

    for(let i = 0; i <= args.length-1; i++)
    {
        for(let c of args)
            colSum += c[0];
    }

    if(rowSum === colSum)
        console.log(true);
    else
        console.log(false);

}
/*
solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);
*/

/*
solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]);
*/
/*
solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]);
*/

function magicalMatrix(arr) {

    //fill rows
    let rowSums = [];
    for(let row in arr){

        let rowSum = 0;
        arr[row].forEach(n => rowSum += n);
        rowSums.push(rowSum);
    }

    //fill cols
    let colSums = [];
    let colSum = 0;
    let counter = 0;

    for(let row in arr){
        for(let col in arr){
            colSum += arr[col][row];
        }
        colSums.push(colSum);
        colSum = 0;
    }


    //check rows
    if(rowSums.filter((a) => a !== rowSums[0]).length > 0){
        console.log('false');
        return;
    }

    //check cols
    if(colSums.filter((a) => a !== rowSums[0]).length > 0){
        console.log('false');
        return;
    }

    console.log('true');

}


magicalMatrix([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]);

magicalMatrix([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);

magicalMatrix([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
);



