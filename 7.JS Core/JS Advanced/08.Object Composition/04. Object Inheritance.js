
function solve(args) {

    let objects = {};
    for (const i in args) {

        let tokens = args[i].split(' ');

        let command = tokens[0];
        let objName = tokens[1];

        if (command === 'create') {

            if (tokens.length > 2) {
                let objectToInheritName = tokens[3];
                let objectToInherit = objects[objectToInheritName];

                objects[objName] = Object.create(objectToInherit);
            }
            else
                objects[objName] = { name: objName };

        } else if (command === 'set') {

            let attribute = tokens[2];
            let value = tokens[3];

            let currentObj = objects[objName];
            currentObj[attribute] = value;

        } else if (command === 'print') {

            let allProperties = [];
            let printObject = objects[objName];
            for (let propName in printObject) {
                if (propName.toString() !== 'name') {
                    allProperties.push(propName + ':' + printObject[propName]);
                }
            }

            console.log(allProperties.join(', '));

        }


    }


}



solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);


