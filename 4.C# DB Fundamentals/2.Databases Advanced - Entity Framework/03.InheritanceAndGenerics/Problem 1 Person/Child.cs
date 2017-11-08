using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Child : Person
{



    public override int Age
    {// TRQBVA DA POLZVAME 'base' ZADULJITELNO ZA DA DOSTUPIM base stoinostta!
        get { return base.Age; }
        set
        {
            if (value > 15)
                throw new ArgumentException("Child's age must be less than 15!");

            base.Age = value; 
        }
    }

    //Nasledqvame i konstruktora ot Person klasa !!!
    public Child(string name, int age)
     : base(name, age)
    {
        this.Age = age;
    }


}

