using AutoMapper;
using SoftUniClone.Models;
using SoftUniClone.Web.Areas.Admin.Models.BindingModels;
using SoftUniClone.Web.Areas.Admin.Models.ViewModels;

namespace SoftUniClone.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
            this.CreateMap<CourseCreationBindingModel, Course>(); //map the CourseBindingModel class to a Course class
            this.CreateMap<Course, CourseConciseViewModel>();
            this.CreateMap<Course, CourseDetailsViewModel>();
            this.CreateMap<InstanceCreationBindingModel, CourseInstance>();
        }
    }
}
