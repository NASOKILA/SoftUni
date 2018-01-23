

function solve(args) {

    let biggestProduct = Number.MIN_SAFE_INTEGER;

    for(let i = 0; i <= args.length-1; i++)
    {
        let currentNum = Number(args[i]);
        if( currentNum < 10 && currentNum >= 0)
        {
            let currentProduct = 1;
            for(let j = i+1; j <= i + currentNum; j++)
            {
                let nextNum = Number(args[j]);
                currentProduct *= nextNum;
            }

            if(biggestProduct <= currentProduct)
                biggestProduct = currentProduct;
        }
    }

    console.log(biggestProduct);
}

solve(['10',
    '20',
    '2',
    '30',
    '44',
    '3',
    '56',
    '20',
    '24']);


solve(['100', '200',
    '2',
    '3',
    '2',
    '3',
    '2',
    '1',
    '1']);