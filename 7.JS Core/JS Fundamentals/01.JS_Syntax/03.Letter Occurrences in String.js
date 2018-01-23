
function Occurrences(word, letter) {

    let occurrences = 0;

    for(let lett of word)
    {
        if(lett === letter)
            occurrences++;
    }

    console.log(occurrences);
}

Occurrences('hello', 'l');
Occurrences('panther', 'n');







