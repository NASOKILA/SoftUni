
/*
Routinga e urla koito ni mapva stranicite i ni pozvolqva navgaciq,
tuk obache tova ne se sluchva v servera a na samiq framework.

Pri single Page App  sme vinagi na edna stranica koqto rnderira razlichni neshta i dannite v stranicata ne se prezarejda
vij gmail.com.
V react e podobno zashtoto ne se prezarejda strranicata kato kliknem na daden link a se posochva komponenta kotio 
trqbva da se renderira..
Hubavoto e che loadvame vsichko vednuj i posle polzvme smo promenite.
Po dobre e za usera zshtoto e po lesno  i burzo.
V react nqmame instaliran ruter po default, no go ima kato otdelna biblioteka koqto mojem da polzvame.   
Mnogo e lesno tova e prosto komponnt koito nasledqva Route komponent..    

Instalitane na rutera:
    01.npm install -g react-router           - Sudurja obshti neshta za routinga
    02.npm install -g react-router-dom       - Tova e routing v brawsera - Tova ni e BrowserRouter
        MOJEM DA INSTALIRAME SAMO VTOROTO KOETO SHTE INSTALIRA I PURVOTO.
    

    Kak se polzva ?
    sled instalaciq se importva  BrowserRouter ot 'react-router-dom'vuv index.js faila i posle 
    se wrapva <App/> componenta v tozi BrowserRouter komponent:
    <BrowserRouter> 
        <App />
    </BrowserRouter> 

    Sega mojem da go polzvame v App.js po sledniq nachin:
    Importvame go purvo : 
        import {Route} from 'react-router-dom';

    Posle go polzvame za da mapvame orutovete s komponentite taka:
        <Route path="/home" component={Home}/>   -   Sega obache shte se renderirat i routove kato /home/user/121231235

    Ako iskame da se renderira komponenta Home samo na route-a  /home trqbva d pozlvame 'exact':
        <Route path="/home" exact component={Home}/>   -   Sega /home/user/2731237 NQMA DA RENDERIRA TOZI KOMPONENT !!!!



    CELIQT ROUTER MOJEM DA GO IZNESEM V OTDELEN KOMPONENT ZA DA E PO PODREDEN KODA !!!




    MOjem da si napravim vichki mapove na route i funkciq v otdelen fail i posle da go polzvame v App.js
    Mojem da polzvame Route ot 'react-route-dom' kato otdelen element po sledniq nachin.

    
        MOJEM DA RENDERIRAME KAKVOTO SI POISKAME NA KOITO I ROUTE SI POISKAME.
        <div>
            <footer>My Footer</footer>
            <Route path="/random" render={() => (
                 <h2>Random Router Function Return.</h2>
            )}/>
        </div>

    */




    /*
    Navigation Links:
            Linkovete v navigaciqta moje da sa <a></a> tagove 
            no taka shte se prezarejda stranicata.
            
            Za da ne stawa tova polzvame Link ot 'react-router-dom' 
            taka nqma prezarejdane na stranicata s.l. aplikaciqta raboti kato SPA (Single Page App)


            Imame Active Links:
                mojem da razlichavame koi link e aktiven i samo nego da pokazvame
    
    */


    /*
        Switch:
            Ako imame dva ednakvi routa shte vzeme purviq.
            importvame si go ot 'react-routing-dom'
    */

    /*
        URL Parametri:
                <Route path={/catalog/:category/:userId} component={...}/>
    
            Komponentite se durpat taka:
                this.props.match.params.category
    */

    /*
        Redirect:
            Prosto ni redirectva importvame si go ot 'react-routing-dom'
    */

    /*
        Query Strings:
            
    */


