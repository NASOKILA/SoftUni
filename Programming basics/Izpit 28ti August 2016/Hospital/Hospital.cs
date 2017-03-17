using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int treatedPatients = 0;
            int untreatedPatients = 0;
            int doctors = 7;

            int counter = 0;
            if (days < 1 && days > 1000)
                return;

                for (int i = 0; i < days; i++)
                {
                    int patientsPerDay = int.Parse(Console.ReadLine());
                    if (patientsPerDay < 1 && patientsPerDay > 10000)
                        return;

                
                if (counter == 2)
                {
                    if (treatedPatients < untreatedPatients)
                        doctors++;
                    
                        counter = -1;
                }
                counter++;

                int currentTreatedPatients = Math.Min(doctors, patientsPerDay);           
                int currentUntreatedPatients = patientsPerDay - doctors;

                if (currentUntreatedPatients < 0)
                    currentUntreatedPatients = 0;

               

                treatedPatients += currentTreatedPatients;
                untreatedPatients += currentUntreatedPatients;

               

               
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");

        }
    }
}
