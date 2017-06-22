using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

            Library MyLibrary = new Library()
            {
                Name = "NasosLibrary",
                BookList = new List<Book>()
            };

            SetBooks(MyLibrary);

            DateTime afterDate =  DateTime.ParseExact(Console.ReadLine()
                ,"dd.MM.yyyy"
                , CultureInfo.InvariantCulture);

            PrintResult(afterDate, MyLibrary);

        }

        private static void PrintResult(DateTime afterDate, Library MyLibrary)
        {

            var newBookList = MyLibrary.BookList.Where(d => d.ReleaseDate > afterDate).OrderBy(a => a.ReleaseDate).ThenBy(a => a.Title).ToList();

            foreach (var item in newBookList)
            {
                Console.WriteLine($"{item.Title} -> {item.ReleaseDate.Day:D2}.{item.ReleaseDate.Month:D2}.{item.ReleaseDate.Year}");
            }
        }

        private static void SetBooks(Library MyLibrary)
        {
            int n = int.Parse(Console.ReadLine());

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

        }
    }
}
