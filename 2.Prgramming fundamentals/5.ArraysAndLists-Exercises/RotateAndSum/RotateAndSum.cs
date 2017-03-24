using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAndSum
{
    class RotateAndSum
    {
        static void Main(string[] args)
        {
            /*reverse(A, 0, K-1);
              reverse(A, K, A.length()-1);
              reverse(A, 0, A.length()-1);
              assuming that reverse(A, I, J) operation 
              reverses elements of array A from I-th element to J-th element*/


            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> parsedNumbers = new List<int>(inputNumbers);
            int k = int.Parse(Console.ReadLine());                

            if (parsedNumbers.Count == 0 )// ako duljinata e 0 ili 1 da otpechata samo chiusloto
            {
                Console.WriteLine(string.Join(" ", inputNumbers));
            }
            else
            {

               
                int[] sum = new int[parsedNumbers.Count];
                for (int i = 0; i < parsedNumbers.Count; i++)
                {
                    sum[i] = 0;
                }
                
                for (int i = 0; i < k; i++)  // k puti
                {
                    int last = parsedNumbers[parsedNumbers.Count - 1]; // zapazvame posledniq element
                    parsedNumbers.RemoveAt(parsedNumbers.Count - 1); // mahame posledniq element
                    parsedNumbers.Insert(0, last); // dobavqme posledniq element nai otpred       
              
                    for (int j = 0; j < parsedNumbers.Count; j++)
                    {
                        
                        sum[j] = sum[j] + parsedNumbers[j];
                    
                    }

                }
               
                Console.WriteLine(string.Join(" ", sum));

            }

        }
    }
}
 