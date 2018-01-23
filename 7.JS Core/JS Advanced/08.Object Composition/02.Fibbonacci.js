
function fibonacci() {

    let prevNum = 0;
    let nextNum = 1;
    let fibNum = 0;
    let firstTime = true;
    return function () {

        if(firstTime){
            firstTime = false;
            return 1;
        }

        fibNum = nextNum + prevNum;
        prevNum = nextNum;
        nextNum = fibNum;
        return (fibNum);
    }
}
let fib = fibonacci();

console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());












