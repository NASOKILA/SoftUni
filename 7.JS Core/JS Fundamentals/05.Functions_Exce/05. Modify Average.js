
function s(n) {

    let numberStr = n.toString();
    let sum = (SumDigits(numberStr));

    while(sum / numberStr.length <= 5){
        numberStr += '9';
        sum = SumDigits(numberStr);
    }

    function SumDigits(n) {
        let sum = 0;
        for(let digit of n) {
            sum +=  Number(digit);
        }

        return sum;
    }

    console.log(numberStr);
}

s(101);
s(5835);
