using AutoMapper;
using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Data;
using SoftUniClone.Models;
using SoftUniClone.Services.Admin.Interfaces;
using System;
using System.Threading.Tasks;

namespace SoftUniClone.Services.Admin
{
    public class AdminCourseInstancesService : BaseEFService, IAdminCourseInstancesService
    {
        public AdminCourseInstancesService(
            SoftUniCloneContext dbContext,
            IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<InstanceCreationBindingModel> PrepareInstanceForCreationAsync(int courseId)
        {
            var course = await this.DbContext.Courses.FindAsync(courseId);
            if (course == null)
            {
                return null;
            }

            var model = new InstanceCreationBindingModel()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                CourseId = course.Id,
                Name = course.Name
            };

            return model;
        }

        public async Task<int> CreateInstanceAsync(InstanceCreationBindingModel model)
        {
            var instance = this.Mapper.Map<CourseInstance>(model);
            await this.DbContext.CourseInstances.AddAsync(instance);
            await this.DbContext.SaveChangesAsync();

            return instance.Id;
        }
    }
}
