using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {

            /*data types:
              
            float e s promenliva s plavashta zapetaq
            DayOfWeek  e tip danni za dnite ot sedmicata 
            DayOfWeek Naso = monday;
            
            var idva ot variable.
            Vsichko v pametta e nuli i edinici.
            Ne e dobra praktika da izpolzvame vinagi var zashtoto edin 
            dobur programist e dobre da moje da razpredelq pametta. 


            int otdelq 32 bit ili (4 bytes) ozn che sa 32 nuli i 
            edinici edna sled druga.
            
            ALL INTEGER TYPE : varirat ot  -2 miliarda do 2 miliarda   
            sbyte [-128,...127] 8 bit
            byte [0,...255] unshort 8 bit
            short [-32 768,... 32 767] 16 bit
            ushort [0,...65 535] unshort 16 bit
            int [-2 147 483 648,...2 147 483 647] 32 bit
            uint[0,...4 294 967 295] unshort 32 bit
            long[-9 223 372 036 854 755 808,...9 223 372 036 854 755 807] unshort 64 bit
            undlong[0...18 446 744 073 709 551 615] 64 bit

            Trqbva da mojem da izberem koe ni trqbva v zavisimost ot tova koeto pravim.           
            POVECHETO PUTI SE IZPOLZVA INT, AKO NI TRQBVA PO GOLQMO CHISLO POLZVAME LONG !
            I PO DEFAULT V SISTEMATA E INT!
            
            kak se preobrazuva ot edin tip danni v drug
            (v kakuv tip iskame da go prevurnem)tova koeto iskame da prteobrazim !
             
              */

            // primer s overflow: tova e kogato nadvishim vuzmojnostite na edin tip danni, tq zapochva da vurti ot nachalo.
            byte counter = 0;
            for (int i = 0; i <= 260; i++)
            {

                Console.WriteLine(counter); // byte e ot 0 do 255
                counter++; // prevurta s 5 chisla tova se naricha OVERFLOW zashtoto zapochva ot nachalo !!!
            }

            Console.WriteLine(); Console.WriteLine();

            // zadacha 1 ot domashnoto:
            //convert centuries into years days hours and minutes

            Console.Write("Centuries = ");
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes",
            centuries, years, days, hours, minutes);


            Console.WriteLine(); Console.WriteLine();

            //INTEGER LITERAL: tova sa bukvichki koito ni pokazvat edno chislo tochno kakuv tip danni e !
            //0L e 64 bit chislo i v int ne stava trqbva long
            //U E PAK ZA 64 BIT samoche ot 0 nagore. To e za ulong ili uint.
            long nula = 0U;
            Console.WriteLine(nula);// pokazva edna i sushta nula


            /*FLOATING POINT TYPES:
             tova e realno chislo s plavashta zapetaq.
             moje da sudurja mnogo golqmi stoinosti ili mnogo malki sushto
             No zapazva edna i sushta pamet, za nego nqma znachenie kakvo e chisloto. 
             Float ima mnogo tochnost.

             Double e dva puti kolkoto float!
             float 32 bits precision up to 7 digits.
             double 64 bits precision up to 15 ot 16 digits.            
             */

            // imame F i D,  primerno 0.00F  i 0.00D za da ocenqt kakvo e chisloto !!!
            float floatPI = 3.141592653589793238F;
            double doublePI = 3.141592653589793238; // tuk ne ni trqbva D zashtoto po default go priema kato double!!!
            Console.WriteLine("float :" + floatPI); // pokazva do 7miq znak i zakruglq chisloto
            Console.WriteLine("double :" + doublePI);


            Console.WriteLine(); Console.WriteLine();


            //Math.  e mnogo hubava biblioteka s mnogo gotini raboti vutre !!!
            /*Rounding floating point numbers :*/
            Console.WriteLine(Math.Round(2.5)); // zakruglq nagore v sluchaq do 3
            Console.WriteLine(Math.Round(2.49)); // zakruglq nadolo v sluchaq do 2
            Console.WriteLine(Math.Round(2.12345600000000, 3)); // vtoriq parametur e do kolko chisla iskame da zakrugli !

            //Math.Ceiling() zakruglq nagore       priema samo edin parametur!
            //Math.Floor() zakruglq na dolo        priema samo edin parametur!

            Console.WriteLine(); Console.WriteLine();


            //Zadacha ot domashnoto  Circle Area(12 digit precision)
            double radius = double.Parse(Console.ReadLine());
            radius = Math.PI * radius * radius; // Formulata e Math.PI * radius * radius
            Console.WriteLine("{0:f12}", radius);

            Console.WriteLine(); Console.WriteLine();

            /*Scientific notation (nauchno predstavqne na chisla):*/
            double d = 10000000000000000000000000000000000.0; // 1 * 10 na 34ta stepen
            Console.WriteLine(d);// 1E + 34  oznachava 1 s 34 nuli otzad!
            double d2 = 20e-3; // 20 * 10 na -3ta stepen
            Console.WriteLine(d2);// 0.02

            // MaxValue e nai golqmata stoinost na edno chislo MinValue e nai malkata !!!

            // za int
            int maxint = int.MaxValue;
            Console.WriteLine("int max = " + maxint);
            int minint = int.MinValue;
            Console.WriteLine("int min = " + minint);

            Console.WriteLine();

            //za float
            float maxfloat = float.MaxValue;
            Console.WriteLine("float max = " + maxfloat);
            float minfloat = float.MinValue;
            Console.WriteLine("float min = " + minfloat);

            Console.WriteLine();

            //za double
            double maxdouble = double.MaxValue;
            Console.WriteLine("double max = " + maxdouble);
            double mindouble = double.MinValue;
            Console.WriteLine("double min = " + mindouble);


            Console.WriteLine(); Console.WriteLine();
            /*Floating point division:
             ako delim dve celi chisla otgovora e cqlo chislo
             ako delim na double ili float poluchavame double ili float
             samo edno trqbva da e s desetichna zapetaq za da stane!
             */

            /*DECIMAL NUMBERS:*/

            double a = 1.0f, b = 0.33f, sum = 1.33;
            Console.WriteLine("a + b = {0}, sum = {1}, equals = {2}", a + b, sum, (a + b == sum));
            // qsno se vijda che 'a + b'  ne e tochno 1.33

            // decimals nakraq se otbelqzvat s M primerno 0.00M
            /*Pazi 128bita  pochti nqma round errors, ima mnogo po malki i mnogo po golemi
             chisla ot double, ima mnogo poveche precision.*/

            int aa = int.Parse(Console.ReadLine());
            decimal sum2 = 0;


            for (int i = 0; i < aa; i++)
            {
                sum2 += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum2); // pokazva ni istinskata suma probvai s double da vidish che e razlichno 


            /*Type conversion: Implicid and Explicid
             
             implicit conversion e bez zaguba na preciznost: primer:
             float heightInMeters = 1.75f;
             double maxHeightInMeters = heightInMeters;
             
             Explicid conversion e suz zaguba na preciznost: primer:
             double size = 3.14;
             int intSize = (int)size;        // TUK VZIMA SAMO CQLOTO CHISLO

            MOJEM DA SLOJIM NESHTO MALKO V PO GOLQMA KUTIQ NO NE I OBRATNOTO BEZ ZAGUBA NA DANNI!
             */

            Console.WriteLine(); Console.WriteLine();


            /*Bool data type 
             
             Durji samo true ili false stoinost,   samo 0  i  1 

            bool MOJE DA PRAVI PROVERKI ZA TRUE ILI FALSE :   NO NE E KATO IF ELSE

            BULEVITE STOINOSTI NE SE SUBIRAT !!!
             */
            int aaa = 1;
            int bbb = 2;

            bool aaaIsGreatherThanBbb = (aaa > bbb);
                Console.WriteLine(aaaIsGreatherThanBbb);   // tova e false             

            bool aaaIsLessThanBbb = (aaa < bbb);     // tova e true           
                Console.WriteLine(aaaIsLessThanBbb);



            Console.WriteLine(); Console.WriteLine();


            /*Char data type:   idva ot character i e nqkakuv sinvol 
             VSICHKO KOETO VIJDAME NA KOMPIUTURA E SINVOL 
             SHTOM MOJEM DA GO SELEKTIRAME ILI KOPIRAME ZNACHI E CHAR
            VSEKI SINVOL IMA NQKAKUV KOD!!!

            char sudurja 16 bita pamet, ot  (U+0000  do U+FFFF) SHESNAISETICHNA BROINA SISTEMA  i desetichna broina sistema
            Vsqka bukva e 16 bita i sudurja chislo zad neq !
            Ima ACSII tablica koqto e malkiq variant, cqlata tablica se kazva UNICODE ili UTF, tq sudurja absolutno vsichko 
            i vsichki azbuki !
            
            sudurja '/0' po default !!!
              */


            char obratnoUdivitelnoOtUnicodeTablicata = (char)161;  // 161 e ot desetichna broina sistema
            Console.WriteLine("Znak : "+obratnoUdivitelnoOtUnicodeTablicata);
            Console.WriteLine(("Chislo zad znaka : "+(int)obratnoUdivitelnoOtUnicodeTablicata)); // taka vijdame kakvo e chisloto zad sinvola


            // za da eskaipvame sinvolik polzvame  \    primerno
            Console.WriteLine();
            Console.WriteLine("Atanas");
            Console.WriteLine("\"Atanas\"");  // taka eskeipvame v sluchaq kavichkite 

            //   \t   sova e TAB        \n tova e NEW LINE


            Console.WriteLine(); Console.WriteLine();
            /*Stringove:  
             Pishat se v kavichki,  te sa poredica ot charove, po default imat stoinost NULL, primerno : string NASO = "",
             ne e 0 zashtoto nulata e sinvol !!!
             Mogat da se konkatenirat s  + 
             Stringa e masiv ot sinvoli !!! */

            // int.Parse() E KOGATO PRAVIM STRING V CHISLO, A (int)  RABOTI ZA CHISLA I CHAROVE !!!  MNOGO VAJNO !!!

            //Ima tri nachina za izobrazqvane na stringove: Standart, Verbatim i Interpolated
            string file = "C: \\Windows\\win.ini"; // standart
            string file2 = @"C: \Windows\win.ini";  // verbatib, TUK NQMA NUJDA OT ESKEIPVANE NA SINVOLI, PISHEM SAMO TOVA KOETO NI TRQBVA!!!

            Console.WriteLine("Standart : "+file); Console.WriteLine("Verbatim : "+file2);
            // za interpolated se izpolzvat promenlivi vutre v stringovete no ne e zaduljitelno, ima i druigi nachini
            

            string FIRSTNAME = "Asen";
            string LASTNAME = "Kambitov";
            string FULLNAME = $"{FIRSTNAME} {LASTNAME}";   // mojem da ne izpolzvame $
            Console.WriteLine("Interpolated : " + FULLNAME);




            // Naming variables   DEKLARIRANETO NA PROMENLIVI VINAGI E CAMELCASE , NE DEKLARIRAITE PO NIKAKUV DRUG NACHIN !!!


            Console.WriteLine(); Console.WriteLine();



            /*Variable scope and lifetime :
             
             scoupa koeto e {} ni pokazva ot kude mojem da imame dostup do promenlivata, a 
             jivota na promenlivite e vuv skobite, ako ne e v skobite znachi e globalna.*/


            var outer = "I am outside !";
                                                                // 1
            for (int i = 0; i < 5; i++)                         // 2
            {                                                   // 3
                var inner =  "I am insade the loop !";          // 4
            }                                                   // 5
                                                                // 6
            Console.WriteLine(outer);                           // SPAN na outer v sluchaq e 6 reda      VAJNO !!!!

            // Console.WriteLine(inner);   tuk ni dava greshka !!! nqmame dostup do tazi promenliva !!!



            //SPAN E VREMETO KATO REDOVE V KOITO TEZI PROMENLIVI VAJUT, DEFINIRAITE PROMENLIVITE NAI KUSNO VUZMOJNO !!!
            // V pascal ili po nqkoga v javascript purvo se deklarirat vsichki promenlivi i posle se raboti s tqh, V C# ne trqbva da e taka !!!



            // RAZLIKA MEJDU {0:f6} i Math.Round(num, 6);  :

            double num3 = 1.123456789;
            double num4 = 1.123456789;
            Console.WriteLine("{0:f4}", num3); // Pokazva 1.123457 , zakruglq go  drugoto si e v pametta ne e otrqzano i moje da bude vizualizirano 
            Console.WriteLine("{0:f7}", num3);

            num4 = Math.Round(num4, 4); // Ako dadem taka, programata go reje
            Console.WriteLine(Math.Round(num4, 4));// Pokazva sushtoto, pak go zakruglq no go reje, sega nie ne mojem fa vizualizirame ostanalite chisla !     
            Console.WriteLine(Math.Round(num4, 7)); // ne ni go pokazva zashtoto veched e otrqzalo chisloto





            /*SUMMARY:
             
             int numbers 8bit, 16bit, 32bit, 64bit, 128bit
             floating point numbers  : float up to 7 digits{32bit}, double up to 15 or 16 digits{64bit}, decimal every digits{128bit}
             converting data types !!!
             characters, strings and boolean types !!!
             variables, scope, span
             
             // int.Parse() E KOGATO PRAVIM STRING V CHISLO A (int)  RABOTI ZA CHISLA I CHAROVE !!!  MNOGO VAJNO !!!

             byte, float, unshort se izpolzva kogato primerno ni trqbva po malko choislo.
             long, decimal e za obratnoto.
             
             IMA RAZLIKA MEJDU {0:f6} i Math.Round(num, 6);  i dvete go zakruglqt do 6toto chislo sled zapetaqta 
             obache Math.Round go reje a drugoto ne .
             */



            // ZA BOOL  1 DAVA TRUE A 0 DAVA FALSE !!!
            // ne e hubavo da ima poveche iot 3 ifa edin v drug, stava oburkvashto

            /*Data types and variables 2 :*/



            /*TRENALEN OPERATOR: 
             Kogato ifa e mnogo maluk moje da go otpechatame taka :
             Console.WriteLie(nameOfVariable ? "ShowTextIfTrue" : "ShowTextIfFalse");   
             TOVA SE NARICHA TRENALEN OPERATOR!!!
             Za po podredeno moje i taka :
             
            Console.WriteLie(nameOfVariable 
            ? "ShowTextIfTrue" 
            : "ShowTextIfFalse");
             
             */







        }
    }
}
