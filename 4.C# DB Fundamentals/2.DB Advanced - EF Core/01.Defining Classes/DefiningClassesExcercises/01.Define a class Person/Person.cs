using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    /*Trqbva ni prazen konstruktor za da mojem da si setvame po
     noemalniq nachin*/
    public Person()
    {

    }

    /*Trqbva ni takuv konstrukto za da mojem da se tvame inline, 
     t.e. INLINE INITIALIZATION !!!*/
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

