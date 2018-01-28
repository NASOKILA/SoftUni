
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


console.log();
function s(arr) {

    //subirame vsichko v edin string, posle go pravim toq string na masiv
    //obrushtame go, pravim go pak na string i go printirame
    console.log(arr.join("").split("").reverse().join(""));
}


s(['I','am','student']);
s(['race', 'car']);










