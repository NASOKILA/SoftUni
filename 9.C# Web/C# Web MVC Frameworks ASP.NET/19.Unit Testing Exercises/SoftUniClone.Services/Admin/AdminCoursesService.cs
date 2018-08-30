using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Common.Admin.ViewModels;
using SoftUniClone.Data;
using SoftUniClone.Models;
using SoftUniClone.Services.Admin.Interfaces;

namespace SoftUniClone.Services.Admin
{
    public class AdminCoursesService : BaseEFService, IAdminCoursesService
    {
        public AdminCoursesService(
            SoftUniCloneContext dbContext,
            IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<CourseConciseViewModel>> GetCoursesAsync()
        {
            var courses = await this.DbContext.Courses.ToListAsync();
            var modelCourses = this.Mapper.Map<IEnumerable<CourseConciseViewModel>>(courses);
            return modelCourses;
        }

        public async Task<CourseDetailsViewModel> GetCourseDetailsAsync(int id)
        {
            var course = await this.DbContext.Courses
                .Include(c => c.Instances)
                .FirstOrDefaultAsync(c => c.Id == id);
            var model = this.Mapper.Map<CourseDetailsViewModel>(course);
            return model;
        }

        public async Task AddCourseAsync(CourseCreationBindingModel model)
        {
            var course = this.Mapper.Map<Course>(model);
            await this.DbContext.Courses.AddAsync(course);
            await this.DbContext.SaveChangesAsync();
        }
    }
}
