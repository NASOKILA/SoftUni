using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class DefineAClassPerson
    {
        static void Main(string[] args)
        {

        Type personType = typeof(Person);
        PropertyInfo[] properties = personType.GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(properties.Length);


        /*Suzdavame si tri obekta po dva razlichni nachina*/
        Person pesho = new Person();
        pesho.Name = "Pesho";
        pesho.Age = 24;
        //Console.WriteLine($"Name:{pesho.Name}, Age:{pesho.Age}");


        Person gosho = new Person();
        gosho.Name = "Gosho";
        gosho.Age = 18;
        //Console.WriteLine($"Name:{gosho.Name}, Age:{gosho.Age}");

        Person stamat = new Person("Stamat", 43);
        //Console.WriteLine($"Name:{stamat.Name}, Age:{stamat.Age}");


    }
}

