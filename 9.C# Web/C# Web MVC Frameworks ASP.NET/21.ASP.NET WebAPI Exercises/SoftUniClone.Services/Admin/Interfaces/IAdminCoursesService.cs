using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Common.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftUniClone.Services.Admin.Interfaces
{
    public interface IAdminCoursesService
    {
        Task<IEnumerable<CourseConciseViewModel>> GetCoursesAsync();

        Task AddCourseAsync(CourseCreationBindingModel model);

        Task<CourseDetailsViewModel> GetCourseDetailsAsync(int id);
    }
}
