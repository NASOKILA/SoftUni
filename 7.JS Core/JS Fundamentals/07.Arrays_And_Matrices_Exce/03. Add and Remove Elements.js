
function solve(args) {


    let arr = [];
    let counter = 1;
    for(let elem of args)
    {
        if(elem === 'add')
        {
            arr.push(counter);
            counter++;
        }
        else if(elem === 'remove')
        {
            arr.pop();
            counter++;
        }
    }

    if(arr.length < 1)
        console.log("Empty");
    else
        arr.forEach(e => console.log(e));
}

//solve(['add','add','add','add',]);
//solve(['add','add','remove','add','add',]);
//solve(['remove','remove','remove']);






function AddAndRemoveElements(commands) {

    let nums = [];

    for(let com = 0; com < commands.length; com++){

        if(commands[com] === 'add'){
            nums.push(com+1);
        }else if(commands[com] === 'remove'){
            nums.pop();
        }
    }

    if(nums.length === 0)
        console.log('Empty');
    else
        nums.forEach(n => console.log(n));
}

  AddAndRemoveElements(['remove','remove','remove']);
  AddAndRemoveElements(['add','add','remove','add','add',]);

