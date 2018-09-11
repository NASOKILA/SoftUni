using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoftUniClone.Web.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    [Authorize(Roles = "Administrator, Lecturer")]
    public abstract class LecturerController : Controller
    {
    }
}