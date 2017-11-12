using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//IMPLEMENTIRAME INTERFEISA IMovabl koito napravihme predi
//Mojem da implementirame mnogo kato gi razdelqme sus zapetaq
class Animal : IMovable
{
    //Za da ne mrunka trqbva da slojim v tozi klas vsichko koeto ima interfeisa !
    //V nashiq skuchai e samo edin metod Move() !!!

    private string name;
    private int age;
    private int weight;

    public Animal(string name, int age, int weight)
    {
        this.Name = name;
        this.Age = age;
        this.Weight = weight;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {

                throw new ArgumentException("Age cannot be less than 0!");
            }
            this.age = value;

        }
    }

    public int Weight
    {
        get { return this.weight; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Weight cannot be less than 0!");
            }
            this.weight = value;

        }
    }


    //Pravim go virtualen za da mojem da o preapisvame i da go promenqme !
    public virtual void Eat()
    {
        Console.WriteLine("Animal is Eating ...");
    }




    //Tova ni trqbva zashtoto sme implementirali interfeisa IMovable
  
    public void Move(int distance)
    {
        Console.WriteLine($"Moved {distance}");
    }

   
}

