using System;
using System.Collections.Generic;
using System.Linq;


namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {

            
            String commandLine = Console.ReadLine();

            

            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while ( ! commandLine.Equals("END")) // vkarvame dokato ne napishem END
            {
                string[] commandArgs = commandLine.Split(' '); // splitvame

                string command = commandArgs[0]; // ravno na purvata komanda

                if (command.Equals("A")) // Ako e a
                {
                    // Add
                    string name = commandArgs[1];  //  ime
                    string number = commandArgs[2];  // nomer

                    phonebook[name] = number;  
                    // mojem i sus Add(name, number); no ako imame dva klucha s edno ime shte dade gredshka // dobavqme gi v rechnika

                }
                else if (command.Equals("S"))
                {
                    //search
                    string name = commandArgs[1];


                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine("{0} -> {1}", name, phonebook[name]); // vzimame imeto i toka koeto v rechnuika otgovarq na tova ime 
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", name);
                    }
                }

                commandLine = Console.ReadLine();
            }
             
        }
    }
}
