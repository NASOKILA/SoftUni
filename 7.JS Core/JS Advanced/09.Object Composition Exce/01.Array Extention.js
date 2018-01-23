

(function () {

    Array.prototype.last = function () {

        //vrushtame posledniq element.
        return this[this.length-1];
    };

    Array.prototype.skip = function (n) {

        //vrushtame posledniq element.
        return this.slice(n);
    };

    Array.prototype.take = function (n) {

        //vrushtame posledniq element.
        return this.slice(0,n);
    };

    Array.prototype.sum = function () {

        //vrushtame posledniq element.
        return this.reduce((a, b) => a + b, 0);
    };

    Array.prototype.average = function () {

        let sum = this.reduce((a, b) => a + b, 0);
        //vrushtame posledniq element.
        return sum/this.length;
    };

}())


let arr = [1,2,3,5];
console.log(arr.skip(2));
console.log(arr.take(2));
console.log(arr.sum());
console.log(arr.average());