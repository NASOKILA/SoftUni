function solve(args){

    let words = args
        .join(' ')  // joinvame gi s prazen string
        .split(/\W+/)  // splitvame s regex
        .filter(w => w.length > 0) //mahame tazi koito sa s length 0
        .filter(x => x === x.toUpperCase())
        .join(', ');  // vzimame SAMO TEZI NAPISANI S UPPERCASE
    //moje da se napravi i s for cikul obache e mnogo pisane.

// MOJEM DA NAPISHEM I new RegExp('\W+');

    console.log(words);
}
solve([
    "PHP is great. We love it. ",
    "JavaScript is even better. It has a great API ",
    "CSHARP Forever."
]);
