

let findMaxNum = (function (){

    let maxElement = 0;
    return function findMaxNum(args) {

        maxElement = Math.max.apply(null, args);
        return(maxElement);
    }

})();


console.log(findMaxNum([1, 44, 123, 33]));


/*
function solve(args) {

    let maxElement = 0;

    maxElement = Math.max.apply(null, args);
    return(maxElement);
}

console.log(solve([1, 44, 123, 33]));
*/


