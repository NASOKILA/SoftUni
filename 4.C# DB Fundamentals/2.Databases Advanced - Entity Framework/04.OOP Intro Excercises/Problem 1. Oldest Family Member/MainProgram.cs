using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{
    static void Main(string[] args)
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }




        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        List<Person> listOfPeople = new List<Person>();


        for (int i = 0; i < n; i++)
        {
            string[] p = Console.ReadLine()
                .Split().
                ToArray();

            string personName = p[0];
            int personAge = int.Parse(p[1]);

            Person person = new Person(personName, personAge);
            family.AddMember(person);
        }

        Person result =  family.GetOldestMember();

        Console.WriteLine(result);

    }


}

