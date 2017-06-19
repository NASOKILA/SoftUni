using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionariesAndListsMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            int totalseconds = 120;
            int minutes = totalseconds / 60;
            int seconds = totalseconds % 60;

            int n = 5;
            Console.WriteLine($"Total seconds {totalseconds} = {minutes}m {seconds}s");
            Console.WriteLine($"I dont give {n:D5} shits !");
        }
    }
}
