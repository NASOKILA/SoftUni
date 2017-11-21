namespace P01_StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //Pravim go internal za da mojem samo ot tozi proekt da go dostupvame
    internal class Configuration
    {
        internal static string conectionString { get; set; }
            = @"Server=HAL\MSSQLSERVER2; Database=Student System;Integrated Security=True;";
            
    }
}
