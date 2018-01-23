
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

solve('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');


