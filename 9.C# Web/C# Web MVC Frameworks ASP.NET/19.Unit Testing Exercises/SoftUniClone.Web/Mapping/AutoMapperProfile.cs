using AutoMapper;
using SoftUniClone.Common.Admin.BindingModels;
using SoftUniClone.Models;

namespace SoftUniClone.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<InstanceCreationBindingModel, CourseInstance>();
        }
    }
}
