
function solve(str, end) {

    if(str.endsWith(end))
        console.log(true);
    else
        console.log(false);

}

//solve('This is Houston, we have…', 'We have…');
//solve('This sentence ends with fun?', 'fun?');






function s(text, end) {
    console.log(text.endsWith(end) ? true : false)
}
s('This is Houston, we have…', 'We have…');
s('This sentence ends with fun?', 'fun?');








