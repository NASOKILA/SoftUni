

function getSortedList() {

    function add(element) {
        this.internalArr.push(element);
        this.internalArr = this.internalArr.sort((a, b) => a - b);
        this.size++;
        return this.internalArr;
    }

    function remove(index) {
        if(index >= 0 && index < this.internalArr.length) {
            this.internalArr.splice(index, 1);
            this.internalArr = this.internalArr.sort((a, b) => a - b);
            this.size--;
        }
    }

    function get(index) {
        if(index >= 0 && index < this.internalArr.length)
            return this.internalArr[index];

        return '';
    }

    return {
        internalArr: [],
        size: 0,
        add,
        remove,
        get,
    }
}

let arr = getSortedList();

console.log(arr.add(5));
console.log(arr.add(55));
console.log(arr.add(555));
console.log(arr.remove(32));
console.log(arr.get(1));
console.log(arr.get(11));
//console.log(arr.get(6));



