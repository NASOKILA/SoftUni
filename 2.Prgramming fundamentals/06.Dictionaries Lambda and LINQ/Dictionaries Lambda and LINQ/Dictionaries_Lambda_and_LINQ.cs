using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries_Lambda_and_LINQ
{
    class Dictionaries_Lambda_and_LINQ
    {
        static void Main(string[] args)
        {
            /*rechnici ili mapove sa ASOCIATIVNI MASIVI.
              shte govorim za:
              1.rechnici i sortirani rechnici 
              mapping keys and values 
              2. s obrabotvane na danni s LAmbda i LINQ
              filtering mapping ordering.

              Asociativnite masivi sa masivi s kluchove vmesto s indeksi
              kluchovete durjat stoinosti, ne moje da ima 2 ednakvi klucha.
              Count e broikata kluchove ili stoinosti koito ima v A.Masiv
              klucha moje da e chislo, string, char, obekt i dr.           

              definira se taka:
              Dictionary<key, value> name = new Dictionary<key, value>();
              s foreach mojem da rabotim s tqh
      
             pri premahaneto na kluch se maha i stoinosta kum nego i obratnoto,
             ne moje da se mahne samo ednoto.
             
             */

            Dictionary<string, int> name = new Dictionary<string, int>();
            foreach (var key in name.Keys) // taka vzimame vsichki kluchove   
            {// s name.Values  vzimame vsichki stoinosti
                Console.WriteLine(key);
            }

            // Osnovnite komandi sa Add(), Remove() i Clear() 

            /* 
            
            ContainsKey() proverqvame dali sushtestvuva daden kluch 
            ContainsValue() proverqva za sushtestvuvaneto na dadena stonost
              
            TryGetValue() Proverqva dali ima daden kluch i otpechatva stoinosta mu,
            ako nqma takuv kluch vrushta stoinost po default.
            Ako vurne 0 v kovechetu sluchai ne e namerilo dadeniqt kluch.

            VSICHKO MINAVA PREZ HASHFUNKCIQTA 
            */


            var phonebook = new Dictionary<string, string>(); // taka se definira
            // MOJE I TAKA : Dictionary<string, string> phonebook = new Dictionary<string, string>(); NO PISHEM VAR ZA UDOBSTVO ! 
            phonebook["John Smith"] = "0889094323";  // ime[kluch] = "stoinost"; taka se befinirat elementite !
            phonebook["Lisa Smith"] = "0886745521";
            phonebook["Sam Doe"] = "0887034456";
            phonebook["Nakov"] = "0998123634";
            phonebook["Nakov"] = "0886223564"; // ako imame dva ednakvi klucha s razlichnitoriq kluch zamestva purviq !

            phonebook.Remove("John Smith"); // iztriva klucha I STOINOSTA

            foreach (var show in phonebook) {
                Console.WriteLine("{0} --> {1}", show.Key, show.Value);
                // taka pokazvame i klucha s stoinostta, POLZVAME KeyValuePair<key, value> name in Dictionary name 
                // ili prosto za olesnenie pishem var.
            }

            Console.WriteLine(); Console.WriteLine();



            // za da vzema samo stoinostite:
            foreach (var value in phonebook.Values)
            {
                //mojem da slojim Dictionary<string, string>.ValueCollection vmesto var
                // ValueCollection vzima vs stoinosti a KayCollection vzima vsichki kluchove.

                Console.WriteLine(value);


            }


            /*SORTIRANI RECHNICI :
             Razlikata pri tqh e che ttse sortirat po kluchove :
             Ako klucha e string se sortira po azbuchen red.
             Ako e int ot po malko kum po golamo
             Ako e char ot po malko kum po golamo 
             i t.n.
             
             Po baven e ot standartniq rechnik no elementite tuk 
             vinagi vlizat avtomatichno sortirani.
             
             */

            /*Lambda funkcii i LINQ
             
             Lambda funkciqta e kato normalna funkciq no bez ime
             pak priema i vrushta dadena stoinost, moje direkno da se 
             izpolzva, vse edno da napishem metod na edin red.

            LINQ e biblioteka s vgradeni operacii za masivi, listove 
            rechnici i dr, kato Min(), Max(), Sort(), Sum(), Average() i dr.
            izvikvat se taka:
            ImeNaMasiv.Min(); , ImeNaMasiv.Max();  ...


            puska se taka : using System.Linq;    no e vgradena avtomatichno.
             
            Select() se izpolzva za chetene na kolekcii.

            Select(number => double.Parse(number)); tova v skobite e lambda funkciq
            koqto vzima edno chislo i go vrushta parsnato

             */

            // mojem da napishem var
            double[] nums = Console.ReadLine()
               .Split(' ')
               .Select(number => double.Parse(number))
               .Select(number => number + Math.PI) // TOVA SUBIRA number s PI
               .ToArray();
            // ot string pravim double   Mojem da slojim ToList() sushto za list
            // ToDictionary() , ToCharArray() 


            // S TOVA MOJEM DA RESHIM POVECHETO ZADACHI OT BASICA S PO EDIN RED  VAJNO!!!

            foreach (var num in nums)
            {
                Console.WriteLine(num); // pokazvame vsichki chisla!
            }




           

            /*Ot LINQ imame funkciq OrderBy() i OrderByDescending() koeto 
             podrejda elementite ot malko kum golqmo.

               ThenBy() e kato OrderBy() obache se izpolzva sled OrderBy()
               v sluchai che ni trqbva da sortirame po oshte edin kriterii.
               primerno:

              .....
              .OrderBy(pair => pair.Value)
              .ThenBy(pair => pair.Key)
              ...

              NQMA KAK DA SORTIRAME PURVO PO KLUCHOVE I POSLE PO STOINOSTI !
              Za OrderByDescending() sushtestvuva i ThenByDescending()

               */





                Console.WriteLine(); Console.WriteLine();

            // Using Take(), Skip()


            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            int[] nums1 = numbers.Take(3).ToArray(); // ot nums vzimame samo purvite 3 elementa
            Console.WriteLine(string.Join(" ", nums1));// nums = [1, 2, 3]

            int[] nums2 = numbers.Skip(3).ToArray();// sus Skip() prezkachame podadenite elementi i vzimame vsichki ostanali
            Console.WriteLine(string.Join(" ", nums2)); // nums = [4, 5, 6]

            //ako masiva ima samo dva elementa a nie vuv skip napishem primerno 3, shte ni vurne prazen masiv
            // NIE NE PROMENQME MASIVA numbers !!!

            int[] nums3 = numbers.Skip(2).Take(2).ToArray();
            Console.WriteLine(string.Join(" ", nums3)); // vzehme samo 3 i 4

            //VIJDATE CHE LINQ POMAGA MNOGO I PRAVI NESHTATA PO LESNI !

            /*Lambda funkciite sa Anonimni funkcii koito sa na edin red, vzimat stoinost i vrushtat,
             =>  oznachava 'goes to' .  */






            Console.WriteLine(); Console.WriteLine();
            
            /*Where() i Count()
             
             Where() proverqva vsichki elementi i vrushta samo elementite koito otgovarqt na uslovieto vutre
             Count() Vrushta samo BROIKATA na tezi elementi Koito otgovarqt na uslovieto!!!
             */

            int[] nnn = { 4, 6, 7, 89, 56 };

            var even = nnn.Where(x => x % 2 == 0); // v where() proverqvame ako chisloto e chetno!
            var odd = nnn.Where(x => x % 2 == 1);

            var evenCount = nnn.Count(x => x % 2 == 0); // vzimame broikata samo na chetnite chisla
            var oddCount = nnn.Count(x => x % 2 == 1);  // vzimame broikata samo na nechetnite chisla

            Console.WriteLine(string.Join(" ", even)); // vrushta samo chetnite chisla v nnn
            Console.WriteLine(string.Join(" ", odd));

            Console.WriteLine("Samo broikata chetni " + string.Join(" ", evenCount));
            Console.WriteLine("Samo broikata nechetni " + string.Join(" ", oddCount));





            Console.WriteLine(); Console.WriteLine();

            /*Distinct() Vzima elementite samo po vednij,t.e. ako daden element se povtarq ç
             shte go vzeme samo vednuj a ne dva puti !!! */


            int[] jjj = { 1, 2, 3, 4, 2, 5, 3, 7, 8, 9, 8, 7, 6 };
            jjj = jjj
                .Distinct()
                .ToArray();

            Console.WriteLine(string.Join(" ", jjj));




            Console.WriteLine(); Console.WriteLine();

            /*First() vzima samo purviq element
             Last() vzima samo posledniq element
             Single() vzima samo edin NE SE POLZVA POCHTI NIKOGA*/

            int[] jj = { 1, 2, 3, 4, };

            int first = jj
                .First(x => x % 2 == 0); // purviq cheten element

            int last = jj
                .Last(x => x % 2 ==0); // posledniq cheten element

            int single = jj
                .Single(x => x == 4); // samo edin element koito e = na primerno 4


            Console.WriteLine("first  "+string.Join(" ", first));
            Console.WriteLine("last  " + string.Join(" ", last));
            Console.WriteLine("single  " + string.Join(" ", single)); // Ako ima poveche ot edna 4 ka moje da se schupi 

            Console.WriteLine(); Console.WriteLine();

            /*Reverse() obrushta edin masiv*/
            int[] rev = { 1, 2, 3, 4, };
            rev = rev
                .Reverse()
                .ToArray();

            Console.WriteLine("reverse   "+string.Join(" ", rev));




            Console.WriteLine(); Console.WriteLine();
            /*Concat() ni pozvolqva da svurjem dva masiva :*/

            int[] one = { 1, 2, 3, 4, };
            int[] two = { 5, 6, 7, 8, };

            one = one
                .Concat(two) // svurzvame  two  kum  one
                .ToArray();


            Console.WriteLine("Concat  " + string.Join(" ", one));

            // Concat() SUZDAVA NOV MASIV V PAMETTA !!!




            /*Overview : 
             Dictionaries, keys and values, interate by KeyValuePair<K, V>,
             Lambda i LINQ s teh mojem da reshim pochti vsichki zadachi do sega !*/
        }
    }
}
