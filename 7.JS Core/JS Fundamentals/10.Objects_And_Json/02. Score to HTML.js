
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
solve('[{"name":"<div>a && \'b\'</div>","score":111},{"name":"Jichka Jochkova","score":-50}]');
