
function solve(args) {

    let x1 = args[0];
    let y1 = args[1];
    let z1 = args[2];

    let x2 = args[3];
    let y2 = args[4];
    let z2 = args[5];

    let distance = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2) + Math.pow((z2 - z1), 2));
    console.log(distance);
}

let input = [1, 1, 0, 5, 4, 0];
let input2 = [3.5, 0, 1, 0, 2, -1];

solve(input);
solve(input2);










