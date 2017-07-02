using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.MelrahShake
{
    class MelrahShake
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string key = Console.ReadLine();
            

            while (true)
            {

                var leftIndex = input.IndexOf(key);
                var rightIndex = input.LastIndexOf(key);

                // ako nenameri indexa znachi shte vurne -1 t.e. ako e != ot -1 znachi ima suvpadenie
                bool leftIndexExist = leftIndex != -1;
                bool rightIndexExist = rightIndex != -1;

                // za da sheiknem trqbva da imame pone 2 suvpadeniq
                // ako indexiste sa im razlichni imame > 1 uvpadeniq
                bool okToShake = leftIndex != rightIndex;

                bool keyNotEmpty = key != string.Empty;

                if (leftIndexExist && rightIndexExist && okToShake && keyNotEmpty)
                {
                    // we are ready to shake
                    // input = "astalavista baby";
                    // remove first match
                    input = input.Remove(leftIndex, key.Length);
                    // remove second match
                    input = input.Remove(rightIndex - key.Length, key.Length);

                    Console.WriteLine("Shaked it.");

                    // remove middle elment from the key
                    key = key.Remove(key.Length / 2, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }

            Console.WriteLine(input);


        }
    }
}
