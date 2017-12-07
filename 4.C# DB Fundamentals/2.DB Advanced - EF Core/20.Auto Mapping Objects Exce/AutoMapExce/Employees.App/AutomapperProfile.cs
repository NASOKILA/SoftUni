namespace Employees.App
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using Employees.Models;
    using Employees.DtoModels;

    internal class AutomapperProfile : Profile
    {
        /*
            8.V .App si dobavqme nov klas koito s ime AutomapperProfile i 
            da nasledqva  Profile, v nego polzvame utomapper using Automapper i 
            si slagame vsichki konfiguracii koito ni trqbvat. Klasa e internal.
        */

        public AutomapperProfile()
        {
            //Tuk si soagame vsichki konfiguracii koe kum koe da se mapva
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            
            CreateMap<Employee, EmployeePersonalDto>();
            CreateMap<EmployeePersonalDto, Employee>();
        }

    }
}
