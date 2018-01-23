
function extractText() {
    let result = [];

    //vzimame texta ot litata
    $('#items li').each((index, element) => {
        "use strict";
        result.push(element.textContent);
    });

    //vzimame purviq div
    let div = $('#result')[0];
    div.textContent = result.join(', ');

}



