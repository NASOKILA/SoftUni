using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndClasses
{
    public class Cat  // dobavqme public
    {
        // Vseki klas shte ima slednite kriterii
        // MOJEM DA SI DOBAVQME VSQKAKVI GLUPOSTI KOITO SI ISKAME !
        //SET I GET OZNACHAVAT CHE MOGA DA ZAPISVAM  set PROMENQM  I  get CHETA  
        public string Name { set; get; }
        public int Age { set; get; }
        public string Color { set; get; }
        public bool IsAsleep { set; get; }


        List<Cat> AllBLackAwakeCats = new List<Cat>(); // iskam spisuk ot vsichki kotki


        /* Vseki edin klas moje da ima povedenie za sebesi (FUNKCII)
           SAMOCHE TUK METODITE SE PISHAT BEZ static   
        */

        public string SayHello() {

            if (IsAsleep) { // AKO KOTKATA E ZASPALA NQMA KAK DA SI KAZVA IMETO !

                return "The cat is sleeping !";
            }

            return $"Hello My name is {Name} and I am {Age} years old.";

            /*HUBAVO E TEZI METODI DA VRUSHTAT STOINOST OTKOLKOTO DA PECHATAT NESHTO NA KONZOLATA.
              DA PISHEM TUK PRIMERNO : Console.WriteLine(); e greshka za NEKACHESTVEN KOD,
              EDNA KOTKA NE RAZBIRA NISHTO OT KONZOLA
             
             */
        }

        public void GoesToSleep() {

            IsAsleep = true;  // s tazi funkciq prispivame kotkata 
        }

        public void Awake() {

            IsAsleep = false;
        }

    }
}
