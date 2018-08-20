using AutoMapper;
using SoftUniClone.Models;
using SoftUniClone.Web.Areas.Admin.Models.ViewModels;

namespace SoftUniClone.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
        }
    }
}
