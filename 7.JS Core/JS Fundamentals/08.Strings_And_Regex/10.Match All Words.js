


function solve(text) {

    let regex = /[0-9a-zA-Z_]+/g;

    let result = text.match(regex);


    console.log(result.join('|'));
    //console.log(result.split(' ').join("|"));
}

solve('A Regular Expression needs to have the global flag in order to match all occurrences in the text');
solve('_(Underscores) are also word characters');







