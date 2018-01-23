
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
solve(['remove','remove','remove']);









