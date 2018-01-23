
function solve(args) {

    let result = [];
    let arr = [];
    let k = args[0];

    for(let i = 1; i <= args.length -1; i++)
        arr.push(args[i]);

    for(let j = 0; j <= k-1; j++)
        result.push(arr[j]);

    for(let l = arr.length - k; l <= arr.length-1; l++)
        result.push(arr[l]);


    console.log(result);
}

solve([2,7,8,9]);
solve([3,6,7,8,9]);









