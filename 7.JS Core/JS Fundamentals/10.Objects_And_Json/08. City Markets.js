

//{town} -> {product} -> {amountOfSales} : {priceForOneUnit}
function solve(args) {

    let map = new Map();

    for(let elem of args)
    {
        let elemArgs = elem.split(' -> ');

        let city = elemArgs[0];
        let product = elemArgs[1];
        let amountAndPrice = elemArgs[2].split(' : ');

        let totalSales = amountAndPrice[0] * amountAndPrice[1];

        let productsAndTotalPricas = `${product} : ${totalSales}`;
        let arr = [];

        //ako se sudurja tozi kluch
        if(map.has(city))
            arr = map.get(city);

        arr.push(productsAndTotalPricas);
        map.set(city,arr);
    }

    //printirame
    for(let city of map)
    {
        console.log(`Town - ${city[0]}`);
        for(let product of city[1])
            console.log(`$$$${product}`);
    }

}

/*
solve(['Sofia -> Laptops HP -> 200 : 2000',
'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000',
'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2',
'Montana -> Chereshas -> 1000 : 0.3']);
*/





function s(input) {

    let towns = new Map();
    for (let row of input) {

        let productsAndPrices = new Map();

        let [town, product, prices] = row.split(' -> ');
        let [amountOfSales, priceForOneUnit] = prices.split(' : ');
        let productTotalIncome = Number(amountOfSales) * Number(priceForOneUnit);

        if(towns.has(town))
            productsAndPrices = towns.get(town);

        productsAndPrices.set(product, productTotalIncome);

        towns.set(town, productsAndPrices);
    }

    towns.forEach((innerMap, mapName) => {
        console.log(`Town - ${mapName}`);
        for (let [product,total] of innerMap) {
            console.log(`$$$${product} : ${total}`);
        }
    });

}

s(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']);





