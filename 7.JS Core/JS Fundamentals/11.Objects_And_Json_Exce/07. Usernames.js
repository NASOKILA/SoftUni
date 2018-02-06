


function solve(args) {

    let names = new Set();

    
    for(let name of args)
        names.add(name);
    

    [...names].sort((a,b) => {
        
        if(a.length == b.length)
            return a.localeCompare(b);
        else
        return a.length - b.length
    })
    .forEach(e => console.log(e));
}


function s(args){

    let names = new Set();
    args.forEach(n => names.add(n));


    [...names].sort((a, b) => {
        if(a.length != b.length) //ako duljinata NE e ednakva
            return (a.length - b.length);  // purvo sortirame po duljina
        else
            return a.localeCompare(b); //AKO DULJINATA E EDNAKVA SORTIRAME ALPHABETICHNO

    })
    .forEach(e => console.log(e));
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




