
function solve(input){

    let number = input[0];

    let operations = {
        dice:(num) => Math.sqrt(num),
        spice:(num) => ++num,
        chop:(num) => num / 2,
        bake:(num) => num * 3,
        fillet:(num) => num -= num * 0.2
    };

    for(let i = 1; i < input.length; i++){
        const currentOperation = input[i];
        try{
            number = operations[currentOperation](number);
            console.log(number);
        }catch(error){
            console.log('Invalid operation');
        }


    }

}

//solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);



