using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cat : Animal
{
    //KONSTRUKTORITE NE SE NASLEDQVAT, TE SE IZVIKVAT !!!
    //Izvikvame animal konstruktora
    public Cat(string name, int age, int weight) : base(name, age, weight)
    {
    }

    public void Meaw()
    {
        Console.WriteLine("Meaw ...");
    }
    public override void Eat()
    {
        //base.Eat();

        Console.WriteLine("Cat is eating ...");
    }

}

