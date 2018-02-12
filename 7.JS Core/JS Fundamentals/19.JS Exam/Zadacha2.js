


function solve(map, input) {

    let mapOfSofia = [];

    for (let i = 0; i < map.length; i++) {

        let row = map[i].split(' ').map(e => Number(e));
        mapOfSofia.push(row);
    }

    for (let item of input) {

        let tokens = item.split(' ');

        let command = tokens[0];
        let index = Number(tokens[1]);

        if (command === 'breeze') {

            for (let i = 0; i < mapOfSofia.length; i++) {

                //polluted blicks cannot go below 0
                mapOfSofia[index][i] -= 15;

                if (mapOfSofia[index][i] < 0)
                    mapOfSofia[index][i] = 0;

            }
        }
        else if (command === 'gale') {

            for (let i = 0; i < mapOfSofia.length; i++) {

                //polluted blicks cannot go below 0
                
                mapOfSofia[i][index] -= 20;
            
               // if (mapOfSofia[index][i] - 20 >= 0)
                    if(mapOfSofia[i][index] < 0)
                        mapOfSofia[i][index] = 0;
                
                    }

        }
        else if (command === 'smog') {

            for (let i = 0; i < mapOfSofia.length; i++) {
                for (let j = 0; j < mapOfSofia.length; j++) {
                    mapOfSofia[i][j] += index;
                }
            }

        }

    }


    //find pollute areas:

    let polluteBlocks = [];

    for (let i = 0; i < mapOfSofia.length; i++) {
        for (let j = 0; j < mapOfSofia.length; j++) {
            
            let currentBlock = mapOfSofia[i][j];

            if(currentBlock >= 50){
                polluteBlocks.push('[' + i + '-' + j +']');
            }

        }
    }


    //print pollute areas:
    if(polluteBlocks.length > 0)
        console.log('Polluted areas: ' + polluteBlocks.join(', '))
    else
        console.log("No polluted areas");

}



solve([
    "5 7 2 14 4",
    "21 14 2 5 3",
    "3 16 7 42 12",
    "2 20 8 39 14",
    "7 34 1 10 24",
  ],
  ["breeze 1", "gale 2", "smog 35"]
  );

console.log();

solve([
    "5 7 3 28 32",
    "41 12 49 30 33",
    "3 16 20 42 12",
    "2 20 10 39 14",
    "7 34 4 27 24",
  ],
  [ 
    "smog 11", "gale 3", 
    "breeze 1", "smog 2"
  ]
  );

  console.log();
solve([
    "5 7 72 14 4",
    "41 35 37 27 33",
    "23 16 27 42 12",
    "2 20 28 39 14",
    "16 34 31 10 24",
],
    ["breeze 1", "gale 2", "smog 25"]
);









