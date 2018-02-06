

function solve(args) {

    let alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');

    for(let letter of alphabet) {

        //proverqvame dali v inputa ima takiva koito zapochvat stazli bukva
        if (args.some(e => e.startsWith(letter.toUpperCase()))) {
            console.log(letter.toUpperCase());
            
            //vzimame samo tezi koito zapochvat s tazi bukva
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



function s(args){

     let alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');

    for(let letter of alphabet){
        if(args.some(e => e.startsWith(letter.toUpperCase()))){

            console.log(letter.toUpperCase());
            let names = args.filter(e => e.startsWith(letter.toUpperCase()));
            
            //sortirame gi alfabetichno
            names.sort();
            names.forEach(element => {
                let [name, price] = element.split(' : ');
                console.log('  ' + name + ': ' + price);
            });

        } 
    }
}

s(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']);






