using System;

namespace MathPower
{
    class Program
    {
        static double GetMathPower(double number, double power) {

            return Math.Pow(number, power);
        }

        static void Main(string[] args)
        {

            double n = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());
            double mathPower = GetMathPower(n,pow);
            Console.WriteLine(mathPower);
        }
    }
}
