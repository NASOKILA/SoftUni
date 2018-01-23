
    function solve(args) {

        let speed = args[0];
        let territory = args[1];

        switch (territory)
        {
            case "city":
                let limitCity = 50;
                if((speed - limitCity) > 0 && (speed - limitCity) <= 20)
                    console.log('speeding');
                else if((speed - limitCity) > 20 &&  (speed - limitCity) <= 40)
                    console.log('excessive speeding');
                else if((speed - limitCity) > 40)
                    console.log('reckless driving');
                else
                    console.log('');
                break;
            case "residential":
                let limitResidence = 20;
                if((speed - limitResidence) > 0 && (speed - limitResidence) <= 20)
                    console.log('speeding');
                else if((speed - limitResidence) > 20 &&  (speed - limitResidence) <= 40)
                    console.log('excessive speeding');
                else if((speed - limitResidence) > 40)
                    console.log('reckless driving');
                else
                    console.log('');
                break;
            case "interstate":
                let limitInterstate = 90;
                if((speed - limitInterstate) > 0 && (speed - limitInterstate) <= 20)
                    console.log('speeding');
                else if((speed - limitInterstate) > 20 &&  (speed - limitInterstate) <= 40)
                    console.log('excessive speeding');
                else if((speed - limitInterstate) > 40)
                    console.log('reckless driving');
                else
                    console.log('');
                break;
            case "motorway":
                let limitMotorState = 130;
                if((speed - limitMotorState) > 0 && (speed - limitMotorState) <= 20)
                    console.log('speeding');
                else if((speed - limitMotorState) > 20 &&  (speed - limitMotorState) <= 40)
                    console.log('excessive speeding');
                else if((speed - limitMotorState) > 40)
                    console.log('reckless driving');
                else
                    console.log('');
                break;
        }
    }

solve([40, 'city']);
