
function solve(str, array) {


        for (let word of array) {
            while(str.includes(word)) {
                str = str.replace(word, rep('-', word.length - 1));
            }
        }

    console.log(str);

    function rep(simbol, timesToReplace) {

        let result = '';
        for(let i = 0; i<= timesToReplace; i++)
        {
            result += '-';
        }

        return result;
    }
    //mojem da polzvame prosto let var = '-'.replace(length)
    //i posle da pozvame tazi promenliva za da replasnem dumata !!!
}

solve('roses are red, violets are blue',
     [', violets are', 'red']);
/*
solve('David Ruben Piqtoukun (born 1950) is an Inuit artist from Paulatuk, ' +
    'Northwest Territories. His output includes sculpture and prints; ' +
    'the sculptural work is innovative in its use of mixed media. ' +
    'His materials and imagery bring together modern and traditional ' +
    'Inuit stylistic elements in a personal vision. ' +
    'An example of this is his work "The Passage of Time" (1999), which ' +
    'portrays a shaman in the form of a salmon moving through a hole in a hand. ' +
    'While shamanic imagery is common in much of Inuit art, the hand in this work ' +
    'is sheet metal, not a traditional material such as walrus ivory, ' +
    'caribou antler or soapstone. Ruben\'s brother, Abraham Apakark Anghik Ruben,' +
    'is also a sculptor. Fellow Inuit artist Floyd Kuptana learned sculpting' +
    'techniques as an apprentice to David Ruben.',
    'Inuit');
*/


function s(text, words) {

    let copy = text;
    for( let word of words) {
        let length = word.length;

        for (let i = 0; i < copy.length; i++) {

            let piece = text.substr(i, length);

            if (word === piece)
                text = text.replace(piece, '-'.repeat(length));

        }
    }

    console.log(text);
}


s('roses are red, violets are blue',
    [', violets are', 'red']);


s('David Ruben Piqtoukun (born 1950) is an Inuit artist from Paulatuk, ' +
    'Northwest Territories. His output includes sculpture and prints; ' +
    'the sculptural work is innovative in its use of mixed media. ' +
    'His materials and imagery bring together modern and traditional ' +
    'Inuit stylistic elements in a personal vision. ' +
    'An example of this is his work "The Passage of Time" (1999), which ' +
    'portrays a shaman in the form of a salmon moving through a hole in a hand. ' +
    'While shamanic imagery is common in much of Inuit art, the hand in this work ' +
    'is sheet metal, not a traditional material such as walrus ivory, ' +
    'caribou antler or soapstone. Ruben\'s brother, Abraham Apakark Anghik Ruben,' +
    'is also a sculptor. Fellow Inuit artist Floyd Kuptana learned sculpting' +
    'techniques as an apprentice to David Ruben.',
    ['Inuit']);

