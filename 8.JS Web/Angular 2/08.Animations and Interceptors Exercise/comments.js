
/*
 Ako promenim neshto po angular.json faila, za da ima efent trqbva 
 da restartirame proekta ot konzolata zashtoto tozi fail se chete samo vednuj pri 
 puskane na proekta. 
  

 Angular ne razbira ot vsichki validacii na poleta v html, kato min="" max="" ili drugi.
    Za da ni razbere pravilno ili si pravim nie sami atributi za validaciq, ili polzvame :
        'ng2 validation'  -  Tova sa veche gotovi angular atributi za validaciq. 

    Pri reactivni formi go nqmame tozi problem, samo pri template driven forms go ima zatova obache mojem
    da si instalirame samata biblioteka i problema se opravq.

    01. npm install ng2-validation --save
    02. import it into app.module.ts 

    Sled tova prosto mojem da gi polzvame v kvadratni skobi : 
        [min]="5"      shte proraboti



    KAK SEVZIMA ID OT URL ?
        let id = this.route.snapshot.params["id"];


*/
