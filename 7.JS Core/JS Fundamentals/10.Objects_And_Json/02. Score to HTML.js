
function solve(str) {

    let objArr = JSON.parse(str);

    let result = '<table>\n';
    result += `  <tr>`;
    let properties = Object.keys(objArr[0]);

    //zakachame propertitata
    for(let p of properties)
        result += `<th>${p}</th>`;

    result += `</tr>\n`;


    //zakachame stoinsotite
    for(let obj of objArr)
    {
        let name = obj["name"];
        name = checkCharacters(name);

        let score = obj["score"];

        result += `  <tr>`;
        result += `<td>${name}</td>`;
        result += `<td>${score}</td>`;
        result += `</tr>\n`;
    }

    result += `</table>`;
    console.log(result);

    function checkCharacters(name) {

        if(name.indexOf('&') > -1) // ako indexa e > -1 znachi sushtestvuva
            name = name.replace(/[&]+?/g, '&amp;');

        if(name.indexOf('<') > -1)
            name = name.replace(/[<]+?/g, '&lt;');

        if(name.indexOf('>') > -1)
            name = name.replace(/[>]+?/g, '&gt;');

        if(name.indexOf('"') > -1)
            name = name.replace(/["]+?/g, '&quot;');

        if(name.indexOf('\'') > -1)
            name = name.replace(/[']+?/g, '&#39;');

        return name;
    }
}

//solve('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');
//solve('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');
//solve('[{"name":"Pencho Penchev","score":0},{"name":"<script>alert(\"Wrong!\")</script>","score":1}]');
//solve('[{"name":"<div>a && \'b\'</div>","score":111},{"name":"Jichka Jochkova","score":-50}]');




function s(input) {

    let objects = JSON.parse(input);

    let table = '<table>\n';
    let keys = Object.keys(objects[0]);

    table += `  <tr><th>${escapeSimbols(keys[0])}</th><th>${escapeSimbols(keys[1])}</th></tr>\n`;

    for (let obj of objects)
        table += `  <tr><td>${escapeSimbols(obj[keys[0]].toString())}</td><td>${escapeSimbols(obj[keys[1]] + '')}</td></tr>\n`;

    table += '</table>';

    function escapeSimbols(arr) {
        return arr.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;')
    }

    console.log(table);
}

s('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');
s('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');
//s('[{"name":"Pencho Penchev","score":0},{"name":"<script>alert(\"Wrong!\")</script>","score":1}]');



