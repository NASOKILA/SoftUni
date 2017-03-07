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

            int productsCount = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> Shop = new Dictionary<string, decimal>();
            SetShop(productsCount, Shop);


            string clients = Console.ReadLine();
            List<Costumer> Clients = new List<Costumer>();
            SetCostumerShopList(clients, Clients, Shop);


            PrintClientProductQuantityAndBill(Clients, Shop);


        }

        private static void PrintClientProductQuantityAndBill(List<Costumer> Clients, Dictionary<string, decimal> Shop)
        {
            decimal totalBill = 0;
            foreach (var Client in Clients.OrderBy(x => x.Name))
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
            Console.WriteLine("Total bill: {0:f2}", totalBill);
        }

        private static void SetCostumerShopList(string clients, List<Costumer> Clients,
            Dictionary<string, decimal> Shop)
        {


            
            while (!clients.Equals("end of clients"))
            {

                string[] NameProductQuantity = clients.Split(',','-').ToArray();
                string name = NameProductQuantity[0];
                string product = NameProductQuantity[1];
                int quantity = int.Parse(NameProductQuantity[2]);
                
                if (!Shop.ContainsKey(product))         // Ako nqma takuv produkt v Shopa da mine na sledvashtiq
                {
                    continue;
                }

                if (Clients.Any(c => c.Name == name))
                {
                    // ANY PROVERQVA DALI NQKOI OT OBEKTITE NA DADENIQ LIST SUDURJA ELEMENT KOITO OTGOVARQ NA DADENO USLOVIE
                    // s ANY mojem da obhojdame elementite na daden obekt VAJNO , DAVA TRUE AKO SUSHTESTVUVATAKUV OBEKT !
                    // V sluchaq proverqvame dali veche ima KLIENT S IME KATO name

                    Costumer costumer = Clients.First(c => c.Name == name); // pravim sushtata proverka s first()

                    if (!costumer.BougthProductAndQuantity.ContainsKey(product))
                    {
                        // proverqvame dali veche ima takava poruchka, ako nqma q dobavqme !
                        costumer.BougthProductAndQuantity.Add(product, quantity);

                    }
                    else
                    {
                        // Ako ima takava poruchka prosto i subirame quantity-to
                        costumer.BougthProductAndQuantity[product] += quantity;

                    }

                    costumer.Bill += quantity * Shop[product];   // TOVA E SMETKATA

                }
                else
                {
                    // Ako v spisuka Clients ne se sudurja klient s Ime = na name
                    Costumer costumer = new Costumer();  //suzdavame si go si go
                    costumer.Name = name;
                    costumer.BougthProductAndQuantity = new Dictionary<string, int>(); // inicializirame si direktoriqta za da ne grumne !

                    costumer.BougthProductAndQuantity.Add(product, quantity); //dobavqme si poruchkata
                    costumer.Bill += quantity * Shop[product]; // Pravim si smetkata

                    Clients.Add(costumer); // dobavqme si klienta kum spisuka s klienti
                }




                clients = Console.ReadLine();
                          


            }


        }




        private static void SetShop(int productsCount, Dictionary<string, decimal> Shop)
        {
            for (int i = 0; i < productsCount; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                if (price > 9)
                    price = decimal.Parse(input[1]) / 100;

                
                    Shop[product] = price;
                
            }
        }
    }
}

