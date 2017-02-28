using System;


namespace SumArrays
{
    public class SumArrays
    {
        public static void Main(string[] args)
        {
            string values1 = Console.ReadLine();
            string values2 = Console.ReadLine();
            string[] items1 = values1.Split(' ');
            string[] items2 = values2.Split(' ');
            int[] Arr1 = new int[items1.Length];
            int[] Arr2 = new int[items2.Length];
           
            for(int i = 0; i < items1.Length; i++){
                Arr1[i] = int.Parse(items1[i]);
            }

            for (int i = 0; i < items2.Length; i++){
                Arr2[i] = int.Parse(items2[i]);
            }

            int[] result = new int[Math.Max(items1.Length, items2.Length)];
            //duljinata na result e kolkoto tazi na po dulgiq ot dvata masiva !


            int[] ArrMin = new int[Math.Min(Arr1.Length, Arr2.Length)];
            for (int k = 0; k < ArrMin.Length; k++)
            {
                if (Arr1.Length == Math.Min(Arr1.Length, Arr2.Length))
                {
                    ArrMin[k] = Arr1[k];
                }
                else
                {
                    ArrMin[k] = Arr2[k];
                }
            }
            // opredelihme ArrMin[] koito e po malkiq masiv



            int[] ArrMax = new int[Math.Max(Arr1.Length, Arr2.Length)];
            for (int k = 0; k < ArrMax.Length; k++)
            {
                if (Arr1.Length == Math.Max(Arr1.Length, Arr2.Length))
                {
                    ArrMax[k] = Arr1[k];
                }
                else
                {
                    ArrMax[k] = Arr2[k];
                }
            }
            // opredelihme ArrMax[] koito e po golqmiq masiv



            int[] ArrFull = new int[ArrMax.Length];
            // tova shte bude masiv s duljina na ArrMax[] no s elementite na ArrMin[]
            int counter = 0;
            for (int h = 0; h < ArrFull.Length; h++)
            {

                if (h >= ArrMin.Length)
                {
                    ArrFull[h] = ArrMin[counter];
                    counter++;
                    if (counter == ArrMin.Length) { counter = 0; }
                }
                else { ArrFull[h] = ArrMin[h]; }

            }



            for (int i = 0; i < result.Length; i++)    // PRAVIM SI PRESMQTANETO
            {
                if (Arr1.Length != Arr2.Length)
                {
                    result[i] = ArrMax[i] + ArrFull[i];
                    Console.Write(result[i] + " ");
                }
                else
                {
                    result[i] = Arr1[i] + Arr2[i];
                    Console.Write(result[i] + " ");
                }
            }

        }
    }
}
