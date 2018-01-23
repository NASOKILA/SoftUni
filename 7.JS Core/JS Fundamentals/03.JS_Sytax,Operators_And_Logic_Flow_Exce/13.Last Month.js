

function s(args) {

    let day = args[0];
    let month = args[1];
    let year = args[2];

    let date = new Date();
    date.setYear(year);
    date.setMonth(month-1);
    date.setDate(0);

    let lastDay = date.getDate();

    console.log(lastDay);
}

s([17, 3, 2002]);
s([13, 12, 2004]);
