using FindMyPet.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Tests.Mocks
{
    public static class MockDbContext  
    {
        public static FindMyPetDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<FindMyPetDbContext>()
                .Options; 
            
            var DbContext = new FindMyPetDbContext(options);
            
            return DbContext;
        }
    }
}
