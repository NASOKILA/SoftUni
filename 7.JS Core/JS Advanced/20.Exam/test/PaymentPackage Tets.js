

/*

Zadacha 2:
Proverqvai dali funkciite sushtestvuvat.    
ZA DA HVURLQSH GRESHKI TRQBVA DA IMASH ARROW FUNKCIQ V EXPECTA.
static FUNKCIITE 'NE' SA ZAKACHENI Z KONTEXTA.

*/



let expect = require('chai').expect;

let PaymentPackage = require('../PaymentPackage');

//Check if exists
//console.log(createList);

describe("PaymentPackages Mocha Tests", function () {

    it("Shuld return: Error", function () {
        try {
            const hrPack = new PaymentPackage('HR Services');
        } catch(err) {

            expect(err).to.be.equal(err);
        }
        
    });


    it("Shuld return: ...", function () {
       let p = new PaymentPackage('HR Services', 1500);
        

        expect(p.toString()).to.be.equal('Package: HR Services\n'+ 
        '- Value (excl. VAT): 1500\n'+
        '- Value (VAT 20%): 1800');
        
    });

    it("Shuld DOUBLE WORKS return: ...", function () {
        let p = new PaymentPackage('HR Services', 1500.5);
         
         expect(p.toString()).to.be.equal('Package: HR Services\n'+ 
         '- Value (excl. VAT): 1500.5\n'+
         '- Value (VAT 20%): 1800.6');
     });
     

    it("Shuld return: ...", function () {
        
        const packages = [
            new PaymentPackage('HR Services', 1500),
            new PaymentPackage('Consultation', 800),
            new PaymentPackage('Partnership Fee', 7000),
        ];
 
         expect(packages.join('\n')).to.be.equal('Package: HR Services\n'+
         '- Value (excl. VAT): 1500\n'+
         '- Value (VAT 20%): 1800\n'+
         'Package: Consultation\n'+
         '- Value (excl. VAT): 800\n'+
         '- Value (VAT 20%): 960\n'+
         'Package: Partnership Fee\n'+
         '- Value (excl. VAT): 7000\n'+
         '- Value (VAT 20%): 8400');
     });
 


     it("Shuld return: Error", function () { 
        
        expect(() => new PaymentPackage('HR Services')).to.throw(Error, 'Value must be a non-negative number');
    });
    
    it("Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', -1)).to.throw(Error, 'Value must be a non-negative number');
    });

     

    it("Shuld return: Value must be a non-negative number", function () { 
        
        const wrongPack = new PaymentPackage('Transfer Fee', 100);
        expect(() => wrongPack.active = null).to.throw(Error, 'Active status must be a boolean');
    });
    
    //test all exceptions 


    //Test NAME
    it("Shuld return: Error SUS STOINOTITE NA OBRATNO", function () { 
        
        expect(() => new PaymentPackage(0, 'HR Services')).to.throw(Error, 'Name must be a non-empty string');
    });    
    it("Shuld return: Error SUS '' ZA NAME", function () { 
        
        expect(() => new PaymentPackage(5.7, 5)).to.throw(Error, 'Name must be a non-empty string');
    });
    it("Shuld return: Error SUS '' ZA NAME", function () { 
        
        expect(() => new PaymentPackage(true, 5)).to.throw(Error, 'Name must be a non-empty string');
    });
    it("Shuld return: Error SUS '' ZA NAME", function () { 
        
        expect(() => new PaymentPackage({}, 5)).to.throw(Error, 'Name must be a non-empty string');
    });
    it("Shuld return: Error SUS '' ZA NAME", function () { 
        
        expect(() => new PaymentPackage([], 5)).to.throw(Error, 'Name must be a non-empty string');
    });
    it("Shuld return: Error SUS '' ZA NAME", function () { 
        
        expect(() => new PaymentPackage(5, 5)).to.throw(Error, 'Name must be a non-empty string');
    });
    it("Shuld return: Error SUS '' ZA NAME", function () { 
        
        expect(() => new PaymentPackage(5)).to.throw(Error, 'Name must be a non-empty string');
    });

    



    //testValues
    it("TEST VALUE Shuld return: Error AKO NQMAMV VALUE", function () { 
        
        expect(() => new PaymentPackage('HR Services')).to.throw(Error, 'Value must be a non-negative number');
    });
    
    it("TEST VALUE NEGATIVE Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', -1)).to.throw(Error, 'Value must be a non-negative number');
    });
    
    it("TEST VALUE NEGATIVE Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', true)).to.throw(Error, 'Value must be a non-negative number');
    });
    
    it("TEST VALUE NEGATIVE Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', [])).to.throw(Error, 'Value must be a non-negative number');
    });
    it("TEST VALUE NEGATIVE Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', {})).to.throw(Error, 'Value must be a non-negative number');
    });
    it("TEST VALUE NEGATIVE Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', "1")).to.throw(Error, 'Value must be a non-negative number');
    });
    
    it("TEST VALUE NEGATIVE Shuld return: Error SUS -1", function () { 
        
        expect(() => new PaymentPackage('HR Services', undefined)).to.throw(Error, 'Value must be a non-negative number');
    });


    //Test VAT
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);

        expect(() => p.VAT = -1).to.throw(Error, 'VAT must be a non-negative number');
    });
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);

        expect(() => p.VAT = "1").to.throw(Error, 'VAT must be a non-negative number');
    });
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);

        expect(() => p.VAT = true).to.throw(Error, 'VAT must be a non-negative number');
    });
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);

        expect(() => p.VAT = []).to.throw(Error, 'VAT must be a non-negative number');
    });
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);

        expect(() => p.VAT = {}).to.throw(Error, 'VAT must be a non-negative number');
    });
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);

        expect(() => p.VAT = undefined).to.throw(Error, 'VAT must be a non-negative number');
    });
    
    
    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);
        p.VAT = 5.5;
        expect(p.VAT).to.be.equal(5.5);
    });

    it("TEST VAT: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);
        p.value = 5.5;
        expect(p.value).to.be.equal(5.5);
    });
    

    //Test Active
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);
        p.active = false;
        expect(p.active).to.be.false;
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);
        p.active = true;
        expect(p.active).to.be.true;
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5);
        
        expect(() => p.active = "s").to.throw(Error, 'Active status must be a boolean');
        
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(() => p.active = 0).to.throw(Error, 'Active status must be a boolean');
    });
    
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(() => p.active = []).to.throw(Error, 'Active status must be a boolean');
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(() => p.active = {}).to.throw(Error, 'Active status must be a boolean');
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(() => p.active = undefined).to.throw(Error, 'Active status must be a boolean');
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(() => p.active = 'ksadkak').to.throw(Error, 'Active status must be a boolean');
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(() => p.active = 5.4).to.throw(Error, 'Active status must be a boolean');
    });
    it("TEST ACTIVE: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(p.active).to.be.true;
    });
    
    
    
    //Test ToString()
    it("TEST ToString: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        expect(p.toString()).to.be.equal('Package: HR Services\n' +
        '- Value (excl. VAT): 5\n' +
        '- Value (VAT 20%): 6');
    });

    it("TEST ToString: ", function () { 
        
        let p = new PaymentPackage('HR Services', 5); 
        p.active = false;
        expect(p.toString()).to.be.equal('Package: HR Services (inactive)\n' +
        '- Value (excl. VAT): 5\n' +
        '- Value (VAT 20%): 6');
    });


     //test if methods exist

     it('Should return true', function () {
        expect(PaymentPackage.prototype.hasOwnProperty('name')).to.be.true;
    })
    it('Should return true', function () {
        expect(PaymentPackage.prototype.hasOwnProperty('value')).to.be.true;
    })
    it('Should return true', function () {
        expect(PaymentPackage.prototype.hasOwnProperty('VAT')).to.be.true;
    })
    it('Should return true', function () {
        expect(PaymentPackage.prototype.hasOwnProperty('active')).to.be.true;
    })
    
    //proveri propertitata
    it('Should return true', function () {
        let p = new PaymentPackage('HR Services', 5); 
       
        expect(p.hasOwnProperty('_name')).to.be.true;
    })
    it('Should return true', function () {
        let p = new PaymentPackage('HR Services', 5); 
       
        expect(p.hasOwnProperty('_value')).to.be.true;
    })
    it('Should return true', function () {
        let p = new PaymentPackage('HR Services', 5); 
       
        expect(p.hasOwnProperty('_VAT')).to.be.true;
    })
    it('Should return true', function () {
        let p = new PaymentPackage('HR Services', 5); 
       
        expect(p.hasOwnProperty('_active')).to.be.true;
    })
    
    it('Should return true', function () {
        let p = new PaymentPackage('HR Services', 5); 
       
        expect(PaymentPackage.prototype.hasOwnProperty('toString')).to.be.true;

    })
    
       
});










