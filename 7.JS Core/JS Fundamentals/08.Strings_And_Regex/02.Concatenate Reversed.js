
function solve(args) {

    let str = '';

    for(let i = 0; i <= args.length-1; i++) {
        str += args[i]
    }

    //Array from

    console.log(str.split("").reverse().join(""));

}

solve(['I','am','student']);
solve(['race', 'car']);










