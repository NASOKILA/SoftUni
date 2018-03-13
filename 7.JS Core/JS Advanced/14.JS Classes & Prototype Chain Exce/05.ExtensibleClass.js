
/*
function extend(template) {
    for (let prop in template) {
        if (typeof (prop) === 'function')
            Object.getPrototypeOf(this)[prop] = template[prop];
        else
            this[prop] = template[prop];
    }
}


let template = {
    extensionData: 5,
    extensionMethod: function (value) {
        return value + 1;
    }
};
*/



(function(){
    
let id = 0;

return class Extensible {

    constructor() {
        this.id = id++;
    }

    extend(template) {
        for (let prop in template) {
            if (typeof template[prop] === 'function')
                Object.getPrototypeOf(this)[prop] = template[prop];
            else
                this[prop] = template[prop];
        }
    }

}

})()

/*
let testObj = new Extensible();
console.log(testObj.id);
testObj.extend(template);
*/

/*
let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);
*/











