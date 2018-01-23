
function solve(word) {

    //obruhtame stringa i proverqvame dali e edin
    //i susht s purvonachalnata duma

    let reversedWord = word.split('').reverse().join("");
    if(word === reversedWord)
        console.log(true);
    else
        console.log(false);
}

solve('racecar');
solve('haha');
solve('unitinu');








