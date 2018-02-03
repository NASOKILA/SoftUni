

function solve(args, mapword2) {

    let map = new Map();
    for(let word of args[0].split(/\W/).filter(e => e !== ''))
    {
        word = word.toLowerCase();
        let counter = 1;

        if(map.has(word)) {
            counter = map.get(word);
            counter++;
        }
        map.set(word,counter);
    }

    for(let elem of [...map].sort())
        console.log("'" + elem[0] + "'" + ' -> ' + elem[1] + ' times');
}

//solve(['JS devs use Node.js for server-side JS. JS devs use JS. -- JS for devs --']);
//solve(['Far too slow, you\'re far too slow.']);







function s(input) {

    let map = new Map();
    let words = input[0]
        .split(/\W+/g)
        .map(e => e.trim())
        .filter(e => e != '');


    for (let word of words) {
        let count = 1;
        word = word.toLowerCase();
        if(map.has(word))
            count += map.get(word);

        map.set(word, count);
    }

    for (let [key, value] of [...map].sort((a,b) => a >= b))
        console.log(`'${key}' -> ${value} times`);


    //STAVA I TAKA DA PRINTIRAME:
    //[...map].sort().forEach(e => console.log(`'${e[0]}' -> ${e[1]} times`));

}

//s(['JS devs use Node.js for server-side JS. JS devs use JS. -- JS for devs --']);
s(['Far too slow, you\'re far too slow.']);






