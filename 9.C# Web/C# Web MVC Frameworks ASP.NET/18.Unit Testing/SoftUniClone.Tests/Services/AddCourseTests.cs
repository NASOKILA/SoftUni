using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Data;
using SoftUniClone.Models;
using SoftUniClone.Services.Admin;
using SoftUniClone.Tests.Mocks;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniClone.Tests.Services
{
    [TestClass]
    public class AddCourseTests
    {
        private SoftUniCloneContext DbContext { get; set; }

        private IMapper Mapper { get; set; }
        
        private AdminCoursesService Service;
        
        [TestInitialize]
        public void BeforeEachTest()
        {
            this.DbContext = MockDbContext.GetContext();
            
            this.Mapper = MockAutoMapper.GetMapper();

            this.Service = new AdminCoursesService(this.DbContext, this.Mapper);
        }

        [TestMethod]
        public async Task AddCourse_WithCourse_ShpuldAddItCorrectly()
        {
            
            var courseModel = new CourseCreationBindingModel()
            {
                Name = "New Course Name",
                Slug = "new-course-name"
            };


            await this.Service.AddCourseAsync(courseModel);

            //check count
            Assert.AreEqual(1, this.DbContext.Courses.Count());

            //check name
            Assert.AreEqual(courseModel.Name, this.DbContext.Courses.First().Name);
            
            //check slug
            Assert.AreEqual(courseModel.Slug, this.DbContext.Courses.First().Slug);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => this.Service.AddCourseAsync(null));
        }       
    }
}
