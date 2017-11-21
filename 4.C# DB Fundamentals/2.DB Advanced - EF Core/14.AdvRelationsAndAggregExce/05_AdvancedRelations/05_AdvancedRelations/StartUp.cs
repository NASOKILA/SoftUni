namespace _05_AdvancedRelations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using P01_BillsPaymentSystem.Data;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {

            using (var db = new BillsPaymentSystemContext())
            {
                Reset(db);


                //Zadacha 3 User Details


                //Poluchavame userId ot konzolata
                string userIdStr = Console.ReadLine();


                //V sluchai che ne poluchim nomer slojih try i catch
                try
                {

                    //Parsvame v Int 
                    int userId = int.Parse(userIdStr);
                
                
                    //Vzimame go ot bazata zaedno s vsichko svurzano s nego !
                    var user = db.Users
                        .Include(u => u.PaymentMethods)
                        .ThenInclude(p => p.BankAccount)
                        .Include(u => u.PaymentMethods)
                        .ThenInclude(p => p.CreditCard)
                        .Where(u => u.UserId == userId)
                        .ToList();

                    if(user.Count < 1)
                    {
                        Console.WriteLine($"User with id {userId} not found!");
                        return;
                    }


                    foreach (var item in user)
                    {
                        Console.WriteLine($"User: {item.FirstName} {item.LastName}");


                        //List All Bank Accounts
                        Console.WriteLine("Bank Accounts:");
                        foreach (var paymentMethod in item.PaymentMethods)
                        {
                            if (paymentMethod.BankAccount != null)
                            {
                                Console.WriteLine($"-- ID: {paymentMethod.BankAccountId}");
                                Console.WriteLine($"--- Balance: {paymentMethod.BankAccount.Balance:f2}");
                                Console.WriteLine($"--- Bank: {paymentMethod.BankAccount.BankName}");
                                Console.WriteLine($"--- SWIFT: {paymentMethod.BankAccount.SwiftCode}");
                            }
                        }

                        //List All Credit Cards
                        Console.WriteLine("Credit Cards:");
                        foreach (var paymentMethod in item.PaymentMethods)
                        {
                            if (paymentMethod.CreditCard != null)
                            {
                                Console.WriteLine($"-- ID: {paymentMethod.CreditCardId}");
                                Console.WriteLine($"--- Limit: {paymentMethod.CreditCard.Limit:f2}");
                                Console.WriteLine($"--- Money Owed: {paymentMethod.CreditCard.MoneyOwed:f2}");
                                Console.WriteLine($"--- Limit Left:: {paymentMethod.CreditCard.LimitLeft:f2}"); //Tova property go ignorirahme zatova go nqma v bazata.
                                Console.WriteLine($"--- Expiration Date: {paymentMethod.CreditCard.ExpirationDate.Year + "/" + paymentMethod.CreditCard.ExpirationDate.Month.ToString("00")}");
                            }
                        }

                    }
                
                }
                catch 
                {
                    Console.WriteLine($"User with id {userIdStr} not found!"); 
                }

            }    

        }

        private static void Reset(BillsPaymentSystemContext db)
        {

            db.Database.EnsureDeleted();
            db.Database.Migrate();          //Pishem migrate za da ni ndapravi bazata s migraciite

            Seed(db);
        }

        private static void Seed(BillsPaymentSystemContext db)
        {
            //Zadacha 2 
            var BankAccounts = new[]
            {
                new BankAccount() { Balance = 12311, BankName = "Societe Generale", SwiftCode = "GHERGFWE" },
                new BankAccount() { Balance = 8866435, BankName = "Bank Of America", SwiftCode = "UKUFBDSF" },
                new BankAccount() { Balance = 345436346, BankName = "UniCredit Bulbank", SwiftCode = "ADWAFFAW" },
                new BankAccount() { Balance = 953342, BankName = "First Investment Bank", SwiftCode = "SDFSGGSE" }
            };
            db.BankAccounts.AddRange(BankAccounts);


            var CreditCards = new[]
            {
                new CreditCard() { Limit = 999999, MoneyOwed = 34531, ExpirationDate = Convert.ToDateTime("05-08-2018") },
                new CreditCard() { Limit = 888888, MoneyOwed = 11261, ExpirationDate = Convert.ToDateTime("01-04-2019") },
                new CreditCard() { Limit = 777777, MoneyOwed = 74235, ExpirationDate = Convert.ToDateTime("09-01-2020") },
                new CreditCard() { Limit = 666666, MoneyOwed = 12655, ExpirationDate = Convert.ToDateTime("02-08-2022") }
            };
            db.CreditCards.AddRange(CreditCards);

            var Users = new[]
            {
                new User() { FirstName = "Atanas", LastName = "Kambitov", Email = "nasko@abv.bg", Password = "75aw745dwa32"},
                new User() { FirstName = "Todor", LastName = "Stoqnov", Email = "toshko@abv.bg", Password = "63627afwa42"}
            };
            db.Users.AddRange(Users);

            var PaymentMethods = new[]
            {
                new PaymentMethod() { User = Users[0], Type = P01_BillsPaymentSystem.Data.Models.Type.BankAccount, BankAccount = BankAccounts[0] },
                new PaymentMethod() { User = Users[0], Type = P01_BillsPaymentSystem.Data.Models.Type.BankAccount, BankAccount = BankAccounts[1] },
                new PaymentMethod() { User = Users[1], Type = P01_BillsPaymentSystem.Data.Models.Type.BankAccount, BankAccount = BankAccounts[2] },
                new PaymentMethod() { User = Users[1], Type = P01_BillsPaymentSystem.Data.Models.Type.BankAccount, BankAccount = BankAccounts[3] },

                new PaymentMethod() { User = Users[0], Type = P01_BillsPaymentSystem.Data.Models.Type.CreditCard, CreditCard = CreditCards[0] },
                new PaymentMethod() { User = Users[0], Type = P01_BillsPaymentSystem.Data.Models.Type.CreditCard, CreditCard = CreditCards[1] },
                new PaymentMethod() { User = Users[1], Type = P01_BillsPaymentSystem.Data.Models.Type.CreditCard, CreditCard = CreditCards[2] },
                new PaymentMethod() { User = Users[1], Type = P01_BillsPaymentSystem.Data.Models.Type.CreditCard, CreditCard = CreditCards[3] }
                

            };
            db.PaymentMethods.AddRange(PaymentMethods);


            db.SaveChanges();

        }
    }
}
