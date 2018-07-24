namespace BookLibrary.Web.Pages
{
    using BookLibrary.Data;
    using BookLibrary.Models;
    using BookLibrary.Web.Pages.Models;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IndexModel : PageModel
    {
        public List<BookIndexModel> Books { get; set; }

        public void OnGet()
        {
            using (var context = new BookLibraryContext())
            {
                var books = context.Books.Include(b => b.Author)
                        .Select(b => new BookIndexModel() {
                            Id = b.Id,
                            Author = b.Author,
                            Title = b.Title,
                            Status = b.Status
                        })
                        .ToList();

                this.Books = books;

                StringBuilder sb = new StringBuilder();

                foreach (BookIndexModel book in books)
                {

                    if (book.Status == "Borrowed")
                    {
                        sb.Append($@"
                        <tr>
                            <td><a href=""/books/details/{book.Id}"">{book.Title}</a></td>
                            <td><a href=""/author/details/{book.Author.Id}"">{book.Author.Name}</a></td>
                            <td class=""borrowed"">{book.Status}</td>
                        </tr>");
                    }
                    else
                    {
                        sb.Append($@"
                        <tr>
                            <td><a href=""/books/details/{book.Id}"">{book.Title}</a></td>
                            <td><a href=""/author/details/{book.Author.Id}"">{book.Author.Name}</a></td>
                            <td>{book.Status}</td>
                        </tr>");
                    }
                }

                ViewData["Books"] = sb;
            }
        }
    }
}
