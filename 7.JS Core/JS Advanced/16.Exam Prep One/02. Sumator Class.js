





class Sumator {

    constructor() {
      this.data = []; //ima data koqto e prazan masiv
    }

    //funkciq za dobavqne v .data poemashta parametur
    add(item) {
      this.data.push(item);
    }

    //vadi obshtata suma ot .data AKO E CHISLO
    sumNums() {
        let sum = 0;
        for (let item of this.data){
            if (typeof (item) === 'number'){
                sum += item;
            }
        }
      return sum;
    }

    //premahva elementi po podadena funkciq
    removeByFilter(filterFunc) {
      this.data = this.data.filter(x => !filterFunc(x));
    }

    //printira vsichki elementi s join osven ako .data ne e prazen
    toString() {
      if (this.data.length > 0)
        return this.data.join(", ");
      else
        return '(empty)';
    }
  }
  
module.exports = Sumator;




