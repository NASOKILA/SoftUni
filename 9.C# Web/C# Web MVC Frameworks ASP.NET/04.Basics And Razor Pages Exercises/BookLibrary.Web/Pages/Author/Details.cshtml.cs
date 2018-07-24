namespace BookLibrary.Web.Pages.Author
{
    using BookLibrary.Data;
    using BookLibrary.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DetailsModel : PageModel
    {
        public Author Author { get; set; }

        public string BooksString { get; set; }

        public IActionResult OnGet(int id)
        {
            using (var context = new BookLibraryContext())
            {
             
                var author = context.Authors.Find(id);

                if (author == null)
                {
                    return RedirectToPage("/Index");
                }

                this.Author = author;

                StringBuilder sb = new StringBuilder();

                List<Book> books = context
                    .Books
                    .Where(b => b.AuthorId == author.Id)
                    .ToList();

                foreach (var b in books)
                {
                    sb.AppendLine($@"
                        <li>
                            <a href=""/books/details/{b.Id}"">{b.Title}</a>({b.Status})
                        </li>");
                }

                this.BooksString = sb.ToString();

                return Page();
            }
        }
    }
}