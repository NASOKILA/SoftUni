

namespace BookLibrary.Web.Pages
{
    using BookLibrary.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;

    public class SearchModel : PageModel
    {
        public string Search { get; set; }

        public string Result { get; set; }

        public void OnGet()
        {}

        public IActionResult OnPost(string search)
        {
            this.Search = search;

            using (var context = new BookLibraryContext()) {

                var authors = context.Authors.ToList();



                var books = context.Books.ToList();


            }

                this.Result = search;
            
            return Page();
        }

    }
}