

let solve = (function () {

    let objects = [];

    function createObject(name) {
        let obj = {name:name};
        objects.push(obj);
    }

    function printObject(name) {
        let objToPrint = objects.find(o => o.name === name);

        let properties = [];
        for(let property in objToPrint) {
            if(property !== 'name')
                properties.push(`${property}:${objToPrint[property]}`);
        }

        console.log(properties.join(', '));
    }

    function inheritAnObject(objectName, inheritedObjectName) {

        let objToInherit = objects.find(o => o.name === inheritedObjectName);
        let obj = Object.create(objToInherit);
        obj.name = objectName;
        objects.push(obj);
    }

    function changeProperty(name, property, value) {
        let objToChange = objects.find(o => o.name === name);
        objToChange[property] = value;
    }

    return function (input) {

        for(let row of input) {
            let elements = row.split(' ');
            
            if(elements[0] === 'create' && elements.length === 2) {
                createObject(elements[1])
            }else if(elements[0] === 'print'){
                printObject(elements[1]);
            }else if(elements[0] === 'create' && elements.length === 4){
                inheritAnObject(elements[1], elements[3]);
            }else{
                changeProperty(elements[1],elements[2],elements[3]);
            }
        }
    }
})()

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);







