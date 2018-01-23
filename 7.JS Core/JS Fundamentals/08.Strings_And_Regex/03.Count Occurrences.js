

function solve(word, sentence) {

    let strLength = word.length;
    //console.log(sentence);

    let occurrencies = 0;
    for(let i = 0; i <= sentence.length-1; i++)
    {
        let piece = sentence.substr(i, strLength);

        if(word === piece)
            occurrencies++;

    }
    console.log(occurrencies);
}

//solve('the', 'The quick brown fox jumps over the lay dog.');
solve('ma', 'Marine mammal training is the training and caring for marine life such as, dolphins, killer whales, sea lions, walruses, and other marine mammals. It is also a duty of the trainer to do mental and physical exercises to keep the animal healthy and happy.');














