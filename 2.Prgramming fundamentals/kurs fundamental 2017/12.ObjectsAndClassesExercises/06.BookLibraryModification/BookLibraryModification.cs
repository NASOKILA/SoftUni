using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BookLibraryModification
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> BookList { get; set; }
    }

    class BookLibraryModification
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());



            Library MyLibrary = new Library()
            {
                Name = "NasosLibrary",
                BookList = new List<Book>()
            };

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                Book Mybook = new Book()
                {
                    Title = input[0],
                    Author = input[1],
                    Publisher = input[2],
                    ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBN = input[4],
                    Price = double.Parse(input[5])

                };

                MyLibrary.BookList.Add(Mybook);

            }


            foreach (var item in MyLibrary.BookList)
            {

            }

        }
    }
}
