


function solve(arr){

    let rows = arr[0];
    let cols = arr[1];

    let matrix = [];
    for(let i = 0; i < rows; i++) {
        let row = [];
        for(let j = 0; j < cols; j++) {
            row.push(0);
        }
        matrix.push(row);
    }

    let x = arr[2];
    let y = arr[3];


    let waves = 1;
    let number = 1;
    matrix[x][y] = number;

    while(true) {

        let startX = Math.max(0, x-waves);
        let startY = Math.max(0, y-waves);
        let endX = Math.min(rows -1, x + waves);
        let endY = Math.min(cols -1, y + waves);

        for (let row = startX; row <= endX; row++) {
            for (let col = startY; col <= endY; col++) {

                if (matrix[row][col] === 0) {
                    matrix[row][col] = waves+1;
                }
            }
        }

        waves++;
        if(waves === matrix.length)
            break;
    }

    //print matrix
    matrix.forEach(n => console.log(n.join(" ")));
}

solve([5,5,2,2]);












