

function solve(args) {

    //Pravim set za da izbenem ednakvite stoinosti
    let words = new Set();

    for(let row of args)
    {
        for(let word of row.split(/[\s\.\,?!_]+/g).filter(e => e !== ''))
            words.add(word.toLowerCase());
    }

    console.log([...words].join(', '));
}
/*
solve(['Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']);
*/



function s(input) {

    let wordPatt = /\b\w+\b/g;

    let uniqueWords = new Set();

    for (let line of input) {

        let words = line.match(wordPatt);

        for (let word of words)
            uniqueWords.add(word.toLowerCase());

    }

    console.log([...uniqueWords.values()].join(', '));
}

s(['Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']);







