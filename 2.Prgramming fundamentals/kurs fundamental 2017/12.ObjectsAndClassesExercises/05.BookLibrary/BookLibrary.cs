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

            Library MyLibrary = new Library() {
                Name = "NasosLibrary",
                BookList = new List<Book>()
            };

            Dictionary<string, double> nameAndSum = new Dictionary<string, double>();

            SetLibrary(MyLibrary);
            
            SetBooks(MyLibrary, nameAndSum);
            
            PrintBooks(nameAndSum);
        }

        private static void SetBooks(Library myLibrary, Dictionary<string, double> nameAndSum)
        {

            var orderedBookList = myLibrary.BookList.OrderBy(a => a.Price).ThenByDescending(a => a.Author);

            foreach (var book in orderedBookList)
            {
                var sumByAuthor = myLibrary.BookList.Where(au => au.Author == book.Author).Select(ad => ad.Price).Sum();
                nameAndSum[book.Author] = sumByAuthor;

            }

        }

        private static void SetLibrary(Library myLibrary)
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

                myLibrary.BookList.Add(Mybook);

            }
        }

        private static void PrintBooks(Dictionary<string, double> namesAndSums)
        {
            namesAndSums = namesAndSums
                .OrderByDescending(a => a.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key ,v => v.Value);

            foreach (var nameAndSum in namesAndSums)
            {
                Console.WriteLine($"{nameAndSum.Key} -> {nameAndSum.Value:F2}");
            }
        }
    }
}
