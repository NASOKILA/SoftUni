
function solve(args){

    let x = Number(args[0]);
    let y = Number(args[1]);
    let z = Number(args[2]);

    let negativeNums = 0;

    if(x < 0){
        negativeNums++;
    }
    if(y < 0){
        negativeNums++;
    }
    if(z < 0){
        negativeNums++;
    }

    if(negativeNums === 1){
        console.log("Negative");
    }
    else
    {
        console.log("Positive");
    }
}
solve(['6','-3','-2']);




