


/*

    Shte razgledame :
        Moduli, 
        Babel, 
        RequireJS,
        Other JavaScript Module System,
        ES6 Etma Script 6,
        Formats and Loaders


        Kakvo e Modul ?
        Modulqrnost e da mojem da si razdelqme proekta v razlichni failove, taka po lesno 
        se raboti.
        Ne e mnogo hubavo da imame vsichko v edin fail.
    
        Durji ni globalniq skoup chist.
        zarejda samo failovete koito a ni nujni i pri greshka ni 
        pokazva v koi fail se e sustoila.
        Po lesno se raboti kato koda e podreden i razpredelen vuv failove.

        'module.exports = ...'  -  exportva dadeno neshto za da moje da se polzva v drugi failove
        'require(pathToFail);'  - vzimame dadeniq klas, funkciq ili tov koeto exportva faila 

        ako exportvame obekt: module.exports = {nameOfClass}   posle trqbva da go izvikame 
        taka require(pathToFail).NameOfClass


        VAJNOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!
            Mojem ot edin fail da vrushtame nqkolko klasove ili funkcii ...
            module.exports = { classOne, ClassTwo, FunctionOne, FunktionTwo }


        REVEALING MODULE PATTERN:
        Tova e da imame IIFE koeto da vima nqkakva logika i da vruhta obekt. 

        FORMATS:
         01.Common.js    -    Polzva se ot Node.js
         02.ES& Format,
         03.Asunchronous Module Definition    ( AMD )
         04.System.register
         05.Universal Module Definition  ( UMD )


        LOADERS:
        
        01.RequireJS: TOI POLZVA NODE.JS 
            RequireJS e biblioteka koqto ni pozvolqva da rabotim s AMD formata
            PRI NAS RABOTI I S NEGO IMPORTVAME NESHTA OT DRUGI FAILOVE V TEKUSHTIQ FAIL
            OBACHE V BRAWSERA NQMA DA STANE ZASHTOTO NQMA NODE.JS   

        02.SystemJS: Dobre e za survurna implementaciq
            SUPOTVA I PETT GORNI FORMATA.


        AMD & RequireJS:  -  Tova sa biblioteki
            KAK SE INSTALIRA RequireJS ?
            PISHEM NA KONZOLATA    
                npm install --save requirejs           //--save oznachava da go zapazi v 'package.json' faila v node modules papkata
            
            MOJEM I DA Q INSTALIRAME GLOBALNO:
                npm install --save systemjs

            ili da go svalim ot requirejs.org


        VAJNOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ZA DA IMPORTVAME I EXPORTVAME FAILOVE V BRAWSERA NI TRQBVA BIBLIOTEKATA 
            'Require.js'

        FORMATA E MALKO RAZZLICHEN:
        define([ 'TUK IMPORTVAME, OPISVAME PUTQ' ], function(){

            //TUK SI PORAVIM S LOGiKATA

            return {
                //EXPORTVAME TOVA KOETO ISKAME 
            }
        })

        VAJNOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!
            Kato importvame nqkakvi skriptove v HTML fail trqbva da vnimavame 
            v kakuv red gi importvame zashtoto sa zavisimi edin ot drug.






        CommonJS:    
            COMMONJS E NORMALNIQ NACHIN, SUS require(...); I module.exports = ...;
            
        SystemJS:
            ZA DA GO POLZVAME V BRAWSERA TRQBVA DA INSTALIRAME BIBLIOTEKATA 'systemjs'
            V NASHIQ PROEKT S HTML FAILOVE:
                npm install systemjs
            TRQBVA DA SE KONFIGURIRA.



        ES6 Native Modules:
            SINTAXIS:

            Kak se exportva:
                exports {..., ..., ...};
            Kak se importva:
                import * as NAME_WE_WANT from './PATH_TO_FILE'; 
                    NAME_WE_WANT.updateScore()  // taka go izvikvame ot modula

                '*' oznachava che vkluchvame vsichko
            MOJEM DA IMPORTVAME NQKOLKO NESHTA
                import {fOne, fTwo} from './PATH_TO_FILE';    
                    fOne();   // taka go izvikvame ot modula

            OBACHE NQMA DA VURVI V BRAWSERA ZATOVA SHTE NI TRQBVA 'Babel Transpiler'


            Babel Transpiler:
                NQKOI STARI BRAWSERI NE RAZBIRAT OT NOV JAVASCRIPT KOD ZATOVA IDVAt NA POMOSH
                TRANSPAILERITE KOITO PREVEJDAT STAR JS KOD NA NOV I OBRATNOTO ZA DA MOJE 
                SAMIQ BRAWSER DA GO RAZBERE.
                Instalira se sus:
                    npm install --save-dev babel-cli -g


                INSTALIRAME I PLUGIN SPECIALEN ZA BABEL ZA DA MU KAJEM KUM KAKVO DA NI PREVEJDA KODA.
                    npm install --save-dev babel-plugin-transform-es2015-modules-commonjs 

            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!:
                Trqbva da suzdaden specialen babel configuration fail 'babelrc.json' v nashiq proekt
                i v nego da zapishem :

                {
                    "plugins": ["transform-es2015-modules-commonjs"]
                }

                Tova mojem da go napravim s komanda chrez terminala:
                    echo {"plugins": ["transform-es2015-modules-commonjs"]} > .babelrc.json

            //TRQBVA OSHTE KONGIFURACII, TRQBVA DA KAJEM KUDE DA NU SKLADIRA PREVEDENITE FAILOVE.
                npx babel ./k_modules/demo/js -d result

        PO LESNO E DA PISHEM KOMNANDI V TERMINALA OT KOLKOTO DA KONFIGURIRAME NIE RUSHO CHREZ WEBTROMA ILI DR.

        TRQBVA DA SI IMPORTNEM system.js KUM HTML-a

        VSICHKI TEZI BIBLIOTEKI POSTIGAT EDNO I SUSHTO NESHTO.




        SUMMARY:
            01.Modulit sa nujni i polezni za podredba na koda, kachestvo i po lesno namirane na greshki.
            02.JS failovete moga da se zarejdat chrez razlichni vunshni biblioteki.
            03.ES6 ni dava module support, sintaksisa e sledniq:
                
                IMPORTVANE:
                    import funcName from './PATH_TO_FILE';

                EXPORTVANE:
                    export { WHAT_WE_WANT as NAME_WE_WANT }
                
            04.Transpailerite sa nujni da ni prevejdat nov JS kod kum star za da se razbira ot starite brawseri.









*/
















