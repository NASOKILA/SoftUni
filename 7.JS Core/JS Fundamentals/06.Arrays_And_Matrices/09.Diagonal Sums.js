
function diagonalSum(matrix) {

    let normalDiagonal = 0;
    let backDiagonal = 0;
    let sum = 0;

        for(let row in matrix){
            for(let col in matrix[row]){

                //0,0  1,1  2,2  3,3 ...
                if(row === col)
                    normalDiagonal += matrix[row][col];

                let indexForBackDiagonal = matrix.length-Number(col)-1;

                if(Number(row) === indexForBackDiagonal)
                    backDiagonal += matrix[row][col];
            }
        }

    console.log(normalDiagonal + ' ' + backDiagonal);
}

diagonalSum(
        [[20, 40],
        [10, 60]]);

diagonalSum(
        [[3, 5, 17],
        [-1, 7, 14],
        [1, -8, 89]]);

diagonalSum(
        [[1,2,3,4,5],
        [1,2,3,4,5],
        [1,2,3,4,5],
        [1,2,3,4,5],
        [1,2,3,4,5]]);

