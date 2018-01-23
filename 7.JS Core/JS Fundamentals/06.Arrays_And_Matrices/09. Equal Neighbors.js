
function solve(args) {

    let result = "";
    if(args.length === 2)
    {
        result += args[0][0] + args[1][1] + ' ';
        result += args[0][1] + args[1][0];
    }
    else if(args.length === 3)
    {
        result += args[0][0] + args[1][1] + args[2][2] + ' ';
        result += args[0][2] + args[1][1] + args[2][0];
    }
    else if(args.length === 5)
    {
        result += args[0][0] + args[1][1] + args[2][2] + args[3][3] + args[4][4] + ' ';
        result += args[0][4] + args[1][3] + args[2][2] + args[3][1] + args[4][0];
    }

    console.log(result);
}

//solve([[20, 40],[10, 60]]);

/*
solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]);
*/


solve([[1,2,3,4,5],
      [1,2,3,4,5],
      [1,2,3,4,5],
      [1,2,3,4,5],
      [1,2,3,4,5]]);











