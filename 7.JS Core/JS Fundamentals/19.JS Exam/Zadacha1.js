



function solve(args) {

    let boughtBitcoins = 0;
    let totalMoney = 0;
    let firstDayBoughtBitcoin = 0;
    let firstDayFound = false;

    let count = 1;
    for(let i = 0; i < args.length; i++)
    {
        let goldDiggedInGrams = Number(args[i]);

        //stealing every third day
        if(count % 3 === 0 && count > 0)
        {
            //30%
            let thirtyPercent = goldDiggedInGrams - (goldDiggedInGrams / 2) 
            - (goldDiggedInGrams / 5);  

            goldDiggedInGrams -= thirtyPercent;            
            
        }
        let leva = 67.51 * goldDiggedInGrams;
        totalMoney += Number(leva);
        
        
            
        
        while(totalMoney >= 11949.16)
        {
            if(!firstDayFound)
            {
                firstDayBoughtBitcoin = count;
                firstDayFound = true;
            }

            boughtBitcoins++;
            totalMoney -= 11949.16;
        }

            //Vzimame purviq den v koito sme kupili bitcoin:
           
            //totalMoney = Math.round(totalMoney).toFixed(2);
        
        count++;
    }

    console.log("Bought bitcoins: " + boughtBitcoins);
    
    if(boughtBitcoins > 0)
        console.log("Day of the first purchased bitcoin: " + firstDayBoughtBitcoin);
    
    
        console.log("Left money: " + totalMoney.toFixed(2) +" lv.");


}


solve(['3124.15', '504.212', '2511.124']);
console.log();
solve(['50', '100']);
console.log();
solve(['100', '200', '300']);














