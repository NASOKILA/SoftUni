using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{
    static void Main(string[] args)
    {

    

        string[] peopleAndMoney = Console.ReadLine()
            .Split(';')
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();

        List<Person> People = new List<Person>(); 
        foreach (var item in peopleAndMoney)
        {
            string[] itemSplit = item.Split('=').ToArray();
            string name = itemSplit[0];
            decimal money = decimal.Parse(itemSplit[1]);


            Person person = new Person(name, money);
            if (person.personexceptionMade == true)
            {
                Console.WriteLine(person.personError);
                return;
            }

            People.Add(person);
        }



        string[] productsAndPrices = Console.ReadLine()
            .Split(';')
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();


        List<Product> Products = new List<Product>();
        
        foreach (var item in productsAndPrices)
        {
            string[] itemSplit = item.Split('=').ToArray();
            string productName = itemSplit[0];
            decimal productPrice = decimal.Parse(itemSplit[1]);

            Product product = new Product(productName, productPrice);
            if (product.exceptionMade == true)
            {
                Console.WriteLine(product.error);
                return;
            }

            Products.Add(product);
        }




        string command = Console.ReadLine();
        while (command != "END")
        {
            string[] input = command.Split().ToArray();
            string personWhoBouth = input[0];
            string productBougth = input[1];

            decimal price = 0;
            foreach (var item in Products.Where(p => p.Name == productBougth))
            {
                price = item.Price;
            }      
                

            foreach (var item in People.Where(p => p.Name == personWhoBouth))
            {
                if (item.Money >= price)
                {
                    item.Money -= price;

                    foreach (var item2 in Products.Where(p => p.Name == productBougth))
                    {
                        item.Bag.Add(item2);
                    }

                    Console.WriteLine($"{personWhoBouth} bought {productBougth}");
                }
                else
                {
                    Console.WriteLine($"{personWhoBouth} can't afford {productBougth}");
                }
            }



            command = Console.ReadLine();
        }


        foreach (var p in People)
        {

            Console.Write($"{p.Name} - ");

            if (p.Bag.Count == 0)
            {
                Console.Write($"Nothing bought");
            }
            else
            {
                Console.WriteLine(string.Join(", ", p.Bag.Select(b => b.Name)));
            }
        }

    }
}








