
function solve(args) {

    let sum = 0;
    let words = [];
    for(let i of args)
    {
        let town = i.split('| ');
        town = town.filter(function(n){ return n != "" });

        let word = '';

        let reversedTown = town[0].split("").reverse().join("");
        for(let letter of reversedTown)
        {
            if(letter !== ' ')
            {
                let index = reversedTown.indexOf(letter);
                word = reversedTown.substr(index);
                break;
            }
        }

        let townToUse = word.split("").reverse().join("");

        words.push(townToUse);
        sum += Number(town[1]);
    }

    console.log(words.join(', '));
    console.log(sum);
}

solve(['| Sofia           | 300',
       '| Veliko Tarnovo  | 500',
       '| Yambol          | 275']);















