


let isSymmetric = require('../05.Check For Symmetry');

let expect = require('chai').expect;


describe('Symmetry', function(){


    it('Should return true [2,1,1,2]', function(){
        expect(isSymmetric([2,1,1,2])).to.be.true;
    })

    it('Should return true [1,2,1]', function(){
        expect(isSymmetric([1,2,1])).to.be.true;
    })
   
    it('Should return false ["test"]', function(){
        expect(isSymmetric(["test"])).to.be.true;
    })
    
    it('Should return true []', function(){
        expect(isSymmetric([])).to.be.true;
    })

    it('Should return false   ', function(){
        expect(isSymmetric()).to.be.false;
    })

    it("should return true for [5,'hi',{a:5},new Date(),{a:5},'hi',5]", function () {
        expect(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5])).to.be.equal(true);
    });

})

