/*
    Angular e framework ot google.
    Ot Angular 2 nagore se pishe na TypeScript.

    Nie shte rabotim s Angular 6 zatova shte nitrqbvat node.js ot 8.00 na gore 
    i npm ot 6 na gore.

    Shte razgledame :
        Components Basics,
        Creating Components,
        Boootstrapping & Modules,
        Data Binding & Templates,
        Lifecicle hooks,
        Component Interaction,
        Services with Fake data
*/

/*
    Mojem da podavame danni ot glavniq komponent kum ostanalite komponenti
    i obratnoto.

    V Angular se polzvat Servisi sus dependency injection za vruzka s bazata.
    
    Tuk nqma new Class ...  
*/


/*
    S modulite mojem da inkapsulirame logika.

    Komponentite sa kakto pri ReactJS, vsichko vodi kum SPA (Single Page App).
   
    @Component ({
        selector: 'app-root',    // Imeto koeto polzvame za da izvikame komponenta
        template: '<h1>Welcome {{ Username }}</h1>',   //Moje da bude i TemplateUrl kum nqkoi HTML fail
        styles: [ h1 {
            background-color:red;
        }]                                     //Moje da bude i StylesUrl kum nqkoi CSS fail
    })

    Kak se izvikva ?
        <app-root></app-root>

    Vsichko trugva ot App-root Komponenta.


    KAK SE SUZDAVAT KOMPONENTI ?
        Ami suzdavat se chrez terminala ili cmd-to,
        otivame v papka 'app' i pishem komandata: 
            'ng g c ComponentName'     Stands for ng Generate Component ComponentName !!!!
        ILI
            'ng generate component componentName'

            I NI GENERIRA NUJNITE FAILOVE KOITO SA 4 : html, css, js i ts failove
            MOJEM DA SI GI SUZDADEM NIE PO OTDELNO NO IMA VARIANT DA ZBURKAME ZATOVA E DOBRE DA
            POLZVAME CLI ot CMD-to

            VAJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!
                Kogato go suzdadem chrez cmd-to avtomatichno ni go importva vuv app komponenta !!!!!!!!!
                I ni suzdava i js failche za unit testove !!!


VAJNOOOOOOOOOOOOOOO!!!!!!!!!!        
  ngOnInit() {
    //this is a lifecicle hook that is executring before the html i srendered
    //like ComponentDidMount in ReactJS
    //this comes right after the constructor
  }


*/

/*
    Ima lesno pravene na eventi.
    Lesno se baindvat dannite ot formi.

*/



/*
Logika vuv viewtata:

    for loop:
        <li *ngFor="let car of cars">
            <div>
                {{car.Model}}
            </div>
            <div>
                {{car.Price}}
            </div>
        </li>

     if statement:
        <span *ngIf="game.price >= 100">-> Price: {{game.price}}</span>
*/


/*
  Events and Binding:

  <button (click)="showContent($event)">Show Content</button>

    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        KOGATO VZIMAME DANNI OT VIEWTO GO PRAVIM SUS () 
        A KOGATO DAVAME DANNI NA VIEWTO GO PRAVIM SUS {{}}, Ima i drug nachin sus []


    MNOOOOOOOOOOGOOOOOOOOOOOOOO VAJNOOOOOOOOOOOOOOOOO !!!!!!!!!
    Two Way Binding:
        Oznachava: 
            Kogato vzemem neshto ot koda i go promenim vuv view-to togava avtomatichno
            da se promenq i samoto property s modela (koda).
        
        Pravi se sus [()], naricha se banana in the box.

        <img [src]="game.image" width="300px" alt="No img avalible"/>

        Mojem da polzvame ternlni operatori v logikata v html-a

*/


/*
  NIKOGA NE PISHI STILOVE VUV HTML-a
*/


/*
  Input poleta: 

    <input #name placeholder="Name"/>
    <button (click)="showName(name.value)">Send</button>

  Ima i drugi nachini za bindvane cher bindvane na poleta.
    */




/*
  Mojem da prilagame bootstrap v angular
  samoche bootstrap 4 e mnogo bugav i na mesta moje da se schupi osobeno
  ako pishem na angular 5.
  
  Nikoga ne polzvai document.getElementById
*/

/*
  Angular augury:
    Tova e extension za debugvane na angular v Google Chrome.
*/


/*
  Two way binding se sluchva ot input poleto.
  i promenq propertito v momenta v koito nie go napishem v poleto
  bez da sme cuknali na butoncheto,

  Two way binding se polzva chesto pri formichki kato Edit, i kato cuknem na
  butoncheto samo tovaga da se izprashta novoto neshot v bazata s veche promenenite 
  propertita ot nashite html poleta.
*/





/*
  life cicle hoks:
    tova sa vgradeni funkcii kato ComponentDidMount v ReactJS
    v koito mojem da pishem dadena logika za komponenta.
    ngOnInit(){} se izpulnqva venaga sled konstruktura.

    kato useri mojem da se zapisvame i otpisvame na daden hook za informaciq

    Imame mnogo hookove no nai polzvanite sa:
        ngOnDestroy(){} koeto se izpulnqva sled unishtojavane na daden hook.
        ngOnChange(){} koeto se izpulnqva sled promqna na daden hook.

        PO PRINCIP TAM PISHEM ZAQVKITE KUM BAZATA.
        NIKOGA NE PRAVETE VRUZKA KUM BZATA OT FRONTENDA !!!

    Component Interaaction:
        Kak da komunikirat dva komponenta pomejdu si i kak si podavat danni
        edin na drug.
        Podavat se neshta na HTML elementite v komponentite kato parametri        
        
        Mojem da podavame informaciq na samiq komponent:
            <app-subscribe [subGame]="game.id" ></app-subscribe>

        Ima dva nachina:
            From Child to Parent - Trqbva da importnem ´Input´
            From Parent to Child - Trqbva da importnem ´Input´, ´Output´ i ´EventEmmitter´

            Bashtiniq komponent trqbva da razbere za daden subscription kum daden komponent.

        LESNO E.
             
        Komponentite trqbva da mogat da se preizpolzvat,
        moje da imame edin komponent koito da pravi razlichni neshta sprqmo parametura koito mu
            podavame.



    ZA NAPRED PAK SHTE IMAME ROUTER KOITO DA MATCHVA KOQ ROUTE NA KOI KOMPONENT DA OTGOVARQ.
*/


/*
  Summary:
    Vajno e da zapomnim kakvo e :
        selector - ime na komponenta za izpolzvane,
        template & teplateUrl - html i put kum html fail,
        styleUrls - masiv s putishta do .css failove.

        ngOnInit(){} - vgradena funkciq (lifecicle)  izpulnqvashte se sled konstrutura,

        NE SE PISHE CSS V HTML-A
        
        Mojem da podavame logika mejdu komponentite kato gi nestnem,
        t.e. slagam ediniq v drugiq komponent i podavame logika nagore i nadolo.

        Podvane na danni ot view kum Koda se pravi sus (), ako pravim obratnoto
        se polzvat [] !!!
        Imame i two way binding koeto se pravi sus [()] Banana in the box
*/



