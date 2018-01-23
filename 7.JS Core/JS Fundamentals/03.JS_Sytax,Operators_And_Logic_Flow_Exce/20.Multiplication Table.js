
function solve(n) {

    let result = '<table border = "1">\n';

    result += "<tr><th>x</th>";
    for(let i = 1; i <= n; i++)
    {
        result += `<th>${i}</th>`
    }
    result += `</tr>` + "\n";

    for(let i = 1; i <= n; i++)
    {
        result += `<tr><th>${i}</th>`;
        for(let ii = 1; ii <= n; ii++)
        {
            result += `<td>${ii * i}</td>`;
        }
        result += `</tr>` + "\n";
    }

    result += "</table>";

    console.log(result);
}

solve(5);















