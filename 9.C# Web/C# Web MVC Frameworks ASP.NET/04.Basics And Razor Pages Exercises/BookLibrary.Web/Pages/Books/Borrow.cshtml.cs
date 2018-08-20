using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.Web.Pages.Books
{

    public class BorrowModel : PageModel
    {
        public Book Book { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You have to specify a borrower name.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You have to specify a borrower address.")]
        public string Address { get; set; }

        public void OnGet(int id)
        { }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (var context = new BookLibraryContext())
                {
                    this.Book = context.Books.Find(id);

                    if (context.Borrowers.Any(b => b.Name == this.Name && b.Address == this.Address))
                    {
                        //if borroewr exists
                        Borrower borrower = context.Borrowers.FirstOrDefault(b => b.Name == this.Name && b.Address == this.Address);

                        BorrowersBooks borrowersBooks = new BorrowersBooks
                        {
                            Book = this.Book,
                            BookId = this.Book.Id,
                            BorrowerId = borrower.Id,
                            Borrower = borrower,
                            StartDate = this.StartDate,
                            EndDate = this.EndDate
                        };

                        this.Book.Status = "Borrowed";
                        this.Book.Borrowers.Add(borrowersBooks);

                        context.Books.Update(this.Book);
                        context.SaveChanges();
                    }
                    else
                    {
                        Borrower borrower = new Borrower
                        {
                            Name = this.Name,
                            Address = this.Address
                        };

                        context.Borrowers.Add(borrower);
                        context.SaveChanges();

                        BorrowersBooks borrowersBooks = new BorrowersBooks
                        {
                            Book = this.Book,
                            BookId = this.Book.Id,
                            BorrowerId = borrower.Id,
                            Borrower = borrower,
                            StartDate = this.StartDate,
                            EndDate = this.EndDate
                        };

                        this.Book.Status = "Borrowed";
                        this.Book.Borrowers.Add(borrowersBooks);

                        context.Books.Update(this.Book);
                        context.SaveChanges();
                    }

                    return RedirectToPage("/Index");
                }

            }
            return Page();
        }
    }
}
