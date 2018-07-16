

/*
    Shte govorim za:
        01.Componenti
        02.props - Properties in the Components
        03.State in Components
        04.Component Lifecicle and what can we do with it
        05.Fetching Data - durpane na danni ot otdelechen server


    S Reakt mojem da pravim sushtoto kato s JQuery samoche po burzo i lesno.


    01.Components:
        Te sa kato funkciite, malki parcheta kod koito mojem da preizpolzvame.
        Primerno edna stranica moje da se razdeli na komponenti kato navigaciq, ndolo footer i dr.
        vsichko moje da bude izneseno v komponent koito da vrushta daden HTML.
        Polzvame gi mnogo chesto kogato se povtarq HTML kato partials v Handlebars !!!

        Komponentite imat propertita na koito mojem da zakachame kakvoto si iskame i da go preizpolzvame,
        kato {this.props.name}, zahachame vsichko na this.props.

        Imat i State ( sustoqnie  ), 
    
        Komponentite sa funkcii koito vrushtat HTML !!!


    02.Props - Component Properties
        Te sa ReadOnly i idvat kato parametri v Componenta
        Polzvat se za da podavame otvun danni na komponent za da
        se razlichava na dadeni mesta zashtoto moje edin komponent da se polzva na mnogo mesta. 
            
        Primerno mojem da imame nqkolko butona koito da sa edin i sush komponent obache da imat razlichen 
        text i da sochat na razlichen adres.


        Za komponenti mojem da importnem Components klasa ot React ili da go polzvame direktno.

        Komponentit moje da da ni izneseni v otdelna papka i posle da gi importnem v glavnta papka.


        KOGATO IZPOLZVAME HTML V JAVASCRIPT (JSX) E ZDULJITELNO DA IMAME React INSTALIRANO. 


        Mojem da si pravim css za vseki edin komponent


        MOjem da polzvame propertita ot daden obekt i sus {...NameOfObject} da gi destruktorirame da rabotqt za 
        dadeniq komoponent pri izvikvaneto im.


        VAJNOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!
        Ima saitove kato http://jsbeautifier.org/  v koito mojem da slojim SBIT js ili html kod i da ni go napravi krasiv.





    03.Component State:
        Ideqt na state-a e da mojem da promenqme nqkkvi danni,
        primerno kato kliknem na nqkoe butonhe da se smenq dadeno neshto.    
        Ili da se dobavq nesjto v nqkkuv kontainer ili da se maha, tova pak se vodi kato promqna.

        TUK NE POLZVAME 'props' !!!

        VAJNOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!
            State-a se namira na {this.state}
            I ako iskame da go polzvame shte ni trqbva constructor v komponenta koito da podava props na gorniqt klas.
            I trqbva da inicializirame defoutnoto sustoqnie na state-a
            constructor(props){
                super(props)

                this.state = {
                    count:0,
                    color:'red',
                    isDisabled:false
                    ...
                }
            }

            super() izvikva na bazoviq klas konstructura.

        VAJNOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Ako iskame da go promenqme nqkude na dolo trqbva da pozlvame 
            
            this.setState({
                ...
            }) 

            funkciqta koqto updeitva state-a, tq e zvtomatichno zakachena za kontexta 'this'


        VAJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ZA DA ACTIVIRAME NQKAKVA FUNCIQ CHREZ BUTON TRQBVA :
                this.NameOfFunction.bind(this) ILI (e) => this.NameOfFunction(e)  
                
                Sus .bind() kazvame kakuv da bude 'this' za tazi funkciq.
                AKO FUNKCIQTA E ARROW FUNKCIQ ZNACHI 'this' SOCHI NA TAM OT KUDETO SME IZVIKALI DADENATA FUNKCIQ


        Sus sustiqnieto ( State ) nie mojem da promenqme neshta po HTML-a bez da go pipame direktno, 
        po princip state-a e obekt s propertita v nego.
        Mojem da proemnqme cvetove kounteri, dali neshto e disabled ili ne.

        POLZVAME 'this.state' ZA DA MANIPULIRAME DANNI ZASHTOTO 'this.props' E ReadOnly I NE MOJEM DA GO PROMENQME KOGATO SI ISKAME,
        MOJEM SAMO DA GO PODPUHVAME.




        
    04.Component LifeCicle:
        React izpulnqva dadeni eventi pri vsqko edno neshto, prierno kogato suzdadem component se suzdava edin event,
        kogato renderirame se fireva drug i taka na tatuk.
        Tezi eventi ili funkcii idvat na gotovo i sa zakacheni za kontexta i se kazvat 'Hooks'.
        Mnogo ot tqh nqma nikoga da gi vidim no e vajno da nauchim samo nai vajnite.

        01.componentDidMount() - Izpulnqva se kogato renderirame neshto na ekrana sled koeto mojem da pravim AJAX requesti kum dadeni serveri.
        02.componentWillUnmount() - Izpulnqva se kogato komponentut poluchava dadeno properti  
        03.componentWillReceveProps() - Izpulnqva se kogato se iztriva daden element ot DOM Durvoto, POLZVA SE ZA DA MAHNEM NQKKUV Event Listener 
            PRIMERNO ZA DA NE SEDI IZLISHNO.
        04.componentDidCatch() - 
        05.componentDidUpdate() - Izpulnqva se pri updeitvane na neshto v samiq komponent

        IMA I OSHTE MNOGO NO SA MNOGO SPECIFICHNI I NE SE POLZVAT MNOGO.

        Polzvame tezi funkcii koito gi imame na gotovo predi da se e sluchilo neshto za da pusnem neshto koeto iskame nie,
        primerno nqkkva funkciq. 






    05.Fetching Data from another server:
        Polzva se vgradenata funkciqta fetch() koqto e promise t.e. mojem da polzvame .then() i .catch()

        fetch('https://www.google.bg/')
            .then((res) => {
                console.log(res)
            })
            .catch(err => console.log(err))

        Samoche nqkoi brawseri kato Google Chome ni zashtitavat ot tova i shte hvurlqt greshka v konzolata.


        Zaqvkite v Rect se pravqt sus vgradeniq fetch() metoda !!!!!!!!!!!!!!!!!!!!!!!!!!!
*/













