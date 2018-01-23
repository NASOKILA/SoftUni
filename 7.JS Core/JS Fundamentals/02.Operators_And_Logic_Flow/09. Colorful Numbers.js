
function Generator(n) {

    let ul = `<ul>`;

    for (let i = 1; i <= n; i++) {

        let color;
        if (i % 2 === 1)
            color = "green";
        else
            color = "blue";

        ul += `<li><span style="color:${color}">${i}</span></li>\n`;
    }
    ul += '</ul>';
    console.log(ul);
}

Generator(10);


