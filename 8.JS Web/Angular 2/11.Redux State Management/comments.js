

/*

    Redux State Management :
        Redux e za manage na state-a ni.
        Doste se polzva i e udoben za reshavane na problemi.
        Kolkoto po golqmo ni stawa prilojenieto stawa po trudno da prenasqme dannite mejdu komponentite.
        Zatova polzvame redux.

        Ako imame glaven komponent s mnogo deca koito i te imat deca stava trudno ot nai vutreshniq komponent 
        da podavame dannite kum glavniq komponent zashtoto trqbva da minem rz vsichki komponenti mejdu tqh.
        
        IDEQTA E state-a se pazi v edno edinstveno mqsto v koeto da se promenq,
        komponentite ne promenqt direktno state-a.

        Malko e shantavo za razbirane i moje da otneme malko vreme, polzva se za po goqmi aplikacii.


        Redux NE e chast ot Angular ili React, to si e otdelno samostoqtelno neshto.
        Mojem da si go implementirame po nash si nachin, a mojem i da polzvame BIBLIOTEKI kato :
            01. NgRX Store
            02. NgXS - Tova e alternativa na NgRX Store


        SHTE GOVORIM ZA :
            01.Store & App State
            02.Actions,
            03.Reducers,
            04.Dispatching Actions

            05.NgXS - Tova e alternativa na NgRX Store




        KAK RABOTI REDUX?
            Komponentite nqmat pravo da promenqt state-a, za tqh toi e samo Readonly property !!!!!!!!!!!!!!!!!!!
            Te ne mogat da go promenat direktno !!!!!!!!!!!!!

            Ako iskame da promenim neshto v state-a vsichki komponenti razbirat za tova.

            Nqmame podavane na state mejdu komponenti, state-a se sudurja na edno mqsto.
            
            
            PURE FUNCTIONS:
                Tova sa funkcii koito poluchavat parametri i ne gi promenqt
                TE NE PROMENQT PARAMETRITE KOITO POLUCHAVAT.

            Redux polzva pure funkcii, vmesto da promenqt state-a vseki put toi prosto suzdava nov state.


            Data Flow (Potoka na danni) e vinagi ednoposochen t.e. dannite tekut samo kum edna posika.
            Dannite idvat ot state-a do komponenta.

            
            
            
            
            Po trudno e da zburkame neshto sus Redux !!!
            PO DOBRE E DA NE GO POLZVAME ZA MALKI PROEKTCHETA.


            Reducers:
                Tova e funkciq koqto promenq state-a, moje da dobavq neshto kum state-a ili da trie ot nego.
                Moje da filtrira primerno.
                Samo reducera moje da promenq state-a.

            Actions:
                Tova sa neshtata koito usera pravi koito sledovatelno promenq state-a.

            KAK SE DVIJI STATE-A ? 
                Redux ima konteiner na ime 'Redux Store' koito durji state-a i 'Reducer' koito da promenq samiq state.
                sled koeto state-a se izprashte kum viewto i stiga do usera koito chrez 'Actions' moje da 
                    dispatchne dadena promqna kum state-a.
                    I posle Reducera koito e v Redux store-a moje da promenq state-a.

                A samiq State sa prosto danni, moje da e spistuk s neshto primerno.




        NgRX :
            Tova e 'state management tool' s nego mnogo lesno obrabotvame state-a.

            Kak se instalira ?
                npm install @ngrx/store --save

        

        VAJNOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!
            Elementite koito podavame na lqvo na dqsno sa prosto modeli ili obekti.
            Neshtata za redux trqbva da sa v papka 'store'.

            KAK RABOTI VSICHKO V KODA ?
                01.Trqbvat ni modeli primerno interfeisi v otdelna papka.
                02.Trabva ni fail app.state.ts koito durji samiq state i e readonly.
                03.Actions, funkcii koito da manipulirat state-a i koito se polzvat ot usera

                Actionite imat type i payload,
                typa opisva kakvo pravi samiq action a payloada e parametur koito se podava prez constructura,
                v zavisimost ot kakvo pravi nashiq action.



            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
                Export type:
                    Definirame tip pri exportvaneto, primerno :
                    
                    export type Actions = AddCourse | RemoveCourse;
                        Sega kato polzvame Actions class mojem da mu podavame obekti SAMO OT TIP AddCourse ILI RemoveCourse
                        Polzva se mnogo vuv funkcii:

                        function(param : Actions){
                            //Sega parametura e ot tip AddCourse ili RemoveCourse
                            ...
                        }


            Reducers: 
                Te poluchavat Action i promenqt state-a na bazata na tozi action, suzdava nov state !!!
                01.Pravim si papka reducers i tam si pravim clas reducer.ts
                02.Reducera e prosto funkciq priemashta state i Action obache state-a ne moje da bude null
                    zatova go setvame oshte v nachaloto na masiv s daden obekt v nego
                03.Sled tova switch case-vame tipa na actiona i suzdavame nov state. 


            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!
            TRQBVA DA IMPORTNEM VSICHKO V app.module.ts :

            import { StoreModule } from 'ngrx/store'; 

            imports : [
                StoreModule.forRoot({
                    courses : coursesReducer     //kazvame che za courses se griji coursesReducer 
                })
            ]
            


            NgXS : 
                Tova pravi absoltno sushtoto neshto kato NgRX samoche ima drug sintaksis.
                Pesti pisaneto na mnogo failove, tuk nqmame reducer fail, toi si e pri actionite.
                Ima i oshte razliki no neshtata kato cqlo sa identichni.
                
                Instalaciq:
                    npm install @ngxs/store --save
                    ima i specialni plugini


                NgRX e po populqrno zashtoto e ednakvo navsqkude s koqto i tehnologiq da programirame Reduxa shte e ednakkuv.
                Za poveche informaciq procheti dokumentaciqta.


        ZADULJITELNO PREGLEDAI CQLATA PAPKA 'store' V ngrx-demo PROEKTA !!!!!!!!!!!!!!!!!!!!!!!!!!!!
*/
