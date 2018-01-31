


function solve(str, start) {
    if(str.startsWith(start))
        console.log(true);
    else
        console.log(false);
}
/*
solve('Hoa have you been?','how');

solve('The quick brown fox…',
      'The quick brown fox…');
*/


function s(text, start) {
    let result = text.startsWith(start) ? true : false;
    console.log(result);
}

s('Hoa have you been?','how');

s('The quick brown fox…',
    'The quick brown fox…');














