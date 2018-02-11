
function solve(initialHeight) {

    let initialHeightNumbersParsed = initialHeight
        .map(n => Number(n));

    let totalDailyConcreteUsed = [];


    //vurtim cikul dokato vsichki nomera ne stanat 30
    while (initialHeightNumbersParsed.some(n => n < 30)) {
        
        let dailyConcrete = 0;

        for (let i = 0; i < initialHeightNumbersParsed.length; i++) {
            
            if (initialHeightNumbersParsed[i] < 30) {
                dailyConcrete += 195;
                initialHeightNumbersParsed[i]++;
            }

        }
        totalDailyConcreteUsed.push(dailyConcrete);
    }


    let totalCostOfTheWall = 0;
    totalDailyConcreteUsed.map(d => totalCostOfTheWall += d);

    console.log(totalDailyConcreteUsed.join(', '));
    console.log(totalCostOfTheWall * 1900 + ' pesos')

}

solve([17, 22, 17, 19, 17]);


solve(['21', '25', '28']);





