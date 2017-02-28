using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = Console.ReadLine().Split(' ').
                Select(decimal.Parse).ToList();

            var spisuk = new List<decimal>(numbers); // slagame numbers v spisuk
            spisuk.Sort(); //sortirame 
            Console.WriteLine(string.Join(" <= ", spisuk)); // printirame

        }
    }
}
