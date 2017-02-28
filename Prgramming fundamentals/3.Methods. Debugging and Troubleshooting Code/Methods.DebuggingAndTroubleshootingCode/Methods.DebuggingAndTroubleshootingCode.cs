using System;


namespace Methods.DebuggingAndTroubleshootingCode
{
    class Program
    {
        static void Main(string[] args)
        {

            /*This lession will cover : 
              1.Using methods  2.Methods with Parameters   3.Overloading   4.Debugging   5.Brst Practice*/

            /* Metod e parche kod s ime koeto kato se izvika izpulnqva dadenoto parche kod.
               Izpolzvaiki metodi ne se povtara kod po lesno se chete i razbira, vsichko e po dobre.
               Metodite trqbva da sa zaduljitelno v KLAS.
               LOKALNI PROMENLIVI SA DEKLARIRANI VUTRE A GLOBALNITE OT VUNKA.
               Void e motod koito ne vrushta stoinost. Metodite se izvikvat sus skobi sled imeto im, mogat da se 
               izvikvat i v drugi metodi i nai veche ot MAIN.
               Edin metod moje da izvikva sebesi koeto se naricha REKURSIQ, tova nqma krai osven ako ne mu slojim.
               Recursiqta e stackOverflowExeprion.


                METODI S PARAMETRI :
                Definirat se v skobite i se zardelqt sus zapetaq !
                moje da ima 0 i poveche parametri, mogat da sa ot razlichen tip
                vseki parametur ima  Ime i Tip.
               */
            /*
             Za maksimalen element mojem da polzvame GetMax(5, 10); kakto i za minimalen element !
             moje da se izpolzva i v izraz .
             Parse() e metod ot klasa int,  ReadLine(), WriteLine(), Write() i dr sa metodi ot klasa Console !!!     
             VSICHKO KOETO PISHEM OT KONZOLATA E STRING ZA TOVA TRQBVA DA GO PARSVAME !!!

            //  MOJE DA IMA MNOGO METODI S EDNO I SUSHTO IME NO DA PRAVQT RAZLICHNI NESHTA RAZLICHAVAT SE PO PARAMETRITE !!!

          */



            // ZA DAVIDIM REZULTATA NA METOD KOITO NE E VOID E NUJNO DA NAZNACHIM PROMENLIVA!
            string result =  ReadFullName();
            Console.WriteLine(result);

            Console.WriteLine();

            int result2 = MaxNum();
            Console.WriteLine(result2);


        }





        static double GetSquare(double i) { // primer za metod



            return i * i; // rezultat shte bude double !
            // sled tozi return nikaniv kod nqma da se izpulni !!!
            
        }


        static int Function (int i)
        {
            double a = 5.1356;
            double b = 10.5445;
            return  i * (int)a * (int)b; // tuk dava greshka ako ne slojim (int) zashtoto trqbva razultata da bude integer
        }



        static string ReadFullName() // nqma da priema parametri
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            return firstName + " " + lastName; 
        }


        
        static int MaxNum() {

            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            return Math.Max(firstNum, secondNum);

        }


        //  MOJE DA IMA MNOGO METODI S EDNO I SUSHTO IME NO DA PRAVQT RAZLICHNI NESHTA RAZLICHAVAT SE PO PARAMETRITE !!!

        /* SLEDNOTO NESHTO NE E OVERLOADING I E ABSOLUTNO ZABRANENO ZASHTOTO KOMPILATORA 
         * NQMA DA ZNAE KOE DA IZVIKA !!! 
          
         static void Print(string a) {
            Console.WriteLine(a);
        }

         static string Print(string a) {
            return a;
        }
         
         */


        /*PROGRAM EXECUTION FLOW    kak se izpulnqva programata, span, lifespan i dr.
         
         stack e kato kutiqs knigi, kato q otvorish vijdash samo purvata.
         Tam se izpulnqvat metodi promenlivi i dr. SLED KATO SE IZPULNQT TE
         IZCHEZVAT I STAKA SE PRAZNI.  MN VAJNO !!!
         Staka znae tochno na koi red se namirame. Qsno e pri debugvaneto.

         */
        /*Debugging code:
           debugging pomaga mnogo, mnamira i oprava greshki na dadeniq red.
           chervenata tochka se kazva breakpoint. SLAGA SE S   F9 
        */

        /*Naming Methods and best practices:
         Metodut trqbva da kzva kakvo pravi.
         AKO PECHATAME NESHTO ZNACHI TRQVBA DA E    Print
         AKO CHETE NESHTO ZNACHI E                  Read
         AKO VRUSHTA NESHTO ZNACHI E                Return
         AKO VZIMA NQKAKVI STOINOSTI ZNAHI E        Get
         AKO ZAREJDA NESHTO E                       Load
         AKO NAMIRA DADENI STOINOSTI E              Find

        Izpolzva se PASTELCASE koeto znachi che vshichki dumi sa s glavni bukvi.
        Parametrite se pishat kato promenlivi, s CAMELCASE zapochva s malka bukva 
        posle vsichki dumi sa s golama bukva.

        Vseki metod trqbva da pravi samo edno neshto primerno : v edin metod samo 
        namirane na neshto, v drug metod samo sabirane i v treti metod samo printirane !!!
        
        EDIN METOD E NORMALNO DO 30 REDA DULUG.

         */

        /*SUMMARY :
         Metodite sa do 30 reda i se polzvat za razbivane na programata na malki chasti.
          Vikat se po imeto, priemat parametri, vrushtat sushtiq tip stoinost, void e 
         metod koito ne vrushta nishto. 
         Debugera pomaga za namirane na greshka i otstranqvane na neq.
         
        FUNKCIQ I METOD E EDNO I SUSHTO NESHTO !!!
         */


        // CONTROL + K + D    direktno redaktira koda i go podrejda !!!  VAJNO!!!

        /*OVERLOADING E DA IMAME 2 METODA S EDNAKVO IME NO S RAZLICHNA SIGNATURA !!!
         * signatura ne metoda e primetno  Print(string a) 
         * PRIMERNO IMAME :
         * 
         * static string A(string name){   return name; }
         * static int A(string name){   return 1; }
        
        v takuv sluchaq edinstvenata razlika e vuv tipa na vrushtane ! Kompilatora nqma kak da znae koi 
        ot dvata metoda da izvika.

        OVERLOADING E KATO SIGNATURATA IM E RAZLICHNA !
        
          static string A(string name){   return name; }
          static int A(string name){   return 1; }
         
          */
    }
}
