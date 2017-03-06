using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
    public class AndreyAndBilliard
    {
        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> Shop = new Dictionary<string, decimal>();
            SetShop(n, Shop);


            string clients = Console.ReadLine();
            List<Costumer> CostumerShopList = new List<Costumer>();            
            SetCostumerShopList(clients, CostumerShopList, Shop);


            PrintClientProductQuantityAndBill(CostumerShopList, Shop);    


        }

        private static void PrintClientProductQuantityAndBill(List<Costumer> CostumerShopList, Dictionary<string, decimal> Shop)
        {
            decimal totalBill = 0;
            foreach (var Client in CostumerShopList.OrderBy(x => x.Name))
            {
                string product = "";
                decimal quantity = 0;
                
                Console.WriteLine(Client.Name);              // client name
                foreach (var item in Client.BougthProductAndQuantity)
                {
                    product = item.Key;
                    quantity = item.Value;
                    Console.WriteLine("-- {0} - {1}", item.Key, item.Value);   //What the cliend bougth and the quantity
                }

                decimal fullBill = quantity * Shop[product];
                totalBill += fullBill;
                Console.WriteLine("Bill: {0:f2}", fullBill);// the bill the client paid
                
            }
            Console.WriteLine("Total bill: {0:f2}",totalBill);
        }

        private static void SetCostumerShopList( string clients, List<Costumer> CostumerShopList,
            Dictionary<string, decimal> Shop)
        {
            
            char[] separator = { '-', ',' };

            while (!clients.Equals("end of clients"))
            {

                string[] NameProductQuantity = clients.Split(separator).ToArray();
                string name = NameProductQuantity[0];
                string product = NameProductQuantity[1];
                int quantity = int.Parse(NameProductQuantity[2]);

                if (Shop.ContainsKey(product))         // Ako nqma takuv produkt v Shopa da mine na sledvashtiq
                {


                    Dictionary<string, int> ProductQuantity = new Dictionary<string, int>();
                    ProductQuantity[product] = quantity;

                    Costumer client = new Costumer
                    {

                        Name = name,
                        BougthProductAndQuantity = ProductQuantity,

                    };

                    CostumerShopList.Add(client);     // dobavqme si klienta v spisuka !

                    clients = Console.ReadLine();
                }
                else
                    clients = Console.ReadLine();

                
            }


        }

        private static void SetShop(int n, Dictionary<string, decimal> Shop)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                if (price > 9)
                    price = decimal.Parse(input[1]) / 100 ;

                Shop[product] = price;

            }
        }
    }
}
