using System;

namespace DayOfWeek
{
    public class DayOfWeek
    {
        public static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());            
            string[] daysOfTheWeek = new string[7]; // suzdavame masiva
            SetDaysOfWeek(daysOfTheWeek); // slagame mu imenata na dnite

            PrintDaysOfWeek(day, daysOfTheWeek); // printirame podadeniq den ot sedmicata
        }

        public static void SetDaysOfWeek(string[] daysOfWeek) {
            // vkarvame si masiva kato parametur i mu davame stoinosti!
            daysOfWeek[0] = "Monday";
            daysOfWeek[1] = "Tuesday";
            daysOfWeek[2] = "Wednesday";
            daysOfWeek[3] = "Thursday";
            daysOfWeek[4] = "Friday";
            daysOfWeek[5] = "Saturday";
            daysOfWeek[6] = "Sunday";

           
        }

        public static void PrintDaysOfWeek(int day, string[] daysOfTheWeek ) {

            SetDaysOfWeek(daysOfTheWeek);    // IZVIKVAME TAZI FUNKCIQ TUK ZA DA STANE 

            if (day == 1 || day == 2 || day == 3 || day == 4 || day == 5 || day == 6 || day == 7)
            {
                day--; // namalqvame day s 1 zashtoto  masivite zapochvat ot 0
                Console.WriteLine(daysOfTheWeek[day]);  // printirame vkaraniq ot konzolata den
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }

        }
    }
}
