

function wordsUppercase(str) {
    let strUpper = str.toUpperCase();
    let words = extractWords();
    words = words.filter(w => w != ''); // mahame praznite elementi s filter
    return words.join(', ');
    function extractWords() {return strUpper.split(/\W+/)}
    //polzvame regex da extraktnem samo dumite.
}

console.log(wordsUppercase('Hi, how are you?'));
console.log(wordsUppercase('hello'));

