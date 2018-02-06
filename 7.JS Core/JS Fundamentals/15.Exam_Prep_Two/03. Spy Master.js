

function solve(args) {

    let specialKey = args[0];

    let patt = `(\\s|^)(${specialKey})\\s+([!%$#A-Z]{8,})(\\.|,|\\s|$)`;

    let rgx = new RegExp(patt,'gmi'); //podavame mu flagovete
    for(let i = 1; i <= args.length-1; i++)
    {
        let text = args[i];
        let match = text.match(rgx);

        if(match)
        {
            for(let m of match) {

                let resultArr = m.toString().trim();
                let result = resultArr.split(/\s+/g)[1];
                let res = result;

                //proverqvame dali matchva samo malki ili samo golqmi bukvi
                if(result.toUpperCase() !== result)
                    continue;

                result = result.replace(/!/g,'1');
                result = result.replace(/%/g,'2');
                result = result.replace(/#/g,'3');
                result = result.replace(/\$/g,'4');

                let newResult = '';
                for(let l of result)
                {
                    if(isNaN(l) !== -1)
                    {
                        if(l === l.toUpperCase())
                        l = l.toLowerCase();
                        else
                            l = l.toUpperCase();
                    }
                    newResult += l;

                }
                text = text.replace(res, newResult);
            }
        }
         console.log(text);

    }
}


solve(['specialKey',
    'In this text the specialKey HELLOWORLD! is correct, but',
    'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
    'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!']);

console.log();
solve(['enCode',
    'Some messages are just not encoded what can you do?',
    'RE - ENCODE THEMNOW! - he said.',
    'Damn encode, ITSALLHETHINKSABOUT, eNcoDe BULL$#!%.']);



