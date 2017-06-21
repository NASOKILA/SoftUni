using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var nasko = new
            {
                age = 25,
                name = "Atanas",
                year = 1992
            };

            // operatora new suzdava neshto novo

            Console.WriteLine(nasko);


            var stringObject = new String('s', 3);

            Console.WriteLine(stringObject);
            

        }
    }
}
