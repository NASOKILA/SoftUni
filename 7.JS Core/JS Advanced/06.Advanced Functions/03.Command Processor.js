
function solve(commands) {

    //processor e IIFE koeto vrushta dadena funkciq koeto vrushta daden rezultat
    let processor = (function () {

        let result = '';
        //taq funkciq vijda promenlivata 'result'
        return function processor(tokens) {

                let command = tokens.split(' ')[0];
                let input = tokens.split(' ')[1];

                if(command === 'append') {
                    result += input;
                }else if(command === 'removeStart') {
                    result = result.substr(Number(input));

                }else if(command === 'removeEnd') {

                    result = result.split("").reverse().toString()
                        .replace(/\,/g, '')
                        .substr(Number(input))
                        .split("")
                        .reverse().toString()
                        .replace(/\,/g, '');

                }else if(command === 'print') {

                    console.log(result);
                }
            }

    })();


    //podavame edin po edin parametrite na processor() funkciqta
    for(let com of commands)
        processor(com);


}

    solve(['append 123',
        'append 45',
        'removeStart 2',
        'removeEnd 1',
        'print']);

