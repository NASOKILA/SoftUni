


class Rat
{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    unite(otherRat){

        let className = otherRat.constructor.name;
        if(className === "Rat")
            this.unitedRats.push(otherRat);
    }

    getRats(){

        return this.unitedRats;   
    }

    toString(){
        let result = `${this.name}`;
        for (let rat of this.unitedRats) 
            result += '\n##' + rat.name;
        
        return result;
    }
}



let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]


test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());

console.log(test.toString());

console.log();

let rat2 = new Rat("Viktor");
let rat3 = new Rat("Vichi");
let rat4 = "fake rat";

rat2.unite(rat4);
console.log(rat2.toString());


