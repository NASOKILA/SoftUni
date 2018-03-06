

try{

function makeCard(card, suit){

    //ako kartata ne e validna
    if(!CardIsValid(card))
        throw new Error('Error');
    

    //ako kartata ne e validna
    if(!SuitIsValid(suit))
        throw new Error('Error');
    
    //set Suit
    suit = setSuit(suit);


    let newCard = {
        card: card, 
        suit: suit, 
        toString: function(){
            return (this.card + this.suit).toString();  
        }
    };

    return newCard;

    function CardIsValid(card){
        
        let validCards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        
        if(validCards.some(c => c === card))
            return true;
        else 
            return false;
    
    }

    function SuitIsValid(suit){
        
        let validSuit = ['S', 'H', 'D', 'C'];
        
        if(validSuit.some(s => s === suit))
            return true;
        else 
            return false;
    
    }

    function setSuit(suit){

        if(suit === 'S'){
            suit = '\u2660';
        }
        else if(suit === 'H'){
            suit = '\u2665';
        }
        else if(suit === 'D'){
            suit = '\u2666';
        }
        else if(suit === 'C'){
            suit = '\u2663';
        }   

        return suit;
    }

} 



console.log('' + makeCard(1, 'S'));
//console.log('' + makeCard('A', 'S'));
//console.log('' + makeCard('10', 'H'));
//console.log('' + makeCard('1', 'C'));
}

catch(e){
    console.log(e.message);
}
