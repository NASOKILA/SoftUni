using System;


namespace StringsAndObjects
{
   public class StringsAndObjects
    {
       public static void Main(string[] args)  // TOZI TEMPLATE GO EXPORTNAHME !!!  VAJNO !!!
        {

            string stringOne = "Hello";
            string stringTwo = "World";
            object objOne = stringOne + " " + stringTwo; // suzdavame obekt koito gi konkatenira s interval mejdu tqh !
            string result = (string)objOne;   // suzdavame treti string result i mu davame stoinosta na obekta !
            Console.WriteLine(result);

        }
    }
}
