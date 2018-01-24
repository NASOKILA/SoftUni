


function radioCristals(arr) {

    //tekushta debelina na diamantite
    let targetThickness = arr[0];

    //operacii za manipulaciq
    let operations = {
        cut: (num) => num / 4, // cut it in 4
        lap: (num) => num -= num / 5, //20%
        grind: (num) => num - 20,
        etch: (num) => num - 2,
        xray: (num) => {console.log(`X-ray x1`);return ++num},
        transportAndWash:(num) => {console.log(`Transporting and washing`);return Math.floor(num)}
    };

    //za vseki diamana izpulnqvame dadeni manipulacii
    for(let i = 1; i < arr.length; i++)
    {
        let currentMicrons = arr[1];
        console.log(`Processing chunk ${currentMicrons
        } microns`);
        //we have to shape the cristal
        currentMicrons = manipulateCristal(targetThickness, currentMicrons, 'Cut', operations.cut);
        currentMicrons = manipulateCristal(targetThickness, currentMicrons, 'Lap', operations.lap);
        currentMicrons = manipulateCristal(targetThickness, currentMicrons, 'Grind', operations.grind);
        currentMicrons = manipulateCristal(targetThickness, currentMicrons, 'Etch', operations.etch);


        if(currentMicrons+1 === targetThickness)
            currentMicrons = operations.xray(currentMicrons);

        console.log(`Finished crystal ${currentMicrons} microns`);
    }

    function manipulateCristal(targetThickness, currentMicrons, opName, operation) {

        //dokato targeta e po maluk ot teushtite mikroni

        let counter = 0; // trqbva ni kounter za da smqtame kolko puti trqbva da se izpulni;

        while(operation(currentMicrons) >= targetThickness-1){

            currentMicrons = operation(currentMicrons); // izvurshvame podadenqta operaciq
            counter++;
        }

        if(counter > 0){
            console.log(`${opName} x${counter}`);
            currentMicrons = operations.transportAndWash(currentMicrons); // zakruglqme i printirame s funkciqta transportAndWash
        }

        return currentMicrons; //vrushtame promqnite

    }
}

radioCristals([1375, 50000]);
//radioCristals([1000, 4000, 8100]);

