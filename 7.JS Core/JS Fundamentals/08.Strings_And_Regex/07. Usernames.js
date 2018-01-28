
function solve(emails) {

    let result = [];

    for(let e of emails)
    {
        let name = '';
        for(let i = 0; i <= e.length-1; i++)
        {
            if(e[i] === '@')
                break;

            name += e[i];
        }

        let kliomba = e.indexOf('@');

        let uduljenie = '';
        uduljenie += e[kliomba+1];

        for(let i = kliomba; i <= e.length-1; i++)
        {
            if(e[i] === '.')
            {
                uduljenie += e[i+1];
            }
        }

        name += `.${uduljenie}`;
        result.push(name);
    }

    console.log(result.join(', '));
}

//solve(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);



function s(emails) {

    let result = [];

    for(let email of emails){

        let validEmail = '';

        let tokens = email.split("@");
        let username = tokens[0];
        let rest = tokens[1];

        validEmail = username;
        validEmail += '.' + rest[0];

        for(let ch in rest){
            if( rest[ch] === '.')
            {
                let element = rest[Number(ch)+1];
                validEmail += element;
            }
        }

        result.push(validEmail);
    }

    console.log(result.join(", "));
}
s(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);
