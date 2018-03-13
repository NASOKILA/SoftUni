

class Textbox {

    constructor(selector, regexForInvalidSymbols){

        this.selector = selector;
        this._invalidSymbols = regexForInvalidSymbols;
        this._elements = $(this.selector); // vzimame vsichki elementi
       
        $(this._elements).on('input', (e) => { 
            this._value = $(e.target).val();
            this.updateElements();
        })
    }

    updateElements() {
        for (let element of this._elements) {
            $(element).val(this._value);
        }
    }

    get value()
    {
        return this._value;
    }
    set value(newValue)
    {
        this._value = newValue;
        this.updateElements();
    }

    get elements(){
        return this._elements;
    }

    //tuk proverqvame dali regexa matchva _value
    isValid(){

        //vrushtame true ili false
        //ako rezultata e true nie vrushtame false i ako resultata e false nie vrushtame true.
        return !this._invalidSymbols.test(this._value); 
    }

}





let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = $('.textbox');

inputs.on('input',function(){console.log(textbox.value);});


