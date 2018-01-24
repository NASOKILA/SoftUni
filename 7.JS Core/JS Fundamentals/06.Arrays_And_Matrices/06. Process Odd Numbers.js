function solve(args) {

    let result = [];

    for(let i = 0; i <= args.length-1; i++)
    {
        if(i % 2 === 1)
        {
            result.push(args[i] * 2);
        }
    }

    result.reverse().forEach(e => console.log(e));
}
solve([10, 15, 20, 25]);


console.log();


function printOdd(arr){
    let oddNumbers = arr.filter((e,i) => i % 2 !== 0).map(e => e*2)
        .reverse()
        .map(e => console.log(e));
}

printOdd([3, 0, 10, 4, 7, 3]);
printOdd([10,15,20,25]);
