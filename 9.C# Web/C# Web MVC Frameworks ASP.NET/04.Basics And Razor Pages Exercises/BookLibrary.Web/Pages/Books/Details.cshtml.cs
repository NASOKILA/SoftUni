namespace BookLibrary.Web.Pages.Books
{
    using System;
    using System.Linq;
    using BookLibrary.Data;
    using BookLibrary.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : PageModel
    {

        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {

            using (var context = new BookLibraryContext()) {

                Console.WriteLine();

                var book = context
                    .Books
                    .Include(b => b.Author)
                    .FirstOrDefault(b => b.Id == id);

                if (book == null) {
                    return RedirectToPage("/Index");
                }

                this.Book = book;

                return Page();
            }
        }
    }
}