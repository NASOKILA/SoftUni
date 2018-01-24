
function solve(args) {

    let result = [];

    for(let i = 0; i <= args.length - 1; i++) {

        if(i % 2 === 0) {
            result.push(args[i]);
        }
    }

    console.log(result.join(' '));
}

solve(['20', '30', '40']);



