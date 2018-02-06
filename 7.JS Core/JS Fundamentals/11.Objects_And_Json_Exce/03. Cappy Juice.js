
function solve(dataRows) {

    let flavours = {};
    let bottles = {};

    for(let row of dataRows)
    {
        let data = row.split(' => ');
        let name = data[0];
        let quantity = Number(data[1]);

        if(flavours.hasOwnProperty(name))
            quantity += Number(flavours[name]);

            flavours[name] = quantity;

        let bottle = quantity / 1000;
        bottle = Math.floor(bottle);

        if(bottle >= 1)
            bottles[name] = bottle;
    }

    //sega proverqvame za veki i pulnim botilkite:


    // print
    for(let b in bottles)
        console.log(`${b} => ${bottles[b]}`);
}

/*
solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']);
*/


function s(args){

    let juices = new Map(); 

    let bottles = new Map();
    
    for(let row of args){

        let tokens = row.split(' => ');
        let currentJuice = tokens[0];
        let quantity = Number(tokens[1]);
        
        if(juices.has(currentJuice)){
            quantity += juices.get(currentJuice);
        }

        juices.set(currentJuice, quantity);
        
        let currentBottles = Math.floor(juices.get(currentJuice) / 1000);
        if(currentBottles > 0)
            bottles.set(currentJuice, currentBottles);
    }

    for(let [juice, bottlesCount] of bottles){
        console.log(juice + ' => ' + bottlesCount);
    }
    
}

s(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);


