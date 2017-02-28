using System;


namespace TripleSum
{
    public class TripleSum
    {
        public static void Main(string[] args)
        {

            string numbers = Console.ReadLine();

            string[] items = numbers.Split(' ');

            int[] Array = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                Array[i] = int.Parse(items[i]);

            }

            // Ot srtinga parsnahme razdelenite ot Split() nomerata i gi slojihme v masiva Array[] !!!

            // ZADACHATA ZAPOCHVA OT TUKA


            int sum = 0;
            bool check = false;

            for (int firtsDigit = 0; firtsDigit < Array.Length; firtsDigit++)   // ot 0 do obshto broi variacii
            {
                for (int secondDigit = firtsDigit+1; secondDigit < Array.Length; secondDigit++) // slagame go da zapochva ot firstDigit za da ne smqta s minali chisla
                {                   
    
                    sum = Array[firtsDigit] + Array[secondDigit];

                     for (int k = 0; k < Array.Length; k++)
                     {              
                        if (sum == Array[k]) // pravim proverkata dali resultata se sudurja vnqkoi ot stoinostite na masiva
                        {
                            Console.WriteLine("{0} + {1} == {2}", // printirame
                            Array[firtsDigit],
                            Array[secondDigit],
                            sum);
                            check = true;

                            break; 
                            // slagame break ako imame nqkolko povtoreniq edno sled drugo primer: 4 4 4 0 0
                            // kato nameri sbora koito e  4 shte go printira nqkolko puti vmesto samo vednuj
                        }
                    }
                   
                }

            }

            if (check == false) // ako nqma takiva variacii pishem No
            {
                Console.WriteLine("No");
            }

        }
    }
}
