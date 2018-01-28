
function solve(text) {
    let ul = '<ul>\n';
    for(let sentence of text)
    {
        let replace = sentence
            .replace(/\&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/\"/g, '&quot;');

        let li = `<li>${replace}</li>`;
        ul += `  ` + li + `\n`;
    }
    ul += '</ul>';

    console.log(ul);
}

solve(['<div style=\"color: red;\">Hello, Red!</div>', '<table><tr><td>Cell 1</td><td>Cell 2</td><tr>']);
solve(['<b>unescaped text</b>', 'normal text']);




