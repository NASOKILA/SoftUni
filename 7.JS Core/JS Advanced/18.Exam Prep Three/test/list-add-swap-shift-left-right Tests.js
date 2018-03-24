


let expect = require('chai').expect;

let createList = require('../list-add-swap-shift-left-right');

console.log(createList);



//add: go znaem
// 1 5 7
//shift left:  =  5 7 1     shift right: = 7 1 5     AKO RAZMERA NA MASIVA E > 1

//swap: 
//Ako index1:    NE e nomer ILI  e < 0 ILI e > DULJINATA NA MASIVA  VRUSTA 'false' ILI e = na index2.
//Ako index2:    NE e nomer ILI  e < 0 ILI e > DULJINATA NA MASIVA  VRUSTA 'false' ILI e = na index1.
//inache in razmenq mestata i vrushta 'true'.

//toString() vrushta masiva joinnata sus ', ' !!!


describe("Create List Mocha Tests", function () {

    it("shuld return: list = [1, two, 3]", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);

        expect(`list = [${list}]`).to.be.equal("list = [1, two, 3]");
    });


    it("shuld return: list = [two, 3, 1]", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        expect(`list = [${list}]`).to.be.equal("list = [two, 3, 1]");
    });

    it("shuld return: list = [two, 3, 1, four]", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        expect(`list = [${list}]`).to.be.equal("list = [two, 3, 1, four]");
    });


    it("shuld return: list = [four, two, 3, 1]", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        list.shiftRight();
        expect(`list = [${list}]`).to.be.equal("list = [four, two, 3, 1]");
    });

    it("shuld return: Swaping [0] and [3]: true", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        list.shiftRight();
        expect(`Swaping [0] and [3]: ${list.swap(0, 3)}`).to.be.equal("Swaping [0] and [3]: true");
    });

    it("shuld return: list = [1, two, 3, four]", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        list.shiftRight();
        list.swap(0, 3);
        expect(`list = [${list}]`).to.be.equal("list = [1, two, 3, four]");
    });


    it("shuld return: Swaping [1] and [1]: false", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        list.shiftRight();
        list.swap(0, 3)
        expect(`Swaping [1] and [1]: ${list.swap(1, 1)}`).to.be.equal("Swaping [1] and [1]: false");
    });

    it("shuld return: Swaping [1] and [1]: false", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        list.shiftRight();
        list.swap(3, 0)
        expect(`Swaping [1] and [1]: ${list.swap(1, 1)}`).to.be.equal("Swaping [1] and [1]: false");
    });


    it("shuld return: list = [1, two, 3, four]", function () {
        let list = createList();
        list.add(1);
        list.add("two");
        list.add(3);
        list.shiftLeft();
        list.add(["four"]);
        list.shiftRight();
        list.swap(0, 3);
        list.swap(1, 1)
        expect(`list = [${list}]`).to.be.equal("list = [1, two, 3, four]");
    });



    //MY TESTS:


    //shiftLeft when array has only one NUMBER element 
    it("shuld return: list = [1]", function () {
        let list = createList();
        list.add(1);
        list.shiftLeft();
        expect(`list = [${list}]`).to.be.equal("list = [1]");
    });

    //shiftRight when array has only one NUMBER element 
    it("shuld return: list = [1]", function () {
        let list = createList();
        list.add(1);
        list.shiftRight();
        expect(`list = [${list}]`).to.be.equal("list = [1]");
    });

    //shiftLeft when array has only one STRING element 
    it("shuld return: list = [hello]", function () {
        let list = createList();
        list.add("hello");
        list.shiftLeft();
        expect(`list = [${list}]`).to.be.equal("list = [hello]");
    });

    //shiftRight when array has only one STRING element 
    it("shuld return: list = [hello]", function () {
        let list = createList();
        list.add("hello");
        list.shiftRight();
        expect(`list = [${list}]`).to.be.equal("list = [hello]");
    });

    //Shift left on empty array
    it("shuld return: list = []", function () {
        let list = createList();
        list.shiftLeft();
        expect(`list = [${list}]`).to.be.equal("list = []");
    });

    //Shift right on empty array
    it("shuld return: list = []", function () {
        let list = createList();
        list.shiftRight();
        expect(`list = [${list}]`).to.be.equal("list = []");
    });



    //Swapping:

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(3, 1);
        //list.swap(1,1)
        expect(`list = [${list}]`).to.be.equal("list = [1, 4, 3, 2]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(3, 0);
        //list.swap(1,1)
        expect(`list = [${list}]`).to.be.equal("list = [4, 2, 3, 1]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(0, 3);
        //list.swap(1,1)
        expect(`list = [${list}]`).to.be.equal("list = [4, 2, 3, 1]");
    });

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add("One");
        list.add("Two");
        list.add("Three");
        list.add("Four");
        list.swap(0, 3);
        //list.swap(1,1)
        expect(`list = [${list}]`).to.be.equal("list = [Four, Two, Three, One]");
    });
    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add("One");
        list.add("Two");
        list.add("Three");
        list.add("Four");
        list.swap(-1, 3);
        expect(`list = [${list}]`).to.be.equal("list = [One, Two, Three, Four]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add("One");
        list.add("Two");
        list.add("Three");
        list.add("Four");
        list.swap(1, -2);
        expect(`list = [${list}]`).to.be.equal("list = [One, Two, Three, Four]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add("One");
        list.add("Two");
        list.add("Three");
        list.add("Four");
        list.swap(1, 4);
        expect(`list = [${list}]`).to.be.equal("list = [One, Two, Three, Four]");
    });
    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add("One");
        list.add("Two");
        list.add("Three");
        list.add("Four");
        list.swap(4, 1);
        expect(`list = [${list}]`).to.be.equal("list = [One, Two, Three, Four]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add("One");
        list.add("Two");
        list.add("Three");
        list.add("Four");
        list.swap(1, 1);
        expect(`list = [${list}]`).to.be.equal("list = [One, Two, Three, Four]");
    });it("shuld return: list = [One, One]", function () {
        let list = createList();
        list.add("One");
        list.add("One");
        list.swap(0, 1);
        expect(`list = [${list}]`).to.be.equal("list = [One, One]");
    });

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(-3, -0);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, -0);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(-5, 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    
    it("shuld return: list = []", function () {
        let list = createList();
        list.swap(1, 2);
        expect(`list = [${list}]`).to.be.equal("list = []");
    });



    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap("5", 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap({}, 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap([], 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(true, 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(NaN, 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(undefined, 5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });



    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, "5");
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, true);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, []);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, {});
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, undefined);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5, NaN);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(1.1, 2.5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });
    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(1, 2.5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });

    
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(0, 1);
        expect(`list = [${list.toString()}]`).to.be.equal("list = [2, 1, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(3, 1);
        expect(`list = [${list.toString()}]`).to.be.equal("list = [1, 4, 3, 2]");
    });

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(1, 0);
        expect(`list = [${list.toString()}]`).to.be.equal("list = [2, 1, 3, 4]");
    });
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        let output = list.swap(1, 3);
        expect(output).to.be.true;
        expect(`list = [${list.toString()}]`).to.be.equal("list = [1, 4, 3, 2]");
    });
//Ako nqkoi ot indexite ne sushtestvuvat
    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap(5);
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });

    it("shuld return: list = [1, 4, 3, 2]", function () {
        let list = createList();
        list.add(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.swap();
        expect(`list = [${list}]`).to.be.equal("list = [1, 2, 3, 4]");
    });


    //Check if funcktions exist
    it('Should return true', function () {
        let list = createList();
        expect(list.hasOwnProperty('add')).to.be.true;
    })
    it('Should return true', function () {
        let list = createList();
        expect(list.hasOwnProperty('shiftLeft')).to.be.true;
    })
    it('Should return true', function () {
        let list = createList();
        expect(list.hasOwnProperty('shiftRight')).to.be.true;
    })
    it('Should return true', function () {
        let list = createList();
        expect(list.hasOwnProperty('swap')).to.be.true;
    })
    it('Should return true', function () {
        let list = createList();
        expect(list.hasOwnProperty('toString')).to.be.true;
    })

});












