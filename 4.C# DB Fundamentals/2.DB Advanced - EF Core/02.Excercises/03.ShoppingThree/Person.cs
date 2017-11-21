using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    private string name { get; set; }
    private decimal money { get; set; }
    private List<Product> bag { get; set; }
    public bool personexceptionMade = false;
    public string personError = "";

    public Person()
    {

    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    //Validacii:

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == string.Empty || value == " ")
            {
                personError = "Name cannot be empty";
                personexceptionMade = true;
            }

            this.name = value;
        }
    }


    public decimal Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                personError = "Money cannot be negative";
                personexceptionMade = true;   
            }

            this.money = value;
        }
    }

    public List<Product> Bag
    {
        get { return this.bag; }
        set { this.bag = value; }
    }
}











