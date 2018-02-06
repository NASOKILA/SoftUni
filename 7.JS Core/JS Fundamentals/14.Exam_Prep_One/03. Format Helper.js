
function solve(args) {

    let text = args[0];

    text = text.replace(/[.!?,:;]\s*/g, (match) => match.trim() + " ");


    let pattTwo = /[ ]+[.,;:!?]/g;
    matches = text.match(pattTwo);
    if(matches !== null) {
        for (let match of matches) {

            let newPiece = match[match.length - 1];
            text = text.replace(match, newPiece);
        }
    }

    let pattThree = /[,.?!;:]+[ ]+[,.?!;:]/g;
    matches = text.match(pattThree);
    if(matches !== null) {
        for (let match of moreMatches) {
            let index = text.indexOf(match);
            let newPiece = '';
            for (let p of match) {
                if (p !== ' ')
                    newPiece += p;
            }
            text = text.replace(/[,.?!;:]+[ ]+[,.?!;:]/g, newPiece);
        }
    }

    let pattFour = /[.][ ]+\d+/g;
    matches = text.match(pattFour);
    if(matches !== null) {
        for (let match of matches) {
            let index = text.indexOf(match);
            let newPiece = '';
            for (let p of match) {
                if (p !== ' ')
                    newPiece += p;
            }
            text = text.replace(match, newPiece);
        }
    }

    let pattFive = /["](\s*[^\"]+\s*)["]/g;
    text = text.replace(pattFive, (match, gr1) => `"${gr1.trim()}"`);

    console.log(text);
}

solve(['Terribly formatted text      .  With chaotic spacings." Terrible quoting   "! Also this date is pretty confusing : 20   .   12.  16 .']);
solve(['Make,sure to give:proper spacing where is needed... !']);






