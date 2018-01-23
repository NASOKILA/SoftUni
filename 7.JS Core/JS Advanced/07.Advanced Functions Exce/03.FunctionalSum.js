
(function () {

    let sum = 0;

    return function add(num) {

        sum += num;
        //prezapisvame add da vrushta sumata.
        add.toString = function () {
            return sum;
        };

        //i vrushtame add.
        return add;
    }
})()
console.log(add(1)(6)(-3).toString());
