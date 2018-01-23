

let moduleToUse = (function () {

let Suits = {
    SPADES: '♠',
    HEARTS: '♥',
    DIAMONDS: '♦',
    CLUBS: '♣'
};

let Faces = ["2", "3", "4", "5", "6", "7",
        "8", "9", "10", "J", "Q", "K", "A"];

class Card {

//Mojem da pravim proverkite v konstruktura
    constructor(face, suit){

        let constainsIt = false;
        for(let i = 0; i < Faces.length; i++){
            if(Faces[i] == face)
                constainsIt = true;
        }

        if (constainsIt)
            this._face = face;
        else
            throw new Error('Invalid face');


        if (!Object.keys(Suits).map(k => Suits[k]).includes(suit))
            throw new Error('Invalid suit');

        this._suit = suit;
    }


    toString(){
        return this._face + this._suit;
    }

}

return {Suits, Card};

})()

/*
let c1 = new moduleToUse.Card("1", moduleToUse.Suits.CLUBS);
console.log(c1.toString());
*/

//c1.face = 4;
let c2 = new moduleToUse.Card("A", moduleToUse.Suits.SPADES);
console.log(c2.toString());


