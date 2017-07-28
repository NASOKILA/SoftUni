using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleWithStars
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('%',n*2));

            if(n % 2 == 0)
                for (int i = 0; i < n-1; i++)
                {
                    if (i != n/2-1)
                    {
                        Console.Write("%");
                        Console.Write(new string(' ', n * 2 - 2));
                        Console.WriteLine("%");
                    }
                    else
                    {
                        Console.Write("%");
                        Console.Write(new string(' ', n - 2));
                        Console.Write("**");
                        Console.Write(new string(' ', n - 2));
                        Console.WriteLine("%");

                    }
                }
            else
                for (int i = 0; i < n; i++)
                {
                    if (i != (n-1) / 2 )
                    {
                        Console.Write("%");
                        Console.Write(new string(' ', n * 2 - 2));
                        Console.WriteLine("%");
                    }
                    else
                    {
                        Console.Write("%");
                        Console.Write(new string(' ', n - 2));
                        Console.Write("**");
                        Console.Write(new string(' ', n - 2));
                        Console.WriteLine("%");

                    }

                }

            Console.WriteLine(new string('%', n * 2));
        }
    }
}
