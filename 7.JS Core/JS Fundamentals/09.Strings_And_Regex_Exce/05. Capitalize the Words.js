
function solve(args) {

    let result = '';
    let arr = args.split(' ');
    for(let word of arr)
    {
        let wordResult = word.charAt(0).toUpperCase();
        for(let i = 1; i <= word.length-1; i++)
        {
            wordResult += word.charAt(i).toLowerCase();
        }

        result += wordResult + ' ';
    }
    console.log(result);
}

//solve('Capitalize these words');
//solve('Was that Easy? tRY thIs onE for SiZe!');






function s(text) {

    let result = [];
    text.split(' ').forEach(w => {

       let word = w[0].toUpperCase();
       for(let i = 1; i < w.length; i++)
           word += w[i].toLowerCase();

       result.push(word);
    });
    console.log(result.join(' '));
}

s('Capitalize these words');
s('Was that Easy? tRY thIs onE for SiZe!');



