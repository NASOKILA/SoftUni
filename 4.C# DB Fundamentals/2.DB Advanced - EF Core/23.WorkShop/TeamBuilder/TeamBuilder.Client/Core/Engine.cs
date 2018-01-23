namespace TeamBuilder.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {

        //setvame v konstruktora dispatchera 
        private readonly CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Command : ");
                    string input = Console.ReadLine();

                    //podavame inputa i ni vrushta rezultata ot komandata
                    string output = commandDispatcher.Dispatch(input);

                    Console.WriteLine(output);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }

    }
}
