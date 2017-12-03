namespace Forum.App
{
    using Forum.Services.Contracts;
    using System;
    using Forum.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    //Tozi klas shte inicializira bazata, da inkapsulira logikata na nasheto priojenie i shte izpulnqva komandite ni.
    //Shte bude kato main metoda, a v main metoda samo shte napravim instanciq na tozi klas i shte mu podadem service providera za da raboti s nego.
    public class Engine
    {
        //TOZI KLAS NE trQBVA DA ZNAE ZA BAZATA 


        private IServiceProvider serviceProvider;

        //ot tozi konstruktor shte podadem service proviedera na tozi klas
        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {


            //Instalirame si paketa Microsoft.Extensions.DependencyInjection za da mojem da polzvame IService<> i IServiceCollection<>, IServiceProvider i dr.
            //using Microsoft.Extensions.DependencyInjection; za damojem da gi polzvame !!!
            
            //Vzimame si userservisa, SEGA MOJEM DA POLZVAME VSICHKO OT NEGO
            var userService = serviceProvider.GetService<IUserService>();

            //Predi da polzvame interfeisite trqbva da gi slojim v konfiguraciite.
            var databaseSeedService = serviceProvider.GetService<IDatabaseInitializeService>();

            databaseSeedService.InitializeDatabase();


            while (true)
            {
                //SEGA MOJEM DA POLZVAME VSICHKO KOETO SUZDADOHME V USERSERVICE-a
                Console.WriteLine("Enter Command: ");

                var input = Console.ReadLine();

                var commandTokens = input.Split(" ");

                var commandName = commandTokens.First();

                var commandArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    //parsvame comandata chrez metoda koito suzdadohme
                    var command = CommandParser.ParseCommand(serviceProvider, commandName);

                    //puskame komandata i q zapisvame v promenliva
                    var result = command.Excecute(commandArgs);

                    //pokazvame rezultata.
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

            }



        }
    }
}
