/*
    Na izpitniq proekt shte polzvame template driven formi.


    Direktivi:
    
    Ima 3 tipa:
    01.Komponenti
    02.Strukturni direktivi *ngIf() i *ngFor()
    03.Attributni direktivi, te promenqt css-a
    
    Mojem da si pravim nashi si sobstveni custom Attributni direktivi.
    
    Vij faila directives/highlight.directive.ts !
    
    Za da vurvi trqbva da go imortnem v app.module.ts



    Pipes:
        Tova sa gotovi funkciiki ot angular kato 'uppercase', 'lowercase' i oshte mnogo
        koito se polzvat v templeita polzvaiki '|' !!!

        Mogat da se chainvat, mojem da imame mnogo | na edno mqsto.
        Polzvat se za formatirane na stringove, dati i oshte.

        Mojem da si pishem i nashi si pipove, vij faila pipes/capitalize.pipe.ts

        Za da vurvi trqbva da go imortnem v app.module.ts





        Instalirane na bootstrap:
            Vzimat se gotovi temi na bootstrap ot https://bootswatch.com/
            zapazvat se vuv fail vuv papkata assets v proekta i
            se zapisva faila v 
            architect: {
                options: {
                    styles: []
                }
            }

            Ili prosto se kopita css-a v styles.css 


        VAJNOOOOOOOOOOO!!!!!!!!!!!!!!!!!
            GUARD oznachava klas koito da proverqva neshto, primerno dali sme lognati 
            ZA DA MOJEM DA DOSTUPIM DADENA STRANICA, INACHE VSEKI MOJE DA PROMENI LINKA !!! 
            IMAT FUNKCIQ canActivate koqto opredelq dali mojem da dostupim daden route !!! 

            Tezi klasove polzvat vunshni funkcii kato:
            checkIfLoggedIn(){
                ...    
            }

            KATO GI NAPRAVIM GI POLZVME V SAMIQ ROUTER.
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] }, // we use our guard 
            

            MOJEM I CHREZ TQH DA REDIRECTVAME 

            VJ PAPKATA guards !!!   

            Primerno edin ne authentikiran user da ne moje da dostupi dadeni putishta.
            Pravim si papka 'guards' i si q pulnim s gardove

            MOJEM DA GI GENERIRAME SUS CLI, t.e. terminala:
                ng generate guard GUARDNAME ili
                ng g g GUARDNAME

            generirame gi s CLI i gi mestim v guards papkata.

        VAJNOOOOOOOOO!!!!!!!!!!!!!!!
            Redirektva se sus Router ot @angular/router; i polzvame metoda
            router.navigate(['/home'])  OBACHE ISKA MASIV, NE ZNAM ZASHTO.


*/


