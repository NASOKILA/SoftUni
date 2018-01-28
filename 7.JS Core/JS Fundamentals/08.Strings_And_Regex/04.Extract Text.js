
function solve(sentence) {

    let words = [];

    while(true)
    {

        let start = sentence.indexOf('(');
        let end = sentence.indexOf(')');

        if(start === -1 || end === -1)
            break;

        if(sentence === "")
            break;

        let word = sentence.substring(start+1, end);

        sentence = sentence.replace('(', '');
        sentence = sentence.replace(')', '');

        words.push(word);
    }

    console.log(words.join(', '));
}

//solve('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');





function s(str){

    let elements = [];

    let start = str.indexOf('(');
    while(start > -1){

        let end = str.indexOf(')', start);

        if(end == -1)
            break;

        let elem = str.substring(start+1, end);
        elements.push(elem);

        let newStr = str.substr(++end);
        start = str.indexOf('(', end);
    }

    console.log(elements.join(", "));
}

s('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');







