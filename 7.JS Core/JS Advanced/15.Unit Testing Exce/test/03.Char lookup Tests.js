



let expect = require('chai').expect;

let lookupChar = require('../03. Char Lookup');

describe("Look Up Char", function(){

    it('Shoud Return "h" from "hhhhhhhh", 3', function(){
        expect(lookupChar("hhhhhhhh", 3)).to.equal("h");
    })
    it('Shoud Return "b" from "abcde", 1', function(){
        expect(lookupChar("abcde", 1)).to.equal("b");
    })
    it('Shoud Return "Incorrect index" from "abcde", -2', function(){
        expect(lookupChar("abcde", -2)).to.be.equal("Incorrect index");
    })
    it('Shoud Return "Incorrect index" from "abcde", 10', function(){
        expect(lookupChar("abcde", 10)).to.be.equal("Incorrect index");
    })
    it('Shoud Return "Incorrect index" from "abcde", 4', function(){
        expect(lookupChar("abcde", 5)).to.be.equal("Incorrect index");
    })
    it('Shoud Return "Incorrect index" from "abcde", 4', function(){
        expect(lookupChar("abcde", 0)).to.be.equal("a");
    })
    it('Shoud Return "Incorrect index" from "abcde", 4', function(){
        expect(lookupChar("", 5)).to.be.equal("Incorrect index");
    })
   
    it('Shoud Return "Incorrect index" from "abcde", 4', function(){
        expect(lookupChar(5)).to.be.equal(undefined);
    })
    it('Shoud Return "Incorrect index" from "abcde", 4', function(){
        expect(lookupChar("")).to.be.equal(undefined);
    })


    it('Shoud Return "Incorrect index" from "abcde", 4', function(){
        expect(lookupChar("abcde", 5.2)).to.be.equal(undefined);
    })
    
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar("abcde", 3)).to.equal('d');
    })



    it('Shoud Return "undefined" from "abcde", "3"', function(){
        expect(lookupChar("abcde", "3")).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar("false", [])).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar("false", {})).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar("false", false)).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar("awdfafawamocha", function(){})).to.equal(undefined);
    })



    it('Shoud Return "undefined" from [], "3"', function(){
        expect(lookupChar([], "3")).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar([], 3)).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar([], [])).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar([], {})).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar([], false)).to.equal(undefined);
    })
    it('Shoud Return "undefined" from false, "3"', function(){
        expect(lookupChar([], function(){})).to.equal(undefined);
    })

})










