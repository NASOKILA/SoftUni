namespace TeamBuilder.Client.Utilities
{
    using System;
    //Proverqva duljinata na podaden masiv i ako ima greshka hvurlq daden exception ot klasa Constraints
    public class Checks
    {
        public static void CheckLenght(int expectedLength, string[] array)
        {
            if (expectedLength != array.Length)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }
        }

    }
}
