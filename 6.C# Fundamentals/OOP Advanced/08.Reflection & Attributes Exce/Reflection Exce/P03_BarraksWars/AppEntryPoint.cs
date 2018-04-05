﻿

namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Abstractions;
    using P03_BarraksWars.Core;
    using System;
    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            //PRAVIM DEPENDENCY INJECTION t.e. IZNASQME LOGIKATA IZVUN ENGINA!!!

            //pravim is service provider, TOVA E KATO CHANTA KOQTO SHTE PULNIM SUS SERVISI. 
            //V SLUCHAQ IMAME SAMO DVA: repository I unitFactory
            IServiceProvider serviceProvider = ConfigureService();
            
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            //Pravim si chantata:
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
