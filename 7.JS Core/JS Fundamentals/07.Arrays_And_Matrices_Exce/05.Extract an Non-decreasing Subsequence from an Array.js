
function solve(args) {

    let max = -999999999999;

    for(let e of args)
    {
        if(e >= max)
        {
            console.log(e);
            max = e;
        }
    }
}

//solve([1,3,8,4,10,12,3,2,24]);


function Extract(arr) {

    let max = -99999999999;
    let newArr = arr.map((n) => {
        if(n >= max){
            max = n;
            return max;
        }
        return '';
    })
        .filter( e => e !== '');


    newArr.forEach( n => console.log(n));
}

Extract([1,3,8,4,10,12,3,2,24]);






