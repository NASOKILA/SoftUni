
function solve(args) {

    let patt = /^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]+$/;

    if(patt.test(args))
        console.log("Valid");
    else
        console.log("Invalid");
}

solve('valid@email.bg');
solve('invalid@emai1.bg');









