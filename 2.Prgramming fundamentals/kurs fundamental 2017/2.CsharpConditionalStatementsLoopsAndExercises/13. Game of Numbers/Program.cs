using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool numFound = false;

            for (int i = N; i <= M; i++)
            {
                for (int j = N; j <= M; j++)
                {
                    combinations++;
                    
                    if (numFound == false) {
                        if (magicNum == j + i)
                        {
                            Console.WriteLine($"Number found! {j} + {i} = {magicNum}");
                            numFound = true;
                            break;
                        }
                    }
                }
                if (numFound == true)
                    break;    
            }

            if (numFound == false)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNum}");
               
            }

        }
    }
}
