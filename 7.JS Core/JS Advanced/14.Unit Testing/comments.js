



    /*

    Error handling  -  Kogato primerno funkciqta SE izvika sus masiv a tq priema samo string
    Exception handling  -  Kogato samata funkciq se chupi i huvrlq exception
    Unit testing 
    Motha and Chai for Unit Testing


    Error Handling:
        Edna funkciq trqbva da izpulnqva tova koeto imeto i ni podskazva ili
        da pokazva daden problem, vsqko drugo povedenie e nekorektno.
        
        Tezi koito ne sa korektni trqbva da hvurlqt 
        Error, 
        Undfined,
        NaN,
        -1,
        ili hvurlq daden exception.
        
        Exceptioni:  -  Tova se sluchva kogato dadena fnkciq ne moje da si svurshi rabotata.
        01.Uncaught RangeError
        02.RangeError
        03.Uncaught ReferenceError
        04.ReferenceError
        05.Uncaught TypeError
        06.TypeError
        07.NaN(special value)
        08.Invalid Date
        09.NaN


        DATITE NA MOMENTI SE DURJAT STRANNO, NE NI HVURLQ EXCEPTION NO SE BAZIKA OT VREME NA VREME.

        Mojem sami da si hvurlqme exceptioni.


        KAKVOTO I CHISLO DA SUBEREM S NaN ni vrushta NaN.


    Exception Handling:
        Tova e variantut v koito programata hvurlq greshka ili
        nie iskame da hvurlim greshka.

        Greshkite se hvurlqt sus:
            throw new Error('...');
        Sus try{...}catch(...){...} E HVASHTA GRESHKATA.

        */

try {
    throw new Error('Ima Greshka!');
} catch (error) {
    console.log('--------------------------');
    console.log('Exception object: ' + error);
    console.log('--------------------------');    
    console.log('Type: ' + error.name);
    console.log('--------------------------');
    console.log('Error message: ' + error.message);
    console.log('--------------------------');
    console.log('Error stack: ' + error.stack);
    console.log('--------------------------');
}





/*
    UNIT TESTING:
        Pravim si testove s koito da si testvame koda,
        V realniq jivot nqmame judge zatova sami trqbva da si 
        testvame programata dali vsichko e vqrno.


        AAA Pattern:  Arrange, Act, Assert

        Arrange = Definirane na samiq input.
        Act = Izvikvane na samiq metod
        Assert = Sravnqvane na polucheniq rezultat s ochekvaniq
    


    PO PRINCIP NA VREMETO SA SE PRAVILI FUNKCII PRIMERNO testSum(){...} V 
    KOITO SA SE PRAVELI VSICHKI PROVERKI SUS IFOVE.




    VAJNO !!!
    NO SEGA IMA GOTOVI FRAMEWORCI ZA PRAVENE NA UNIT TESTOVE.
    
    Za Java: JUnit
    Za C#: NUnit, Visual Studio Team Test (VSTT)
    Za PHP: PHPUnit

    Za JAVASCRIPT: Mocha, Chai, QUnit, Unit.js, Jasmine ...


    Ne e trudno da pishem unit testove, trudno e da izmislim malkite neshta
    v testvaneto na i mnogoto po tranni scenarii.
    
    Primerno: Kakvo stava ako se podade slednoto?
    null, 
    undefined, 
    NaN, 
    otricatelni chislo, 
    mnogo golqmi chisla, 
    mnogo malki chisla  ...


    Sami trqbva da si izmislqme testovete.
    Moje da imame 100 testa koito da testvat edno i sushto neshto.
    No moje i da imame 10 testa koito da testvat mnogo poveche.



    
    NIE SHTE POLZVAME BIBLIOTEKITE 'Mocha' I 'Chai'.
    KAK SE INSTALIRAT:

    MOJEM DA GI INSTALIRAM 'GLOBALNO' (PREPORUCHITELNO) t.e. ZA VSICHKI 
    PROEKTI ILI SAMO ZA EDIN PROEKT t.e. 'Lokalno'

    GLOBALNO INTALIRANE:
    01.Otvarqme CMD i PISHEM: 
        npm -g install mocha
    02.Za Chai e sushtoto samoche pishem:
        npm -g install chai
    03.ZA GLOBALNO INTALIRAE NI TRQBVAT SLEDNITE 2 KONFIGURACII PAK V CMD-to:
        setx NODE_PATH %AppData%\npm\node_modules
        set NODE_PATH=%AppData%\npm\node_modules
    04.Trqbva da imame papka s ime 'test' v proekta za da se orientira 
        mochata !!!!
    05.Sled instalirane restartirame Visual Studio Code.

    VAJNO E PRI INSTALACIQTA DA NE PROPUSKAME -g TOVA E GLOBALNIQ FLAG, INACHE SHTE GO INSTALIRA SAMO
    V EDNA PAPKA I NQMA DA GO IMAME NA VSQKUDE..



    KAK SE TRIQT GLOBALNO ? 
        npm -g remove mocha
        npm -g remove chai


    VAJNO !!!!
        PREDI DA SE KAZVA JavaScript SE E KAZVAL 'MOCHA', POLSE 'WhiteScript' I POSLE 'JAVA'
        DAVA LICENZ NA 'WhiteScript' DA STANE 'JavaScript'.

        
    VAJNO !!!!
        ZA BECKEND I ZA SERVERNA LOGIKA SE POLZVA NODE.JS .
        ZA FRONTEND NE SE POLZVA NODE.JS ZASHTOTO BRAWSERITE NE GO PODDURJAT.  


        'expect' IDVA OT bibliotekata 'Chai' I OT NQ NI TRQBVA METODA 'expect' SUS KOITO STAVAT 
            TESTVANIQTA. POLZVA SE TAKA:
                expect(Sum([1,2]).to.be.equal(3);  KAZVAME CHE FUNKCIQTA Sum() S PARAMETRI MASIV OT
                STOINOSTI 1 i 2 TRQBVA DA VRUSTA 3.


        'describe' IDVA OT bibliotekata 'Mocha' I E ZA MNOGO TESTOVE OPISVA FUNKCIQTA I KAKVO 
            SE PRIEMA KATO PARAMETUR.
        'it' PAK IDVA OT bibliotekata 'Mocha' I E ZA EDIN TEST I AKO TESTA E GRESHEN VRUSHTA ERROR
            SUZDADEN OT NAS.



    VAJNOOOOOOOOOOOOOOOOOOOO !!!!!!!!
        MOJEM DA GO TESTVAME V TERMINALA ILI V CMD-to KATO VLEZEM V PAPKATA KOQTO 
        SUDURJA test PAPKATA I PROSTO NAPISHEM 'mocha', SHTE NI POKAJE KOLKO TESTOVE SA 
        VQRNI I KOLKO NE.


    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!
        TESTOVETE PO PRINCIP STOQT V OTDELEN FAIL, NE PRI SAMATA FUNKCIQ.
        ZA DA Q POLZVAE OT VUNHNIQ SVQT TRQBVA DA Q EXPORTIRAME PO SLEDNIQ NACHIN.
            module.exports = nameOfFunction;


    VAJNOOOO !!!!!!
        NA IZPITA NI SE DAVA GOTOVA FUNKCIQ I NIE TRQBVA DA NAPRAVIM TESTOVE ZA NEQ.
        


    //Sus before Each si refreshvame kalkulatora predi vseki test        
    beforeEach(function(){

    })



    ///IMAME I AFTER EACH
    afterEach(function(){

    })


    SUMMARY:
        01. Error Handling
        02. Exception Handling
        03. Unit Testing

*/







