

function solve(args) {

    let str = '';
    args.forEach(e => str += e);

    let obj = {};
    for(let word of str.split(/\W/g).filter(e => e !== ''))
    {
        let counter = 1;

        if(obj.hasOwnProperty(word))
        {
            counter = obj[word];
            counter++;
        }
        obj[word] = counter;
    }
    console.log(JSON.stringify(obj));
}

solve(['Far too slow, you\'re far too slow.']);
//solve('JS devs use Node.js for server-side JS.-- JS for devs');









