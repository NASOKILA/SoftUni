

function attachEventsListeners() {

    document.getElementById('convert').addEventListener('click', function () {


        let rates =
            {
                'km' : 1000,
                'm' : 1,
                'cm' : 0.01,
                'mm' : 0.001,
                'mi' : 1609.34,
                'yrd': 0.9144,
                'ft' : 0.3048,
                'in' : 0.0254
            };

        //vzimame si nomera ot poleto
        let number = Number(document.getElementById('inputDistance').value);

        //vzimame i optiona na purviq selekt
        let inputUnits = document.getElementById('inputUnits').value;

        //vzimame i optiona na vtoriq selekt
        let outputUnits = document.getElementById('outputUnits').value;

        console.log(number);
        console.log(inputUnits);
        console.log(outputUnits);

        let result = number * rates[inputUnits] / rates[outputUnits];

        document.getElementById('outputDistance').value = result;

    });
}











