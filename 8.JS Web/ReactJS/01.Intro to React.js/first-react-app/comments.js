/*
    COURSE INTRO COMMENTS:

    Shte nauchim kak se polzva i sintaxisa no NE celiq framework (bibliotea) React.

    Za kursa shte trqbva da znaem HTML, CSS i JavaScript + Asynchonous Programming zashtoto 
    vsqka dna zaqvka e asinhromna osven ako ne polzvame async & await.


    Shte govorim za:
        01.JSX - TOVA E DIALEKTA NA KOITO SE PISHAT KOMPONENTITE NA REACT.JS TOVA E JAVASCRIPT V KOITO MOJEM DA NAPISHEM HTML,
        02.React - sintaxis,
        03.Redux,
        04.Asynhronous programming Redux

    shte govorim za komponenti i formulqri i rutirane. 

    Zashtitata na proekt e na 15ti IULI i e 6 chasa i MOJE DA STANE PO SKAYP

    React e biblioteka za renderirane (Templating) v koqto mojem da ishem ogika i toi ne ni dava nishto na gotovo.
*/




/*
    LESSON COMMENTS:
        React.js e front-end framework (biblioteka) i e mnogo gotin.
        NESHTO KATO HANDLEBARS SAMOCHE MOJEM DA SI PISHEM LOGIKA TAM, TAKA BECKEND SERVERA NI NE SE NATOVARVA S
        MNOGO IZCHISLENIQ I FRONTENDA SE GRIJI ZA PRESMQTANIQ I TAKIVA RABOTI + RENDERIRANE NA VIEWTA.


        PREDIMSTVA:
            Do predi uchehme Node.js i Express.js koeto e za pravene na serveri koito da vrushtat html viwta.
        
            No ima i drug nachin da obrabotvame danni i izchisleniq, da ne se sluchvat v servera a da se iznasqt na 
            samiq brawser i toi da q svurshi.

            Taka spestqvame rabota na nashite serveri zashtoto ako imame edno izchisleniq za edin user v nashiq server,
            ako imame 1000 usera stava malko trudno za servera zatova se podavat dannite na gotovo na brawsera i toi da si
            pravi izchisleniqta i da si renderira viwtata.

            React.js e framework za front-end na koito mojem da pishem logika, taka rabotata na servera stawa po lesna i ne 
            se natovarva zashtoto chast ot izchisleniqta se podavat na front-enda i toi si gi presmqta.

        NEDOSTATUCI:
            Obche loshoto e che mojem da imame ednakva logika i na servera i na front-enda.
            NA MOMENTI IMA DVOINA RABOTA OBACHE ZA USERA E PO DOBRE ZASHTOTO RABOTI KATO Single Page Application.

            Drug nedostatuk e che che slagame nov tool kum proekta i trqbva da imame nujnite znaniq za da po polzvame.

            Drug nedostatuk e SEO (Search Engine Optimization):
                Ako servera ni prosto vrushta HtML botove kato GOOGLE primerno mnogo go analizirat.
                Kogato imame Single Page Application SEO ne raboti chak tolkova dobre.

        
        
        Dobre e da go imame React.js v proektita no trqbva da go znaem, shte ni trqbva malko poveche vreme za razrabotka.
        SEO-to moje da ni spadne.

        FRONT END FRAMEWORCITE NE SA NUJNI NO E DOBRE DA GI IMAME.

        REACT E LESEN ZA UCHENE I E MNOGO BAZOV, NO NQMA MNOGO VGRADENI NESHTA ZA POLZVANE, NALAGA SE DA SVALQME 
            DOPULNITELNI PAKETI.
        
        ANGULAR.JS E OBRATNOTO, DAVA MNOGO NESHTA NA GOTOVO, NE E NUJNO DA SVALQME DOPULNITELNI PAKETI 
            OBACHE E MNOGO PO TRUDEN ZA UCHENE.         
        

        React.js e mnogo lesen za uchene, za 1 chas mojem da go nauchim.
        Vurshi pipaneto po HTML-a na front-enda





        Installation:
            Stawa mnogo lesno, samo s edna komanda v konzolata i sme gotovi, imame gotov i rabotesh app.
            npm install create-react-app



        History:
            JQuery e pradqdo na tezi frameworci zashtoto te go polzvat.
            No ako iskame da napravim neshto malko nqma smisul da vkarvame celiq framework, mojem prosto da polzvame samo JQuery.
            No ako celiqt ni sait e mnogo hyperAktiven mojem da polzvame front-end frameworci kato React i Angular.

            IMA I DRUGI FRAMEWORCI KATO Knockout.js OBACHE NAKRAQ IZLIZA  ANGULAR I             
            SE VODI NOMER 1.
            
            Angular.js e nomer 1 obache e mnogo baven i tejichuk, zatova izliza Rect.js koito
            e po lek i po burz no nqma mnogo vgradeni neshta, kato .NET CORE e.

            V nachaloto na React nikoi ne mu e obrushtal vnimanie no posle e zapochnal da se 
            polzva poveche.

            Polse izliza ANGULAR 2 koito e malko po burz i pak ima 150 neshta v nego.
            React.js SE PODDURJA OT FACEBOOK I E IZMISLEN OT FACEBOOK INJINER Jordan Walke.            
            Povecheto podobni frameworci se poddurjat ili ot facebook ili ot google. 

        React.js razdelq samata stranica na KOMPONENTI (Chasti) VSQKA EDNA CHAST SI IMA SOBSTWENA LOGIKA I HTML.    
        I Angular.js raboti taka.
        KOMPONENTITE IMAT DURVOVIDNA STRUKTURA.



        REDUX:
            Redux e malko po truden za svashtane ako ne sme rabotili s React.js do sega,
            NE SE POLZVA MNOGO ZA MALKI PROEKTCHETA.
            Shte vijdame REDUX prez kursa no ne e zaduljitelen na izpita.

            REDUX NI ULESNQVA RABOTATA S KOMPONENTITE.
            Primerno ako iskame kato kliknem daden buton da se skriva neshto chak na kraq na stranicata,
            nie trabva da minem prez vsichki komponenti KOITO SA DURVOVIDNA STRUKTURA za da otidem do dadeniq elementi i da go skriem.
            Tova na momenti e trudno zatova idva na pomosh REDUX.
		
			Redux ni slaga mnogo pravila za sledvane, ako reshim da go polzvame ne mojem da si pishem kofa kakto nie si iskame
			zashtoto proekta gurmi koeto e dobre zashtoto ni kazva kude kakvo trqbva da popravim.
			Redux ni nalaga disciplina i pravila za pisane na koda.
			PITAT ZA REDUX NA INTERVIEW-ta. 

			IMA SI SPECIALEN PLUGIN ZA DEBUGVANE NA ReDUX.



    INFO ZA REACT:
        React.js e open sorce koeto e mnogo polezno zashtoto moje da dobavqme novi neshta i da pomagame,
        ima mnogo golqm plus.

        Mnogo po e lesen za uchene ot Angular.js i e po lesen za debugvane.
        React.js RABOTI AVTOMATICHNO S DOM DURVOTO (HTMLa) TAKACHE NIE NE E NUJNO DA GO PIPAME DAJE.

        REACT MOJE DA BUDE IZOMORFEN T.E. DA SE RUNVA NA SERVERA KATO HANDLEBARS.

        MOJE I DA SE POLZVA ZA MOBILNI PRILOJENIQ.

        Mojem da imame normalni stranici i da imame Singel Page Application samo na dadeni mesta kudeto ni trqbva.

        ZA DA RABOTIM S REACT ni trqBVat DOPULNITELNI BIBLiOTEKI.



        Instalira se taka : 
            npm install create-react-app -g
            ili
            npm -g install create-react-app 
            

        Suzdavane na proekt:
            create-react-app nameOfApp


        Startirane:
            V papkata ot terminala "npm start" i puskame proekta i mojem da go vidim,
            avtomatichno se vkluchva.

        

        IMA I DRUGI VARIANTI NO TOZI E NAI BURZ ZA NACHINAESHTI V REACT


        STRANICITE SE PROMENQT DINAMICHNO !


        VAJNOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            "npm run build"    ni go pravi gotovo za "production", suzdava papka build
            v koqto samiq proekt e gotov za deployvane za userite. 


        React udurja samo JS obekti,
        React DOM pravi vruzka mejdu HTML-a i JS-a


*/


/*
   JSX:
        TOVA E DIALEKTA NA KOITO VURVI REACT.JS
        Mojem da pishem direktno HTML v JS faila.
        HTML-a i JavaScripta sa nabluskani v edno i prosto React.js prevrushta HTMLa v JavaScript.
        HTML-a NE SE PISHE KATO STRING.
        
        React.js e kato Handlebars samoche na steroidi, mnogo po mojshten e i moje da pravi poveche.
        V React.js logikata i viewtata ne sa po otdelno a sa zaedno v edin fail.     
        TUK KONTROLLER I VIEW SA SUBRANI ZAEDNO V EDNO.
        JSX VEDNAGA KOMPILIRA I NI KAZVA KUDE IMAME GRESHKA.

    
        Nai golemite front-end frameworci polzvat JSX i TypeScript no ne i chist JavaScript.
        Mixsira JS i HTML

        VMESTO class="..." SE POLZVA className="..." ZASHTOTO INACHE SHTE SE SCHUPI

        ZA DA RABOTI JSX NI TRQBVA REACT
*/

/*
    Conponents v React.js:
        Komponentite sa prosto klasove koito nasledqvat klasa React.component.


    MOJEM DATESTVAME REACT V www.codepen.io !!!
     


*/




/*
VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    PRIMER OT CODEPEN:


    
class AnotherComponent extends React.Component {
  render()
  {
    let anotherComponent = <InnerComponent />;
    return <h4></h4>
       
  }
}

//MOjemd da slageme komponenti v komponenti
class InnerComponent extends React.Component {
  render() {
    //tuk mojem da imame cqlostna logika s promenlivi, obekti i dr !!!  
    let message = "Inner Component";
    let obj = {
      name: "Atanas",
      surename: "Kambitov",
      age: 25
    }
    
    return <div>
           <h3>
            {this.props.innerMessage}, {message}, 
           </h3>
           <h4>
            Message From {obj.name} {obj.surename}. 
           </h4>
      </div>
  }
}
//komponentite sa prosto klasove nasledqvashti React.component klasa
//VIMAGGI SA SUS GLAVNA BUKVA INACHE NE STAWA.
class MainComponent extends React.Component {
  
  //za davurnem nqkolko elementa trqbva da sa v slojeni zaedno v edin element
  render() {
    
    //mojem da podavame vunshni propertita na dadenite komponenti i da gi setvame pri poluchavane. 
    //this.props si idva ot React i na nego mojem da zakachame kakvoto si poiskame.
    
    
    //mojem da slagame celiq komponent v promenliva
    let innerComponentVar = <InnerComponent innerMessage="Hello"/>;
    return <div>
      <h1>{this.props.message}</h1>
      <h2>Main Component !!!</h2>
      {innerComponentVar}
    </div>
  }
}



//taka renderirame html v dom elementa s id 'demo'
ReactDOM.render(
<MainComponent message="Hello"/>,//tuk setvame podadenoto property na komponenta koito izvikvame
document.getElementById('demo')
);



Ima si Google Chrome plugin za dabugvane na React proekti.
Kazva se React Developer Tools.


TypeScript e za tipizirane na JAVASCRIPT, polzva se mnogo v angular.


Redux ni slaga mnogo pravila za sledvane, ako reshim da go polzvame ne mojem da si pishem kofa kakto nie si iskame
zashtoto proekta gurmi koeto e dobre zashtoto ni kazva kude kakvo trqbva da popravim.
Redux ni nalaga disciplina i pravila za pisane na koda.
PITAT ZA REDUX NA INTERVIEW-ta. 


*/






