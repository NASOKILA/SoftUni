using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presmqtane_v_programiraneto
{
    class Program
    {
        static void Main(string[] args)
        {

            var Double = double.Parse(Console.ReadLine());
            Console.WriteLine(Double);

            // A = 65   ot ascii tablicata Bukvite si imat imena

            var Char = char.Parse(Console.ReadLine());
            Console.WriteLine(Char);


            var inches = double.Parse(Console.ReadLine());
            var centimeters = inches * 2.54;
            Console.WriteLine(centimeters);
            //Math.Round(1 parameter); zakruglq chislo moje da zakrugli nagore ili na dolo

            Console.WriteLine(Math.Round(centimeters, 4)); // taka rakruglq do 4toto chislo



            //CHETENE NA TEXT  

            // Place holder - pozvolqva da indeksirame promenlivi vutre vuv samiq string

            string name = "Naso";
            string name2 = "Asi";
            string name3 = "Toni";
            Console.WriteLine("Hello {2}", name, name2, name3);  // sled zapetaqta pishem vuzmojnostite za placeholdera a v nego pishem nomera na indeksa koito iskame da e vutre


            Console.WriteLine("Zdravei {0}{5}{1}{4}{2}{3}{6}", name, name2, "kak e ", name3, " e, ", ", ", "?"); // mojem da pravim kakvoto si iskame

            // VSICHKO TOVA MOJE DA SE NAPRAVI S PROSTA KONKATENACIQ TOEST S PLUSOVE

            //Console.WriteLine($"Zdrasti {name2}"); // SAMO VUV VISUAL STUDIO AKO SLOJIM DOLARCHE MOJEM NAPRAVO DA NAPISHEM IMETO NA PROMENLIVATA V PLACEHOLDERA
            //ako ne mahnem dolarcheto  gi schita za stringove

            var firstName = Console.ReadLine();
            var lastName = Console.ReadLine();
            var age = Console.ReadLine();
            var town = Console.ReadLine();

            Console.WriteLine("I am {0} {1}, a {2} years old person from {3}", firstName, lastName, age, town);





        }
    }
}
