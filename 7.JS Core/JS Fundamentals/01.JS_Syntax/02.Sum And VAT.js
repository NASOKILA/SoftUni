
function SumAndVAT(args) {

    let sum = 0;
    for(a in args)
        sum += parseFloat(args[a]);

    let vat = sum / 5.0;
    let total = sum + vat;

    // .toFixed() gi prevrushta v string do
    // podadenite znachi sled desetichnata zapetaq
    // Loshoto na tova e che stava na string
    console.log(sum.toFixed(2));
    console.log(vat.toFixed(2));
    console.log(total.toFixed(2));
}

let input = ['3.12', '5', '18', '19.24', '1953.2262', '0.001564', '1.1445'];
let input2 = ['1.20', '2.60', '3.50'];

SumAndVAT(input);





