

function solve(args) {

    for(let elem of args)
    {
        let regex = /\b\d{1,2}-[A-Z][a-z]{2}-\d{4}\b/g;
        let result = elem.match(regex);

        if(result !== null)
        {
            let dateCopy = result[0];
            let year = dateCopy.split("").reverse().join("").substr(0, 4).split("").reverse().join("");
            let thisYear = new Date().getFullYear();
            if(year <= thisYear)
            {

                let index = dateCopy.indexOf('-');
                let resultToPrint = result[0] + ` (Day: ${dateCopy.substr(0,index)}, Month: ${dateCopy.substr(index+1, 3)}, Year: ${year})`;
                console.log(resultToPrint);
            }

        }

    }

}
/*
solve(['1-Jan-1999 is a valid date.',
      'So is 01-July-2000.',
      'I am an awful liar, by the way – Ivo, 28-Sep-2016.']);
*/

solve(['I dont know what to test anymore so here are some random dates.',
    '15-May-1996',
    '21-June-1995',
    '31-February-3000',
    'woops that was invalid...',
    '111-Nov-2332',
    '01-January-0001',
    'What the fuck',
    '11-Sep-2001',
    'One minute of silence!']);









