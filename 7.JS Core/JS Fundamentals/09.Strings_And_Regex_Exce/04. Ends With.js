
function solve(str, end) {

    if(str.endsWith(end))
        console.log(true);
    else
        console.log(false);

}

solve('This is Houston, we have…', 'We have…');
solve('This sentence ends with fun?', 'fun?');



