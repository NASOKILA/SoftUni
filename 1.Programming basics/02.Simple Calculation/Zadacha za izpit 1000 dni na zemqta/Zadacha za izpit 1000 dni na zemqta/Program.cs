using System;
using System.Collections.Generic;
using System.Globalization;  // tova ni trqbva za CultureInfo.InvariantCulture ili mu davame null
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_1000_dni_na_zemqta
{
    class Program
    {
        static void Main(string[] args)
        {

            string date = Console.ReadLine();
            string format = "dd-MM-yyyy";
            
            //DateTime e tip   toi e tip data
            DateTime birthday = DateTime.ParseExact(date, format, null);
            // prevrushta datata koqto trqbva da e string vuv formata koito sushto e string no ni trqbva provider kato treti parametur !!!
            birthday = birthday.AddDays(999);

            Console.WriteLine(birthday.ToString(format));  // konvertirame s string i slagame sushtiq format
            // TRQBVA FORMATA DA SUVPADA INACHE DAVA GRESHKA

        }
    }
}
