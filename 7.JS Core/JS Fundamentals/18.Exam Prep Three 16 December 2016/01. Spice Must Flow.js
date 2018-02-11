


function solve(source) {

    let days = 0;
    let crewConsumption = 26;   //26 per day
    let extractedSpice = 0;

    if(source < 100)
    {
        console.log(days);
        console.log(extractedSpice);
        return;
    }
    
    while (source >= 100) {

        days++;

        extractedSpice += source;
        
        extractedSpice -= crewConsumption;

        source -= 10;
        
    }

    //abbandon the source
    extractedSpice -= crewConsumption;

    console.log(days);
    console.log(extractedSpice);

}

solve(99);

solve(450);

solve(200);
