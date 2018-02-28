
function solve(arr, order) {

    if(order === 'asc')
        arr.sort((a, b) => a - b);
    else
        arr.sort((a, b) => b - a);
    
    return arr;
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));

console.log(solve([3, 1, 2, 10, 4, 8, 5, 7, 9, 20, 6], 'asc'));





