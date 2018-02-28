
function currencyFormatter(separator, symbol, symbolFirst, value) {

    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    
    if (symbolFirst) 
        return symbol + ' ' + result;
    else 
        return result + ' ' + symbol;
}


//TOVA E HIGHER ORDER FUNCTION
//suzdavame si funkciq koqto priema druga funkciq
function result (func){

    //funkciqta vrushta funkciq koqto priema edin parametur
    return function(num){

        //tq izvikva func koqto e funkciqta podadena na result sus dadenite parametri I VKLUCHITELNO SOBSTVENIQ PARAMETUR
        return func(',', '$', true, num);
    }
}

//prisvoqvame funkciqta result v promenliva 
let dollarFormatter = result(currencyFormatter);

//sega dollarFormatter stava vurnatata funkciq koqto priema chislo
console.log(dollarFormatter(5345));   // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709));  


//MOJE DA SE IZVIKA I TAKA:
console.log();
console.log(result(currencyFormatter)(5345));
console.log(result(currencyFormatter)(3.1429));
console.log(result(currencyFormatter)(2.709));


