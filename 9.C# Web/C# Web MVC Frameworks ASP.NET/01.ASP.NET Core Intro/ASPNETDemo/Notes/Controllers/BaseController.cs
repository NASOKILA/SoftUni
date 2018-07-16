using Microsoft.AspNetCore.Mvc;
using Notes.Data;

namespace Notes.Controllers
{
    public class BaseController : Controller
    {
        protected NotesContext Context { get; set; }

        protected BaseController()
        {
            this.Context = new NotesContext(); 
        }

    }
}
