
function solve(str) {

    let elements = str.split(/[\s.();,]+/); //splitvame po tozi regex
    console.log(elements.join("\n")); // i printirame vsichko na nov red
}

//solve('let sum = 4 * 4,b = "wow";');



function s(input) {

    let words = input.split(/[.,;()\s]+/gm);
    console.log(words.join('\n'));
}


s('let sum = 4 * 4,b = "wow";');
s('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');


















