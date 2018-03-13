

const expect = require('chai').expect;
const Console = require('../05.C# Console');



describe('Class Console Tests', function(){

    it('Should return same string as the one in the input', function(){
        expect(Console.writeLine('test')).to.be.equal('test');
    })

    it('Should return object stringified on object input', function(){
        let obj = {name:"Pesho"};
        expect(Console.writeLine(obj)).to.be.equal(JSON.stringify(obj));
    })

    it('Should replace the vlues in the placeholders', function(){
        expect(Console.writeLine('{0}, {1}, {2}', 1, 2, 3)).to.be.equal('1, 2, 3');
    })

    it('Should return TypeError if multiple parameters exist and the first one is NOT a string', function(){
        expect(() => {Console.writeLine([], 2, 3) })
            .to.throw(TypeError)
    }) //VAJNO POLZVAME to.throw(TypeError);  ZA DA HVURLIM GRESHKA 
    //OBACHE TRQBVA V EXPECT PODADENOTO DA E V ARROW FUNKCIQ.

    
    it('Should return RangeError if placeholders count differs from parameters count', function(){
        expect(() => {Console.writeLine('{0}, {1}, {2}', 1, 2, 3, 4)})
            .to.throw(RangeError);
    })

    it('Should return RangeError if placeholders count differs from parameters count', function(){
        expect(() => {Console.writeLine('{0}, {1}, {2}', 1, 2)})
            .to.throw(RangeError);
    })

    
    it('Should return RangeError if placeholders count differs from parameters count', function(){
        expect(() => {Console.writeLine('{10}', 1, 2, 4)})
            .to.throw(RangeError);
    })

    it('Should return RangeError if placeholders differs from parameters', function(){
        expect(() => {Console.writeLine('{0}, {1}, {22}', 1, 2, 3)})
            .to.throw(RangeError);
    })

});



