


function neighbours(matrix) {

    let neighbours = 0;

    for(let row in matrix){
        for(let col in matrix[row]){

            //sruvnqvame nadolo, slagame if za da ne izlezem ot matricata
            if(Number(row)+1 < matrix.length) {

                let rowCol = matrix[row][col];
                let rowPlusOneCol = matrix[row][Number(col)+1];
                let rowColPlusOne = matrix[Number(row)+1][col];

                //sega sravnqvame chislata dali sa ednakvi
                if(matrix[row][col] === matrix[Number(row)+1][col])
                    neighbours++;


                if (matrix[row][col] === matrix[row][Number(col) + 1])
                    neighbours++;
            }else{

                if (matrix[row][col] === matrix[row][Number(col) + 1])
                    neighbours++;
            }
        }
    }

    console.log(neighbours);
}
/*
neighbours(
    [['2', '3', '4', '7', '0'],
        ['4', '0', '5', '3', '4'],
        ['2', '3', '5', '4', '2'],
        ['9', '8', '7', '5', '4']]);

neighbours(
    [['test', 'yes', 'yo', 'ho'],
        ['well', 'done', 'yo', '6'],
        ['not', 'done', 'yet', '5']]);
*/

neighbours(
    [[2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]]);