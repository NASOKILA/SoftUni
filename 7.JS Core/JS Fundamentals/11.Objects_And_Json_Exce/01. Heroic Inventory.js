
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
        hero['items'] = items;

        heroes.push(hero);
    }

    console.log(JSON.stringify(heroes));
}


solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);

solve(['Jake / 1000 / Gauss, HolidayGrenade']);
