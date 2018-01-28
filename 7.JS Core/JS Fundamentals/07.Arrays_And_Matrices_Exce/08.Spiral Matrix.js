
function solve(rows, cols) {

    let matrix = [];

    //fill the matrix with 0
    for(let i = 0; i < rows; i++){

        let currentRow = [];

        for(let j = 0; j < cols; j++)
            currentRow.push(0);

        matrix.push(currentRow);
    }

    let number = 1;
    let currentRow = 0;
    let currentCol = 0;
    let targetNumber = rows * cols; //25
    let rotations = 0;

    //until we fill the matrix totally
    while(targetNumber >= number)
    {

        //top row
        for(let i = rotations; i < cols - rotations; i++)
            matrix[currentRow][currentCol++] = number++;

        //right side downwords
        currentCol -= 1;
        for(let i = ++currentRow; i <= rows - 1 - rotations; i++)
            matrix[currentRow++][currentCol] = number++;

        //bottom side leftwards
        currentRow--;
        for(let i = --currentCol; i >= rotations; i--)
            matrix[currentRow][currentCol--] = number++;

        //left col upwards
        currentCol++;
        for(let i = --currentRow; i > rotations; i--) {
            matrix[currentRow--][currentCol] = number++;
        }

        //increase row, col and rotation WE WILL USE IT FOR THE REST
        currentCol++;
        currentRow++;
        rotations++;
    }

    //print the matrix
    matrix.forEach(r => console.log(r.join(" ")));
}

solve(5,5);




