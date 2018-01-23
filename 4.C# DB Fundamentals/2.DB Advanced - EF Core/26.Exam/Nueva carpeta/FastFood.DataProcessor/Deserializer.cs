using System;
using FastFood.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using FastFood.DataProcessor.Dto.Import;
using System.Text;
using FastFood.Models;
using AutoMapper;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var deseriaizedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            List<Employee> validEmployees = new List<Employee>();

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in deseriaizedEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                
                

                //Ako poziciqta sushtestvuva v bazata
                //Vzimame q
                Position position = context.Positions
                    .SingleOrDefault(p => p.Name == employeeDto.Position);


                if (position == null)
                {

                    position = new Position()
                    {
                        Name = employeeDto.Position
                    };

                    context.Positions.Add(position);
                    context.SaveChanges();
                }
                


                //pravim si employeeto
                Employee employee = new Employee()
                {
                    Age = employeeDto.Age,
                    Name = employeeDto.Name,
                    Position = position
                };

                validEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
                
            }

            

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var deseriaizedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            List<Item> validItems = new List<Item>();

            StringBuilder sb = new StringBuilder();

            foreach (var itemDto in deseriaizedItems)
            {
                
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                //PRI DECIMAL "0.01" VALIDTORA GURMI
                if (itemDto.Price < (decimal)0.01 )
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                //proverqvame dali sushtestvuva itema 
                bool alreadyExists = validItems.Any(i => i.Name == itemDto.Name);

                if (alreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Vzimame si kategoriqta ot bazata
                Category category = context.Categories.SingleOrDefault(c => c.Name == itemDto.Category);

                //Ako q nqma v bazata q suzdavame i q dobavqme v bazata
                if (category == null)
                {
                    category = new Category()
                    {
                        Name = itemDto.Category
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();
                }

                Item item = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };
                
                
                validItems.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));


            }


            context.Items.AddRange(validItems);
            context.SaveChanges();

            return sb.ToString();

        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {

            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (OrderDto[])serializer
                .Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
           // XDocument xDoc = XDocument.Parse(xmlString);

            StringBuilder sb = new StringBuilder();

            List<Order> validOrders = new List<Order>();

            foreach (var orderDto in deserializedOrders)
            {

                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                
                //get employee

                Employee employee = context.Employees.SingleOrDefault(e => e.Name == orderDto.Employee);

                //Ako go nqma
                if (employee == null || orderDto.DateTime == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Order items
                if (orderDto.Customer == null || orderDto.DateTime == null
                    || orderDto.Employee == null || orderDto.Type == null
                    || orderDto.Items == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Vzimame si enum
                var type = Enum.Parse<OrderType>(orderDto.Type);

                if (OrderType.ForHere == type || OrderType.ToGo == type)
                { }
                else
                {
                    //Enum ne sushtestvuva
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var orderItems = new List<OrderItem>();
                bool itemsExist = true;

                foreach (var item in orderDto.Items)
                {
                    //Ako nqma takuv item
                    if (!context.Items.Any(i => i.Name == item.Name))
                    {
                        itemsExist = false;
                        break;
                    }
                    
                }

                
                if (!itemsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                DateTime datetime = DateTime
                    .ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);


                
                Order order = new Order()
                {
                    Customer = orderDto.Customer,
                    Employee = employee,
                    DateTime = datetime,
                    Type = type
                };


                //Shte gi dobavqm v bazata edno po edno
                if (context.Orders.Any(o => o.Customer == orderDto.Customer))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                context.Orders.Add(order);
                context.SaveChanges();

                //sled kato veche go ima tozi otrder v bazata si pravq OrderItems


                //Ako sme stignali do tuk znachi itemite sa validni
                foreach (var item in orderDto.Items)
                {

                    //Ako go ima itema si go vzimame
                    var itemToUse = context.Items.SingleOrDefault(i => i.Name == item.Name);

                    var orderToUse = context.Orders.SingleOrDefault(o => o.Customer == orderDto.Customer);

                    var quantity = orderDto.Items.Any(i => i.Name == itemToUse.Name);
                    //Pravim si orderItema i si go dobavqme kum bazata
                    OrderItem orderItem = new OrderItem()
                    {
                        ItemId = itemToUse.Id,
                        OrderId = orderToUse.Id,
                        Quantity = item.Quantity
                    };
                    
                    context.OrderItems.Add(orderItem);
                    context.SaveChanges();

                }





                //Ako veche sme q slojili
                if (validOrders.Contains(order))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                validOrders.Add(order);
                sb.AppendLine(string.Format($"{orderDto.Customer} on {orderDto.DateTime}"));

            }
            


            

            return sb.ToString();
        }


        //PRI DECIMAL "0.01" VALIDTORA GURMI
        //Shte ni validira vsichki propertita spored anotaciite
        private static bool IsValid(object obj)
        {
            //Ima validator koito proverqva dali propertito shte se schupi 
            //Imame anotazii na propertito
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            //Tuk shte si zapisvame rezultatite
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }


    }
}