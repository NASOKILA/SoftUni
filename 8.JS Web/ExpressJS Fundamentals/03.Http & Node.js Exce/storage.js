

let memory = {};

let storage = {

    put: (key, value) => {
        if (typeof key !== 'string') {
            throw Error('Key should be a String !');
            //return 'Key should be a String';
        }

        if (key in memory) {
            throw Error('Key already exists in storage !');
            //return 'Key already exists in storage';
        }

        memory[`${key}`] = value;
    },

    get: (key) => {
        checkKey(key);
        return memory[`${key}`];
    },

    getAll: () => {
        if (Object.keys(memory).length === 0) {
            throw Error('Storage is Empty !');
            //return 'There are no items in the storage';
        }

        return memory;
    },

    update: (key, newValue) => {
        checkKey(key);
        memory[`${key}`] = newValue;
    },

    delete: (key) => {
        checkKey(key);
        delete memory[`${key}`];
    },

    clear: () => {
        memory = {};
    },

    save: () => {
        var fs = require('fs');
        fs.writeFileSync("storage.json", JSON.stringify(memory), 'utf8');
    },

    //podavame funkciq
    load: (callback) => {
        var fs = require('fs');

        fs.readFileSync("storage.json", 'utf8', ((err, data) => {
            if (err)
                return;

            memory = JSON.parse(data);
            callback();

        }));
    }

    
};


function checkKey(key) {
    if (typeof key !== 'string') {
        throw Error('Key should be a String !');
        //return 'Key should be a String';
    }
    if (!(key in memory)) {
        throw Error('Key does not exist in storage !');
        //return 'Key does not exist in storage';
    }
}


module.exports = storage;


