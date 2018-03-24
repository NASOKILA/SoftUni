

class MailBox
{
    constructor()
    {
        this.mailBox = []; 
    }

    get messageCount()
    {
        return this.mailBox.length;
    }

    addMessage(subject, text)
    {
        let obj = {};
        obj[subject] = text;
        this.mailBox.push(obj);

        //returns the mailBox itself to allow chaining
        return this;
    }

    deleteAllMessages()
    {
        this.mailBox = [];
    }

    findBySubject(substr)
    {
        //posle probvai s foreach
        let validMessages = [];
        
        //validMessages = this.mailBox.filter(m => Object.keys(m)[0].includes(substr));
        
        this.mailBox.forEach(m => {

            let key = Object.keys(m)[0];

            let obj = {};
            obj['subject'] = key;
            obj['text'] = m[key];

            if(key.includes(substr))
                validMessages.push(obj);
        });
        
        return validMessages;
    }


    toString(){

        let result = '';

        if(this.mailBox.length === 0)
            result = '* (empty mailbox)';
        else
        {
            this.mailBox.forEach((mail) => {
                
                
                let key = Object.keys(mail)[0];
                let value = mail[key];
                result += `* [${key}] ${value}\n`;
            })
        }
        return result;
    }

}

let mb = new MailBox();

mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");

let msgs = mb.findBySubject('ee');
console.log(msgs[0].subject) //meeting



/*
let mb = new MailBox();
mb.AddMessage('NASKO', 'The best PROGRAMMER ever');
mb.AddMessage('SPASKO', 'The best BOXER ever');
mb.AddMessage('VASKO', 'NOT The best ever');
mb.AddMessage('GOSHKATA', 'HAHAHA');
console.log(mb.messageCount);



let messagesEndingWithSKO = mb.findBySubject("SKO");
console.log(messagesEndingWithSKO);


//mb.deleteAllMessages();
//console.log(mb.messageCount);

console.log('' + mb);

*/

/*
let mb = new MailBox();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);
console.log("Messages holding 'rakiya': " +
    JSON.stringify(mb.findBySubject('rakiya')));
console.log("Messages holding 'ee': " +
    JSON.stringify(mb.findBySubject('ee')));

mb.deleteAllMessages();
console.log("Msg count: " + mb.messageCount);
console.log('Messages:\n' + mb);

console.log("New mailbox:\n" +
    new MailBox()
        .addMessage("Subj 1", "Msg 1")
        .addMessage("Subj 2", "Msg 2")
        .addMessage("Subj 3", "Msg 3")
        .toString());



*/