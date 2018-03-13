





//(function() {

    class SorterList {

        constructor(){
            this.internalArr = [];
            this.size = 0;
        }

        add(element) {
            this.internalArr.push(element);
            this.internalArr = this.internalArr.sort((a, b) => a - b);
            this.size++;
        }

        remove(index) {
            if (index >= 0 && index < this.internalArr.length) {
                this.internalArr.splice(index, 1);
                this.internalArr = this.internalArr.sort((a, b) => a - b);
                this.size--;
            }
        }

        get(index) {
            if (index >= 0 && index < this.internalArr.length)
                return this.internalArr[index];

            return '';
        }
    }


    let list = new SorterList();
        list.add(5)
        list.add(55);
        list.add(555);
        list.add(55555);

        list.remove(2);
        console.log(list.get(0));




//})()






