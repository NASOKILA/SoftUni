


function solve() {
    
    class Balloon {

        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = Number(gasWeight);
        }

    }

    class PartyBalloon extends Balloon {

        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbonColor = ribbonColor;
            this.ribbonLength = Number(ribbonLength);
            this.ribbon = { 'color': this.ribbonColor, 'length': this.ribbonLength }
        }

        get getRibbon() {
            return this.ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this.text = text;
        }

        get getText() {
            return this.text;
        }
    }

    return {Balloon, PartyBalloon, BirthdayBalloon};
}


let classes = solve();
let test = new classes.BirthdayBalloon("Tumno-bqlo", 20.5, "Svetlo-cherno", 10.25, "Happy Birthday!!!");

console.log(test.ribbonLength);

