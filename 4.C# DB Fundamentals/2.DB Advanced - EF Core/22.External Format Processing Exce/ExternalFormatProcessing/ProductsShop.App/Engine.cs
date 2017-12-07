namespace ProductsShop.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {

        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter Command:");

                string[] input = Console.ReadLine().Split(" ");


                //Imeto na komandata
                string commandName = input[0];

                //Parametrite na komandata
                string[] commandParameters = input
                        .Skip(1)
                        .ToArray();

                try
                {

                    //parsvame komandata kato podavame serviceProvidera i imato na komandata.
                    var command = CommandParser.ParseCommand(serviceProvider, commandName);

                    //podavame parametrite na metoda Excecute koito shte ni vurne rezultata ot komandata 
                    var result = command.Excecute(commandParameters);

                    //Printirame rezultata
                    Console.WriteLine(result);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

    }
}









