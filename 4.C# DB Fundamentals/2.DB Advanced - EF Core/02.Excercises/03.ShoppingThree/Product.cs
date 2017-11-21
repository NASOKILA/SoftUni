using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Product
{

    //poletata
    private string name;
    private decimal price;
    public bool exceptionMade = false;
    public string error = "";

    //konstruktorite
    public Product()
    {
    }

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    //Pravim si validaciite
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == string.Empty || value == " ")
            {
                error  = "Name cannot be empty";
                exceptionMade = true;
            }

            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            
            if (value <= 0)
            {
                exceptionMade = true;
                error = "Money cannot be negative";
                
            }

            this.price = value;

        }
    }

}

