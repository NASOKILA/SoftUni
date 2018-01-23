

function Calculate(x1, y1, x2, y2)
{
    //Pitagorova teorema
    let pointA = {x:x1, y:y1};
    let pointB = {x:x2, y:y2};

    let distanceX = Math.pow(pointA.x - pointB.x, 2); // vdigame na vtora
    let distanceY = Math.pow(pointA.y - pointB.y, 2); // vdigame na vtora
    console.log(Math.sqrt(distanceX + distanceY)); //vzimame korena
}


Calculate(2, 4, 5, 0);
Calculate(2.34, 15.66, -13.55, -2.9985);

