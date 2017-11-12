using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Puppy : Dog
{
    //KONSTRUKTORITE NE SE NASLEDQVAT, TE SE IZVIKVAT !!!
    //Izvikvame dog konstruktora
    public Puppy(string name, int age, int weight) : base(name, age, weight)
    {
    }

    public void Weep()
    {
        Console.WriteLine("Weeping ...");
    }

    public override void Eat()
    {
        // base.Eat();

        Console.WriteLine("Puppy is eating ...");
    }
}

