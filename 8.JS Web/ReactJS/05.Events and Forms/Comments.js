


/*
    Pri reakt formite sa na ruka.
    Ne e trudno no ne e na gotovo.
    V Angular e na gotovo.


    Shte govorim za:
        01.Handing Events,
        02.Managing forms
        03.State vs Props,
        04.Component Composition


    
    01.React Events:
        podobni sa na tezi ot DOM durvoto, polzvat si sobsveni eventi.
        Polzva edin obekt koito e encapsuliran i raboti za vsichki brawseri.

        Kato cqlo eventite sa ednakvi.
        Mojem da hi zakachame na HTML elementi.
        Razlikata e : 
            click -> onClick
            change -> onChange
            focus -> onFocus
            ...

        Eventite NE se polzvat asinhromno.

        
        Pooled Events oznachva che eventite se zachistvat sled izpulnenieto na funkciqta
        Sledovatelno ne mojem da se tvame eventa ili da go zapazvame v promenliva 
        zashtoto sled kraq na funkciqta toi e zachisten.
        NO MOJEM DA VZIMAME STOINOSTTA NA EVENTA.


        'prevent default' OZNACHAV DA MAHNE DEFAUTNOTO POVEDENIE NA NESHTO.

        Vajno e da apomnim che ni trqbva d apolzvame 'state' i che trqbva da bindvame funkciite 
            koito polzvame, nai dobre e da gi bindvame v konstruktura zashtoto se minava ot tam samo vednuj. 

            Za vseki event shte ni trqbva funkciq, koqto poluvhabva (event) !!!





        02.State vs Props:
            'state' mojem da go promenqme dokato 'props' sa readOnly
            Te se podavat ot vunka i gi polzvame za da podavame informaciq.
            Mojem da iznesem state-a v edin komponent i posle da go polzvame v drugi.

            Vajno e da slagame id-ta za elementi na masivi zashtoto taka react 
            razgranichava elementite edin ot drug.
            I TRQBVA DA GI DOBAVQME KATO KLUCHOVE KOGATO RENDERIRAME !!!


        KOGATO ISKAM DA PODAM NESHTO OT EDIN KOMPONENT KUM DRUG PURVO MU PODAVAM
        CHREZ 'props' FUNKCIQ KOQTO DA POLUCHVA TOVA NESHTO KOEto MI TRQBVA.


        VAJNO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Edin komponent moje da bude izpolzvan kato normalen HTML element s drugi lementi vutre v nego.
            Tezi elementi v nego vlizat pod 'this.props.children' koeto e masiv !
            Primer:
                <ContainerComponent>
                    <h1>Hello</h1>      
                    <h2>World</h2>
                </ContainerComponent>

                'Hello' i 'World' vlizat kato masiv ot elementi pod 'this.props.childern' na ContainetComponent ª!!!!



        'npm install prop-types' Tova ni zashtitawa ot nevalidni podadeni ot usera propertita.
        Primerno nie ochakvame string no ni se podava 'true' i ni se chupi vsichko, zatova polzvame 
            prop-types za da se usigurim che tipovete na dannite sa pravilni.
            Ako ne sa, togava ni hvurlq exeption.


        Trqbva da imame glaven komponent koito da durgi state-a i da polzva drugite komponenti
*/  









