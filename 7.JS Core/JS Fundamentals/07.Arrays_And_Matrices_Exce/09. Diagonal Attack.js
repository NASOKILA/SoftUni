
function solve(arr) {

    let matrix = [];

    for(let i = 0; i < arr.length; i++)
        matrix.push(arr[i].split(' ').map(Number));

    let diagonalSum = 0;

    let secondaryDiagonalSum = 0;

    for(let row = 0; row < matrix.length; row++) {
        for(let col = 0; col < matrix[row].length; col++) {
            if(row === col)
                diagonalSum += matrix[row][col];

            if(col === matrix[row].length - row - 1)
                secondaryDiagonalSum += matrix[row][col];
        }
    }

    if(diagonalSum === secondaryDiagonalSum)
    {
        for(let row = 0; row < matrix.length; row++)
        {
            for(let col = 0; col < matrix[row].length; col++)
            {
                if(row !== col && col !== matrix.length-1-row)
                {
                    matrix[row][col] = diagonalSum;
                }
            }
        }
    }

    let result = matrix.map(row => row.join(' ')).join('\n');
    console.log(result);
    function isPartOfDiagonal(row, col, matrix) {

    }

}
/*
solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']);
*/




function diagonalAttack(arr) {

    //fill tje matrix
    let matrix = [];
    for (let row = 0; row < arr.length; row++) {
        let currentRow = arr[row]
            .split(' ')
            .map(e => Number(e));

        matrix.push(currentRow);

    }

    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    for (let row = 0; row < arr.length; row++) {
        for (let col = 0; col < arr[row].length; col++) {

            if (row === col)
                leftDiagonalSum += matrix[row][col];

            if(col === matrix[row].length - row - 1)
                rightDiagonalSum += matrix[row][col];
        }
    }

    let newMatrix = matrix;

    if (leftDiagonalSum !== rightDiagonalSum) {
        //print the matrix
        matrix.forEach(e => console.log(e.join(" ")));
    }
    else
    {
        //change the new matrix
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {

                if (row === col){}
                else if(col === matrix[row].length - row - 1){}
                else
                    newMatrix[row][col] = rightDiagonalSum;

            }
        }

        newMatrix.forEach(e => console.log(e.join(" ")));
    }
}

/*
diagonalAttack(
    ['1 1 1',
    '1 1 1',
    '1 1 0']
);
*/
diagonalAttack(
    ['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

