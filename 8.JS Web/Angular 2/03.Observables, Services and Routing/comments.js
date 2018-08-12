/*
    Angular polzva dependency injection i oshte dobri praktiki.

    Dependency injection znaem kakvo e:
        tova e obekt ot koito nashiqt klas se nujdae i mu go 
        podavame prez konstruktura.

    vsichki klasove koito importvame v nashiq klas sa dependency-ta.
    loshoto obache e che gi preizpolzvame.


    VAJNOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Dva klasa koito zavisqt edin ot drug se narichat 
            ´coupled classes´


    Ako polzvame dumichkata ´new´ za suzdavane na nov klas znachi tova e Dependency.
    
    Daden proekt moje da zavisi ot daden framework i ako toi se promeni znachi 
    proekta se chupi.
    
    Kakto daden service moje da zavisi ot baza danni i ako q nqma dadena tablica, servisa 
    se chupi.
    
    Mojem da podadem samiqt klas prez konstruktura i da NE polzvame ´new´ keyworda.

    KAKVA E CELTA DA DEPENDENCY INJECTION ?
        01.Ako iskame da promenim podadeniq clas prez konstrukutra
            prosto mojem da go nasledim v drug klas i da dobavim kakvoto si poiskame
            sled koeto da gi polzvame v klasa v koito gi podavame.
            I mojem direktno da podadem NASLEDNIKA NA TOZI KLAS.
        
        02.Ne polzvame dumichkata ´new´, koeto e dobra praktika i ima po malko veroqtnost
            da se schupi neshto.   

        03.Klasovete koito polzvat Dependency Injection sa po guvkavi, v smisul ako primerno
            imame klas Latop koito polzva klas Bateriq i klas Videokarta,
            to ako nie gi podadem chrez konstruktura, polse kogato opitame da napravim klas 
            Laptop shte mojem da pravim razlichni laptopi s razlichni bateii i videokarti 
            
        04.Po lesno e da se proverqva i debugva.

    Samite komponenti v angular mogat da polzvat deendency injection. 
        i tova stawa samo chrez konstruktura dokato po princip
        dependency injection moje da se podawa i na funkciq ili property.

        komponentite se p

    Nai mnogo se pozlva konstruktur injection za klasove.


    Angular e konteiner koito handelva dependencyta.


*/

/*
    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!x
    Injectable:
        Za da polzvame dependency injection na daden klas v drug,
        purvi trqbva da markirame klasa koito shte podadem v konstruktura 
        kato @Injectable() VIJ FAIL HomeService.ts 
        I posle trqbva da go zapishe v app.modules.ts v masiva Providers .
        
        Sled koeto moje da go injectnem  !!!!!!!!!!!!

        Masiva Providers mojem da go zakachim i za samiq komponent
        i da go mahnem ot app.modules.ts obache togava shte vaji ne za vsichki komponenti
        v App komponenta a samo za HomeComponenta.
            VIJ FAil home.component.ts 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
  providers: [HomeService]
})

*/

/*
    Mojem da polzvame Redux za da podavame state, za da 
    ne pravim imame edin glaven komponent kakto naravihme v react

*/

/*
    Funkcionalno programirane:
        Tova e da podavame funkcii navsqkude po koda
        koito da izvurshvat po lesno operacii za nas.

        Polzvat se postoqnno vgradeni funkciiki kato
        .filter()
        .map()
        .reduce()
         ...
        
         vmesto da pishem for cikli navsqkude prosto polzvame 
         takiva kato gornite.

         Ulesnqvat mnogo rabotata s masivi i danni.

*/


/*
    Front-End programming:
        Tova programirane e asyncromno.

*/

/*
    Steam:
        Stream e potok ot danni koito postoqnno se izprashta
        kum brawsera ili aplikaciqta.
        Dannite NE se prashtat na vednuj.
*/



/*
    Observables:
        Te sa kato golqmi Promisi koito se razvivat postoqnno
        i mogat da izmestqt promisite i davat poveche funkcionalnosti.

    V Angular 2 kogato rabotm sus streamove se polzvat 
    Observables.

    Mogat da:
        suzdavat streamove, 
        subsribe na streamove,
        reaigira na values


    Obseravbles NE sa chast ot Angular 2, te sushtestvuvat mnogo otdvna,
    purvite sa bili napraveni ot Microsoft na C# i posle sa gi vmuknali 
    v ReactJS zashtoto sa se dosetili che shte budat mnogo polezni za front-end.

*/

/*
    RxJS: Reactive Extentions for JavaScript
        Tova ni implementira bibliotekata za Observalite za da mojem da gi 
        polzvame.

        let stream = Rx.Observavble.interval(1000)
            .take(5)
            .fromArray([1,2,3,4,5])
            .do(i => i.consoel.log(i));

        //taka suzdavame stream koito da vzima novo chislo vsqka sekunda do 5
        //inache samiqt sream e vechen
        //podavame mu masiv vurhu koito da raboti
        //i mu kazvame kakvo da pravi s dannite NO, ´do´ NE PORMENQ DANNITE, TOVA STAWA S .map !!!

        Mojem da se subscribvame s KOETO PUSKAME SAMIQT POTOK:
            obs.subscribe(i => console.log("Obrerver 1 received " + i))

            KATO SE SUBSCRIBNEM POTOKUT TRUGVA

        
        VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!
            EDIN OBSERVER E STUDEN KOGATO NQMA SUBSCRIBERI,
            BEZ SUBSCRIBER EDIN OBSERVER NE MOJE DA TRUGNE, TE CHAKAT NQKOI DA SE SUBSCRIBNE.

            TOPUL OBSERVER E KOGATO IMA NQKOI SUBSCRIBER.


        VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!
            Subscriberite ne sa spodeleni, t.e. izpulnqva se 
            edno i sushto neshto za vseki asynhromno po otdelno.
            
            AKO NAPISHEM .share() SEGA SE IZPULNQVA OPERACIQTA 
            EDIN PUT ZA VSICHKI I VSEKI OBSERVER SE IZPULNQVA ZA SEBESI.
            TOVA IMA RAZLIKA.

        .do() raboti sus stoinostite no NE gi promenq
        .map() promenq samite stoinosti
        .filter() tursim i selektirame
        .reduce() hvasht vsichki stoinosti i vruht edna generrana ot dadena funkciq
        .scan() podobno na reduce samoche vrushta vsichki stoinosti vmesto sam poslednata.

        DAVA NI MNOGO POVECHE OT PROMISE KOITO NI DAVA SAMO then() I catch().
        
        Mojem da go napravim na promise sus .toPromise()

        Mojem i da hvashtame grehki sus err
*/

/*
    HTTP Service:
        Vgraden e vutre v Angular.
        Polzva Observales i samo trqbva da se subscribvame kum tqh.

        Za da fetchvame danni trqbva da importnem HttpClient
        i da go slojim v app.modules.ts v imports masiva.
        Importvame go ot @angular/common/http !!!        
        
        Mojem da polzvame httpClient v komponentite za da fetchvame danni !!!

        Mojem i da hvashtame grehki sus err vuv subscribe-a.

        Post zaqvkite sa edni i sushti samoche sus body.

*/







