using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string title, string author, decimal price) 
        : base(title, author, price)
    {
       
    }

    
    public override string ToString()
    {
        string result = string.Empty;
        result = (
              $"Type: {this.GetType().Name}" + Environment.NewLine
            + $"Title: {this.Title}" + Environment.NewLine
            + $"Author: {this.Author}" + Environment.NewLine
            + $"Price: {this.Price + (this.Price *= 0.3m):f2}"
            );

        
        return result;
    }

}

