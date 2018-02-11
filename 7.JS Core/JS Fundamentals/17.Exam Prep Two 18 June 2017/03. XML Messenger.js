
function solve(message) {

    let patt = /<message (([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*|([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*|([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*|([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*([a-z]{1,})=\"([a-zA-Z0-9\s\.]{1,})\"\s*)>((?:.|\n)+)<\/message>$/gm
    let regex = new RegExp(patt);
    let match = regex.exec(message);
    
    if (match) {

        //check if sender and recever exist
        let senderExists = match.some(g => g === 'to');
        let receverExists = match.some(g => g === 'from');

        if (!senderExists || !receverExists) {
            console.log('Missing attributes');
            return;
        }

        //get recever and sender
        let sender = '';
        let recever = '';

        let indexofTO = match.indexOf('to');
        let indexofFROM = match.indexOf('from');
        
        recever = match[indexofTO+1].toString();
        sender = match[indexofFROM+1].toString();
        

        //form the message:
        let article = '<article>\n';
        article += '  <div>From: <span class="sender">'+ sender +'</span></div>\n';
        article += '  <div>To: <span class="recipient">'+ recever +'</span></div>\n';
        article += '  <div>\n';

        //check if the message has newLine in it and spit it if it does
        let mess = match[match.length-1].toString();
        message = mess.split('\n'); 

        for (const piece of message) {
            article += '    <p>'+ piece +'</p>\n';
        }
        
        article += '  </div>\n';
        article += '</article>';
        
    console.log(article);

    }
    else {
        console.log('Invalid message format');
        return;
    }

}



solve('<message to="Bob" from="Alice" timestamp="1497254114">Same old, \nsame old\nLet\'s go out for a beer</message>');

