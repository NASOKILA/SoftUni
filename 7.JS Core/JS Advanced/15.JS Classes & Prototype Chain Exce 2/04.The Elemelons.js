
function solve() {

    class Melon {
        constructor(weight, melonSort) {

            if (new.target === Melon)
                throw new Error('Abstract class cannot be instantiated directly');

            this.weight = Number(weight);
            this.melonSort = melonSort;
        }
    }


    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.elementIndex = this.weight * this.melonSort.length;
        }

        get getElementIndex() {
            return this.elementIndex;
        }

        toString() {
            let name = this.constructor.name;
            name = name.substring(0, name.length - 5);
            return `Element: ${name}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }

    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.elementIndex = this.weight * this.melonSort.length;
        }

        get getElementIndex() {
            return this.elementIndex;
        }


        toString() {
            let name = this.constructor.name;
            name = name.substring(0, name.length - 5);
            return `Element: ${name}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.elementIndex = this.weight * this.melonSort.length;
        }

        get getElementIndex() {
            return this.elementIndex;
        }


        toString() {
            let name = this.constructor.name;
            name = name.substring(0, name.length - 5);
            return `Element: ${name}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.elementIndex = this.weight * this.melonSort.length;
        }

        get getElementIndex() {
            return this.elementIndex;
        }

        toString() {
            let name = this.constructor.name;
            name = name.substring(0, name.length - 5);
            return `Element: ${name}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Melolemonmelon extends Watermelon
    {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.allElements = ['Fire', 'Earth', 'Air', 'Water'];
            this.currentElement = 'Water';
        }

        morph(){
            
            this.currentElement = this.allElements.shift();
            this.allElements.push(this.currentElement);
        }

        toString() {
            
            return `Element: ${this.currentElement}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }

    }


    return { Melon, Watermelon, Firemelon, Earthmelon, Airmelon, Melolemonmelon };
}


let result = solve();
let classes = solve();

let test = new classes.Melolemonmelon(150, "Melo");
test.morph();
test.morph();
console.log(test.toString());

/*
let melolemonmelon = new result.Melolemonmelon(20, 'Melolemonsize');
console.log(melolemonmelon.toString());

//let test = new result.Melon(100, "Test");      //Throws error

let watermelon = new result.Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());

// Element: Water
// Sort: Kingsize
// Element Index: 100

console.log();

let firemelon = new result.Firemelon(2.5, "Dogsize");
console.log(firemelon.toString());

console.log();

let earthmelon = new result.Earthmelon(10, "Mansize");
console.log(earthmelon.toString());

console.log();

let airmelon = new result.Airmelon(20, "Catsize");
console.log(airmelon.toString());

*/