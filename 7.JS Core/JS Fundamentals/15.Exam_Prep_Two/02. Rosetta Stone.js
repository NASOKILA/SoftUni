

function solve(args) {

    let matrixLength = Number(args[0]);
    let matrix = [];
    for(let i = 1; i <= matrixLength; i++)
        matrix.push(args[i].trim());

    let overlayMatrix = [];
    for(let i = matrixLength+1; i <= args.length-1; i++)
        overlayMatrix .push(args[i].trim());

    let overlay = [];
    for(let i = 0; i <= matrixLength-1; i++)
        overlay.push(overlayMatrix[i].substr(0,matrixLength*2).trim());


    let parsedMatrix = [];
    matrix.forEach(e => {
        parsedMatrix.push(e.split(' ').map(Number));
    });

    let overlayMatrixParsed = [];
    overlayMatrix.forEach(e => {
        overlayMatrixParsed.push(e.split(' ').map(Number));
    });

    let overlayParsed = [];
    overlay.forEach(e => {
        overlayParsed.push(e.split(' ').map(Number));
    });

    //console.log(63 % 27)
}

solve([ '2',
    '59 36',
    '82 52',
    '4 18 25 19 8',
    '4 2 8 2 18',
    '23 14 22 0 22',
    '2 17 13 19 20',
    '0 9 0 22 22' ]);


