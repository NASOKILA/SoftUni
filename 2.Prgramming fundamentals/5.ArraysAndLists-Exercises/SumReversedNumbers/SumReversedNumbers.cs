using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumReversedNumbers
{
    class SumReversedNumbers
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;

            for(int i = 0; i<input.Length;i++) { // do duljinata na input

                int rev = 0;

                while (input[i] > 0) {  // dokato chisloto input[i] e po golqmo ot 0

                    int r = input[i] % 10; // vzimme poslednata cifra ot elementa
                    rev = rev * 10 + r;   // slagame go v r kato edinichni, desetichno i  t. n.
                    input[i] = input[i] / 10;  // triem poslednata cifra ot elementa

                    //PRAVIM GO NA VSICHKI ELEMENTI !!!
                }
                sum = sum + rev;

            }
            Console.WriteLine(sum);

        }
    }
}
