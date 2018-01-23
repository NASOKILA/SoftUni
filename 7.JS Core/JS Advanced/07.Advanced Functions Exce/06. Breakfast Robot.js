
//V JUDja minaVA bez IIFE funkciq
//Za da trugne tuka trqbva da q zatvorim v IIFE funkciq

let manager = (function () {

var flavoursCount = 0;
var fatsCount = 0;
var carbsCount = 0;
var proteinsCount = 0;

return function (args) {

    let input = args.split(' ');
    let command = input[0];
    let quantity = Number(input[2]);

    if(command === 'restock') {

        let microelement = input[1];
        if(microelement === 'protein'){
            proteinsCount += quantity;
            return 'Success';
        }else if(microelement === 'carbohydrate'){
            carbsCount += quantity;
            return 'Success';
        }else if(microelement === 'fat'){
            fatsCount += quantity;
            return 'Success';
        }else if(microelement === 'flavour'){
            flavoursCount += quantity;
            return 'Success';
        }

    }else if(command === 'prepare'){

        let recipe = input[1];

        if(recipe === 'apple') {
                if (carbsCount >= (1 * quantity) && flavoursCount >= (2 * quantity)) {
                    carbsCount -= (1 * quantity);
                    flavoursCount -= (2 * quantity);
                    return 'Success';

                } else {
                    let missingProduct = '';

                    if (carbsCount < (1 * quantity))
                        missingProduct = 'carbohydrate';
                    else if (flavoursCount < (2 * quantity))
                        missingProduct = 'flavour';

                    return `Error: not enough ${missingProduct} in stock`;
                }

        }else if(recipe === 'coke'){

            if(carbsCount >= (10 * quantity) && flavoursCount >= (20 * quantity)) {

                carbsCount -= (10 * quantity);
                flavoursCount -= (20 * quantity);
                return 'Success';
            }else{

                let missingProduct = '';

                if(carbsCount < (10 * quantity))
                    missingProduct = 'carbohydrate';
                else if(flavoursCount < (20 * quantity))
                    missingProduct = 'flavour';

                return `Error: not enough ${missingProduct} in stock`;
            }

        }else if(recipe === 'burger'){

            if(carbsCount >= (5 * quantity) && fatsCount >= (7 * quantity) && flavoursCount >= (1 * quantity)) {
                carbsCount -= (5 * quantity);
                fatsCount -= (7 * quantity);
                flavoursCount -= (3 * quantity);
                return 'Success';

            }else{

                let missingProduct = '';

                if(carbsCount < (5 * quantity))
                    missingProduct = 'carbohydrate';
                else if(fatsCount < (7 * quantity))
                    missingProduct = 'fat';
                else if(flavoursCount < (3 * quantity))
                    missingProduct = 'flavour';

                return `Error: not enough ${missingProduct} in stock`;
            }

        }else if(recipe === 'omlet'){

            if(proteinsCount >= (5 * quantity) && fatsCount >= (1 * quantity) && flavoursCount >= (1 * quantity)) {
                proteinsCount -= (5 * quantity);
                fatsCount -= (1 * quantity);
                flavoursCount -= (1 * quantity);
                return 'Success';

            }else{
                let missingProduct = '';

                if(proteinsCount < (5 * quantity))
                    missingProduct = 'protein';
                else if(fatsCount < (10 * quantity))
                    missingProduct = 'fat';
                else if(flavoursCount < (10 * quantity))
                    missingProduct = 'flavour';

                return `Error: not enough ${missingProduct} in stock`;
            }

        }else if(recipe === 'cheverme'){

            if(proteinsCount >= (10 * quantity) && carbsCount >= (10 * quantity) && fatsCount >= (10 * quantity) && flavoursCount >= (10 * quantity)) {
                proteinsCount -= (10 * quantity);
                carbsCount -= (10 * quantity);
                fatsCount -= (10 * quantity);
                flavoursCount -= (10 * quantity);
                return 'Success';
            }else{
                let missingProduct = '';

                if(proteinsCount < (10 * quantity))
                    missingProduct = 'protein';
                else if(carbsCount < (10 * quantity))
                    missingProduct = 'carbohydrate';
                else if(fatsCount < (10 * quantity))
                    missingProduct = 'fat';
                else if(flavoursCount < (10 * quantity))
                    missingProduct = 'flavour';

                return `Error: not enough ${missingProduct} in stock`;
            }
        }

    }else if(command === 'report'){
        return `protein=${proteinsCount} carbohydrate=${carbsCount} fat=${fatsCount} flavour=${flavoursCount}`;
    }
}

})()

/*
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));
*/


console.log(manager('restock protein 100'));
console.log(manager('restock carbohydrate 100'));
console.log(manager('restock fat 100'));
console.log(manager('restock flavour 100'));
console.log(manager('report'));
console.log(manager('prepare apple 2'));
console.log(manager('report'));
console.log(manager('prepare apple 1'));
console.log(manager('report'));

/*
manager("prepare cheverme 1");
manager("restock protein 10");
manager("prepare cheverme 1");
manager("restock carbohydrate 10");
manager("prepare cheverme 1");
manager("restock fat 10");
manager("prepare cheverme 1");
manager("restock flavour 10");
manager("prepare cheverme 1");
manager("report");
*/


