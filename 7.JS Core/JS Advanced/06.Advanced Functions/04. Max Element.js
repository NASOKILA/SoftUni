



function solve(args){

    //I TAKA STAVA !!!
    //return  Math.max(...args);

    //Shte smenim na Math.max() 'this';
    //return Math.max.call(...args);  // SUS ...args razbivame masiva na chasti

    //MOJE I S Math.max.apply('', args)   //TRQBVA DA PODADEM NESHTO NA PURVATA POZICIQ, MOJE I DA E PRAZEN STRING
    return Math.max.apply('', args);
}

console.log(solve([10, 20, 5]));

