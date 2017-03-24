using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class Lists
    {
       public static void Main(string[] args)
        {
            // SPISUCI
            /*Te prilichat na masivi, sudurjat poredica ot elementi.
             Count - kazva kolko elementa imame v Spisuka t.e. duljinata
             Add() - dobavq element v spisuka
             Remove() - vrushta true ako nameri elementa ot spisuka i go iztrie 
             RemoveAt() - maha elem na dadena poziciq
             rEMOVEaLL() - TRIE VSICHKI ELEMENTI
             Insert() - dobavq element v opredelena poziciq v spisuka
             Contains() - proverqva dali edin elem se sudurja v spisuka
            
             LISTOVETE PO PODRAZBIRANE SA PRAZNI, GLAVNO SE RABOTI S GORNITE OPERACII.
             
             RAZLIKATA MEJDU MASIVI I SPISUCI E CHE ZA MASIVITE PURVO PRI DEFINIRANETO 
             NIE TRQBVA DA OPREDELIM DULJINATA I POSLE NE MOJEM DA Q PROMENQME. 
             A SPISUCITE SE ORAZMERQVAT TOEST TE SI PROMENQT RAZMERA.
         
             SUS SPISUITE SE RABOTI PO DOBRE NO SA PO BAVNI OT MASIVITE !!! VAJNO !!!
              NO AKO ZNAEM KOLKO TOCHNO ELEMENTI NI TRQBVAT PO DOBRE DA POLZVAME MASIVI
              A AKO NE ZNAEM SPISUCI. 
             */


            List<int> spisuk = new List<int>();  // suzdavame spisuk
            spisuk.Add(3);
            spisuk.Add(4);
            spisuk.Add(5);
            spisuk.Add(6);
            spisuk.Add(5);      
            spisuk.Add(5);   // imame tri puti 5
            spisuk.Add(7);
            spisuk.Add(8);


            foreach (var element in spisuk)
            {

                Console.WriteLine(element);
            }


            spisuk.Remove(5); // SHTE PREMAHNE SAMO PURVATA PETICA !!! VAJNO
            /*NQMA SMISUL DA PISHEM DVA PUTI spisuk.Remove(10) NQMA DA STANE !!!*/

            spisuk.RemoveAt(0);  // MAHAME PURVIQ ELEMENT OT SPISUKA

            Console.WriteLine(); Console.WriteLine();
            foreach (var element in spisuk) {

                Console.WriteLine(element);
            }


            spisuk.Insert(2, 2222222); // pishem purvo poziciqta i posle chisloto


            Console.WriteLine(); Console.WriteLine();
            foreach (var element in spisuk)
            {

                Console.WriteLine(element);
            }


            Console.WriteLine(); Console.WriteLine();
            // SORTING LISTS AND ARRAYS :
            /*MOJEM DA POLZVAME Sort()
             
             */

            var names = new List<string>()
            {
                "Naskov","Asen", "Ivan","Atanas","Boris"
            }; // taka se definira list sus elementi v nego

            //PECHATA SE SUS string.Join();    ILI SUS for CIKUL !
            Console.WriteLine(string.Join(", ", names));  // shte bude v sushtiq red !

            names.Sort();
            Console.WriteLine(string.Join(", ", names)); // sega shte se sortiraot po malko kum po golqmo!

            //v sort mojem da pishem mnigo neshta, primerno KOMPARATOR koeto e funkciq kazvashta ni kak da sortirame elementite !

            names.Sort((a, b) => b.CompareTo(a));  // tova vuv sort() e  komparator
                                                   //Kazvame: ako podredim ot  a  kum  b  da gi sortira ot  b  kum  a 

            Console.WriteLine(string.Join(", ", names)); // sortira gi po obraten nachin ot po golqmo do po malko


        }
    }
}
