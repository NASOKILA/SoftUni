
/*
    Animacii i Interceptori (Animations and interceptors):
        


    Animacii:
        Tova e dopulnitlna lekciq, vsichki ot tuk natam shte budat dopulnitelni lekcii.
        Ako slagame animacii v nashiq proekt tova shte donese bonus tochki.

        Animaciite sa vgradeni v angular.
        Vseki dom element ima purvonachalen state i s animaciite ili tranziciite promenqt tozi state.
        Ima mnogo css v animaciite i trqnziciite.

        Kak raboti ?
            01.importvame si BrowserAnimationModule from '@angular/platform-browser/animations'
                ako nqmame '@angular/platform-browser/animations' trqbva da go instalirame chrez npm.
            02.Dobavqme go v ap.module.ts


        Mojem da razprostranqvame animacii kakto css.

        V komponenta si dobavqme animations: []
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  animations: appAnimations  
})

        V app animations faila imame trigger za tazi animaciq
        
        Kak se dobqva v html-a ?
            //divState e imeto na triggera a 'state' e ima na promentliva v koda ni.
            /mojem da imame mnogo state-ove
            <div [@divState]="state"></div> 


        translqteX : 5px;  // se mesti na lqvo 
        translqteX : -5px;  // se mesti na dqsno 
        translqteY : 5px;  // se mesti na gore 
        translqteY : -5px;  // se mesti na dolo 



  //This is a transition
  //name of the trigger
  trigger('divState', [

    //we can have many states
    //state normal css
    state('normal', style({
      backgroundColor: 'red',
      transform: 'translateX(0)'
    })),

    //state highlighted css
    state('highlighted', style({
      backgroundColor: 'blue',
      transform: 'translateX(100px)'
    })),

    //we define the direction of the animation and the time of execution, 300 miliseconds
    
    transition("normal => highlighted", animate(300)),
    transition("highlighted => normal", animate(600))

    //if we want the same speed for both directions we need '<=>'
        //transition("highlighted <=> normal", animate(300))
  ])


    ZADULJTELNO PROVERI :
        app.animations.ts 
        app.component.ts
        app.component.html


    Interceptori:
        Nqmat nishto obshto s animaciite.   
        Interceptora zakacha headeri v samiq HTTP obekt na requesta kum servera.
        Toi zakacha informaciq kum zaqvkata.
        
        Mojem da zakachame (JWT tokens) no moje i da zakacha drugi neshta kato tezi 
        obekti koito se vrushtat ot kinvey.

        SHTE GI TESTVAME NA STAROTO UPRAJNENIE 'Forms Exercise' !!!
        VMESTO DA ZAKACHEME HEADERI RUCHNO NA ZAQVKITE SHTE POLZVAME INTERCEPTORI.

        Pravim si papka Interceptors i v neq si pravim neshtata.

        Vsichki interceptori sa injectable.

        Te ni slqgat vsichki headeri na razlichnite requesti avtomatichno.

        KAK SE IMPORTVAT ?
        //we have to import this in app.module.ts in providers but LIKE THIS:
{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi : true
}

        VAJNO !!!!!!!!!
            Chast ot greshkite mogat da se handelvat oshte v samiq interceptor.

        VIJ FAILA token.interceptor.ts vuv papka Forms Exercise/lesson-and-forms-exercise



    REDUX V ANGULAR E PO TRUDEN OT KOLKOTO V REAKT.
*/



