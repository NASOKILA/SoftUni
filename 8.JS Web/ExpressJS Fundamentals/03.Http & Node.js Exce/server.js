
const http = require('http');

let server = http.createServer((req, res) => {
    res.write('Hello, I am a new server.\n');
    res.end('End of server.\n');
});

let port = '7000';
server.listen(port);

//SERVERA SE PUSKA OT KONZOLATA SUS: node server.js (IMETO NA FAILA)
//I SE SPIRA SUS: 'CTRL + C'

