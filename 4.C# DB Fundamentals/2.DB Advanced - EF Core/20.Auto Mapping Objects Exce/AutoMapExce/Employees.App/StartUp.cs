namespace Employees.App
{
    using AutoMapper;
    using Employees.Data;
    using Employees.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {

            

            var serviceProvider = ConfigureServices();
            var engine = new Engine(serviceProvider);
            engine.Run();
        }


        //Konfiguraciq na interfeisite
         static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            //Pravim si DbContexta
            serviceCollection.AddDbContext<EmployeesContext>(options => options
                .UseSqlServer(ConfigurationStr.connectionString));

            //Dobavqme si interfeisite ako reshim da gi pravim
            
            serviceCollection.AddTransient<EmployeeService>();
            
            serviceCollection.AddAutoMapper(conf => conf.AddProfile<AutomapperProfile>());
        
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }

    }
}
