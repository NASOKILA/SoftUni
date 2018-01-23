


function solve(args) {

    let result = args.sort(compare).join('\n');
    console.log(result);
    function compare(a,b)
    {
        if(a.length < b.length)
            return -1;
        else if(a.length > b.length)
            return 1;
        else
        {
            if(a < b)
                return -1;
            else if(a > b)
                return 1;
            else
                return 0;

        }
    }
}

/*
solve([
    'Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']);
*/

/*
solve(['alpha',
    'beta',
    'gamma']);
*/

solve(['Deny',
    'omen',
    'test',
    'Default']);



