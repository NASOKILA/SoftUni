using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Events
    {
        static void Main(string[] args)
        { 
            
            /*
             SORTIRANI RECHNICI :
             Razlikata pri tqh e che ttse sortirat po kluchove :
             Ako klucha e string se sortira po azbuchen red.
             Ako e int ot po malko kum po golamo
             Ako e char ot po malko kum po golamo 
             i t.n.
             
             Po baven e ot standartniq rechnik no elementite tuk 
             vinagi vlizat avtomatichno sortirani.
             */


            //Tazi zadacha e sus SortedDictionary<>
            var events = new SortedDictionary<DateTime, string>(); 
            // suzdavame sortiran rechnik

            events[new DateTime(1998, 9, 4)] = "Google's birthday.";
            events[new DateTime(2014, 11, 5)] = "SoftUni's birthday.";
            events[new DateTime(1975, 4, 4)] = "Microsoft's birthday.";
            events[new DateTime(2004, 2, 4)] = "Facebook's birthday.";
            events[new DateTime(2014, 11, 5)] = "SoftUni was found.";
            //dobavihme vsichkki elementi i sega avtomatichno shte gi sortira !

            foreach (var item in events)
            {
                Console.WriteLine("{0: dd-MM-yyyy}: {1}",item.Key, item.Value);
                // Datite avtomatichno sa sortirani ot po malko kum po golqmo !!!
            }
        }
    }
}
