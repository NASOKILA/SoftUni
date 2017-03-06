using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace BookLibraryModification
{
    public class BookLibraryModification
    {
        public static void Main(string[] args)
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
                book.Price = double.Parse(input[5]);  // VAJNO V JUDJA TRUGVA NO TUK TRQBVA DA GO RAZDELQ NA 100 ZAPOMNI

                books.Add(book);    // Dobavqme si knigata v spisaka s knigi

            }


          



            Library library = new Library      // dobavqme si v bibliotekata
            {
                Name = "NASO",
                books = books,
            };






            DateTime date = DateTime.ParseExact(Console.ReadLine()         // TRQBVA DA PRINTIRAME KNIGITE OBISANI SLED TAZI DATA
               , "dd.MM.yyyy", CultureInfo.InvariantCulture);






            List<Book> sortedBooks = new List<Book>();

            foreach (var book in books)  // vsichki izdadeni knigi sled taq data gi slagame v sortedBooks
            {
                if (book.ReleaseDate > date) {
                    sortedBooks.Add(book);
                }
            }



            foreach (var book in sortedBooks
                .OrderBy(b => b.ReleaseDate)
                .ThenBy(b => b.Autor))
            {
                Console.WriteLine("{0} -> {1:f2}", book.Title, book.ReleaseDate.ToString("dd.MM.yyyy"));
            }



        }
    }
}
