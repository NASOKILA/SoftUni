using System;




class Dog : Animal
{

    //KONSTRUKTORITE NE SE NASLEDQVAT, TE SE IZVIKVAT !!!
    //Izvikvame animal konstruktora
    public Dog(string name, int age, int weight) : base(name, age, weight)
    {
    }

   

    //Nasledqvame klasa Animal

    public void Bark()
    {
        Console.WriteLine("Bau bau !!!");
    }


    //preapisvame si virtualniq metod !
    public override void Eat()
    {
        // base.Eat();  izvikva bazoviq klas

        // SEGA TOVA SHTE IZLIZA ZA VSQKO EDNO KUCHE DORI I DA SME POLZVALI 
        // METODA OT Animal Klasa !!!
        Console.WriteLine("Dog is Eating ...");

    }

}

    