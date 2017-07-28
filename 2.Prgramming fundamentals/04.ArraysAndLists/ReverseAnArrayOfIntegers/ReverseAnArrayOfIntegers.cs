using System;


namespace ReverseAnArrayOfIntegers
{
    public class ReverseAnArrayOfIntegers
    {
        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] Arr = new int[n];          

            PrintArray(n,Arr);
            
        }


        public static void SetArray(int num, int[] Array)
        {
            for (int i = 0; i < num; i++)
            {
                Array[i] = int.Parse(Console.ReadLine());
            }
        }

        public static void PrintArray(int num, int[] Array)
        {

            SetArray(num, Array); // zaduljitelno izvikvame tozi metod tuk

            for (int i = num-1; i >= 0; i--) // TRQBVA DA ZAPOCHNEM OT  n-1  DO  >=0   VAJNO!!!
            {
                Console.WriteLine(Array[i]);
            }
           
        }

    }
}
