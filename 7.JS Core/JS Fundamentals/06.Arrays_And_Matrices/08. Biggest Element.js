


function Solution(args)
{
    let max = -99999999999;

    solve(args);

    function solve(args) {

        for(let i = 0; i <= args.length-1; i++)
        {
            if(args[i].constructor === Array)
            {
                solve(args[i]);
            }
            else if(!isNaN(args[i].toString()))
            {
                if(max < args[i])
                    max = args[i];
            }
        }
    }
    console.log(max);
}

Solution([[20, 50, 10],
    [8, 33, 145]]);

Solution([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]);
