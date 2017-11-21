namespace P03_FootballBetting.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //S 'internal' pravim takache samo nashiq DbContext klas da moje da vleze 
    internal class Configure
    {
        //Pravim go internal i da nqma set;   t.e. mojem samo da go vzimame bez da go setvame ili promenqme !
        internal static string connectionString { get;}
            = @"Server=HAL\MSSQLSERVER2;Database=Football Betting;Integrated Security=true";


    }
}
