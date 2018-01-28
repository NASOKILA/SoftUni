
function solve(username, email, phone, input) {

    input.forEach(line => {
        line = line.replace(/<![a-zA-Z]+!>/g, username);
        line = line.replace(/<@[a-zA-Z]+@>/g, email);
        line = line.replace(/<\+[a-zA-Z]+\+>/g, phone);

        console.log(line);
    });

}
/*
solve('Pesho',
      'pesho@softuni.bg',
      '90-60-90',
      ['Hello, <!username!>!',
        'Welcome to your Personal profile.',
        'Here you can modify your profile freely.',
        'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
        'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
        'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']);
*/





function replace(username, email, phone, input) {

    input.forEach(row => {

        row = row.replace(/<![a-zA-Z]+!>/g, username)
            .replace(/<@[a-zA-Z]+@>/g, email)
            .replace(/<\+[a-zA-Z]+\+>/g, phone);

        console.log(row);
    });
}


replace(
    'Pesho',
    'pesho@softuni.bg',
    '90-60-90',
    ['Hello, <!username!>!',
        'Welcome to your Personal profile.',
        'Here you can modify your profile freely.',
        'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
        'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
        'Your current phone number is: <+number+>. Would you like to change that? (Y/N)'
    ]
);






