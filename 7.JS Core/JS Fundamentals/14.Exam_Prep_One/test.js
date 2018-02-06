

function solve(args) {

    let planeIDs = [];
    let planesTrack = {};
    let townAndPlanes = {};
    let cities = [];

    let allPlanes = [];
    for(let row of args)
    {
        let input = row.split(' ');

        let planeId = input[0];
        let town = input[1];
        let passengersCount = Number(input[2]);
        let action = input[3];

        if(cities.indexOf(town) === -1)
            cities.push(town);

        //Tova e za vsichki samoleti
        let pl = {id: planeId, location: town, passengers: passengersCount, action: action};
        allPlanes.push(pl);

        if(planeIDs.indexOf(planeId) === -1 && action === 'land')
        {
            let locationAndPassengers = {};
            locationAndPassengers[town] = passengersCount;
            planeIDs.push(planeId);
            planesTrack[planeId] = locationAndPassengers;
        }
        if(action === 'depart' && planeIDs.indexOf(planeId) !== -1)
        {
            let index = planeIDs.indexOf(planeId);
            planeIDs.splice(index, 1);
            delete planesTrack[planeId];
        }

    }

    console.log(`Planes left:`);
    //purvo gi sortirame:

    let keys = [];
    for (let k in planesTrack)
        if (planesTrack.hasOwnProperty(k))
            keys.push(k);

    for(let plane of keys.sort()) {
        console.log(`- ${plane}`);
    }

    let resultObjects = [];
    for(let city of cities.sort().reverse()) {

        let result = {};
        result['location'] = city;
        let insert = false;

        let arrivals = 0;
        let departures = 0;

        for (let plane of allPlanes) {

            if(plane.location === city)
            {
                if(plane.action === 'land')
                    arrivals += plane['passengers'];
                else if (plane.action === 'depart')
                    departures += plane['passengers'];
            }

        }
        if(arrivals > 0)
        {
            result['Arrivals'] = arrivals;
            result['Departures'] = departures;
            resultObjects.push(result);
        }

    }


    //Now print the results
    for(let obj of resultObjects)
    {
        console.log(obj.location);
        console.log(`Arrivals: ${obj['Arrivals']}`);
        console.log(`Departures: ${obj['Departures']}`);

        console.log("Planes:");
        //get all planes with that location
        let allPlanesIdsResult = [];
        for(let plane of allPlanes) {

            let indexOfPlane = allPlanes.indexOf(plane);
            let actionOfPlane = allPlanes[indexOfPlane].action;
//            console.log('////'+actionOfPlane);

            if (plane.location === obj.location) {

                if(allPlanesIdsResult.indexOf(plane.id) === -1)
                {
                    allPlanesIdsResult.push(plane.id);
                }

            }
        }
        allPlanesIdsResult.sort((a,b) => a.localeCompare(b))
            .forEach(e => console.log(`-- ${e}`));
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
