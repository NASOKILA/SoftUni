

let remote = (() => {

    const BASE_URL = 'https://baas.kinvey.com/';
    const APP_KEY = 'kid_SynTc0i9z'; // APP KEY HERE
    const APP_SECRET = 'c8ea46cb339d4834b62543e35d7c8e17'; // APP SECRET HERE

    //suzdava authentikaciq v zavisimost kakvo mu podadem 'Basic' ili 'Kinvey'
    //Basic se podava kogato ne sme lognati
    //Kinvei se podava kogato sme lognati
    //KINVEI ISKA AUTENTIKACIQ V Base64 FORMAT ZA TOVA POLZVAME FUNKCIQta  'btoa' 
    function makeAuth(auth) {
        if (auth === 'basic') {
            return `Basic ${btoa(APP_KEY + ":" + APP_SECRET)}`;
        } else {
            return `Kinvey ${sessionStorage.getItem('authtoken')}`
        }
    }

    // request method (GET, POST, PUT)
    // kinvey module (user/appdata)
    // url endpoint
    // auth (Basic/Kinvey)
    function makeRequest(method, module, endpoint, auth) {
        return {
            url: BASE_URL + module + '/' + APP_KEY + '/' + endpoint,
            method: method,
            headers: {
                'Authorization': makeAuth(auth)
            }
        }
    }



    
    //zglobqva zaqvka za vzimane GET v zavisimost ot kakvi parametri mu podadem
    function get (module, endpoint, auth) {
        return $.ajax(makeRequest('GET', module, endpoint, auth));
    }

    //zglobqva zaqvka za postvane POST
    function post (module, endpoint, auth, data) {
        let obj = makeRequest('POST', module, endpoint, auth);
        
        if (data) {
            //obj.data = data;
            //dobaveno
            obj.data = JSON.stringify(data);
            obj.contentType = 'application/json';
            //TRY obj.headers['Content-Type'] = 'application/json';
        }
        
        return $.ajax(obj);
    }

    //zglobqva PUT zaqvka
    function update(module, endpoint, auth, data) {
        let obj = makeRequest('PUT', module, endpoint, auth);
        //obj.data = data;
        
        //dobveno 
        obj.data = JSON.stringify(data);
        obj.contentType = 'application/json';
        
        return $.ajax(obj);
    }

    //zglobqva DELETE zaqvka
    function remove(module, endpoint, auth) {
        return $.ajax(makeRequest('DELETE', module, endpoint, auth));
    }

    return {
        get,
        post,
        update,
        remove
    }
})();