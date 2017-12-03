namespace Forum.Services.Contracts
{

    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IDatabaseInitializeService
    {
        //Shte si napravim metod za slagane na danni koito shte go 
        //ima vseki klas koito si implementne tozi interfeis
        void InitializeDatabase();

    }
}
