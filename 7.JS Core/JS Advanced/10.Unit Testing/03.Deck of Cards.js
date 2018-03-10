

function printDeckOfCards(cards) {


    try {

        let result = [];

        // TODO process input
        for (const tokens of cards) {

            let card = tokens.slice(0, tokens.length - 1);
            let suit = tokens[tokens.length - 1];

            let currentCard = makeCard(card, suit);
            result.push(currentCard.toString());
        }


        console.log(result.join(' '));

    }
    catch (ex) {
        console.log(ex.message);
    }


    function makeCard(card, suit) {

        //ako kartata ne e validna
        if (!CardIsValid(card))
            throw new Error(`Invalid card: ${card + suit}`);


        //ako kartata ne e validna
        if (!SuitIsValid(suit))
            throw new Error(`Invalid card: ${card + suit}`);

        //set Suit
        suit = setSuit(suit);


        let newCard = {
            card: card,
            suit: suit,
            toString: function () {
                return (this.card + this.suit).toString();
            }
        };

        return newCard;

        function CardIsValid(card) {

            let validCards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

            if (validCards.some(c => c === card))
                return true;
            else
                return false;

        }

        function SuitIsValid(suit) {

            let validSuit = ['S', 'H', 'D', 'C'];

            if (validSuit.some(s => s === suit))
                return true;
            else
                return false;

        }

        function setSuit(suit) {

            if (suit === 'S') {
                suit = '\u2660';
            }
            else if (suit === 'H') {
                suit = '\u2665';
            }
            else if (suit === 'D') {
                suit = '\u2666';
            }
            else if (suit === 'C') {
                suit = '\u2663';
            }

            return suit;
        }

    }

}

printDeckOfCards(['5S', '3D', 'QD', '1C']);
printDeckOfCards(['AS', '10D', 'KH', '2C']);





