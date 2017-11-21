namespace P03_SalesDatabase.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Configuration
    {
        public static string connectionString { get; set; }
        = @"Server=HAL\MSSQLSERVER2; Database=Sales; Integrated Security=True";
    }
}
