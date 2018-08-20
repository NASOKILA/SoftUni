namespace BookLibrary.Web.Pages
{
    using BookLibrary.Data;
    using BookLibrary.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class AddModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(3, ErrorMessage = "Title must be atleast 3 symbols.")]
        public string Title { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Author is required.")]
        [MinLength(3, ErrorMessage = "Author must be atleast 3 symbols.")]
        public string Author { get; set; }

        [BindProperty]
        [Url(ErrorMessage = "The image has to be a URL.")]
        [Required(ErrorMessage = "ImageUrl is required.")]
        public string ImageUrl { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public void OnGet()
        {}

        public IActionResult OnPost()
        {   
            using(var context = new BookLibraryContext())
            {
                var authors = context.Authors.ToList();

                Book book = new Book();

                BookLibrary.Models.Author author = null;

                //We check if the form is valid by using the attributes
                if (!ModelState.IsValid)
                    return Page();

                //id author exists
                if (authors.Select(a => a.Name).Any(a => a == this.Author))
                {
                    author = authors
                        .FirstOrDefault(a => a.Name == this.Author);

                    book.AuthorId = author.Id; 
                }
                else
                {
                    author = new BookLibrary.Models.Author()
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
                return RedirectToPage("/Books/Details", new { id = addedBook.Id });
            }
        }
    }
}
