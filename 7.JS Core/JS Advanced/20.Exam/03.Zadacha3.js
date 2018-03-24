

/*
Zadacha 3:
Za da ima chaining za dadena funkciq 
trqbva da vruthame samiq klas toest 'this'.
*/

class PaymentProcessor {
    
    constructor(options)
    {

        this.options = this.setOptions(options);
        this.payments = [];
    }
    
    
    registerPayment(id, name, type, value)
    {
        //VALIDATE INPUT PARAMETERS
        let idType = typeof id;
        let nameType = typeof name;
        let typeType = typeof type;
        let valueType = typeof value;
        
        if(nameType !== 'string' || name === '')
        {
            throw Error('invalid name');
        }
        
        if(idType !== 'string' || id === '')
        {
            throw Error('invalid type');
        }
    
        if(valueType !== 'number')
        {
            throw Error();
        }

        if(!(this.types.includes(type)))
        {
            throw Error('invalid type');
        }
    
        if(this.payments.some(p => p.id === id))
        {
            throw Error();

        }

        
        value = value.toFixed(this.precision); 
        let paymentObj = {id, name, type, value};
        this.payments.push(paymentObj);
    }

    deletePayment(id){

        let objToRemove = this.payments.find(p => p.id === id);

        if(objToRemove === null || objToRemove === undefined )
        {
            throw Error();
        }

        let index = this.payments.indexOf(objToRemove);
    
        this.payments.splice(index,1);

    }

    get(id)
    {
        let payment = this.payments.find(p => p.id === id);

        if(payment === null || payment === undefined)
        {
            throw Error('ID not found');
        }

        let result = `Details about payment ID: ${payment.id}\n`+
        `- Name: ${payment.name}\n`+
        `- Type: ${payment.type}\n`+
        `- Value: ${payment.value}`;
        
        return result;
    }

    setOptions(options)
    {
        
            //default values
            this.types = ["service", "product", "other"];
            this.precision = 2;
        
        if(options !== undefined)
        {
            if(options.hasOwnProperty('types'))
            {
                this.types = options.types;
            }

            if(options.hasOwnProperty('precision'))
            {
                this.precision = options.precision;
            }
            
        }
    }
    
    toString()
    {

        let paymentsCount = this.payments.length;
        let balance = 0;
        
        this.payments.forEach(p => {
            let currentValue = Number(p.value);
            balance += currentValue;
        });
        
        let result = 'Summary:\n'+
        `- Payments: ${paymentsCount}\n`+
        `- Balance: ${balance.toFixed(this.precision)}`;
         

        return result;
    }

}

let options = {
    types: ["service", "product", "other"],
    precision: 3
  }
  
const generalPayments = new PaymentProcessor();
generalPayments.registerPayment('0001', 'Microchips', 'product', 15000);
generalPayments.registerPayment('01A3', 'Biopolymer', 'product', 23000);
console.log(generalPayments.toString());

//generalPayments.registerPayment('E028', 'Rare-earth elements', 'materials', 8000);


generalPayments.setOptions({types: ['product', 'material']});
generalPayments.registerPayment('E028', 'Rare-earth elements', 'material', 8000);
console.log(generalPayments.get('E028'));


generalPayments.registerPayment('CF15', 'Enzymes', 'material', 55000);


//generalPayments.deletePayment('E027');
//generalPayments.get('E027');


generalPayments.deletePayment('E028');
console.log(generalPayments.toString());


// Initialize processor with custom types
const servicePyaments = new PaymentProcessor({types: ['service']});
servicePyaments.registerPayment('01', 'HR Consultation', 'service', 3000);
servicePyaments.registerPayment('02', 'Discount', 'service', -1500);
console.log(servicePyaments.toString());

// Initialize processor with custom precision
const transactionLog = new PaymentProcessor({precision: 5});
transactionLog.registerPayment('b5af2d02-327e-4cbf', 'Interest', 'other', 0.00153);
console.log(transactionLog.toString());



/*let pp = new PaymentProcessor(options);
pp.registerPayment('1',"Asi",'other',1.2567);
pp.registerPayment('1',"Nasko",'other',1);
pp.deletePayment(2);

*/
