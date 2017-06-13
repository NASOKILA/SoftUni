using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Jump_Around
{
    class Jump_Around
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int collectedCells = 0;
            
            int index = Array.IndexOf(array, array[0]);
            int numOfIndex = int.MinValue;


                

            

           // Console.WriteLine(collectedCells);

        }
    }
}
