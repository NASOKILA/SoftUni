using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndRegex
{
    class StringsAndRegex
    {
        static void Main(string[] args)
        {
            /*
             Shte govorim za stringove i manipulaciq na stringove
             TOVA SHTE E POLSEDNATA ZADACHA NA IZPITA

            Shte govorim za :
            modifikaciq tursene konkatenaciq, extrakciq na substringove i razdelqne
            na stringove , dobavqna i modificirane na stringove,
            
            REGEX : T.E. regulqrni izrazi,
            i regulqrni izrai v C#.


            string e Klas System.String
            stringa e masiv ot charachters i stringa e READ ONLY

            predi inicializiraneto stringa ima stoinost NULL
            vsichki operacii sus string vsushtnost dobavqt nov string

            OPERATORA + E BAVEN ZASHTOTO DOBAVQ NOV STRING
            */


            /*
            MANIPULACIQ NA STRINGOVE:
            string.Compare ni pozvolqva da sravnim dva stringa po azbuchen red
            kakto gi tursim v rechnika
            Nqma znachenie duljinata dokato purvite dukvi ne sa ednakvi
            */

           
            string str2 = "angel";
            string str1 = "Angel";

            // TOVA E FORMA Case-insensative T.E. ne proverqva za golemi bukvi
            int resultCaseInsensative = string.Compare(str1, str2, true); 
            Console.WriteLine(resultCaseInsensative); // v sluchaq dava 0 
            // vrushta 0 ako str1 e raven na str2
            // vrushta -1 ako str1 e predi str2
            // vrushta 1 ako str1 e sled str2
            // purvo gi slaga na malki bukvi i posle gi sravnqva

            //CaseSensative proverqva za golemi bukvi
            int resultCaseSensative = string.Compare(str1, str2, false); // TOVA E FORMA Case-sensative
            Console.WriteLine(resultCaseSensative); // v sluchaq dava 1 zashtoto glaeda i za glavni bukvi

            /*Vinagi chisloto e -1 , 0 ili 1*/


            /* == proverqva dali ediniq string e raven na vtoriq, vrushta true ili false*/
            Console.WriteLine(str1 == str2);
            // No po pravilniq na chin e sus .Equals zashtoto v c# e edno i sushto no v drugi ezici ne e, zaradi pametta !
            Console.WriteLine(str1.Equals(str2));

            // ima i operator === koito v C# ne raboti no v javascript i php stava, koeto e tochno sravnqvane po vsicchko
            /* V C# == sravnqva po stoinosta vutre kakto Equals()CASE-SENSATICE T.E. GLEDA I ZA GOLQMI BUKVI, i
              tova e samo v C#*/

            string aa = "Naso";
            string bb = "naso";

            Console.WriteLine(aa == bb); // dava false zashtoto gleda i za golqmi bukvi


            Console.WriteLine(); Console.WriteLine();

            /*Concat() : 
            subira stringove v edin ! 
            */

            string a = "a";
            string b = "b";
            string c = string.Concat(a, b);
            Console.WriteLine(c);

            //moje da se napravi i sus + i sus +=

            string d = a + b;
            Console.WriteLine(d);



            Console.WriteLine(); Console.WriteLine();
            // kogato imame zalepvane na stringove no izpolzvame int kato nomer STAVA MNOGO BURZO

            string name = "Atanas";
            int age = 24;
            string nameAge = name + " " + age;  // integera stava na string
            Console.WriteLine(nameAge);
            // TAKA MOJEM DA ZALEPVAME KAKVOTO I DA E SAMOCHE SUS + DOBAVQME NA PRAZNO MQSTO I ZADELQME NOVA PAMET
            
            //MOJE I SUS CONCAT()
            string nameAge2 = string.Concat(name, " ", age);
            Console.WriteLine(nameAge2);


            /*
             IndexOf namira poziciqta na opredelen sinvol ili string v drug string
             */

            string email = "atanasskambitovv@gmail.com";
            int pos1 = email.IndexOf("t");
            int pos2 = email.IndexOf("k");
            int positionOfSeveralLetters = email.IndexOf("nas");
            int nonExistingLetter = email.IndexOf("j");

            Console.WriteLine(pos1); // dava ni na koq poziciq e
            Console.WriteLine(pos2); // dava ni na koq poziciq e
            Console.WriteLine(positionOfSeveralLetters);// dava ni ot koq poziciq zapochva toq text
            Console.WriteLine(nonExistingLetter); // ako nqma takova neshto v stringa vrushta -1



            // AKO IMA POVECHE OT EDIN SINVOL KOITO E EDIN I SUSHT TO NAMIRA PURVIQ
            //AKO ISKAME DA NAMERIM POSLEDNIQ DAVAME LastIndexOf():

            int LastEqualLetter = email.LastIndexOf("o");
            Console.WriteLine(LastEqualLetter); // dava ni poziciqta na posledniq sinvol 'o'



            Console.WriteLine(); Console.WriteLine();
            /*Extracting substrings:
             Substring e chast ot golemiq string 
             Mojem da vadim stringove ot stringove ! sus stringName.Substring(ot koq duljina, do koq duljina).
             */
            string fullName = "Atanas Kambitov";

            string firstName = fullName.Substring(0,6); // otreji ot nuleva do shesta poziciq
            Console.WriteLine(firstName); //Atanas

            string lastName = fullName.Substring(7); // otreji ot sedma poziciq natam
            Console.WriteLine(lastName);

            // ako se opitame da vzemem poveche sinvola otkolkoto se sudurjat shte izgurmi : outOfArgumentException


            Console.WriteLine(); Console.WriteLine();
            /*
            Splitting Strings:
            Kak da razdelim edin golqm string na nqkolko elementa:
            IZPOLZVAME Split();
            */

            string listOfCars = "Ford, Reno, BMW, Mercedes.";
            string[] cars = listOfCars.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            // ako go ostavim taka  .Split( ' ',',','.')   shte ima prazni redove

            // Console.WriteLine(string.Join(" ",cars));

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
            // TOVA GO ZNAEM


            Console.WriteLine(); Console.WriteLine();


            /*str.Replace()    razmestva edin string s drug:*/

            string cocktail = "Vodka + Martini + Cherry";
            string replaced = cocktail.Replace("+","and");
            Console.WriteLine(replaced);  // idva si na novo mqsto v pametta
            // mojem da zamestim i edin string sus tri




            Console.WriteLine(); Console.WriteLine();

            /*str.Remove() premahva stringove ot poziciq do duljina !*/
            string price = "1234567 $";
            string newPrice = price.Remove(2, 3); // premahva ot vtora poziciq natam, tri elementa t.e. '345'
            Console.WriteLine(newPrice);


            Console.WriteLine(); Console.WriteLine();
            /*str.Trim() MAHA PRAZNITE MESTA NO MOJE I DA MAHA KAKVOTO MU KAJEM*/
            string s = "     nasokila    ";
            s = s.Trim();
            Console.WriteLine(s);

            //moejm da mahame i drugi sincoli:
            string n = "  /!,.?Nasokila..,!!  ";
            n = n.Trim(' ', '?','/','.',',','!');
            Console.WriteLine(n);

            //IMAME TrimStart(); i TrimEnd();
            string AA = "     C#     ";
            AA = AA.TrimEnd();  // TrimEnd() MAHA POSLEDNITE PRAZNI MESTA
            // AA = AA.TrimStart();   MAHA SAMO PURVITE PRAZNI MESTA   
            Console.WriteLine(AA);

        }
    }
}




