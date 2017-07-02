using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // KAK DA IZPOLZVAME REGEX V C#  


            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";  // SLAGAME KLIOMBA OT PRED ZA DA STANE 
            Regex regex = new Regex(pattern); // suzdavame regex sus stringa pattern

            string text = "ivan ivanov, Ivan ivanov, ivan Ivanov,IVan Ivanov, Ivan IvAnov, Ivan Ivanov";

            Match match = regex.Match(text);
            /*Match sudurja length: koeto e duljinata na patterna, success: koeto e true ili false,
             Value: samiq matchnat pattern koito e Ivan Ivanov */

            Console.WriteLine(match); // pokazva Ivan Ivanov



            //DRUGIQ NACHIN E SUS boleva promenliva no shte vidim samo dali se sudurja v text
            bool isTextMatch = regex.IsMatch(text);   // taka razbirame dali se sudurja
            Console.WriteLine(isTextMatch); // dava true
                                            //sega znaem che text sudurja pattern

            

            Console.WriteLine(); Console.WriteLine();
            //AKO IMAME POVECHE MATCHOVE MOJEM DA POLZVAME MatchCollection I SHTE MOJEM DA GI IZVADIM VSICHKI


            string pattern2 = @"(\d{4})-(\d{2})-(\d{2})";
            Regex regex2 = new Regex(pattern2);

            string text2 = "Today is 2016-17-10. Yesterday was 2016-16-10";
            MatchCollection matches = regex2.Matches(text2);

            // STAVA KATO MASIV SUS VSICHKI MATCHOVE KATO ELEMENTI, SUDURJA I OSHTE DRUGI RABOTI
            foreach (Match matched in matches)
            {
                Console.WriteLine(matched);
                //MOJEM DA POKAJEM I GRUPITE:
                Console.WriteLine(matched.Groups[2]);

            }
            /* v sluchaq imame 3 GRUPI SUZDADENI OT NAS ZA GODINA,DEN I MESEC NO IMAME I DRUGA KOQTO 
               E PURVATA, [0] KOQTO E CELIQ REGEX T.E. godina + den + mesec !!!!! 
            
             */





            /*Replacing with Regex:
             
             */

            string pattern3 = @"\d{3}";
            Regex regex3 = new Regex(pattern3);

            string text3 = "Nakov: 123, Krasi: 456";

            text3 = regex3.Replace(text3, "***"); // ZAMESTIHME REGEXA SUS ***

            Console.WriteLine(text3);





            // Ako NAPISHEM  . V REGEX OZNACHAVA KAKVOTO I DA E
            //  .* oznachava KAKVOTO I DA E EDIN ILI POVECHE PUTI
            // \S oznachava  ne prazno mqsto

            // + tursi pone edin sinvol a * tursi 0 ili poveche sinvoli







            /*string Split()  moje i da raboti i vuv Regex :*/

            string t = "1     2  3      4";
            string patt = @"\s+";
            string[] results = Regex.Split(t, patt);
            // Mojem da splitvame edin text po regex a ne samo po string


            Console.WriteLine(string.Join(", ", results)); // 1, 2, 3, 4




            /*
            
            Any   i   All:
             
            ako imame nqkamva kolekciq  primerno  2 3 4 5 6 7
            ANY: shte proveri dali elementite otgovarqt na nqkoe uslovie
            primerno imame uslovie: x % 2 == 0;
            Any shte zamesti vsqko edno chislo sus x i shte vidi dali otgovarq na uslovieto
            Ako elementa otgovarq na uslovieto shte dade true, ako ne false i minava na sledvashtiq element
            CELTA E DA NAMERI ELEMENT KOITO DA OTGOVARQ NA USLOVIETO
            
            ALL: shte proveri dali vsichki elementi otgovarqt na uslovieto, ako otgovarqt shte date true
            ako ne shte dade false.   
             
             
            */

            string nums = "2468";    // tova e nashata kolekciq

            if (nums.All(x => x % 2 == 0))   //ako vsichki elementi sa chetni
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            if (nums.Any(n => n % 2 == 1))     // ako ima pone edin necheten element
                Console.WriteLine("false");
            else
                Console.WriteLine("false");









            /*
             LOOK AROUNDS:
             positive look ahead, negative look ahead
             positive look behind, negative look behind

            MEJDU TQH SE SLAGAT REGEXI
            MESTAT KURSERA KUDETO NA NAS NI TRQBVA, POMAGAT MNOGO

            (?=...) - positive look ahead
            (?<=...) - positive look behind
            
            primer:
            
            tursim text mejdu taga <p>...</p>
             (?=<p>)...PISHEM SI REGEKSA...(?<=</p>)



            negative look ahead i negative look behind gledat da go nqma edin element za da matchne 
            za razlika ot positive koito gleda da go ima .

             */



            /*Summary:
             
             string builder e po burzo za manipulacii
             stringovete pri promqna suzdavat novi stringove

            Regular expressions 
             
             */
        }
    }
}
