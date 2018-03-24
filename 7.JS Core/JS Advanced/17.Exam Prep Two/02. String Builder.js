
class StringBuilder {

    constructor(string) {

        if (string !== undefined) {
            StringBuilder._vrfyParam(string); //verificira parametura sus statichna funkciq
            this._stringArray = Array.from(string); //zakacha array ot chars ot podadeniq string
        } else {
            this._stringArray = []; //ako podadenoto e undefined suzdava prazen masiv 
        }

    }

    //AKO SME PODALI STRING
    //zakacha masiv ot char ot podadeniq string nakraq na _stringArray
    append(string) {
        StringBuilder._vrfyParam(string);
        for (let i = 0; i < string.length; i++) {
            this._stringArray.push(string[i]);
        }
    }

    //sushtoto kato gornoto smoche ZAKACHA MASIVA ZA NACHALOTO A NE ZA KRAQ
    prepend(string) {
        StringBuilder._vrfyParam(string);
        for (let i = string.length - 1; i >= 0; i--) {
            this._stringArray.unshift(string[i]);
        }
    }

    //INDEXA VINAGI SHTE E V GRANICITE NA _stringArr
    //zakacha masiv ot char ot podadeniq string na daden index
    insertAt(string, startIndex) {
        StringBuilder._vrfyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }

    //premahva dadena duuljina ot _stringArr ot daden index 
    remove(startIndex, length) {
        this._stringArray.splice(startIndex, length);
    }

    //proverqva dali podadenoto e ot tip string
    static _vrfyParam(param) {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }

    //vrushta vsichki elementi na _stringArray zalepeni s prazen string
    toString() {
        return this._stringArray.join('');
    }
}

console.log(StringBuilder.prototype.hasOwnProperty('_vrfyParam'));
/*
let str = new StringBuilder('hello');
str.append(', there');
str.prepend('User, ');
str.insertAt('woop', 5);
console.log(str.toString());
str.remove(6, 3);
console.log(str.toString());
*/


module.exports = {StringBuilder};