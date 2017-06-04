using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.DNA_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string sequence = string.Empty;

            char ii = ' ';
            char jj = ' ';
            char hh = ' ';

            char matched = ' ';

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4 ; j++)
                {
                    for (int h = 1; h <= 4; h++)
                    {
                        if (i == 1) { ii = 'A'; }
                        else if (i == 2) { ii = 'C'; }
                        else if (i == 3) { ii = 'G'; }
                        else if (i == 4) { ii = 'T'; }

                        if (j == 1) { jj = 'A'; }
                        else if (j == 2) { jj = 'C'; }
                        else if (j == 3) { jj = 'G'; }
                        else if (j == 4) { jj = 'T'; }

                        if (h == 1) { hh = 'A'; }
                        else if (h == 2) { hh = 'C'; }
                        else if (h == 3) { hh = 'G'; }
                        else if (h == 4) { hh = 'T'; }

                        if ((i + j + h) >= n)
                            matched = 'O';
                        else
                            matched = 'X';

                        sequence = sequence + ii + jj + hh;
                        Console.Write($"{matched}{sequence}{matched} ");
                        sequence = string.Empty;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
