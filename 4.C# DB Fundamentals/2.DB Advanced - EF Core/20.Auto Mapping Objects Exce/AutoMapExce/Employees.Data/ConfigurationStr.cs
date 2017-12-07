using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data
{
    public class ConfigurationStr
    {
        //Po pincip e internal no shte ni trqbva za drugo mqsto

        //Ako sloja . ne moje da se svurje sus servera zatova mu zadavam imeto na servera
        public static string connectionString = @"Server=HAL\MSSQLSERVER2;Database=EmployeesDb;Integrated Security=True;";

        //connectionStringa trqbva da e statichen za da mojem da go vikame navsqkude.
    }
}
