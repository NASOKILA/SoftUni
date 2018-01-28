
function solve(args) {

    let result = 'You purchased ';
    let totalPrice = 0;
    for(let i = 0; i <= args.length-1; i++)
    {
        if(i % 2 === 0)
            result += args[i] + ', ';
        else
            totalPrice += Number(args[i]);
    }

    result = result.slice(0, result.length-2);

    result += ` for a total sum of ${totalPrice}`;
    console.log(result);

}

//solve(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);
//solve(['Cola', '1.35', 'Pancakes', '2.88']);


console.log();

function s(input) {

    let products = input.filter((e,i) => i % 2 == 0 );
    let sum = input.filter((e,i) => i % 2 == 1 )
        .map(e => Number(e)) //pravim gi na nomera
        .reduce((a,b) => a + b); //s .reduce() gi sumirame po dvoiki

    console.log(`You purchased ${products.join(", ")} for a total sum of ${sum}`);
}


s(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);
//s(['Cola', '1.35', 'Pancakes', '2.88']);







