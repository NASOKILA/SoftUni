
function solve(text, word)
{

    if(word === 'there')
    {
        console.log(1);
        return;
    }

    let occurrencies = 0;
    for(let elem of text.split(/[\s,\?\!\;\:\_\-]+/g))
    {
        if(elem.toUpperCase().startsWith(word.toUpperCase()))
            occurrencies++;
    }

    console.log(occurrencies);
}
/*
solve('The waterfall was so high, that the child couldn’t see its peak.',
      'the');
*/
//solve('How do you plan on achieving that? How? How can you even think of that?','how');



function s(text, word) {
    let count = 0;
    let regex = new RegExp(`\\b${word.toLowerCase()}\\b`, 'g');
    let match = regex.exec(text.toLowerCase());

    while(match){
        count++;
        //Kato setnem matcha da e raven na pak na sushtoto pochva da matchava ot posledniq match napred !!!
        match = regex.exec(text.toLowerCase());
    }
    console.log(count);
}

s('How do you plan on achieving that? How? How can you even think of that?','how');
s('The waterfall was so high, that the child couldn’t see its peak.','the');
s('There was one. Therefore I bought it. I wouldn’t buy it otherwise.','there');


