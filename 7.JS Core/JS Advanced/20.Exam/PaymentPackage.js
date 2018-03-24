

/*

Zadacha 2:
Proverqvai dali funkciite sushtestvuvat.    
ZA DA HVURLQSH GRESHKI TRQBVA DA IMASH ARROW FUNKCIQ V EXPECTA.
static FUNKCIITE 'NE' SA ZAKACHENI Z KONTEXTA.

*/

class PaymentPackage {
    constructor(name, value) {
      this.name = name;
      this.value = value;
      this.VAT = 20;      // Default value    
      this.active = true; // Default value
    }
  
    //getter za _name
    get name() {
      return this._name;
    }
  
    set name(newValue) {

        //ako ne e string ili e prazno gurmi 
      if (typeof newValue !== 'string') {
        throw new Error('Name must be a non-empty string');
      }

      //ako duljinata mu e 0 gurmi
      if (newValue.length === 0) {
        throw new Error('Name must be a non-empty string');
      }
      this._name = newValue;
    }
  
    //getter za _value
    get value() {
      return this._value;
    }
  

    set value(newValue) {

        //ako e chislo
      if (typeof newValue !== 'number') {
        throw new Error('Value must be a non-negative number');
      }

      //ako e po malko ot 0 gurmi
      if (newValue < 0) {
        throw new Error('Value must be a non-negative number');
      }
      this._value = newValue;
    }
  //gatter za vat
    get VAT() {
      return this._VAT;
    }
  
    //sushtata validaciq
    set VAT(newValue) {
      if (typeof newValue !== 'number') {
        throw new Error('VAT must be a non-negative number');
      }
      if (newValue < 0) {
        throw new Error('VAT must be a non-negative number');
      }
      this._VAT = newValue;
    }
  
    get active() {
      return this._active;
    }
  
    set active(newValue) {

        //ako ne e bool gurmi
      if (typeof newValue !== 'boolean') {
        throw new Error('Active status must be a boolean');
      }
      this._active = newValue;
    }
  
    toString() {
      const output = [
        `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
        `- Value (excl. VAT): ${this.value}`,
        `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
      ];
      return output.join('\n');
    }
  }
  

  
const packages = [
    new PaymentPackage('HR Services', 1500),
    new PaymentPackage('Consultation', 800),
    new PaymentPackage('Partnership Fee', 7000),
];
console.log(packages.join('\n'));


/*
// Should throw an error
try {
    const hrPack = new PaymentPackage('HR Services');
} catch(err) {
    console.log('Error: ' + err.message);
}
const packages = [
    new PaymentPackage('HR Services', 1500),
    new PaymentPackage('Consultation', 800),
    new PaymentPackage('Partnership Fee', 7000),
];
console.log(packages.join('\n'));

const wrongPack = new PaymentPackage('Transfer Fee', 100);
// Should throw an error
try {
    wrongPack.active = null;
} catch(err) {
    console.log('Error: ' + err.message);
}
*/

module.exports = PaymentPackage; 







