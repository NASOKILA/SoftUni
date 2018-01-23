

function solve(args) {

    let n = parseFloat(args[0]);

    for(let i = 1; i <= args.length -1; i++)
    {
        if(args[i] === 'chop')
        {
            n = n / 2;
            console.log(n);
        }
        else if(args[i] === 'dice')
        {
            n = Math.sqrt(n);
            console.log(n);
        }
        else if(args[i] === 'spice')
        {
            n++;
            console.log(n);
        }
        else if(args[i] === 'bake')
        {
            n *= 3;
            console.log(n);
        }
        else if(args[i] === 'fillet')
        {
            let twentyPercent = n / 5.00;
            n = n - twentyPercent;
            console.log(n);
        }


    }
}


//solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);



