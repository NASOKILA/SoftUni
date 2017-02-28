using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of people : ");
            int numberOfPeople = int.Parse(Console.ReadLine());

            Console.Write("Enter number capacity : ");
            int capacity = int.Parse(Console.ReadLine());

            double fullCourses = (double)numberOfPeople / capacity;
            fullCourses = Math.Ceiling(fullCourses);

            Console.Write("Courses needed = ");
            Console.WriteLine(fullCourses);
        }
    }
}
