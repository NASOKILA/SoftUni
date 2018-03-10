
function requestValidator(obj) {
    
    let validMethods = ["GET", "POST", "DELETE", "CONNECT"];
    let uriRegex = /^[\w.]+$/;
    let validVerisons = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    let messageRegex = /^[^<>\\&'"]*$/;

    if(! (obj.method && validMethods.includes(obj.method))){
        throw new Error("Invalid request header: Invalid Method");
    }

    if(! (obj.uri && ( uriRegex.test(obj.uri) || obj.uri == "*"))){
        throw new Error("Invalid request header: Invalid URI");
    }

    if(! (obj.version && validVerisons.includes(obj.version))){
        throw new Error("Invalid request header: Invalid Version");
    }

    if(! ( obj.hasOwnProperty("message") && (messageRegex.test(obj.message) || obj.message == ""))) {
        throw new Error("Invalid request header: Invalid Message");
    }

    return obj;
}


validateRequest({
    method: 'POST',
    uri: '',
    version: 'HTTP/1.0',
    message: ''
});

validateRequest({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
});

validateRequest({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
});

