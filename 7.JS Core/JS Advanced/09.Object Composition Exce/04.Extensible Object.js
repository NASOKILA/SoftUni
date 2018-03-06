

function getExtensibleObject() {

    let obj = {
        __proto__: {},
        extend: function (templateObj) {

            for(let key in templateObj) {

                //Minavame prez vsichki propertita na podadeniq obekt
                let element = templateObj[key];

                //ako tiput mu e funkciq trqbva da q zakachim za prototipa
                //ako ne e funkciq q zakachame za samiq obekt kato property
                if(typeof (element) === 'function')
                    obj.__proto__[key] = element;
                else
                    obj[key] = element;
            }

        }
    };

    //vrushtame obekta
    return obj;
}

//shte polzvame tozi tempate za primer
let template = {
    extensionMethod: function () {
        console.log('Nasko');},
    extensionProperty: 'someString'
};

//pravim si obekta
let myobj = getExtensibleObject();

//i mu pravim promenite kato podavame na funkciqta template-a
myobj.extend(template);

//vijdame obekta
console.log(myobj);

//vijdame i prototipa mu
console.log(Object.getPrototypeOf(myobj));



