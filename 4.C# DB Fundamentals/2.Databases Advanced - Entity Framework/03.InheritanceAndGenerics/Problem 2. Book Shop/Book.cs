using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book( string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price  = price;
    }


    public virtual string Author
    {
        get { return this.author; }
        set
        {
            string[] args = value.Split();

            //Proverqvame dali ima familno ime
            if (args.Length == 2)
            {
                char ch = args[1][0];
                if (Char.IsDigit(ch))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }



    public virtual string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }


    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0 )
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
            //String.Format("{0:0.00}", 123.4567);
        }
    }


    public override string ToString()
    {
        string result = string.Empty;
        result = (
              $"Type: {this.GetType().Name}" + Environment.NewLine
            + $"Title: {this.Title}" + Environment.NewLine
            + $"Author: {this.Author}" + Environment.NewLine
            + $"Price: {this.Price:f2}"
            );

        return result;
    }

}


