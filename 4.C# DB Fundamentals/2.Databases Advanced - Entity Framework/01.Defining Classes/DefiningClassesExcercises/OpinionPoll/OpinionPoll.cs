using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OpinionPoll
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            Person person = new Person();

            string[] input = Console.ReadLine().Split(' ').ToArray();

            person.Name = input[0];
            person.Age = int.Parse(input[1]);

            people.Add(person);
        }


        foreach (var item in people.OrderBy(x => x.Name).ToList())
        {
            if(item.Age > 30)
                Console.WriteLine(item.Name + " - " + item.Age);
        }

    }
}

