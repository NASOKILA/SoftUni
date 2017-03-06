using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndClasses
{
    class ObjectsAndClasses      // TOVA E ABSTRAKTEN KLAS KOITO KAZVA CHE NI STARTIRA PROGRAMATA
    {
        static void Main(string[] args)
        {

            /*SHTE RAZGLEDAME :
             razlika mejdu obekti i klasove, vgradeni klasove API,
             creating our own classes, OOP*/


            /*Obektite pazqt informaciq, primerno :
             Object Birthday olds day, month, year.
             
             Obekra ima ime i svoistva, obektite sa paziteli na informaciq,
             v zamisimost kakvoto iskame da napravim obektite mogat da imat 
             razlichna zbirshtina ot svoistva.
             
             definiciq:  prometrno:
             DateTime BirthdaY = new Datetime(1996, 11, 27);     
             
             S DATTETIME SE SAZDAVAT DATI
            S DUMATA new SE SUZDAVA NOV OBEKT !!!
             
        
            
            Klasovete sa kato primeren shablon za suzdavane na dati !!!
            klasa e opisanieto na vseki edin obekt kakvi danni shte sudurja no 
            ne i samite danni.

            Klasovete opisvat kakvi shte budat dannite.
            primerno: klas Cat moje da ima samo ime i godini
            sled tova vseki obekt koito suzdavame shte sudurja samo ime i godini.
              
            Klasut opredelq i vidivete povedenie i deistvie na dannite 
            Moje da bude ima i funkcii !!!

            Edin klas moje da ima novi instancii TOEST OBEKTI !!!


            Klasut e primerno:

            public class Cat()
            {
            public string name{ set; get;}
            public int age{ set; get;}
            }
            */
            //SET I GET OZNACHAVAT CHE MOGA DA ZAPISVAM PROMENQM  I CHETA 

            var CatFirts = new Cat();    // purvi obekt ( instanciq )
            CatFirts.Name = "Sisa";
            CatFirts.Age = 5;
            CatFirts.Color = "black";
            CatFirts.IsAsleep = false;

            var CatSecond = new Cat();   // vtori obekt ( instanciq )
            CatSecond.Name = "Mika";
            CatSecond.Age = 7;
            CatSecond.Color = "White";
            CatSecond.IsAsleep = true;

            var CatThird = new Cat();   // treti obekt ( instanciq )
            CatSecond.Name = "Nino";
            CatSecond.Age = 1;
            CatSecond.Color = "Grey";
            CatSecond.IsAsleep = true;

            Console.WriteLine(CatFirts.Name);
            Console.WriteLine(CatSecond.Name);
            Console.WriteLine(CatThird.Name);
            // AKO NI TRQBVAT PRIMERNO 1000 KOTKI SHTE E PO LESNO SUS KLASOVE I  OBEKTI V CIKUL


            Console.WriteLine(); Console.WriteLine();


            List<Cat> AllBLackAndAwakeCats = new List<Cat>();
            for (int i = 0; i < 100; i++)
            {
                var currentCat = new Cat();
                currentCat.Name = "Cat" + i.ToString();
                currentCat.Age = i % 10;
                currentCat.Color = "Black";
                currentCat.IsAsleep = false;


                AllBLackAndAwakeCats.Add(currentCat);
                // SUZDAVAME SI SPISUKA PREDI TOVA

            }
            // suzdadohme 100 cherni budni kotki i gi slojihme v spisuk

            Console.WriteLine(AllBLackAndAwakeCats[15].Name);


            Console.WriteLine(); Console.WriteLine();


            // ima i drug nachin za suzdavane i populvane s informaciq  obekt (instanciq)

            var CatFour = new Cat
            {
                Name = "Martaka",
                Age = 6,
                Color = "Yelow",
                IsAsleep = false
            };       // TAKA SPESTQVAME PISANE AKO PROMENLIVATA CatFour NI E PREKALENO DULGA


            //Mojem da smenqvame kakvoto si iskame po vsqko vreme !!!
            CatFour.Name = "Tapaka";
            Console.WriteLine(CatFour.Name);


            Console.WriteLine(); Console.WriteLine();


            // DOBAVIHME FUNKCIQ V KLASA, MOJEM DA Q IZPOLZVAME :
            var CatFirstIntro = CatFirts.SayHello();
            Console.WriteLine(CatFirstIntro);
            // IZPULNQVA SE FUNKCIQTA IZPOLZVAIKI INFORMACIQTA NA DADENIQ OBEKT

            Console.WriteLine(CatSecond.SayHello()); // Mojem i direktno taka, bez promenliva !!!


            Console.WriteLine(); Console.WriteLine();


            //DOBAVIHME OSHTE DVE FUNKCII V KLASA  GoToSleep() i Awake()

            CatThird.GoesToSleep(); // funkciqta prispiva kotkata  
            Console.WriteLine(CatThird.IsAsleep);
            Console.WriteLine(CatThird.SayHello());// Shte izpishe "The cat is sleeping!" 

            CatThird.Awake();
            Console.WriteLine(CatThird.IsAsleep);
            Console.WriteLine(CatThird.SayHello());



            //  DateTime() e gotov shablon sledovatelno e Vgraden Klas  
            var firstDate = new DateTime(2017, 05, 02);
            var secondDate = new DateTime(2015, 02, 01);
            // firstDate i secondDate sa obektite

            Console.WriteLine(); Console.WriteLine();

            /*
             Build in API classes in .NET Framework : 
             using System.Collections.Generic;
             using System.Linq;
             using System.Globalization;
             using System.Threading.Tasks;
             etc...
            Ima i drugi!

            NQKOI OT TQH SA STATICHNI KATO KLASA Math,DateTime i dr,
            NQKOI NE SA STATICHNI KATO KLASA Random i imat nujda ot instanciq
            za da budat izvikani.
             */

            Random rand = new Random();   // purvo suzdavame instanciq
            var randNum = rand.Next(1, 10);
            // s metoda Next() generirame random chislo ot 1 do  PO MALKO OT 10 
            Console.WriteLine(randNum); // printirame chisloto ! 
            //KOMPIUTURA GENERIRA RANDOM CHISLA IZPOLZVAIKI MILISEKUNDI, REALNO NQMA NISHTO RANDOM

            /* Ako klasa Cat beshe statichne shtqhme da mojem izvikame 
               metodite v nego taka : Cat.IsAslep(); ...*/



            /*STATICHNITE METODI : ZA TQH NE E NUJNO DA SUZDAVAME
             OBEKT ZA DA GI IZVIKAME, MOJEM PROSTO DA GI IZVIKAME.
             Primer: suzdadohme metod UnstaticMethod() 
             STATICHNITE METODI SE IZVIKVAT DIREKTNO PREZ KLASA IM,
             KATO: Math.Min(); Math.Max(); i dr.*/
            Console.WriteLine(); Console.WriteLine();

            var instance = new ObjectsAndClasses();
            instance.UnstatcMethod(); // taka trqbva da go izvikame

            //  UnstaticMethod();   ako metoda beshe statichen




            /*WebClient() e Vgraden NESTATICHEN Klas v namespace System.Net;
              koito ima metod Download(), s nego mojem da svalqme failove i da gi 
              postavqme kudeto si iskame.
             
              File e statichen vgraden klas v namespace System.IO; koito ima funkciq Exists koqto proverqva
              dali daden fail sushtestvuva !

              Process e statichen vgraden klas v namespace System.Diagnostics; koito ima funkciq Start koqto startira 
              daden fail koito moje da e izvun nashto prilojenie!
             */

          /*
           SUMMARY:
           Klasovete sa shablon (primer) po koito suzdavame obekti.
           Obektite sudurjat suvkupnost ot informaciq.

            Suzdavane na obekti s 'new'.
            Suzdavane na klasove, VINAGI NA OTDELNO, NE TAM KUDETO TI E MAINA!
            {set; get;} E ZADULJITELNO ZA PROMQNA I CHETENE ZAPOMNI NA IZUS!
             */
        }




        //PRIMER ZA STATICHEN METOD:
        public void UnstatcMethod() {
            Console.WriteLine("Static method!");
        }

    }
}
