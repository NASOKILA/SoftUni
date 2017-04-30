

function solve(args){


    let arr = [];
    for(let i = 0; i <= args.length-1;i++){

        let commandAndArgument = args[i].split(' ');
        let command = commandAndArgument[0];
        let argument = commandAndArgument[1];

        if(command === 'add')
        {
            arr.push(argument);
        }
        else if(command === 'remove')
        {
            let index = argument;
            arr.splice(index,1);
        }

    }
        for( let i = 0; i< arr.length;i++){
            console.log(arr[i]);
        }

}
solve(['add 3', 'add 5', 'remove 2', 'remove 0', 'add 7']);








