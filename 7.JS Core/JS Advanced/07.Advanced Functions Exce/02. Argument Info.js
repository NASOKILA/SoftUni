
function result() {

    let result = [];
    let typesCounts = {};
    for(let index = 0; index < arguments.length; index++)
    {
        let resultInput = '';
        let argument = arguments[index];
        let type = typeof(argument);
        let typeCount = 1;

        if(typesCounts.hasOwnProperty(type)) {
            typesCounts[type] += typeCount;
        } else{
            typesCounts[type] = typeCount;
        }

        resultInput = `${type}: ${argument}`;
        result.push(resultInput);
    }

    console.log(result.join("\n"));
    Print(typesCounts);
    function Print(object){
        for(let kvp in object)
            console.log(`${kvp} = ${object[kvp]}`);
    }
}


result('cat', 42, function () { console.log('Hello world!'); });

