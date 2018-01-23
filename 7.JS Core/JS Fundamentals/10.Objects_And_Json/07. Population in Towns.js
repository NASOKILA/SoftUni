
function solve(args) {

    let map = new Map();

    for(let row of args)
    {
        let input = row.split(' <-> ');

        let city = input[0];
        let population = Number(input[1]);

        if(map.has(city))
            population += Number(map.get(city));

        map.set(city, population);
    }

    for(let tp of map)
        console.log(`${tp[0]} : ${tp[1]}`);
}


/*
solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 1000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);
*/
 solve(['Istanbul <-> 100000',
 'Honk Kong <-> 2100004',
 'Jerusalem <-> 2352344',
 'Mexico City <-> 23401925',
 'Istanbul <-> 1000']);


