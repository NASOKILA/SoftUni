namespace Employees.App
{
    using Employees.App.Commands.CommandInterface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {

            //Trqbva ni using System.Reflection;
            //SUS SLEDVASHTIQ RED SI VZIMAME CELIQ PROEKT KOITO SE EXCECUTVA
            //V SLUCHAQ E Employees.App
            var assembly = Assembly.GetExecutingAssembly();

            //Vzimame vsichki komandi koito nasledqvat ICommand interfeisa
              var commandTypes = assembly.GetTypes()
                   .Where(ct => ct.GetInterfaces().Contains(typeof(ICommand)));

            //Vzimame si podadenata komanda
              var commandType = commandTypes
                 .SingleOrDefault(t => t.Name == $"{commandName}Command");

              //Ako nqma takava komanda hvurlqme exception
              if (commandType == null)
                  throw new InvalidOperationException("Invalid Command !");
              
            //Vzimame konstruktura (purviq) na nashata komanda
            var constructor = commandType.GetConstructors().First();

            //Vzimame parametrite ot tozi konstruktor
            var constructorParameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            //Ot parametrite vzimame servisite koito polzvame i sega mojem 
            //da go podadem na serviceProvidera i toi da ni vurne tova koeto ni trqbva.
            var services = constructorParameters
                .Select(serviceProvider.GetService)
                .ToArray();

            //kastvame komandata v ICommand ZASHTOTO METODA TOVA TRQBVA DA VURNE !!!
            var command = (ICommand)constructor.Invoke(services);

            return command;

        }
    }
}
