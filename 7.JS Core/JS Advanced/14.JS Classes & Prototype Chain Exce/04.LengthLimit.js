




class Stringer {

    constructor(innerString, innerLength){
        
        this.setInnerLength = innerLength;
        this.setInnerString = innerString;
        this.initialString = innerString;
    }

    get getInnerString(){
        return this.innerString;
    }
    set setInnerString(string){
        this.innerString = string;
    }

    get getInnerLength(){
        return this.innerLength;
    }
    set setInnerLength(length){

        if(length < 0)
            this.innerLength = 0;
        else
            this.innerLength = length;
    }

    increase(length){
        this.setInnerLength = (this.getInnerLength + length);
        
        this.innerString = this.initialString.slice(0, length);
    }

    decrease(length){
        this.setInnerLength = (this.getInnerLength - length);
    } 

    toString()
    {
        let stringLength = this.getInnerString.length;
        if(stringLength > this.getInnerLength)
        {
            let difference = Math.abs(stringLength - this.getInnerLength);
            this.innerString = this.innerString.slice(0,stringLength - difference);
            this.innerString  += '...';            
        }

        return this.innerString;
    }

}


let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...


test.decrease(5);
console.log(test.toString()); //...


test.increase(4);
console.log(test.toString()); //Test


