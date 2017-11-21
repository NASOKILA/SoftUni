using System;
using System.Collections.Generic;
using System.Text;

namespace Forum
{
    //Pravim go public
    public class Configuration
    {
        //Hubavo e da napravim Connection Stringa taka za po sigurno.
        public const string ConnectionString 
            = @"Server=HAL\MSSQLSERVER2;Database=Forum;Integrated Security=True;";

        //Bazata ni shte se kazva Forum, OSHTE NE SME Q SUZDALI !
        //S metoda .EnsureCreated() PROVERQVAME DALI DADENA BAZA E SUZDADENA I AKO NE E, Q SUZDAVAME !
        //S metoda .Migrate() MOJEM DA MIGRIRAME TABLICI. 
        
        /*
            VAJNO !!!
            Trqbva da si pusnem SQL Server(HAL\MSSQLSERVER2) OT 'Services' AKO NE NI E PUSNAT VECHE !
         */
    }
}
