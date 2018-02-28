
function result() {

    let summary = {};
    let sortedTypes = [];

    for (let i in arguments) {

        let arg = arguments[i];
        let type = typeof arg;

        if (!summary[type])
            summary[type] = 1;
        else
            summary[type]++;

        console.log(type + ': ' + arg);
    }

    for (let currentType in summary) {
        sortedTypes.push([currentType, summary[currentType]]);
    }

    for (let type in sortedTypes.sort((a,b) => b[1] - a[1])) {
        
        let currentType = sortedTypes[type][0];
        let count = sortedTypes[type][1];

        console.log(currentType + ' = ' + count);
    }

}

result('cat', 42, function () { console.log('Hello world!'); });

result({ name: 'bob'}, 3.333, 9.999);

/*
var expectedOutput = [
    'object:',
    'number: 3.333',
    'number: 9.999',
    'number = 2',
    'string = 1'
];
*/