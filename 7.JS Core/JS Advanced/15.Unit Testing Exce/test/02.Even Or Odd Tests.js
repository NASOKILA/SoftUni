

let expect = require('chai').expect;
let isOddOrEven = require('../02. Even Or Odd.js');

describe('Even Or Odd', function(){

    it('Should return "odd" from "cat"', function() {
        expect(isOddOrEven("cat")).to.equal("odd");
    })
    
    it('Should return "odd" from "cat"', function() {
        expect(isOddOrEven("alabala")).to.equal("odd");
    })
    
    it('Should return "even" from "is it even"', function() {
        expect(isOddOrEven("is it even")).to.be.equal("even");
    })
    
    it('Should return "even" from ""', function() {
        expect(isOddOrEven("")).to.be.equal("even");
    })
    
    it('Should return unefined from {}', function() {
        expect(isOddOrEven({})).to.be.equal(undefined);
    })
    
    it('Should return unefined from ', function() {
        expect(isOddOrEven()).to.be.equal(undefined);
    })
    
    it('Should return unefined from []', function() {
        expect(isOddOrEven([])).to.be.equal(undefined);
    })
})