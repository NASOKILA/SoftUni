


class Entity
{
    constructor (name) {
        
        if(new.target === Entity) 
            throw new TypeError("Cannot construct Entity instances directly");
        
        this.name = name;
    }

}

module.exports = Entity;