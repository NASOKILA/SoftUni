
function formatCurrency (separator, symbol, symbolFirst, value) {

    //razdelqme valutata sus separatora
    let result = Math.trunc(value) + separator;

    //dobavqme kum resultata zakruglenoto value
    // i vzimame ot vtoriq do preposledniq znak
    result += value.toFixed(2).substr(-2,2);

    //proverqvame dali sinvola e na purvo mqsto
    //t.e. dali e true ili false
    if(symbolFirst) {
        return symbol + ' ' + result;
    }
    else {
        return result + ' ' + symbol;
    }
}

function getDollarFormatter(formatter) {

    //Vrushtame funkciq koqto formatira value-to
    //NAMALQVAME BROQ NA PARAMETRITE
    return function (value)
    {
        return formatter(',', '$', true, value);
    }
}

function getEuroFormatter(formatter) {

    //Vrushtame funkciq koqto formatira value-to
    //NAMALQVAME BROQ NA PARAMETRITE
    return function (value)
    {
        return formatter(',', '€', true, value);
    }
}

let dollars = getDollarFormatter(formatCurrency);
let euros = getEuroFormatter(formatCurrency);

console.log(dollars(5434));
console.log(euros(3.14654743));


console.log(formatCurrency(',', 'lv', false, 1.60));






