using SoftUniClone.Common.Admin.BindingModels;
using System.Threading.Tasks;

namespace SoftUniClone.Services.Admin.Interfaces
{
    public interface IAdminCourseInstancesService
    {
        Task<InstanceCreationBindingModel> PrepareInstanceForCreationAsync(int courseId);

        Task<int> CreateInstanceAsync(InstanceCreationBindingModel model);
    }
}
