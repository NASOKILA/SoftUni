using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class StartUp
    {
        static void Main(string[] args)
        {

        /* //Suzdavame nova instanciq i q zapazvame v promenliva
         BankAccount acc = new BankAccount();

         acc.ID = 1;
         acc.Deposit(decimal.Parse((123.45).ToString()));
         acc.Withdraw(decimal.Parse((23.45).ToString()));

         Console.WriteLine($"Account {acc.ID}, balance {acc.Balance:f2}");
         */

        Person person = new Person(18, "Pesho");
        person.Accounts.Add(new BankAccount(1));
            
        
         
        }
    }












