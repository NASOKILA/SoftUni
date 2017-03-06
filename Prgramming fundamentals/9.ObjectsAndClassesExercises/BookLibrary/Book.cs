using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        public string Title { set; get; }
        public string Autor { set; get; }
        public string Publisher { set; get; }
        public DateTime ReleaseDate{ set; get; }
        public int IsbnNumber { set; get; }
        public double Price { set; get; }


    }
}
