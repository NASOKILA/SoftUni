using System;


namespace CubeProperties
{
   public class CubeProperties
    {
        public static void Main(string[] args)
        {
            double sideOfCube = double.Parse(Console.ReadLine());
            string typeOfProperty = Console.ReadLine().ToLower();            
          
            PrintAnswear( sideOfCube, typeOfProperty);
        }

        private static void PrintAnswear(double sideOfTheCube, string typeOfProperty)
        {
            if (typeOfProperty == "face") { PrintFaceOfCube(sideOfTheCube); }
            else if (typeOfProperty == "space") { PrintSpaceOfCube(sideOfTheCube); }
            else if (typeOfProperty == "area") { PrintAreaOfCube(sideOfTheCube); }
            else if (typeOfProperty == "volume") { PrintVolumeOfCube(sideOfTheCube); }
        }      

        private static void PrintFaceOfCube(double sideOfCube)
        {
            double result = Math.Sqrt(2.00 * Math.Pow(sideOfCube, 2));
            Console.WriteLine("{0:f2}", result);
        }

        private static void PrintSpaceOfCube(double sideOfCube)
        {
            double result = Math.Sqrt(3.00 * Math.Pow(sideOfCube, 2));
            Console.WriteLine("{0:f2}", result);
        }

        private static void PrintAreaOfCube(double sideOfCube)
        {
            double result = 6.00 * Math.Pow(sideOfCube, 2.00);
            Console.WriteLine("{0:f2}", result);
        }

        private static void PrintVolumeOfCube(double sideOfCube)
        {
            double result = sideOfCube * sideOfCube * sideOfCube;
            Console.WriteLine("{0:f2}", result);
        }

        
    }
}
