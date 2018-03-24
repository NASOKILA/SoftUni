
let data = require('./data');

function sort(property) {

   
    let result = data.sort(function (a, b) {
        if (a[property] < b[property])
            return -1;
        if (a[property] > b[property])
            return 1;
        return 0;
    });
    return result;
}
    //MOJE I TAKA DA SORTIRAME:
        //let result = data.sort((a,b) => a[property].localeCompare(b[property]))

function filter(property, value) {
    
    let result = [];

    data.forEach(obj => {

        if (obj.hasOwnProperty(property)) {
            let objValue = obj[property];
            if (objValue === value) {
                result.push(obj);
            }
        }
    });

    return result;
}

    //Moje i sus .reduce()

module.exports = { sort, filter };



