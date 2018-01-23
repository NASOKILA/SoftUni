
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


solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);


