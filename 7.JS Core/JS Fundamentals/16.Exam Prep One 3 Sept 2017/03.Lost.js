

function solve(keyword, text){

    let longitutePatt = /(east)([^,]+)?((\d{2})([^,]+)?(,)([^,]+)?(\d{6}))/gi;
    let latitudePatt = /(north)([^,]+)?((\d{2})([^,]+)?(,)([^,]+)?(\d{6}))/gi;
    let dinamicPatt = new RegExp("("+ keyword +"(.+)"+ keyword +")","g");
    
    let longitute = longitutePatt.exec(text);
    let realLongitude = '';
    while(longitute != undefined){
        realLongitude = longitute[4] + '.' + longitute[8] + ' E';
        longitute = longitutePatt.exec(text);
    }


    let latitude = latitudePatt.exec(text);
    let realLatitude = '';
    while(latitude != undefined){

        realLatitude = latitude[4] + '.' + latitude[8] + ' N'
        latitude = latitudePatt.exec(text);
    }
    


    let message = dinamicPatt.exec(text);

    
    console.log(realLatitude);
    console.log(realLongitude);
    console.log("Message: " + message[2].toString());
    

}

//solve('<>', 'o u%&lu43t&^ftgv><nortH4276hrv756dcc,  jytbu64574655k <>ThE sanDwich is iN the refrIGErator<>yl i75evEAsTer23,lfwe 987324tlblu6b');


solve('4ds', 'eaSt 19,432567noRt north east 53,123456north 43,3213454dsNot all those who wander are lost.4dsnorth 47,874532')







