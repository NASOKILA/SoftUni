


function solve(input) {


    let array = [];

    let commands = {
        Add: function (name) {
            array.push(name);
        },
        Remove: function (name) {
            array = array.filter(e => e !== name);
        },
        Print: () => { console.log(array.join(',')) }
    }

    for (let pair of input) {

        let tokens = pair.split(' ');

        if (tokens.length === 1)
            commands.Print();
        else {

            let [command, name] = tokens;
            
            command === "add"
                ? commands.Add(name)
                : commands.Remove(name);
        }
    }
}

//solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);

//solve(['add pesho', 'add gosho', 'add pesho', 'remove pesho', 'print']);

solve([
    'add JSFundamentals',
    'print',
    'add JSAdvanced',
    'print',
    'add JSApplications',
    'print']);

