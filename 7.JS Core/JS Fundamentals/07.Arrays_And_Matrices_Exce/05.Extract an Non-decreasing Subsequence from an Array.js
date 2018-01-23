
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

solve([1,3,8,4,10,12,3,2,24]);










