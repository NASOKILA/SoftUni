
function solve(arr) {

    function reduce(arr, func) {
        let result = arr[0];
        for(let nexElement of arr.slice(1))
            result = func(result, nexElement);
        return result;
    }

    console.log('Sum = ' + reduce(arr, (a,b) => a + b));
    console.log('Min = ' + reduce(arr, (a,b) => a <= b ? a : b));
    //ako a e <= ot b vrushtame a inche b
    console.log('Max = ' + reduce(arr, (a,b) => a >= b ? a : b));
    //ako a e >= ot b vrushtame a inche b
    console.log('Product = ' + reduce(arr, (a,b) => a * b));
    console.log('Join = ' + reduce(arr, (a,b) => '' + a + b));

}

solve([2,3,10,5]);





