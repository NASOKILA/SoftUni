

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
solve(['Far too slow, you\'re far too slow.']);










