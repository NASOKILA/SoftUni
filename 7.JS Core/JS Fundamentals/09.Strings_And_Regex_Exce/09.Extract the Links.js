
function solve(args) {

    let regex = /www\.([a-zA-Z0-9\-]+)(\.[a-z]+)+/gm;

    for(let elem of args)
    {
        for(let word of elem.split(/[\s,\?\!\;\:\_]+/g))
        {
            let match = word.match(regex);

            if(match)
                console.log(match[0]);

        }
    }
}

/*
solve(['Join WebStars now for free, at www.web-stars.com',
    'You can also support our partners:',
    'Internet - www.internet.com',
    'WebSpiders - www.webspiders101.com',
    'Sentinel - www.sentinel.-ko']);

 solve(['Need information about cheap hotels in London?',
 'You can check us at www.london-hotels.co.uk!',
 'We provide the best services in London.',
 'Here are some reviews in some blogs:',
 'London Hotels are awesome!" - www.indigo.bloggers.com',
 'I am very satisfied with their services" - ww.ivan.bg',
 'Best Hotel Services!" - www.rebel21.sedecrem.moc']);

*/


    function extractEmails(arrayOfStrings) {

        let patt = /(www\.)([a-zA-Z0-9\-]+)(\.[a-z]+)+/g;
        let emails = [];
        for(let row of arrayOfStrings)
        {
            //I TAKA STAVA BEZ DAJE DA SME DEKLARIRALI match PROMENLIVA !!!
            while(match = patt.exec(row))
            {
                emails.push(match[0]);
            }
        }
        emails.forEach(e => console.log(e));
    }


extractEmails(['Join WebStars now for free, at www.web-stars.com',
    'You can also support our partners:',
    'Internet - www.internet.com',
    'WebSpiders - www.webspiders101.com',
    'Sentinel - www.sentinel.-ko']);

extractEmails(['Need information about cheap hotels in London?',
    'You can check us at www.london-hotels.co.uk!',
    'We provide the best services in London.',
    'Here are some reviews in some blogs:',
    'London Hotels are awesome!" - www.indigo.bloggers.com',
    'I am very satisfied with their services" - ww.ivan.bg',
    'Best Hotel Services!" - www.rebel21.sedecrem.moc']);




