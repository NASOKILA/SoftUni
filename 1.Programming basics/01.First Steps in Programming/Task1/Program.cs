using System;

public class Program
{
    static void Main()
    {
        Console.Beep(432, 500);// produljitelen zvuk
        Console.Write("Hello world"); // hello csharp`programa

        Console.WriteLine("On a new line with writeline !");
        var str = "I am a string";
        //var ch = 'I am a char';

        // zadacha 2 cikul ot razlichni beepove
        for (int i = 200; i <= 400; i += 200)
        {
            Console.Beep(i, 1000);

        }



        // zadacha 3 ot leva na evro
        var leva = int.Parse(Console.ReadLine());
        var euro = leva / 1.95583;
        Console.WriteLine(euro);
    }
}
 