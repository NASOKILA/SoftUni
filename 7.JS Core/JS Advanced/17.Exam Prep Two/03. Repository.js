

//VAJNO!O!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //Dobra praktika e getterite i setterite da sa vednaga sled konstruktura            


class Repository {
    
    constructor(props) {
        this.props = props;
        this.data = new Map();
        this.id = 0;
    }
    
    get count() {
        return this.data.size;
    }

    add(entity) {

        this.validateEntity(entity);
        this.data.set(this.id, entity);
        return this.id++;
    }

    get(id) {
        this.validateId(id)
        return this.data.get(id);
    }

    update(id, entity) {

        this.validateId(id);
        this.validateEntity(entity);
        this.data.set(id, entity);
    }

    del(id) {
        this.validateId(id);
        this.data.delete(id);
    }

    validateId(id) {

        let keys = Array.from( this.data.keys());
        if(!keys.includes(id))
            throw new Error(`Entity with id: ${id} does not exist!`);
    }

    validateEntity(entity) {
        
        let keysLength = Object.keys(this.props).length;
        for (let i = 0; i < keysLength; i++) {
            //validate keys
            let currentProperty = Object.keys(this.props)[i];
            if (!entity.hasOwnProperty(currentProperty))
                throw new Error(`Property ${currentProperty} is missing from the entity!`);
        
            //validate values
            let currentvalue = entity[currentProperty];
            let typeThatItShouldBe = this.props[`${currentProperty}`];
            if (typeof currentvalue !== typeThatItShouldBe)
                throw new TypeError(`Property ${currentProperty} is of incorrect type!`);
        }
    }
}


// Initialize props object
let properties = {
    name: "string",
    age: "number",
    birthday: "object"
};
//Initialize the repository
let repository = new Repository(properties);
// Add two entities
let entity = {
    name: "Kiril",
    age: 19,
    birthday: new Date(1998, 0, 7)
};
console.log(repository.add(entity)); // Returns 0
console.log(repository.add(entity)); // Returns 1
console.log(repository.get(0));
// {"name":"Kiril","age":19,"birthday":"1998-01-06T22:00:00.000Z"}
console.log(repository.get(1));
// {"name":"Kiril","age":19,"birthday":"1998-01-06T22:00:00.000Z"}
//Update an entity
entity = {
    name: 'Valio',
    age: 19,
    birthday: new Date(1998, 0, 7)
};
repository.update(1, entity);
console.log(repository.get(1));
// {"name":"Valio","age":19,"birthday":"1998-01-06T22:00:00.000Z"}
// Delete an entity
repository.del(0);
console.log(repository.count); // Returns 1
