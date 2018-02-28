


function wikiParser(selector) {


    //NEGATIVE LOOKAHEAD NE RABOTI ZA JUDGE

    let h3Regex = /===([^='\[]+?)===/g;
    let h2Regex = /==([^='\[]+?)==/g;
    let h1Regex = /=([^='\[]+?)=/g;

    let boldRegex = /'''([^'=\[]+?)'''/g;
    let italicRegex = /''([^'=\[]+?)''/g;


    let hyperLinkRegex = /\[\[([^\[\]]+?)\]\]/gm;
    let hyperLinkWithArgumentRegex = /\[\[([^'=\[\]]+?)\|([^'=\[\]]+?)]]/gm;

   /*
   function wikiParser(selector) {
    let text = $(selector).text();
    let formatted = text
        .replace(/===([^='\[]+?)===/g, (m, g) => `<h3>${g}</h3>`)
        .replace(/==([^='\[]+?)==/g, (m, g) => `<h2>${g}</h2>`)
        .replace(/=([^='\[]+?)=/g, (m, g) => `<h1>${g}</h1>`)
        .replace(/'''([^'=\[]+?)'''/g, (m, g) => `<b>${g}</b>`)
        .replace(/''([^'=\[]+?)''/g, (m, g) => `<i>${g}</i>`)
        .replace(/\[\[([^'=\[\]]+?)\|([^'=\[\]]+?)]]/g, (m, g1, g2) => `<a href="/wiki/${g1}">${g2}</a>`)
        .replace(/\[\[([^'=\[\]]+?)]]/g, (m, g) => `<a href="/wiki/${g}">${g}</a>`);

    $(selector).html(formatted);
    }
    */ 

    let text = $(selector).text();


text = text
.replace(h3Regex, (m, group) => `<h3>${group}</h3>`)
.replace(h2Regex, (m, group) => `<h2>${group}</h2>`)
.replace(h1Regex, (m, group) => `<h1>${group}</h1>`)
.replace(boldRegex, (m, g) => `<b>${g}</b>`)
.replace(italicRegex, (m, g) => `<i>${g}</i>`)
.replace(hyperLinkWithArgumentRegex, (m, group1, group2) => `<a href="/wiki/${group1}">${group2}</a>`)
.replace(hyperLinkRegex, (m, group) => `<a href="/wiki/${group}">${group}</a>`);

    $(selector).html(text);
}

