
namespace RazorPagesArchitecture.Pages.Books
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DetailsModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            if (id == 0)
            {
                ViewData["DetailsMessage"] = "No Id specified !";
                return Page();
            }
            ViewData["DetailsMessage"] = "Id: " + id;
            return Page();
        }
        
    }
}