using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.BookLibrary
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

    class BookLibrary
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());



            Library MyLibrary = new Library() {
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

            Dictionary<string, double> nameAndSum = new Dictionary<string, double>();
            foreach (var book in MyLibrary.BookList.OrderBy(a => a.Price).ThenByDescending(a => a.Author))
            {
                var sumByAuthor = MyLibrary.BookList.Where(au => au.Author == book.Author).Select(ad => ad.Price).Sum();
                nameAndSum[book.Author] = sumByAuthor;

            }


            PrintBooks(nameAndSum);
        }

        private static void PrintBooks(Dictionary<string, double> nameAndSum)
        {
            foreach (var item in nameAndSum.OrderByDescending(a => a.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }
}
