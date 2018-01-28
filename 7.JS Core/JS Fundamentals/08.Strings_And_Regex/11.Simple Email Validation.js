
function solve(args) {

    let patt = /^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]+$/gm;

    if(patt.test(args))
        console.log("Valid");
    else
        console.log("Invalid");
}

solve('valid@email.bg');
solve('invalid@emai1.bg');






function s(email) {

    let patt = /^[a-zA-Z0-9]+\@[a-z]+\.[a-z]+$/gm;

    //Taka testvame imeila vurhu patterna i ni vrushta 'true' ili 'false'

    let result = patt.test(email); // true or false

    if(result)
        console.log('Valid');
    else
        console.log('Invalid');
}

s('valid@email.bg');
s('invalid@emai1.bg');
















