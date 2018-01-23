
function solve(n) {

    if(n <= 0)
        n += 400;

    grads = n % 400; //vzimame grads

    let degrees = grads / 400 * 360; // prevrushtame gi v gradusi
    console.log(degrees);
}

solve(100);
solve(400);
solve(850);
solve(-50);










