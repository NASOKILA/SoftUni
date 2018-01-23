

function solve(arr, order) {


    if(order === 'asc') {
        arr = arr.sort((a,b) => {
            "use strict";
            if(a < b)
                return 1;
            else if ( a > b)
                return -1;
            else return 0;
        }).reverse();
    }else{
        arr = arr.sort((a,b) => {
            "use strict";
            if(a < b)
                return 1;
            else if ( a > b)
                return -1;
            else return 0;
        })
    }
    return arr;
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));