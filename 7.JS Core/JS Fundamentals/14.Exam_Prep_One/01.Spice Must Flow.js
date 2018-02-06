



function solve(args)
{
    let startingYeld = Number(args[0]);
    let extractedPiece = 0;
    let days = 0;
    let workersConsumation = 26;

    while(true)
    {
        extractedPiece += (startingYeld - workersConsumation);
        days++;
        startingYeld -= 10;
        if(startingYeld < 100)
        {
            console.log(days);
            console.log(extractedPiece - workersConsumation);
            break;
        }
    }
}

solve(['111']);

solve(['200']);
