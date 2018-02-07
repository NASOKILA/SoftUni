
function solve(primaryMatrix, secondaryMatrix, overlayCoord, startingCoords) {


    for (let row in overlayCoord) {

        //place second matrix over first one

        let indexRowCopy = overlayCoord[row][0];
        let indexColCopy = overlayCoord[row][1];

        for (let i = 0; i < secondaryMatrix.length; i++) {
            for (let j = 0; j < secondaryMatrix.length; j++) {

                let currentPrimaryMatrixRow = (i + indexRowCopy);
                let currentPrimaryMatrixCol = (j + indexColCopy);

                //Ako indexite sa minusove ili po golqmi ot duljinata na primaryMatricata ne pravim nishto
                if (currentPrimaryMatrixRow < 0 || currentPrimaryMatrixRow >= primaryMatrix.length
                    || currentPrimaryMatrixCol < 0 || currentPrimaryMatrixCol >= primaryMatrix.length) {
                    continue;
                }

                //Ako elementa ot vtorata matrica e 1 pravim promenite inache nishto
                if (secondaryMatrix[i][j] == 1) {

                    //invert the value of prymary matrix POLZVAME TRENALEN OPERATOR
                    primaryMatrix[i + indexRowCopy][j + indexColCopy] == 1 
                    ? primaryMatrix[i + indexRowCopy][j + indexColCopy] = 0 
                    : primaryMatrix[i + indexRowCopy][j + indexColCopy] = 1;
                }
            }
        }

    }

    //ALTERNATING IS DONE


    //CHECK FOR WAYS TO EXIT
    let steps = 0;

    let previousDirection;
    let currentRow = startingCoords[0];
    let currentCol = startingCoords[1];
        
    while(true){

        
        //Down
        if(currentRow + 1 < primaryMatrix.length 
            && primaryMatrix[currentRow + 1][currentCol] == 0
            && previousDirection != 'up')
            {
                previousDirection = 'down';
                currentRow++;
            }
        //Right
        else if(currentCol+1 < primaryMatrix[0].length 
            && primaryMatrix[currentRow][currentCol + 1] == 0
            && previousDirection != 'left')
            {
                previousDirection = 'right';
                currentCol++;
            }
        //Up
        else if(currentRow - 1 >= 0 
            && primaryMatrix[currentRow - 1][currentCol] == 0
            && previousDirection != 'down')
            {
                previousDirection = 'up';
                currentRow--;
            }
        //Left
        else if(currentCol - 1 >= 0 
            && primaryMatrix[currentRow][currentCol - 1] == 0
            && previousDirection != 'right')
            {
                previousDirection = 'left';
                currentCol--;
            }
        //None
            else{ //ako nqma na kude da otidem
                break;
            }

        steps++;        
    }

    console.log(++steps);
    definePosition(currentRow, currentCol);
    
    function definePosition(endRow, endCol){

        let output = '';
        //top border
        if(endRow === 0)
            output = 'Top';
        //left border
        else if(endCol === 0)
            output = 'Left';
        //right border
        else if(endRow === primaryMatrix.length-1)
            output = 'Bottom';
        //bottom border
        else if(endCol === primaryMatrix[0].length-1)
            output = 'Right';
        
        //Dead End 1
        else if(endRow < primaryMatrix.length / 2 && endCol >= primaryMatrix[0].length / 2){
            output = 'Dead end 1';
        }
        //Dead End 2
        else if(endRow < primaryMatrix.length / 2 && endCol < primaryMatrix[0].length / 2){
            output = 'Dead end 2';
        }
        //Dead End 3
        else if(endRow >= primaryMatrix.length / 2 && endCol < primaryMatrix[0].length / 2){
            output = 'Dead end 3';
        }
        //Dead End 4
        else if(endRow >= primaryMatrix.length / 2 && endCol >= primaryMatrix[0].length / 2){
            output = 'Dead end 4';
        }

        console.log(output);

    }

}

solve(
    [[1, 1, 0, 1, 1, 1, 1, 0],
    [0, 1, 1, 1, 0, 0, 0, 1],
    [1, 0, 0, 1, 0, 0, 0, 1],
    [0, 0, 0, 1, 1, 0, 0, 1],
    [1, 0, 0, 1, 1, 1, 1, 1],
    [1, 0, 1, 1, 0, 1, 0, 0]],

    [[0, 1, 1],
    [0, 1, 0],
    [1, 1, 0]],

    [[1, 1],
    [2, 3],
    [5, 3]],

    [0, 2]
);

solve(
    [[1, 1, 0, 1],
 [0, 1, 1, 0],
 [0, 0, 1, 0],
 [1, 0, 1, 0]],
[[0, 0, 1, 0, 1],
 [1, 0, 0, 1, 1],
 [1, 0, 1, 1, 1],
 [1, 0, 1, 0, 1]],
[[0, 0],
 [2, 1],
 [1, 0]],
[2, 0]

);
