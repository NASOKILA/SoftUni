/*
    Best Practices:
        Struktura na proekt
        
        01.Code Style - podredba na koda,
        02.Architecture - papkite v proekta,
            Modules - takiva kato App
        03.Unit Testing - Mocha
        04.Lazy loading - Proekta e po lek kato raboti s moduli,

*/


/*
    01.Code Style:
        Edno neshto otgovarq samo za sebesi.
        Edin klas ne trqbva da deendva ot drug, polzva se dependency injection
        Edin klas otgovqrq samo za edno neshto.
  
        Ostanaloto e qsno.
*/

/*
    02.Architecture>
        Papkata assets e prazna pri suzdavaneto na proekta.
        Polzva se za globalni resursi polzvane ot proekta kato snimki, bootstrap i dr.

        V components papkata sa vsichki komponenti
        V core papkata sedqt modelite, interfeisi, guardove, interceptori i servisi.

        Imame dva vida modeli:
            Modeli za displeivne s koito vzimame samo dannite koito ni trqbvat,
            Modeli za two way binding.

        VAJNO !!! :
            Skriptove ili stilove ne se slagat v glavniq index.html zashtoto bavi proekta mnogo.
            Slagat se v angular.json :
                "styles": ["TUK"]
                "scripts": ["TUK"]


        VAJNOOOOO!!!!!!!!!!!
            V app komponenta ne se slaga nikakva logika
            Trqbva da e chist nashiq glaven komponent


        Modules:
            Modulite se suzdavat za da durjat logika i mnogo komponenti,
            nqma smisul da se pravi samo za edin komponent.
            Moje da se suzdade ako saita ni obslujva cars ili books ili drugo. 
            Mojem da generirame moduli kato app prez konzolata.
*/


/*
    Unit Testing:
        pishem gi vuv .js faila v daden komponent.
        Na momenti moje da se okaje gubene na vreme no ot druga strana e hubavo da gi znaem.

        V po malki firmi ima poveche naprejenie i nqma da ima vreme za unit testove.
        Obache v po golqma firma koqto si go ima kato princip tova da se pishat unit testova znachi shte pishem.

        Ima 3 vida testvane na produkt:
            01.Unit testing - tuk testvame dadeni funkcii, klasove ili propertita,
            02.Integration testing - tuk se testva s poveche failove, polzvaiki servisi, testvat se i zaqvki i sa po golqmi i po hubavi,
            03.System testing - more important, tuk se testvat po malko neshta, testva nesht po sistemata, routinga i dr.


        KAK SE PRAVAT UNIT TESTOVE V ANGULAR ?
            V Angular 2+ NE se polzvat chai i mocha
            Tuk prosto ako iskame da testvame nqkoi .ts fail prosto si pravim
            drug fail sus sushtoto ime koito da zavirshva na .spec.ts


//importvame si funkciqta koqto iskame da testvame
import { compute } from '../01-fundamentals/compute';

//vsichko zapochva sus describe() funciq priemashta dva parametura ot koito purviq e samo opisatelen
describe('Testing compute function ...', () => {
    
//testovete zapochvat sus it() funciq priemashta dva parametura ot koito purviq e samo opisatelen
    it('Should return zero if number is negative', () => {
        
        //testvame si funkciqta
        const result = compute(-1);

        //pishem expect za da proverim rezultata
        expect(result).toEqual(0);
    })
})


VAJNOOOOOOOO!!!!!!!!!!!!!!!!!!
    Mojem da polzvame funkciikite beforeEach() i afterEach()
    v Angular sa suhtite kakto v plain JS
    Mojem da testvame klasove i tehnite konstrukturi i dali edin klas
    sudurja dadeno property.

//KAK GI PUSKAME ?
    V Angular Imame vgradeni jasmine-core i karma paketi s koito mojem da si pusnem testovete 

    Pishem v konzolata  'ng test' i ni otvarq otdelno prozorche v brawsera koeto ni pokazva rezultatite

    VAJNO!!!!!!!
        AKO IMAME MNOGO TESTOVE I ISKAM DA PUSNEM SAMO EDIN, PISHEM 'f' PREDI 'it(){}' FUNKCIQTA, IZGLEJDA TAKA:
            fit(){...} I SE PUSKA SAMO TOZI TEST


*/







/*
    Vajno !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ng build pravi proekta po maluk i go prigotvq za deploivane v production. 

        ng build --dev go buildva za development
        ng build --prod go buildva za production sreda

        redux NE se polzva z malki aplikacii.
        No mojem da si go razcukame ako iskame da vzemem bonus.

        Ako iskame neshto da e vidimo za celiq proekt ni trqbva da go exportnem.

        Pri generirane na model nqmame "export" : [] masiv po defaullt, TRQBVA DA SI GO DOBAVIM

        V providers : [] MASIVA dobavqme samo Injectable neshta, ne mojem d dobavqme komponenti.


        V samiq routing mojem da polzvame Gardovete sus canActivate : [guardName]


        MNOGOOO VAJNOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        OnDestroy(){} : 
            Kogato se subscribnem kum neshto, dori i da menim stranicata tozi subscribe produljava da si teche
            dori i da iztriem samiq komponent. 
            Datata si vliza i sled vreme se poluchava MEMORY LEAK.
            Za da se spre tova se polzva OnDestroy();

            importva se ot @angular/core zaedno sus OnInit(){}

            Kak se polzva ?
                Mojem da deklarirame promenlivi kato slednata "book$" s dolarche otzad
                koeto oznachava che pazi subscription kum observable.

                Setvame q na subscriptiona :
                this.book$ = this.bookService.gtAllBooks().subscribe();

                Sled koeto mojem da q unishtojim v OnDestroy(){} metoda taka : 
                    OnDestroy(){
                        this.book$.unsubscribe();
                    }


                MOJEM DA IMAME MASIV SUS SUBSCRIBTIONI I POSLE OT OnDestroy DA GI UNSUBSCRIBNEM VSICHKI !!!
*/


