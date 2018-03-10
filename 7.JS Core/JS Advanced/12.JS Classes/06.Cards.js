

let result = (function () {

let Suits = {
    SPADES: '♠',
    HEARTS: '♥',
    DIAMONDS: '♦',
    CLUBS: '♣'
};

let SuitsValues = ['♣', '♦', '♥', '♠'];


let Faces = ["2", "3", "4", "5", "6", "7",
        "8", "9", "10", "J", "Q", "K", "A"];
    
class Card {

    //NE E DOBRA PRAKTIKA da pravim proverkite v konstruktura
    //PO DOBRE DA IMAME GETTERI I SETTERI
    constructor(face, suit){

        this.face = face;
        this.suit = suit;
    }

    get face(){
        return this._face;
    }
    set face(newFace){

        if(!Faces.includes(newFace))
            throw new Error('Invalid Face');
            
        this._face = newFace;
    }
    
    get suit(){
        return this._suit;
    }
    set suit(newSuit){


        if(!SuitsValues.includes(newSuit))
            throw new Error('Invalid Suit');
        
        this._suit = newSuit;
    }


    toString(){
        return this.face + this.suit;
    }

}


//IIFE funkciqta vrushta obekt sus cartata i boqta
    return {
        Suits: Suits, 
        Card: Card
    };

})()

//vzimame si klasa Card i obekta Suits v otdelni promenlivi
let Card = result.Card;
let Suits = result.Suits;

//suzdavame nova karta
let card = new Card("Q", Suits.CLUBS);

//Promenqme liceto i cveta na kartata 
card.face = "A";
card.suit = result.Suits.DIAMONDS;

console.log(card.toString());

/*
let c1 = new moduleToUse.Card("1", moduleToUse.Suits.CLUBS);
console.log(c1.toString());


//c1.face = 4;
let c2 = new moduleToUse.Card("A", result.Suits.SPADES);
console.log(c2.toString());

*/
