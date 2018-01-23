
function LeapYear(year) {

    if((year % 4 === 0  && year % 100 !== 0)|| year % 400 === 0 )
        console.log('yes');
    else
        console.log('no');
}

LeapYear(1999);
LeapYear(2000);
LeapYear(1900);










