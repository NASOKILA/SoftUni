namespace BookLibrary.Web.Pages
{
    using BookLibrary.Data;
    using BookLibrary.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;

    public class AddModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            
            using(var context = new BookLibraryContext())
            {
                var authors = context.Authors.ToList();

                Book book = new Book();

                Models.Author author = null;
                
                //id author exists
                if (authors.Select(a => a.Name).Any(a => a == this.Author))
                {
                    author = authors
                        .FirstOrDefault(a => a.Name == this.Author);

                    book.AuthorId = author.Id; 
                }
                else
                {
                    author = new Models.Author()
                    {
                        Name = this.Author
                    };

                    context.Authors.Add(author);
                    context.SaveChanges();

                    book.AuthorId = context.Authors
                        .FirstOrDefault(a => a.Name == this.Author)
                        .Id;
                }

                book.Title = this.Title;
                book.Status = "At home";
                book.Description = this.Description;
                book.CoverImage = this.ImageUrl;

                context.Books.Add(book);
                author.Books.Add(book);
                context.SaveChanges();
                

                Book addedBook = context.Books.FirstOrDefault(a => 
                    a.Title == this.Title &&
                    a.Description == this.Description &&
                    a.CoverImage == this.ImageUrl);

                ///Books/Details/{addedBook.Id}
                return RedirectToRoute($"/Index");
            }

        }

    }
}