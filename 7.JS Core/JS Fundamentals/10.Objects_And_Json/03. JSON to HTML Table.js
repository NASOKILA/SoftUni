

    function solve(str) {

        let obj = JSON.parse(str);
        let keys = Object.keys(obj[0]);
        let result = '<table>\n';
        result += `  <tr>`;

        for(let key of keys) {
            key = checkCharacters(key);
            result += `<th>${key}</th>`;
        }
        result += `</tr>\n`;

        //slagame stoinostite
        for(let j = 1; j <= obj.length; j++)
        {
            result += `  <tr>`;
            for(let k = 0; k <= keys.length-1; k++)
            {
                let value = obj[j-1][keys[k]];
                value = checkCharacters(value);

                result += `<td>${value}</td>`;
            }

            result += `</tr>\n`;
        }


        result += `</table>`;
        console.log(result);

        function checkCharacters(name) {

            if(isNaN(name) === false)
                return name;

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

//solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');
//solve('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');




function s(input) {

    let objects = JSON.parse(input);

    let table = '<table>\n';
    let keys = Object.keys(objects[0]);

    table += `  <tr>`;
    for (let key of keys) {
        table += `<th>${escapeSimbols(key)}</th>`;
    }
    table += '</tr>\n';


    for (let obj of objects)
    {
        table += `  <tr>`;
        for (let key of keys) {

            table += `<td>${escapeSimbols(obj[escapeSimbols(key.toString())].toString())}</td>`;
        }
        table += `</tr>\n`;
    }
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

s('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');
//s('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');









