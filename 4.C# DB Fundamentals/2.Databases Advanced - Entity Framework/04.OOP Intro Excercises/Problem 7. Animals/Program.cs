using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {

        string animalType = Console.ReadLine();
        List<Animal> animals = new List<Animal>();
        while (animalType != "Beast!")
        {
            try
            {

                List<string> animalInfo = Console.ReadLine()
                                    .Split()
                                    .ToList();


                string animalName = animalInfo[0];
                int animalAge = int.Parse(animalInfo[1]);
                string animalGender = animalInfo[2];


                if (animalType != "Dog" && animalType != "Cat"
                    && animalType != "Frog" && animalType != "Tomcat"
                    && animalType != "Kitten")
                {
                    throw new ArgumentException("Invalid input!");
                }

                if (animalAge < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                if (animalGender != "Male" && animalGender != "Female"
                    && animalGender != "Tomcat" && animalGender != "Kitten")
                {
                    throw new ArgumentException("Invalid input!");
                }

                

                if (animalType.Equals("Cat"))
                {
                     Cat cat = new Cat(animalName, animalAge, animalGender);
                     animals.Add(cat);   
                }
                else if (animalType.Equals("Dog"))
                {
                    Dog dog = new Dog(animalName, animalAge, animalGender);
                    animals.Add(dog);
                }
                else if (animalType.Equals("Frog"))
                {
                    Frog frog = new Frog(animalName, animalAge, animalGender);
                    animals.Add(frog);
                }
                else if (animalType.Equals("Tomcat"))
                {
                    Tomcat tomcat = new Tomcat(animalName, animalAge, animalGender);
                    animals.Add(tomcat);
                }
                else if (animalType.Equals("Kitten"))
                {
                    Kitten kitten = new Kitten(animalName, animalAge, animalGender);
                    animals.Add(kitten);
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            animalType = Console.ReadLine();

        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            Console.WriteLine(animal.ProduceSound());
        }

    }
}

