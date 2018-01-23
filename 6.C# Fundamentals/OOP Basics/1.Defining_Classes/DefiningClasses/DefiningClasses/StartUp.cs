namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
/*
            Dice dice = new Dice() {
                Sizes = 6
            };
            
            Console.WriteLine($"Sizes : {dice.Sizes}");
      */      //Taka ni suzdava pole v klasa POLETATA VINAGI SA private,   private int sizes;
            //i posle si go setvame v get i set; 

            //this sochi kum tekushtiq obekt, polzva se i za drugi neshta.

    
            //mojem da imame mnogo instancii na tozi obekt t.e. mnogo zarcheta.
            try
            {

                Dice dice2 = new Dice();
                dice2.Sizes = 1;
                
                //bi trqbvalo da grunme sus exception
                Console.WriteLine($"Sizes : {dice2.Sizes}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                //Mojem i taka da gi setvame
                Dice dice3 = new Dice(12);
                //dice3.Sizes = 12;

                //Taka minava zashtoto go setvame v konstruktora i ne minava prez settera
                Console.WriteLine($"Sizes : {dice3.Sizes}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*Po princip validaciqta se pravi v settera, no ima i sluchai se slaga v konstruktora.*/




        }
    }
}





