
function solve(args) {

    let objArr = [];

    args.shift(); // mahame purviq red

    for(let row of args)
    {
        let obj = {};

        let rowArr = row.split(/[|]/).filter(e => e !== '');
        obj["Town"] = rowArr[0].trim();
        obj["Latitude"] = Number(rowArr[1]);
        obj["Longitude"] = Number(rowArr[2]);

        objArr.push(obj);
    }

    console.log(JSON.stringify(objArr));
}
/*
solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);
*/

solve(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']);







