using Microsoft.EntityFrameworkCore;
using SoftUniClone.Data;
using System;

namespace SoftUniClone.Tests.Mocks
{
    //Mocks are fake object which we use for testing only !!!
    //We just initialize the DB and return an instance of it
    public static class MockDbContext
    {
        public static SoftUniCloneContext GetContext()
        {
            //Arrange - get what you need
            var options = new DbContextOptionsBuilder<SoftUniCloneContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) //kazvame mu che moje da polzva baza danni
                .Options; //vzimame mu opciite


            var DbContext = new SoftUniCloneContext(options);
            

            return DbContext;
        }        
    }
}
