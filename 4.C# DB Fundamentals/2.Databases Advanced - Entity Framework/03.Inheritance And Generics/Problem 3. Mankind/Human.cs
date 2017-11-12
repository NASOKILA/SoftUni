using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Human
{
    private string firstName;
    private string lastName;

    public Human()
    {

    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }


    public string FirstName
    {
        get { return this.firstName; }
        set
        {

            if (!Char.IsUpper(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            
            this.firstName = value;
        }
    }

    public string LastName 
    {
        get { return this.lastName; }
        set
        {

            //Hvurlq exception zashtoto lastname e "";
            if (!Char.IsUpper(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            this.lastName = value;
        }
    }
    

}

