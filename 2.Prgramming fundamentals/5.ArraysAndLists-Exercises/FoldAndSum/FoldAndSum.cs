using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            string[] Arr = Console.ReadLine().Split(' ').ToArray();

            int[] Array = new int[Arr.Length];

            for (int i = 0; i < Arr.Length; i++)
            {
                Array[i] = int.Parse(Arr[i]);
            }

            // zadachata zapochva ot tuka

            int[] secondRow = new int[Array.Length/2];
            int counter = Array.Length / 4;
            int counterLength = Array.Length / 4;

            int[] firstRow = new int[Array.Length / 2];
            int counter2 = Array.Length / 4 - 1;
            int counterLength2 = Array.Length / 4;

            int[] sum = new int[Array.Length / 2];




            for (int j = 0; j < Array.Length; j++)
            {
                secondRow[j] = Array[counter];
                counter++;
                if (counter == counterLength + secondRow.Length) { break;}
            }
                     

            for (int h = 0; h < Array.Length; h++)
            {
                firstRow[h] = Array[counter2];

                if (counter2 == 0)
                { counter2 = Array.Length; }
                counter2--;
                if (counter2 == Array.Length - counterLength2 - 1) { break; }
            }
         

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(" ", sum));


        }
    }
}
