using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data
{
    internal class Configuration
    {
        internal static string connectionString { get; set; }
            = @"Server = HAL\MSSQLSERVER2; Database = BillsPaymentSystem; Integrated Security = True";
    }
}
