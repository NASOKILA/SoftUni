
function solve(arrayOfStrings) {

    // na vseki edin regex imame lookAhead koito proverqva za space, tabulciq ili za krai na stringa

    // v numbers regexa vtorata grupa tuka moje da q ima no moje i  da q nqma '*'

    let patterns = {
            names:/(\*[A-Z]{1}([A-Za-z]+)*)(?= |\t|$)/g,
            numbers:/(\+[0-9\-]{10})(?= |\t|$)/g,
            ids:/(\![a-zA-Z0-9]+)(?= |\t|$)/g,
            base:/(\_[a-zA-Z0-9]+)(?= |\t|$)/g
        };

    //VSICHKI TEZI REGEXI MOJEM DA GI SUEDINIM V EDIN KATO GI RAZDELIM S "|" !!!

    let result = '';

    for (let row of arrayOfStrings) {
        result += row;
        for (let p in patterns) {

            let pattern = patterns[p];

            //ZA DA REPLEISNEM MU PODAVAME ANONIMNA ARROW FUNKCIQ KOQTO AVTOMATICHNO PRIEMA
            //PARAMETURA match I MOJE DA RABOTI S NEGO
                result = result
                    .replace(pattern, (match) => {
                        return '|'.repeat(match.length);
                    });
        }
        result += '\n';
    }
    console.log(result);
}

/*
solve([
    'Agent *Ivankov was in the *Ivankov room when it all happened.',
    'The person in the room was heavily armed.',
    'Agent *Ivankov had to act quick in order.',
    'He picked up his phone and called some unknown number.',
    'I think it was +555-49-796',
    'I can\'t really remember...',
    'He said something about "finishing work" with subject !2491a23BVB34Q and returning to Base _Aurora21',
    'Then after that he disappeared from my sight.',
    'As if he vanished in the shadows.',
    'A moment, shorter than a second, later, I saw the person flying off the top floor.',
    'I really don\'t know what happened there.',
    'This is all I saw, that night.',
    'I cannot explain it myself...'
]);
*/

function s(input) {

    input.forEach(element => {
        console.log(element.replace(/(\*[A-Z]{1}([A-Za-z]+)*)(?= |\t|$)|(\+[0-9\-]{10})(?= |\t|$)|(\![a-zA-Z0-9]+)(?= |\t|$)|(\_[a-zA-Z0-9]+)(?= |\t|$)/g,
            (match) => '|'.repeat(match.length)));
    });
}
s([
    'Agent *Ivankov was in the *Ivankov room when it all happened.',
    'The person in the room was heavily armed.',
    'Agent *Ivankov had to act quick in order.',
    'He picked up his phone and called some unknown number.',
    'I think it was +555-49-796',
    'I can\'t really remember...',
    'He said something about "finishing work" with subject !2491a23BVB34Q and returning to Base _Aurora21',
    'Then after that he disappeared from my sight.',
    'As if he vanished in the shadows.',
    'A moment, shorter than a second, later, I saw the person flying off the top floor.',
    'I really don\'t know what happened there.',
    'This is all I saw, that night.',
    'I cannot explain it myself...'
]);








