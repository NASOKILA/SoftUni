using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briggs
{
    class Briggs
    {
        static void Main(string[] args)
        {

            int briggsCount = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int carrierCapacity = int.Parse(Console.ReadLine());

            if (briggsCount < -1000 || briggsCount > 1000 || workersCount < -1000 || workersCount > 1000
                || carrierCapacity < -1000 || carrierCapacity > 1000)
                return;


            double result = 0;    

           
            if (briggsCount % (workersCount * carrierCapacity) != 0) // ako ima ostatuk
            {
                result = (briggsCount / (workersCount * carrierCapacity)) + 1;  // Dobavqme edinica kum rezultata
            }
            else
                result = briggsCount / (workersCount * carrierCapacity);



            Console.WriteLine(result);


        }
    }
}
