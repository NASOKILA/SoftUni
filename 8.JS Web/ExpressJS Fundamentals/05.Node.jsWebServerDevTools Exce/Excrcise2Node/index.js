
const http = require('http');
const url = require('url');
const fs = require('fs');

const handlers = require('./handlers');
const port = '4567';    


http.createServer((req, res) => {

    //console.log(url.parse(req.url));
    req.path = url.parse(req.url).pathname;
   
    let routeNotFound = true;
    
    for (const handler of handlers) {
        
        let result = handler(req, res);

        if(result !== true){
            routeNotFound = false;
            break;
        }

    }
    
    if(routeNotFound)
    {
        fs.readFile('./views/pageNotFound.html', (err, data) => {

            if (err) {
                console.log(err);
                return
            }

            res.writeHead(200, {
                'content-type': 'text/html'
            })
            res.write(data)
            res.end()
        });
    }

}).listen(port);

console.log(`Server running on port ${port}.`)
