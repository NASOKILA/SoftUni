using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
   public class ComparingFloats
    {
      public static void Main(string[] args)
        {
            /*Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001. Note that
            we cannot directly compare two floating-point numbers a and b by a==b because of the nature of the floating-point
            arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than some fixed
            constant eps.*/

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool isItEqual = false;
            double diff = Math.Abs(a - b);

            if (diff < eps) {

                isItEqual = true;
            }

            Console.WriteLine(isItEqual);
        }
    }
}
