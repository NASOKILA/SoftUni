
function solve(args) {

    let result = '';
    let regex = /\d+/g;
    for(let elem of args)
    {
        let match = elem.match(regex);

        if(match)
        {
            for(let elem of match)
                result += elem + ' ';

        }

    }

    console.log(result);
}
/*
solve(['The300',
      'What is that?',
      'I think it’s the 3rd movie.',
      'Lets watch it at 22:45']);
*/

/*
solve(['123a456',
        '789b987',
        '654c321',
        '0']);
*/




function s(input) {

    let result = [];
    input.forEach(line => {
        let nums = line.match(/\d+/g);

        if(nums != null)
        nums.forEach(n => result.push(n));
    });
    console.log(result.join(' '));
}

s(['The300dwadw312',
    'What is that?',
    'I think it’s the 3rd movie.',
    'Lets watch it at 22:45']);

