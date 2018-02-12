

function solve(kingdomsGeneralsAndArmies, battles) {
    let allKingdoms = {};
    for (let obj in kingdomsGeneralsAndArmies) {

        let currentKingdom = kingdomsGeneralsAndArmies[obj].kingdom;
        let currentGeneral = kingdomsGeneralsAndArmies[obj].general;
        let currentArmy = kingdomsGeneralsAndArmies[obj].army;

        if (!allKingdoms.hasOwnProperty(currentKingdom)) {
            //pravim si obekta s generalite i im dobavqme armiite
            let newGeneral = {
                [currentGeneral]: {
                    'army': currentArmy,
                    'wins': 0,
                    'losses': 0
                }
            };

            //i nakraq gi slagame vutre
            allKingdoms[currentKingdom] = newGeneral;

        }
        else {
            //ako go ima toq kingdom
            //proverqvame dali ima toq general v masiva s generali

            if (!allKingdoms[currentKingdom].hasOwnProperty(currentGeneral)) {
                let newGeneralInfo = {
                    'army': currentArmy,
                    'wins': 0,
                    'losses': 0

                };
                //ako go nqma go dobavqme
                allKingdoms[currentKingdom][currentGeneral] = newGeneralInfo;
            }
            else {

                //ako go imame mu dobavqme armiqta
                allKingdoms[currentKingdom][currentGeneral]['army'] += currentArmy;

            }

        }


    }


    //battles start:
    for (let battle of battles) {
        let attackingKingdom = battle[0];
        let attackingGeneral = battle[1];

        let defendingKIngdom = battle[2];
        let defendingGeneral = battle[3];


        //check if kingdom exists
        if (!allKingdoms.hasOwnProperty(attackingKingdom))
            continue;

        //check if general exists
        if (!allKingdoms[attackingKingdom].hasOwnProperty(attackingGeneral))
            continue;

        //check if attacking general exists
        if (!allKingdoms.hasOwnProperty(defendingKIngdom))
            continue;

        //check if dfending general exists
        if (!allKingdoms[defendingKIngdom].hasOwnProperty(defendingGeneral))
            continue;




        //generals From same kingdom cannot attack eachother
        if (attackingKingdom === defendingKIngdom)
            continue;

        //ne znam dali shte stane s tova
        if (attackingGeneral === defendingGeneral)
            continue;

        let attackerArmy = allKingdoms[attackingKingdom][attackingGeneral]['army'];

        let defenderArmy = allKingdoms[defendingKIngdom][defendingGeneral]['army'];

        if (attackerArmy > defenderArmy) {

            //attacker wins
            let tenPercentOfWinnerArmy = attackerArmy / 10;
            allKingdoms[attackingKingdom][attackingGeneral]['army'] += tenPercentOfWinnerArmy;

            //score win
            allKingdoms[attackingKingdom][attackingGeneral]['wins']++;


            //loser loses 10% of his army
            let tenPercentOfLoserArmy = defenderArmy / 10;
            allKingdoms[defendingKIngdom][defendingGeneral]['army'] -= tenPercentOfLoserArmy;

            //score loss
            allKingdoms[defendingKIngdom][defendingGeneral]['losses']++;


        }
        else if (defenderArmy > attackerArmy) {

            let currentAtacker = allKingdoms[attackingKingdom][attackingGeneral];

            let currentDefender = allKingdoms[defendingKIngdom][defendingGeneral];

            //defender wins
            let tenPercentOfWinnerArmy = defenderArmy / 10;
            allKingdoms[defendingKIngdom][defendingGeneral]['army'] += tenPercentOfWinnerArmy;

            //score the win
            allKingdoms[defendingKIngdom][defendingGeneral]['wins']++;


            //loser loses 10% of his army
            let tenPercentOfLoserArmy = attackerArmy / 10;
            allKingdoms[attackingKingdom][attackingGeneral]['army'] -= tenPercentOfLoserArmy;

            //score the loss
            allKingdoms[attackingKingdom][attackingGeneral]['losses']++;

        }


    }


    //sorting and printing

    let maxSumOfWins = 0
    for (let kingdom in allKingdoms) {

        let kingdomSumOfWins = 0;

        for (let general in allKingdoms[kingdom]) {
            kingdomSumOfWins += allKingdoms[kingdom][general]['wins'];
        }

        if (maxSumOfWins < kingdomSumOfWins) {
            maxSumOfWins = kingdomSumOfWins;
        }

    }

//Find winner in deferent way
    let winnerKingdomName = '';
    for (let kingdom in allKingdoms) {

        let kingdomSumOfWins = 0;

        for (let general in allKingdoms[kingdom]) {
            kingdomSumOfWins += allKingdoms[kingdom][general]['wins'];
        }

        if (kingdomSumOfWins === maxSumOfWins) {

            //winner found but if we have two with the same wins ???

            winnerKingdomName = kingdom;
            break;
        }
    }

    var sortableKingdoms = new Map();
    for (let kingd in allKingdoms) {
        var currentKingdom = new Map();

        for (let gener in allKingdoms[kingd]) {

            let generalProperties = new Map();

            generalProperties.set('army', allKingdoms[kingd][gener]['army']);
            generalProperties.set('wins', allKingdoms[kingd][gener]['wins']);
            generalProperties.set('losses', allKingdoms[kingd][gener]['losses']);

            currentKingdom.set(gener, generalProperties);
        }

        sortableKingdoms.set(kingd, currentKingdom);

    }

    let result = [...sortableKingdoms].sort((a, b) => {


        let nameA = a[0].toString();
        let nameB = b[0].toString();
        
        let nameALength = nameA.length;
        let nameBLength = nameB.length;

        //get total general lossess
        let Agenerals = a[1];

        //get total general wins and losses
        let totalAGeneralWins = 0;
        let totalAGeneralLosses = 0;


        for (let gen of Agenerals) {
            let entries = gen[1];
            let win = [...entries][1];
            let loss = [...entries][2];
            totalAGeneralWins += win[1];
            totalAGeneralLosses += loss[1];
        }

        let Bgenerals = b[1];
        let totalBGeneralWins = 0;
        let totalBGeneralLosses = 0;


        for (let gen of Bgenerals) {
            let entries = gen[1];
            let win = [...entries][1];
            let loss = [...entries][2];
            totalBGeneralWins += win[1];
            totalBGeneralLosses += loss[1];
        }


        if (totalAGeneralWins > totalBGeneralWins) {
            return -1;
        }
        else if (totalAGeneralWins < totalBGeneralWins) {
            return 1;
        }
        else {
            //if they are equal
            //sort by losses
            if (totalAGeneralLosses > totalBGeneralLosses) {
                return 1;
            }
            else if (totalAGeneralLosses < totalBGeneralLosses) {
                return -1;
            }
            else {
                
                //ako ne sortirame po ime
                
                if(nameALength > nameBLength)
                    return -1;
                else 
                    return 1;
            }

        }

    })


    let winner = result[0];
    console.log("Winner: " + winner[0])

    let generals = [...winner[1]].sort((a, b) => {

        let Aarmyes = [...a[1]][0];
        let Barmyes = [...b[1]][0];

        if(Aarmyes > Barmyes)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    });
    
    for (let general of generals) {

        
        console.log('/\\general: ' + general[0]);
        let totalArmy = [...general[1]][0][1];
        let totalWins = [...general[1]][1][1];
        let totalLosses = [...general[1]][2][1];

        console.log('---army: ' + Math.floor(totalArmy));
        
        console.log('---wins: ' + Math.floor(totalWins));
        
        console.log('---losses: ' + Math.floor(totalLosses));
    }

}






solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 } ],
[ ["YorkenShire", "Quinn", "Stonegate", "Doran"],
["Stonegate", "Ulric", "Maiden Way", "Merek"] ]
);
console.log();

solve([ { kingdom: "Stonegate", general: "Ulric", army: 5000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 5000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 1000 } ],
[ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
["Maiden Way", "Berinon", "YorkenShire", "Quinn"] ]
);

console.log();
solve([{ kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 100000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Stonegate", "Ulric", "Stonegate", "Doran"],
    ["Stonegate", "Doran", "Maiden Way", "Merek"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"],
    ["Maiden Way", "Berinon", "Stonegate", "Ulric"]]
);








