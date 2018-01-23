using System;
using System.IO;
using FastFood.Data;
using System.Linq;
using FastFood.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {

            var orders = context.Employees
                .Where(e => e.Name == employeeName)
                .Select(e => new
                {

                    Name = e.Name,
                    Orders = e.Orders
                    .Where(o => o.Type == (OrderType)Enum.Parse(typeof(OrderType), orderType))
                        .Select(o => new
                        {
                            Customer = o.Customer,
                            Items = o.OrderItems.Select(oi => new
                            {

                                Name = oi.Item.Name,
                                Price = oi.Item.Price,
                                Quantity = oi.Quantity

                            }),
                            TotalPrice = o.OrderItems.Select(ee => ee.Item.Price * ee.Quantity).Sum()


                        }).OrderByDescending(o => o.TotalPrice)
                        .ThenByDescending(o => o.Items.Count()),
                        
                        TotalMade = e.Orders.Select(aa => aa.OrderItems.Select(aaa => aaa.Item.Price * aaa.Quantity).Sum()).Sum()
                });
            //Joann ne go hvashta a go imam v bazata ne znam zasho
            


            var ordersToExport = JsonConvert.SerializeObject(orders, Formatting.Indented);
            
            return ordersToExport;

            

        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{

            Console.WriteLine(categoriesString);

            string[] categoryNames = categoriesString.Split(',').ToArray();
            

            var categories = context.Categories
                .Include(c => c.Items)
                .ThenInclude(c => c.OrderItems)
                .Where(c => categoryNames.Contains(c.Name))
                .Select(c => new {
                    Name = c.Name,
                    MostPopularItem = c.Items
                    .OrderByDescending(p => p.Price * p.OrderItems.Select(pp => pp.Quantity).Sum()).First()
                    
                }).ToArray();



            XDocument xDov = new XDocument();

            XElement cardsElem = new XElement("Categories");

            foreach (var item in categories)
            {
                var category = new XElement("Category");
                var vategoryName = new XElement("Name", item.Name);

                var vategoryMostItem = new XElement("Name", item.MostPopularItem);

                var mostPItemName = new XElement("Name", item.MostPopularItem.Name);
            }

            /*
        xDoc.Add(cardsElem);

        return xDoc.ToString();

    */
            return "";
        }
    }
}