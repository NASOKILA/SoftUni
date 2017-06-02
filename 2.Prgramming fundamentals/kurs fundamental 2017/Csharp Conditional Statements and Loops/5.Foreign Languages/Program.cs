using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string language = "unknown";
            if (country.Equals("USA") || country.Equals("England"))
            {
                language = "English";
            }
            else if (country.Equals("Spain") || country.Equals("Argentina") ||
                country.Equals("Mexico"))
            {
                language = "Spanish";
            }
            Console.WriteLine(language);
        }
    }
}
