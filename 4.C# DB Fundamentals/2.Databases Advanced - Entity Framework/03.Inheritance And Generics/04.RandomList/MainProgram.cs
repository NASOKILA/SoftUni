using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{       
    static void Main(string[] args)
    {   
        RandomList randomlist = new RandomList();

        for (int i = 0; i < 10; i++)
        { 
            //Vkarvame neshta v spisuka
            randomlist.Add("Pesho" + i);
        }

        //Printirame Random element ot spisuka koito napulnihme
        Console.WriteLine(randomlist.RandomElement());

        //Printirame vsichki elementi v spisuka
        foreach (var pesho in randomlist)
        {
            Console.WriteLine(pesho);
        }

    }   
}       
        
