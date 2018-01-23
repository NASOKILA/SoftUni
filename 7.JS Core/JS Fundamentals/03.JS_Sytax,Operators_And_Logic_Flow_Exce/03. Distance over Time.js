
function solve(input) {

    let dist1 = (input[0] / 3.6) * input[2];
    let dist2 = (input[1] / 3.6) * input[2];

    let delta = Math.abs(dist1- dist2);
    console.log(Math.round(delta));
}

let input = [0, 60, 3600];
solve(input);









