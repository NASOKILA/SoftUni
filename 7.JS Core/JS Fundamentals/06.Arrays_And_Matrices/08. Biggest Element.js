


function Solution(args)
{
    let max = Number.NEGATIVE_INFINITY;

    solve(args);

    function solve(args) {

        for(let i = 0; i <= args.length-1; i++)
        {
            if(args[i].constructor === Array) {
                solve(args[i]);
            }
            else if(!isNaN(args[i].toString())) {
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



console.log();



function biggestNum(matrix) {

    let max = Number.NEGATIVE_INFINITY;

    //obhojdame vseki red
    for(let row in matrix){

        //obhojdame vsqko chislo na tozi red :
        for(let col in matrix[row]){

            //proverqvame dali chisloto e po golqmo
            if(max < matrix[row][col])
                max = matrix[row][col];
        }
    }
    console.log(max);
}

biggestNum(
    [[20, 50, 10],
    [8, 33, 145]]);

biggestNum(
    [[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]);





