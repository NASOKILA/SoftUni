

function solve(args) {

    let p = args[0];
    let i = args[1];
    let n = args[2];
    let t = args[3];

    //let interestRate/(100*( 12/compoundingPeriod)), 12/compoundingPeriod * timespan);
    let result = p * Math.pow(1 + i/(100 * (12/n)), 12/n * t);
    console.log(result.toFixed(2));
//futureValue = investment * (Math.pow(1 + monthlyRate, months) - 1) / monthlyRate;

}

solve([1500, 4.3, 3, 6]);




