function solve(args){

    let result = {};

    for(let i = 0; i < args.length; i++) {
        let townIncome = JSON.parse(args[i]); // prevurnahme stringovete v normalen obekt townIncome
        let name = townIncome.town;      // samo imeto
        let income = townIncome.income;  //samo income

        if (result[name] || result[name] === 0) {
            // ako se sudurja imeto v razultata ili == na 0
            result[name] += income;  // dobavqme i income
        }
        else // ako ne se sudurja
        {
            result[name] = 0; //imeto = 0
        }
    }
        let towns = Object.keys(result).sort(); // vzimame i sortirame vsichki gradove

        for(let i = 0; i < towns.length; i++){
            console.log(`${towns[i]} -> ${result[towns[i]]}`)
        }

}
solve([
    '{"town":"Sofia","income":200}',
    '{"town":"Varna","income":120}',
    '{"town":"Pleven","income":60}',
    '{"town":"Varna","income":70}'
]);
























