using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Encapsulation_and_validation
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            /*
            Poleta i propertita:

            public i private sa access modifiers
            private e samo vidimo ot tekushtiq klas dokato public ot vseki.

             */

            //imame konstruktor zatova moje mda napishem dolnoto
            Dice dice = new Dice(6);
            

            
            for (int i = 0; i < 10; i++)
            {
                var result = dice.Roll();
                Console.WriteLine($"You rolled: {result}");
            }


            Person person1 = new Person("Atanas Kambitov", 24);
            Person person2 = new Person("Asen Kambitov", 25);
            Person person3 = new Person("Stefan Kambitov", 45);

            //Nqma kak da se oburkame vsichko e ok!!!!!
            Console.WriteLine(person1.NameAndAge());
            Console.WriteLine(person2.NameAndAge());
            Console.WriteLine(person3.NameAndAge());

            /*
                Access modifiers:
                1.public
                2.private
                3.protected
                4.internal

            1. Ako neshto e public moje da se dostupva ot vseki edin klas
               OT VSEKI EDIN INTERFEIS !!!!!!
               Trqbva da vnimavame s public


            2. S private inkapsulirame obekti i ne mojem da gi polzvame otvun 
               nashiq klas v koito sme gi suzdali

               KLASOVETE I INTERFAISITE NE MOGAT DA SA private !!!!!


            3. protected: TOVA E NESHTO MEJDU public i private
               DAVA DOSTUP DO OBEKTA SAMO NA KLASOVE KOITO NASLEDQVAT 
               TOZI V KOITO E BIL SUZDADEN OBEKTA !!!!
               NE MOJE DA SEPRILAGA NA KLASOVE I INTERFEISI.
                Nqma da se zanimavame s nasledqvane v tozi kurs !!!


            4. internal: TOVA E PAK NESHTO MEJDU public I private 
               Tova ni pravi obekta da e public samo za PROEKTa (INTERFEISa)v koito 
               e suzdaden.
               Ne mojem da go polzvame v drug PROEKT (INTERFEIS)!!!

            */




            /*
                Validaciqta stava v settera, usera se oprava 
                s exceptionite a ne samiq klas. 
             

                
             */


            //Immutable objects: stringa e takuv !!! PRIMER:
            string myString = "My old string";
            Console.WriteLine(myString);
            myString.Replace("old", "new");
            Console.WriteLine(myString);

            //Vadi dva puti "my old string" t.e. ne repleisva nishto
            /*
                pri konkatenaciq nie suzdavame nov string a ne promenqme 
                samiq string !!!
                
            IMMUTABLE OBEKTITE SA NEPROMENQEMI !!!
             */



            /*
                ReadOnly e za stoinosti koito ne se promenqt a samo se 
                chetat t.e. vijdat.
                No po dobre se polzva pri kolekciite !!!
                
             */

            /*
             mutable obekti : TOVA SA private obekti koito sa SPISUCI !!!
             Private obektite ne sa napulno kapsulirani
             nqmame dostup do tqh no pak mojem da rabotim s tqh
             osobeno ako sa spisuci, mojem da dobavqme v tqh koeto
             na momenti ne trqbva da se pozvolqva.
             
             VAJNO: !!!
             ZA DA SE PREDPAZIM OT TOVA PROSTO V get METODA PISHEM 
             ToList() I NQMA DA NI POZVOLI OTVUN DA DOBAVQME V SPISUKA 
             
                get{return this.SomeThing.ToList()}
             */


            /*
             Summary:
                Encapsulaciq: Tq koda stava po oprosten i po maluk 
                za potrebitelq.
                Klasa Ima propertita koito nie mu kazvame da ima
                Mojem da skriem nqkoi detaili ot usera!

                Access modifiers:
                    pulic, private, protected, internal
                    S tqh mojem da kontrolirame koi ima dostup do dadenite danni.
                 
                Muttable i Immutable obekti:
                    Koe pole moje da se promenq i koe ne moje !!!    

                S ReadOnly() Vrushtame samo readOnly neshta
             */


        }
    }
}
