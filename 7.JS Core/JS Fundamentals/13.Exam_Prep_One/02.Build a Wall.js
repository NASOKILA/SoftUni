
function solve(args) {

    let numbers = args.map(e => Number(e));
    let days = 0;
    let totalPesos = 0;
    let everyDayConsimption = [];

    while(true)
    {
        let cubicYerdsPerFoot = 0;

        for(let i = 0; i <= numbers.length-1; i++) {
            if (numbers[i] < 30) {
                numbers[i]++;
                cubicYerdsPerFoot += 195;
            }
        }
        if (cubicYerdsPerFoot === 0)
            break;
        everyDayConsimption.push(cubicYerdsPerFoot);

    }

    totalPesos = 1900 * everyDayConsimption.reduce((a, b) => a + b, 0);
    console.log(everyDayConsimption.join(', '));
    console.log(totalPesos + ' pesos');

}

//solve(['21','25','28']);

//solve(['17']);

solve(['17','22','17','19', '17']);


