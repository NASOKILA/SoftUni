namespace Forum.Services
{
    using Forum.Data;
    using Forum.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DatabaseInitializeService : IDatabaseInitializeService
    {

        private readonly ForumDbContext context;

        public DatabaseInitializeService(ForumDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            //Vdigame bazata, no tq veche ni e vdignata zatova pishem migrate koeto shte q promeni ako ima promeni !
            context.Database.Migrate();
        }

    }
}
