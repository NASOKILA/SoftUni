using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SoftUniClone.Data;
using SoftUniClone.Models;
using SoftUniClone.Services.Lecturer.Interfaces;

namespace SoftUniClone.Services.Lecturer
{
    public class LecturerCourseInstancesService : BaseEFService, ILecturerCourseInstancesService
    {
        private readonly UserManager<User> userManager;

        public LecturerCourseInstancesService(
            SoftUniCloneContext dbContext,
            IMapper mapper,
            UserManager<User> userManager)
            : base(dbContext, mapper)
        {
            this.userManager = userManager;
        }
    }
}
