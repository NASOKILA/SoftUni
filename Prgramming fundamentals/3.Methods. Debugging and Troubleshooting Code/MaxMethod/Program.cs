using System;

namespace MaxMethod
{
    class Program
    {

        static int GetMax(int getA, int getB, int getC)
        {
            int result = 0;
            int maxOfGetAGetB = 0;

            if (getA >= getB) { maxOfGetAGetB = getA; }
            else { maxOfGetAGetB = getB; }

            if (maxOfGetAGetB >= getC) { result = maxOfGetAGetB; }
            else { result = getC; }

            return result;
        }

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int result = GetMax(a, b, c);
            Console.WriteLine(result);
        }
    }
}
