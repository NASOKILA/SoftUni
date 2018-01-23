
function tribonacci(n, k) {

let arr = [];

arr[0] = 1;

    for (let indexInSeq = 1; indexInSeq < n; indexInSeq++)
    {
        let result = 0;
        for (let prevIndexOfSeq = indexInSeq - 1; prevIndexOfSeq >= 0 && prevIndexOfSeq >= indexInSeq - k; prevIndexOfSeq--)
        {
            result = result + arr[prevIndexOfSeq];
        }
        arr[indexInSeq].push(result);
    }

    console.log(arr.join(" "));

}


console.log(tribonacci('8', '1'));
//or something more complex, for example:







