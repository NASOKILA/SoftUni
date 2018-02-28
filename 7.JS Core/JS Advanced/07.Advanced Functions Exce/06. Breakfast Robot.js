
//V JUDja minaVA bez IIFE funkciq
//Za da trugne tuka trqbva da q zatvorim v IIFE funkciq

function Manager() {

    let ingredients = {

        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    let meals = {

        apple: { protein: 0, carbohydrate: 1, fat: 0, flavour: 2 },
        coke: { protein: 0, carbohydrate: 10, fat: 0, flavour: 20 },
        burger: { protein: 0, carbohydrate: 5, fat: 7, flavour: 3 },
        omelet: { protein: 5, carbohydrate: 0, fat: 1, flavour: 1 },
        cheverme: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }

    return function (input) {


        let inputArgs = input.split(' ');
        let command = inputArgs[0];

        if (command === 'restock') {
            let product = inputArgs[1];
            let quantity = Number(inputArgs[2]);

            ingredients[product] += Number(quantity);
            return 'Success';

        }
        else if (command === 'prepare') {

            let product = inputArgs[1];
            let quantity = Number(inputArgs[2]);

            for (let index = 0; index < quantity; index++) {

                //check if its avaliable
                if (meals[product].protein > ingredients.protein) {
                    return 'Error: not enough protein in stock';
                } if (meals[product].carbohydrate > ingredients.carbohydrate) {
                    return 'Error: not enough carbohydrate in stock';
                } if (meals[product].fat > ingredients.fat) {
                    return 'Error: not enough fat in stock';
                } if (meals[product].flavour > ingredients.flavour) {
                    return 'Error: not enough flavour in stock';
                } else {
                   
                    //subtrckt from ingredients

                    ingredients.protein -= meals[product].protein;
                    ingredients.carbohydrate -= meals[product].carbohydrate;
                    ingredients.fat -= meals[product].fat;
                    ingredients.flavour -= meals[product].flavour;
                }

            }
            return 'Success'


        }
        else if (command === 'report') {
            return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
        }
    }

}

let prepareBreakfast = Manager();

console.log(prepareBreakfast('restock carbohydrate 10'));
console.log(prepareBreakfast('restock flavour 10'));
console.log(prepareBreakfast('prepare apple 1'));
console.log(prepareBreakfast('restock fat 10'));
console.log(prepareBreakfast('prepare burger 1'));
console.log(prepareBreakfast('report'));

console.log();
/*
console.log(prepareBreakfast('restock protein 100'));
console.log(prepareBreakfast('restock carbohydrate 100'));
console.log(prepareBreakfast('restock fat 100'));
console.log(prepareBreakfast('restock flavour 100'));
console.log(prepareBreakfast('report'));
console.log(prepareBreakfast('prepare omelet 2'));
console.log(prepareBreakfast('report'));
console.log(prepareBreakfast('prepare omelet 1'));
console.log(prepareBreakfast('report'));
*/
