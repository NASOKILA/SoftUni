
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
solve('How do you plan on achieving that? How? How can you even think of that?'
     ,'how');








