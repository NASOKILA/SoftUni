using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftUniClone.Data;
using SoftUniClone.Services.Admin;
using SoftUniClone.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniClone.Tests.Services
{
    [TestClass]
    public class AdminCourseService
    {

        private SoftUniCloneContext DbContext { get; set; }

        private IMapper Mapper { get; set; }

        private AdminCoursesService Service;

        [TestInitialize]
        public void BeforeEachTest()
        {
            //we get the context from this mock class that we just created.
            this.DbContext = MockDbContext.GetContext();
            
            //THE MAPPER IS ALREADY INITILIZED IN THE PREVIOUS TEST
            this.Mapper = AutoMapper.Mapper.Instance;

            //var mapper = new IMapper();
            this.Service = new AdminCoursesService(this.DbContext, this.Mapper);
        }
        
        [TestCleanup]
        public void AfterEachTest()
        {}
        
        [TestMethod] //name        pre condition    post condition
        public async Task GetAllCourses_WithFewCourses_ShouldReturnAll()
        {
            //Dobavqme danni v bazata, posle shte q testvame sus metoda ot servica.
            this.DbContext.Courses.Add(new Models.Course() { Id = 1, Name = "My Course" });
            this.DbContext.Courses.Add(new Models.Course() { Id = 2, Name = "My Course 2" });
            this.DbContext.Courses.Add(new Models.Course() { Id = 3, Name = "My Course 3" });
            this.DbContext.SaveChanges();

            //Act - do something
            var courses = await this.Service.GetCoursesAsync();

            //Assert - check solution
            Assert.IsNotNull(courses);
            Assert.AreEqual(courses.Count(), 3);
        }

        [TestMethod] 
        public async Task GetAllCourses_WithNoCourses_ShouldReturnNone()
        {
            this.DbContext.SaveChanges();

            //Act - do something
            var courses = await this.Service.GetCoursesAsync();

            //Assert - check solution
            Assert.IsNotNull(courses);
            Assert.AreEqual(courses.Count(), 0);
        }

    }
}









