
let text = "This is an example text !!!!";

let pattern = /\.\s*(\d+)\.\s*(\d+)/g;

// new RegExp(patt, flag) EXAMPLE
let regex = new RegExp(pattern, 'gm');

// .exec() EXAMPLE
let match = pattern.exec(text);

while(match !== null){

    // . . .

    match = pattern.exec(text); 
}


/*

    let names = {};

    for (const item of args) {

        let tokens = item.split('=');
        let name = tokens[0];
        let information = {};

        let info = tokens[1].split(';');

        if (!names.hasOwnProperty(name)) {

            for (const kvp of info) {

                let token2 = kvp.split(':');
                let key = token2[0];
                let value = token2[1];

                information[key] = value;

            }

            names[name] = information;
        }
        else {
            //has the name
            information = names[name];

            for (const kvp of info) {

                let token2 = kvp.split(':');
                let key = token2[0];
                let value = token2[1];

                //ako go nqma toq kluch mu go slagame  
                //if(!information.hasOwnProperty(key)){
                    information[key] = value;
                             
            }


        }

    }
*/