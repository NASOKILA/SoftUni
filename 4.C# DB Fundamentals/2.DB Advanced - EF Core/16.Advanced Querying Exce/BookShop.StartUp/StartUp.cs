namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            using (var db = new BookShopContext())
            {

                //DbInitializer.ResetDatabase(db);

                
                //Zd 1.
                    string command = Console.ReadLine();
                    var zdOneResult = GetBooksByAgeRestriction(db, command);
                    Console.WriteLine(zdOneResult);
                

                /*
                //Zd 2.
                var zdTwoResult = GetGoldenBooks(db);
                Console.WriteLine(zdTwoResult);
                */

                /*
                //Zd 3.
                var zdThreeResult = GetBooksByPrice(db);
                Console.WriteLine(zdThreeResult);
                */

                /*
                //Zd 4.
                int year = int.Parse(Console.ReadLine());
                var zdFourResult = GetBooksNotRealeasedIn(db, year);
                Console.WriteLine(zdFourResult);
                */

                /*
                //Zd 5. NOT FINISHED
                string categories = Console.ReadLine();
                string zdFiveResult = GetBooksByCategory(db, categories);
                Console.WriteLine(zdFiveResult);
                */

                /*
                //Zd 6.
                string date = Console.ReadLine();
                string zdSixResult = GetBooksReleasedBefore(db, date);
                Console.WriteLine(zdSixResult);
                */

                /*
                //Zd 7.
                string nameEndsWith = Console.ReadLine();
                string zdSevenResult = GetAuthorNamesEndingIn(db, nameEndsWith);
                Console.WriteLine(zdSevenResult);
                */

                /*
                //Zd 8.
                string input = Console.ReadLine();
                string zdEightResult = GetBookTitlesContaining(db, input);
                Console.WriteLine(zdEightResult);
                */

                /*
                //Zd 9.
                string input = Console.ReadLine();
                string zdNineResult = GetBooksByAuthor(db, input);
                Console.WriteLine(zdNineResult);
                */

                /*
                //Zd 10.
                int lengthCheck = int.Parse(Console.ReadLine());
                string zdTenResult = CountBooks(db, lengthCheck);
                Console.WriteLine(zdTenResult);
                */

                /*
                //Zd 11.
                string zdElevenResult = CountCopiesByAuthor(db);
                Console.WriteLine(zdElevenResult);
                */

                /*
                //Zd 12.
                string zdTwelveResult = GetTotalProfitByCategory(db);
                Console.WriteLine(zdTwelveResult);
                */

                /*
                //Zd 13.
                string zdThirtenResult = GetMostRecentBooks(db);
                Console.WriteLine(zdThirtenResult);
                */

                //Zd 14.
                //IncreasePrices(db);

                /*
                //Zd 15.
                int zdFifteenReult = RemoveBooks(db);
                Console.WriteLine(zdFifteenReult);
                */
            }
        }

        public int RemoveBooks(BookShopContext db)
        {
            int result = 0;

            var books = db.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            result = books.Count;

            db.Books.RemoveRange(books);
            db.SaveChanges();
            
            return result;
        }
        public void IncreasePrices(BookShopContext db)
        {
            //NQMA DA POLZVAME BULK OPERACII (BEZ DA GI DURPAME OT BAZATA).

            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                //VAJNO: AKO POLZVAME ANONIMEN OBEKT ZA DA SELEKTIRAM SAMO Price NQMA DA MOGA DA PROMENQM STOINOSTTA !!!
                book.Price = book.Price + 5; 
            }

            db.SaveChanges();
        }
        public string GetMostRecentBooks(BookShopContext db)
        {
            //get all categories ordered by bokCount

            var categories = db.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(cb => cb.Book),
                    BookCount = c.CategoryBooks.Select(cb => cb.Book).Count()

                }).OrderBy(c => c.Name)
                .ToList();

            //Shte polzvame stringBuilder za rezultata
            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.Append($"--{category.Name}" + Environment.NewLine);
                int counter = 0;
                foreach (var book in category.Books.OrderByDescending(b => b.ReleaseDate))
                {
                    if (counter != 3)
                    {
                        result.Append($"{book.Title} ({book.ReleaseDate.Value.Year})" + Environment.NewLine);
                        counter++;
                    }

                }
            }

            return result.ToString();

        } 
        
        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            string result = string.Empty;

            var categories = db.Categories
                .Select(c => new {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Select(cb => cb.Book.Price).Sum() * c.CategoryBooks.Select(cb => cb.Book.Copies).Sum()
                })
                .OrderByDescending(a => a.TotalProfit)
                .ThenBy(a => a.CategoryName)
                .ToList();
            //Problema beshe che mi trqbvashe sumata (.Sum() lipsvashe) a az se opitvah da vzema cqlata kolekciq !!!


            result = string.Join("\n", categories.Select(a => $"{a.CategoryName} ${a.TotalProfit}"));

            return result;
        }
        public static string CountCopiesByAuthor(BookShopContext db)
        {

            string result = string.Empty;

            var authors = db.Authors
                .Select(a => new {
                    Name = a.FirstName + " " + a.LastName,
                    BookCopiesCount = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.BookCopiesCount)
                .ToList();

            result = string.Join("\n", authors.Select(a => $"{a.Name} - {a.BookCopiesCount}"));

            return result;

        }
        public static string CountBooks(BookShopContext db, int lengthCheck)
        {
            
            string result = string.Empty;

            var books = db.Books
                .Select(b => new {
                    b.Title
                })
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            result = string.Join("\n", books.Count);

            return result;
        }
        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            input = input.ToLower();

            input = input.First().ToString().ToUpper() + input.Substring(1);

            string result = string.Empty;

            var books = db.Books
                .Select(b => new {
                    b.BookId,
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .Where(b => b.AuthorLastName.StartsWith(input))
                .OrderBy(a => a.BookId)
                .ToList();

            result = string.Join("\n", books.Select(b => b.Title + " (" + b.AuthorFullName + ")"));

            return result;
        }
        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            input = input.ToLower();

            input = input.First().ToString().ToUpper() + input.Substring(1);
            
            string result = string.Empty;
            
            var books = db.Books
                .Where(b => b.Title.Contains(input))
                .Select(b => new {
                    b.Title
                })
                .OrderBy(a => a.Title)
                .ToList();

            result = string.Join("\n", books.Select(b => b.Title));

            return result;
        }
        public static string GetAuthorNamesEndingIn(BookShopContext db, string nameEndsWith)
        {

            string result = string.Empty;
            

            var authors = db.Authors
                .Where(b => b.FirstName.EndsWith(nameEndsWith))
                .Select(b => new {
                    Name = b.FirstName + " " + b.LastName
                })
                .OrderBy(a => a.Name)
                .ToList();

            result = string.Join("\n", authors.Select(b => b.Name));

            return result;

        }
        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            string result = string.Empty;
            
            var books = db.Books
                .Where(b => b.ReleaseDate < Convert.ToDateTime(date))
                .Select(b => new {
                    b.EditionType,
                    b.Title,
                    b.Price
                })
                .ToList();

            result = string.Join("\n", books.Select(b => b.Title + " - " + b.EditionType + " - $" + b.Price));

            return result;

        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            command = command.ToLower();
            string strCommand = (command.First().ToString().ToUpper() + command.Substring(1)).ToString();

            int intCommant = -1;

            if (strCommand == "Minor")
                intCommant = 0;
            else if (strCommand == "Teen")
                intCommant = 1;
            else if (strCommand == "Adult")
                intCommant = 2;
            else
                return "";

            
            string result = string.Empty;

            var books = context.Books
                .Where(b => (int)b.AgeRestriction == intCommant)
                .Select(b => new {
                    b.Title
                })
                .OrderBy(a => a.Title)
                .ToList();
           
            result = string.Join("\n", books.Select(b => b.Title));
            
            return result;

        }
        public static string GetGoldenBooks(BookShopContext context)
        {

            string result = string.Empty;


            var books = context.Books
                .Where(b => (int)b.EditionType == 2)
                .Where(b => b.Copies < 5000)
                .Select(b => new
                {   
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();


            result = string.Join("\n", books.Select(b => b.Title));

            return result;
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            string result = string.Empty;

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();
            
            result = string.Join("\n", books.OrderByDescending(b => b.Price).Select(b => b.Title + " - $" + b.Price));


            return result;
        }
        public static string GetBooksNotRealeasedIn(BookShopContext db, int year)
        {
            string result = string.Empty;


            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();


            result = string.Join("\n", books.Select(b => b.Title));

            return result;
        }
        public static string GetBooksByCategory(BookShopContext db, string categories)
        {

            List<string> listOfCategories = categories.Split(' ').ToList();
            string result = string.Empty;

            var books = db.Books
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .OrderBy(b => b.Title)
                .Where(b => b.BookCategories.Any(bc => listOfCategories.Contains(bc.Category.Name)))
                .ToList();
            //VAjno !

            result = string.Join("\n", books.Select(b => b.Title));
            
            return result;
        }


    }
}
