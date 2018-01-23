
function solve (args) {

    let result = '<?xml version="1.0" encoding="UTF-8"?>\n';
    result += '<quiz>\n';
    for(let i = 0; i <= args.length-1; i=i+2)
    {
        let question = args[i];
        let answer = args[i+1];

        printXml(question, answer);
    }
    function printXml(question, answer) {
        result += '  <question>\n';
        result += `    ${question}\n`;
        result += '  </question>\n';
        result += '  <answer>\n';
        result += `    ${answer}\n`;
        result += '  </answer>\n';

    }

    result += '</quiz>\n';
    console.log(result);
}

solve(
    ["Dry ice is a frozen form of which gas?",
    "Carbon Dioxide",
    "What is the brightest star in the night sky?",
    "Sirius"]
);






