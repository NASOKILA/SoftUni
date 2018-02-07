
function solve(portions, commands) {

    let mealsEaten = 0;
    for (let comm in commands) {

        let currentCommand = commands[comm]
            .split(" ")
            .filter(e => e != '');


        if (currentCommand[0] == "Serve") {
            console.log(portions.pop() + ' served!');
        }
        else if (currentCommand[0] == "Eat") {

            if (portions.length < 1)
                continue;

            console.log(portions.shift() + ' eaten');
            mealsEaten++;
        }
        else if (currentCommand[0] == "Add") {
            
            let portionToadd = currentCommand[1];
            if (portionToadd != undefined)
                portions.unshift(portionToadd)
        }
        else if (currentCommand[0] == "Consume") {

            let startIndex = Number(currentCommand[1]);
            let endIndex = Number(currentCommand[2]);

            if (startIndex.toString() === 'NaN' || endIndex.toString() === 'NaN')
                continue;

            if (startIndex < 0 || endIndex >= portions.length)
                continue;

            if (startIndex >= endIndex)
                continue;

            for (let i = startIndex; i <= endIndex; i++) {
                portions.splice(startIndex, 1);
                mealsEaten++;
            }
            console.log('Burp!');
        }
        else if (currentCommand[0] == "Shift") {

            let firstPortionIndex = Number(currentCommand[1]);
            let secondPortionIndex = Number(currentCommand[2]);

            if (firstPortionIndex.toString() === 'NaN' || secondPortionIndex.toString() === 'NaN')
                continue;

            if (firstPortionIndex < 0 || secondPortionIndex >= portions.length)
                continue;

            if (firstPortionIndex >= secondPortionIndex)
                continue;

            //we save the elements in variables
            let firstElement = portions[firstPortionIndex];
            let secondElement = portions[secondPortionIndex];

            if (firstElement == undefined || secondElement == undefined)
                continue;

            portions[secondPortionIndex] = firstElement;
            portions[firstPortionIndex] = secondElement;

        }

        else if (currentCommand[0] == "End") {

            if (portions.length < 1)
                console.log('The food is gone');
            else
                console.log('Meals left: ' + portions.join(', '));

            console.log('Meals eaten: ' + mealsEaten);

            break;
        }

    }

}






