
function s(args) {

    let n = args[0];
    let precision = args[1];

    if(precision > 15) {
        precision = 15;
    }

    let result = n.toFixed(precision);

    if(result.length > n.toString().length)
        result = n;

    console.log(result);
}

s([3.1415926535897932384626433832795, 2]);
s([10.5, 3]);










