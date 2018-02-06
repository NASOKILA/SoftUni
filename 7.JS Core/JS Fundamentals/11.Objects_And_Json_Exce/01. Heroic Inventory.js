
function solve(args) {

    let heroes = [];
    for(let row of args)
    {
        let hero = {};
        let elements = row.split(' / ').map(e => e.trim())
            .filter(e => e !== '');

        let name = elements[0];
        let level = Number(elements[1]);

        let items = [];
        for(let item of elements[2].split(', '))
            items.push(item);

        hero['name'] = name;
        hero['level'] = level;
        
        let items = [];
        if(elements.length > 2){
            items =  elements[2].split(', ');
        }

        obj['items'] = items;

        heroes.push(hero);  
    }

    console.log(JSON.stringify(heroes));
}

/*
solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);

solve(['Jake / 1000 / Gauss, HolidayGrenade']);
*/


function s(args){

    let result = [];

    for(let row of args){
        
        let arguments = row
            .split(' / ')
            .filter(e => e =! '');
        
        let obj = {};

        let name = arguments[0];
        let level = Number(arguments[1]);
        
        obj['name'] = name;
        obj['level'] = level;
        
        let items = [];
        if(arguments.length > 2){
            items =  arguments[2].split(', ');
        }
        obj['items'] = items;
    
        result.push(obj);
    }  
        console.log(JSON.stringify(result));       
}

s(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);
