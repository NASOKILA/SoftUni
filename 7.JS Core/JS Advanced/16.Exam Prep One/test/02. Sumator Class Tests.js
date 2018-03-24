

let expect = require('chai').expect;

let Sumator = require('../02. Sumator Class');

let list = new Sumator();
console.log(`list = [${list}]`);


//VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!
//MOJE DA GO IMA NA IZPITA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//PURVO PROVERQVAME DALI FUNKCIITE SE SUDURJAT V PROTOTIPA NA KLASA INACHE PRI TQHNOTO IZVIKVANE SHTE GRUMNE 
describe('Checks if functions exist', function(){

    //proverqvame i za konstruktor
    it('data is not undefined', function(){
        expect(list.data !== undefined).to.be.equal(true);
    });

    it('has add() function', function(){
        expect(Sumator.prototype.hasOwnProperty('add')).to.be.equal(true);
    });
    
    it('has sumNums() function', function(){
        expect(Sumator.prototype.hasOwnProperty('sumNums')).to.be.equal(true);
    });
    
    it('has removeByFilter() function', function(){
        expect(Sumator.prototype.hasOwnProperty('removeByFilter')).to.be.equal(true);
    });
    
    it('has toString() function', function(){
        expect(Sumator.prototype.hasOwnProperty('toString')).to.be.equal(true);
    });
});


describe('Sumator Class Tests', function(){
    
    let list;

    function beforeEach()
    {
        list = new Sumator();
    }

    it('Should return list = [(empty)] !!!', function(){
        
        list = new Sumator();
        expect(`list = [${list}]`).to.be.equal(`list = [(empty)]`);
    });

    it('Should return list = [1, 2, three, 4] !!!', function(){
        
        list = new Sumator();
        list.add(1);
        list.add(2);
        list.add("three");
        list.add(4);

        expect(`list = [${list}]`).to.be.equal(`list = [1, 2, three, 4]`);
    });

    it('Should return sum = 7 !!!', function(){
        
        list = new Sumator();
        list.add(1);
        list.add(2);
        list.add("three");
        list.add(4);

        expect("sum = " + list.sumNums()).to.be.equal(`sum = 7`);
    });

    it('Should return list = [1, 2, three, 4, 5.5, 7.7] !!!', function(){
        
        list = new Sumator();
        list.add(1);
        list.add(2);
        list.add("three");
        list.add(4);    
        list.add("5.5"); // not a number!
        list.add(7.7);

        expect(`list = [${list}]`).to.be.equal(`list = [1, 2, three, 4, 5.5, 7.7]`);
    });

    it('Should return sum = 14.7 !!!', function(){
        
        list = new Sumator();
        list.add(1);
        list.add(2);
        list.add("three");
        list.add(4);    
        list.add("5.5"); // not a number!
        list.add(7.7);

        expect("sum = " + list.sumNums()).to.be.equal(`sum = 14.7`);
    });

    it('Should return list = [1, three, 5.5, 7.7] !!!', function(){
        
        list = new Sumator();
        list.add(1);
        list.add(2);
        list.add("three");
        list.add(4);    
        list.add("5.5"); // not a number!
        list.add(7.7);
        list.removeByFilter(x => x % 2 === 0);

        expect(`list = [${list}]`).to.be.equal(`list = [1, three, 5.5, 7.7]`);
    });
    
    it('Should return sum = 8.7 !!!', function(){
        
        list = new Sumator();
        list.add(1);
        list.add(2);
        list.add("three");
        list.add(4);    
        list.add("5.5"); // not a number!
        list.add(7.7);
        list.removeByFilter(x => x % 2 === 0);

        expect("sum = " + list.sumNums()).to.be.equal(`sum = 8.7`);
    });  
})

