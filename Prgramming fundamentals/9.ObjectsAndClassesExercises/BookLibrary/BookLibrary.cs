using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class BookLibrary
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            
            List<Book> books = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                String[] input = Console.ReadLine().Split(' ').ToArray();

                Book book = new Book
                {

                    Title = input[0],
                    Autor = input[1],
                    Publisher = input[2],

                    ReleaseDate = DateTime.ParseExact(input[3],
                    "dd.MM.yyyy", CultureInfo.InvariantCulture),

                    IsbnNumber = int.Parse(input[4]),
                    

                };
                book.Price = double.Parse(input[5]) ;  // VAJNO V JUDJA TRUGVA NO TUK TRQBVA DA GO RAZDELQ NA 100 ZAPOMNI

                books.Add(book);    // Dobavqme si knigata v spisaka s knigi

            }




            Library library = new Library      // dobavqme si v bibliotekata
            {
                Name = "NASO",
                books = books,
            };





            List<Book> sortedBooks = new List<Book>();

            sortedBooks.Add(books[0]);   // dobavqme purvata kniga

            for (int i = 1; i < books.Count; i++)  // zapochvame ot vtorata kniga PURVATA VECHE Q SUDURJAME
                {
                //  double sumOfPricesByAuthor = 0;

                bool containsAutor = false;                                     
                
                    for (int j = 0; j < sortedBooks.Count; j++)
                    {
                        if (sortedBooks[j].Autor == books[i].Autor) // ako sortedbooks sudurja avtor kato tozi na books
                        {
                            containsAutor = true;
                            sortedBooks[j].Price += books[i].Price;  // samo dobavi cenata kum starata cena

                        }
          
                    }

                if (containsAutor == false)   
                    sortedBooks.Add(books[i]);  // Ako nqma takava kniga s takuv avtor mi dobavi knigata


            }




            foreach (var book in sortedBooks
                .OrderByDescending(b => b.Price)
                .ThenBy(b => b.Autor))
            {
                Console.WriteLine("{0} -> {1:f2}",book.Autor, book.Price);
            }



        }
    }
}
