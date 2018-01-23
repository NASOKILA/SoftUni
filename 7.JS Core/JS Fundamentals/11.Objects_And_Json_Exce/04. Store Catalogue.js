

function solve(args) {

    let alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');

    for(let letter of alphabet) {
        if (args.some(e => e.startsWith(letter.toUpperCase()))) {
            console.log(letter.toUpperCase());
            let result = args.filter(e => e.startsWith(letter.toUpperCase()));

            for(let w of result.sort())
            {
                w = w.split(' : ');
                let name = w[0];
                let price = w[1];

                console.log(`  ${name}: ${price}`);
            }
        }
    }
}
/*
solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);
*/

solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']);






