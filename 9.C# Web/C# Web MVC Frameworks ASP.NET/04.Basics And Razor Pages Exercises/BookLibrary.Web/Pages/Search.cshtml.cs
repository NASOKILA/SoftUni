namespace BookLibrary.Web.Pages
{
    using BookLibrary.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;
    using System.Text;

    public class SearchModel : PageModel
    {
        [BindProperty]
        public string Search { get; set; }

        public string Authors { get; set; }

        public string Books { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            using (var context = new BookLibraryContext()) {

                StringBuilder authorsString = new StringBuilder();

                StringBuilder booksString = new StringBuilder();

                var authors = 
                    context
                    .Authors
                    .Where(a => a.Name.Contains(this.Search))
                    .ToList();
                
                foreach (BookLibrary.Models.Author author in authors)
                {
                    authorsString.AppendLine(
                        $@"<li><a href=""/author/details/{author.Id}"">
                            {author.Name.ToString()
                                .Replace(this.Search, $"<span class=\"paint\">{this.Search}</span>")
                                .Replace(this.Search.ToUpper(), $"<span class=\"paint\">{this.Search.ToUpper()}</span>")}
                        </a>(author)</li>");
                }

                this.Authors = authorsString.ToString();
                
                var books =
                    context
                    .Books
                    .Where(a => a.Title.Contains(this.Search))
                    .ToList();
                
                foreach (BookLibrary.Models.Book book in books)
                {
                    booksString.AppendLine(
                        $@"<li><a href=""/books/details/{book.Id}"">
                            {book.Title.ToString()
                                .Replace(this.Search, $"<span class=\"paint\">{this.Search}</span>")
                                .Replace(this.Search.ToUpper(), $"<span class=\"paint\">{this.Search.ToUpper()}</span>")}
                        </a>(book)</li>");
                }

                this.Books = booksString.ToString();
                
                return Page();
            }
        }
    }
}