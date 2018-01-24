
function tribonacci(n, k) {

let arr = [];

arr[0] = 1;
    for (let indexInSeq = 1; indexInSeq < n; indexInSeq++) {
        let result = 0;
        for (let prevIndexOfSeq = indexInSeq - 1; prevIndexOfSeq >= 0 && prevIndexOfSeq >= indexInSeq - k; prevIndexOfSeq--)
            result += arr[prevIndexOfSeq];

        arr[indexInSeq] = result;
    }
    console.log(arr.join(" "));
}


tribonacci('6', '3');
tribonacci('8', '2');
//or something more complex, for example:

console.log();


function lastKElements(n, k) {

    let result = [1];
    for(let i = 1; i < n; i++){

        let sum = 0;

        //Ako result.length - k > 0 shte go vzeme samo togava i shte slicenem masiva
        // s tova chislo !!!
        let indexToSlice = Math.max(0,result.length - k);

        result.slice(indexToSlice)
            .map(e => sum += e);

        result.push(sum);
    }

    console.log(result.join(' '));
}
lastKElements(6, 3);
lastKElements(8, 2);



