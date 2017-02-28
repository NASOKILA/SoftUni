using System;


namespace CondenseArrayToNumber
{
    public class CondenseArrayToNumber
    {
        public static void Main(string[] args)
        {

            string values = Console.ReadLine();
            string[] items = values.Split(' ');

            int[] Arr = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                Arr[i] = int.Parse(items[i]);
            }

           
            while (Arr.Length > 1)
            {
                int[] Cond = new int[Arr.Length - 1];

                for (int i = 0; i < Cond.Length; i++)
                {
                    Cond[i] = Arr[i] + Arr[i + 1];
                }

                Arr = Cond; // slagame Arr da e ravno na cond, taka mu namalqvame duljinata s 1
              
            }
            Console.WriteLine(Arr[0]);
        }
    }
}
