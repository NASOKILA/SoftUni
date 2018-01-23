

function solve(args) {

    let airport = new Map();
    let townStatisticks = new Map();
    let townPlanes = new Map();

    for(let row of args)
    {
        let input = row.split(' ');

        let planeId = input[0];
        let town = input[1];
        let passengersCount = Number(input[2]);
        let action = input[3];

        if(action === 'land')
        {
            //ako veche go imame toq samolet
            if(airport.has(planeId))
                continue;
            else
                airport.set(planeId, 'land');

            //Ako nqmame go dobavqme
            if(!townStatisticks.has(town))
                townStatisticks.set(town, [0, 0]);
            //SLAGAME MU DEFAULTNI STOINOSTI INAHCE DAVA NAN ZASHTITO E PRAZEN MASIV


            //Ako nqmame go dobavqme
            if(!townPlanes.has(town))
                townPlanes.set(town, new Set());
            //pazim samoletite v set za da nqmame duplikati

            townStatisticks.get(town)[0] += Number(passengersCount);
            townPlanes.get(town).add(planeId); //dobavqme mu prezimeniq samolet

        }else {

            //Departures
            if(airport.has(planeId))
                airport.delete(planeId);
            else
            {
                //ako izlita nesushtestvuvash samolet produljavame
                continue;
            }

            //Pulnim mapovete
            if(!townStatisticks.has(town))
                townStatisticks.set(town, [0,0]);

            if(!townPlanes.has(town))
                townPlanes.set(town, new Set());

            townStatisticks.get(town)[1] += passengersCount;
            townPlanes.get(town).add(planeId);
        }
    }

    let sortedAirport = [...airport]
        .sort((a,b) => a[0].localeCompare(b[0]));

    console.log("Planes left:");
    for(let [planeId] of sortedAirport) {
        console.log('- ' + [planeId][0]);
    }

    let sortedTowns = [...townStatisticks].sort(sortTowns);

    for(let [town, statistics] of sortedTowns)
    {
        console.log(town);
        console.log(`Arrivals: ${statistics[0]}`);
        console.log(`Departures: ${statistics[1]}`);

        //Print Planes:
        console.log("Planes:");
        let sortedPlanes = [...townPlanes.get(town).values()]
            .sort((a,b) => a.localeCompare(b));
        //vrushta ni go kato masiv ot stringove
        sortedPlanes.forEach(e => console.log('-- ' + e));
    }

    function sortTowns(a, b) {

        let aArrivals = a[1][0]; //vzimame broq na izlitashtite
        let bArrivals = b[1][0];

        //Purvi kriterii Vadim a ot b
        let firstCrieteria = bArrivals - aArrivals;

        if(firstCrieteria !== 0) //ako e razlichen ot 0 mi go vurni
            return firstCrieteria;
        else {
            //Vtori kriterii
            return a[0].localeCompare(b[0]);
        }
    }

}


/*
solve(["Boeing474 Madrid 300 land",
    "AirForceOne WashingtonDC 178 land",
    "Airbus London 265 depart",
    "ATR72 WashingtonDC 272 land",
    "ATR72 Madrid 135 depart" ] );

*/

solve(["Airbus Paris 356 land",
    "Airbus London 321 land",
    "Airbus Paris 213 depart",
    "Airbus Ljubljana 250 land" ]);





