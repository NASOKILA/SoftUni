

function ChessBoard(n) {

    let div = `<div class="chessboard">\n`;

    for(let i = 1; i <= n; i++)
    {
        div += `    <div>\n`;
        for(let j = 1; j <= n; j++)
        {
            let color = "black";

            if(j % 2 === 0)
                color = "white";


            if(i % 2 === 0)
            {
                if(j % 2 === 0)
                    color = "black";
                else
                    color = "white";
            }
            div += `        <span class="${color}"></span>\n`;
        }
        div += `    </div>\n`;
    }
    div += `</div>\n`;
    console.log(div);
}

ChessBoard(3);









