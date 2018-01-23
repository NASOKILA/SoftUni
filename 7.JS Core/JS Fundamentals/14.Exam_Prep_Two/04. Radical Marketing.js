
function solve(args) {

    let log = [];
    let personSubscribed = {};
    let rows = [];
    for(let row of args)
    {
        if(row.indexOf('-') === -1)
        {
            //Person command
            let name = row[0];
            let person = {};
            person[name] = new Set('');

            //ako choveka go nqma samo togava go dobavqme
            if(log.indexOf(person) === -1)
                log.push(person);

            if(!personSubscribed.hasOwnProperty(name))
                personSubscribed[name] = 0;

        }
        else if(row.indexOf('-') !== -1)
        {
            //Ako absolutno sushtiq row sushtestvuva skipvame vsichko
            if(rows.indexOf(row) !== -1)
                continue;

            rows.push(row);

            // subscribe command
            let firstPerson = row.split('-')[0];
            let secondPerson = row.split('-')[1];

            //uvelichavame broikata na personSubscribers
            let currentSubscribers = personSubscribed[firstPerson];
            personSubscribed[firstPerson] = currentSubscribers + 1;

            //proverqvame dali i dvamata sushtestvivat
            let firstPersonExists = false;
            let secondPersonExists = false;
            log.forEach(e => {

                let key = Object.keys(e)[0];
                if(key === firstPerson)
                    firstPersonExists = true;

                if(key === secondPerson)
                    secondPersonExists = true;
            });

            //ako ne sushtestvuva edno ot dvete ne produljavame napred
            if(!firstPersonExists || !secondPersonExists) {
                continue;
            }

            //Ako sushtestvuvat i dvamata zapisvame purviq na vtoriq
            Subscribe(firstPerson, secondPerson);
        }
    }

    log.sort((a,b) => {
        "use strict";

        let subsCountOne = [...a[Object.keys(a)]].length;
        let subsCountTwo = [...b[Object.keys(b)]].length;
        let resultCode = subsCountTwo - subsCountOne;

        if(resultCode === 0)
            resultCode = personSubscribed[Object.keys(b)] - personSubscribed[Object.keys(a)];

        return resultCode;

    });

    let mostImportantPerson = log[0];

    let counter = 1;
    console.log(Object.keys(mostImportantPerson)[0]);
    mostImportantPerson[Object.keys(mostImportantPerson)[0]].forEach(e => {
        "use strict";

        console.log(counter + '. ' + e);
        counter++;
    });

    function Subscribe(firstPerson, secondPerson) {

        if(firstPerson !== secondPerson) {

            let currentSecondPerson = log.filter(e => Object.keys(e)[0] === secondPerson)
            let name = Object.keys(currentSecondPerson[0]);
            let subscribers = currentSecondPerson[0][secondPerson];

            //ako ne go sudurja znachi go slagame
            if (!subscribers.hasOwnProperty(firstPerson))
                subscribers.add(firstPerson);
        }
    }
}

solve(['A',
    'B',
    'C',
    'D',
    'A-B','A-B','A-A',
    'B-A',
    'C-A',
    'C-B',
    'D-A']);


solve(['J',
    'G',
    'P',
    'R',
    'C',
    'J-G',
    'G-J',
    'P-R',
    'R-P',
    'C-J']);


