
function solve(args) {

    let movie = args[0].toString().toUpperCase();
    let dayOfWeek = args[1].toString().toUpperCase();

    if(movie === "The Godfather".toUpperCase())
    {
        switch(dayOfWeek)
        {
            case "Monday".toUpperCase():
                console.log(12);
                break;
            case "Tuesday".toUpperCase():
                console.log(10);
                break;
            case "Wednesday".toUpperCase():
                console.log(15);
                break;
            case "Thursday".toUpperCase():
                console.log(12.50);
                break;
            case "Friday".toUpperCase():
                console.log(15);
                break;
            case "Saturday".toUpperCase():
                console.log(25);
                break;
            case "Sunday".toUpperCase():
                console.log(30);
                break;
            default:
            {
                console.log("error");
            }
        }
    }
    else if(movie === "Schindler's List".toUpperCase())
    {
        switch(dayOfWeek)
        {
            case "Monday".toUpperCase():
                console.log(8.50);
                break;
            case "Tuesday".toUpperCase():
                console.log(8.50);
                break;
            case "Wednesday".toUpperCase():
                console.log(8.50);
                break;
            case "Thursday".toUpperCase():
                console.log(8.50);
                break;
            case "Friday".toUpperCase():
                console.log(8.50);
                break;
            case "Saturday".toUpperCase():
                console.log(15);
                break;
            case "Sunday".toUpperCase():
                console.log(15);
                break;
            default:
            {
                console.log("error");
            }
        }
    }
    else if(movie === "Casablanca".toUpperCase())
    {
        switch(dayOfWeek)
        {
            case "Monday".toUpperCase():
                console.log(8);
                break;
            case "Tuesday".toUpperCase():
                console.log(8);
                break;
            case "Wednesday".toUpperCase():
                console.log(8);
                break;
            case "Thursday".toUpperCase():
                console.log(8);
                break;
            case "Friday".toUpperCase():
                console.log(8);
                break;
            case "Saturday".toUpperCase():
                console.log(10);
                break;
            case "Sunday".toUpperCase():
                console.log(10);
                break;
            default:
            {
                console.log("error");
            }
        }

    }
    else if(movie === "The Wizard of Oz".toUpperCase())
    {
        switch(dayOfWeek)
        {
            case "Monday".toUpperCase():
                console.log(10);
                break;
            case "Tuesday".toUpperCase():
                console.log(10);
                break;
            case "Wednesday".toUpperCase():
                console.log(10);
                break;
            case "Thursday".toUpperCase():
                console.log(10);
                break;
            case "Friday".toUpperCase():
                console.log(10);
                break;
            case "Saturday".toUpperCase():
                console.log(15);
                break;
            case "Sunday".toUpperCase():
                console.log(15);
                break;
            default:
            {
                console.log("error");
            }
        }
    }

}

solve(['The Godfather','Friday']);








