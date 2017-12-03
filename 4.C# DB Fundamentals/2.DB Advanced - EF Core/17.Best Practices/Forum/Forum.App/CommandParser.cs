using Forum.App.Commands.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Forum.App
{
    internal class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {
            //iskame da vzemem vsichki neshta koito impolemntirat daden interfeis.
            var assembly = Assembly.GetExecutingAssembly(); //Za tova ni trqbvashe using System.Reflection;

            //Filtrirame gi kato vzimame samo tezi koito implementirat ICommandInterfeisa !
            var commandTypes = assembly.GetTypes()
                .Where(ct => ct.GetInterfaces().Contains(typeof(ICommand)));

            //Vzimame si konkretniq tip koito tursim !
            var commandType = commandTypes
                .SingleOrDefault(t => t.Name == $"{commandName}Command");

            //Ako nqmame takava komanda hvurlqme greshka !
            if (commandType == null)
                throw new InvalidOperationException("Invalid Command !");

            //REFLECTION NI POZVOLQVA MNOGO NESHTA !!!

            //Iskame da napravim nova instanciq na tozi klas kato mu izvikvame konstruktora PURVIQ.
            //Polzvame .GetConstructors() KOETO IDVA OT     using System Reflection;
            var constructor = commandType.GetConstructors().First();

            //Vzimame parametrite ot tozi konstruktor
            var constructorParameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            //Ot parametrite vzimame servisite koito polzvame i sega mojem da go podadem na 
            //serviceProvidera i toi da ni vurne tova koeto ni trqbva.
            var services = constructorParameters
                .Select(serviceProvider.GetService)
                .ToArray();

            //Suzdavame instanciq na tozi klas kato mu podadem services kato parametri
            var command = (ICommand)constructor.Invoke(services);

            return command;

        }
    }
}