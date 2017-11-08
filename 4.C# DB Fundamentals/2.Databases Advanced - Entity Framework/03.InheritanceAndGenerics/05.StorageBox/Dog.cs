using System;




class Dog
{

    private string name;
    private int age;
    private int weight;

    //KONSTRUKTORITE NE SE NASLEDQVAT, TE SE IZVIKVAT !!!
    //Izvikvame animal konstruktora
    public Dog(string name, int age, int weight)
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
        set { this.age = value; }
    }

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }



    //Nasledqvame klasa Animal

    public void Bark()
    {
        Console.WriteLine("Bau bau !!!");
    }


    //preapisvame si virtualniq metod !
    public void Eat()
    {
        // base.Eat();  izvikva bazoviq klas

        // SEGA TOVA SHTE IZLIZA ZA VSQKO EDNO KUCHE DORI I DA SME POLZVALI 
        // METODA OT Animal Klasa !!!
        Console.WriteLine("Dog is Eating ...");

    }

}

    