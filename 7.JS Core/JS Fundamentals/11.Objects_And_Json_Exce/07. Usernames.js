


function solve(args) {

    let names = new Set();

    args = args.sort((a,b) => a.length - b.length);

    for(let name of args.sort())
    {
        names.add(name);
    }

    [...names].sort((a,b) => a.length - b.length)
        .forEach(e => {
            console.log(e);
        });
}


solve(['Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']);




