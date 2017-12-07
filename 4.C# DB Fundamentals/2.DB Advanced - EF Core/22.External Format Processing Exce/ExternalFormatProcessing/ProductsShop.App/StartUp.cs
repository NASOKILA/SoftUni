namespace ProductsShop.App
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using ProductsShop.Models;
    using ProductsShop.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {

            //JSON PROCESSING: 
            //1.IMPORT DATA FROM JSON :

            //ImportUsersFromJson();

            //ImportCategoriesFromJson();

            //ImportProductsFromJson();

            //SetCategories();



            //2.QUERY AND EXPORT DATA TO JSON

            //ExportJsonProductInRange();

            //ExportJsonSuccessfullySoldProducts();

            //ExportJsonCategoriesByProductsCount();

            //ExportJsonUsersAndProducts();



            //XML PROCESSING:  
            //1.IMPORT DATA FROM XML

            //ImportUsersFromXml();

            //ImportCategoriesFromXml();

            //ImportProductsFromXml();

            //SetCategories();



            //2.QUERY AND EXPORT DATA TO XML

            //ExportXmlProductsInRange();

            //ExportXmlSoldProducts();

            // ExportXmlCategoriesByProductsCount();

            //ExportXmlUsersAndProducts();


        }
        //Query 4
        private static void ExportXmlUsersAndProducts()
        {

            using (var db = new ProductsShopContext())
            {
                var usersAndProducts = db.User.Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Where(u => u.Age != null && u.FirstName != null && u.LastName != null)
                    .Select(u => new {

                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {

                            count = u.ProductsSold.Count,
                            products = u.ProductsSold.Select(p => new {
                                name = p.Name,
                                price = p.Price
                            }).ToArray()
                        }

                    }).ToArray();


                var result = new
                {
                    usersCount = usersAndProducts.Count(),
                    users = usersAndProducts
                };


                XDocument xDoc = new XDocument();
                
                var users = new XElement("users");
                users.Add(new XAttribute("count", result.usersCount));

                foreach (var u in result.users)
                {
                    

                    var soldProducts = new XElement("sold-products");
                    soldProducts.Add(new XAttribute("count", u.soldProducts.count));

                    foreach (var p in u.soldProducts.products)
                    {
                        var product = new XElement("product");
                        product.Add(new XAttribute("name", p.name));
                        product.Add(new XAttribute("price", p.price));

                        soldProducts.Add(product);
                    }

                    var user = new XElement("user");
                    user.Add(new XAttribute("first-name", u.firstName));
                    user.Add(new XAttribute("last-name", u.lastName));
                    user.Add(new XAttribute("age", u.age));

                    user.Add(soldProducts);

                    users.Add(user);
                }
                

                xDoc.Add(users);
                string xmlString = xDoc.ToString();
                
                File.WriteAllText("users-and-products.xml", xmlString);

                Console.WriteLine($"{result.usersCount} users and products were exported correctry to users-and-products.xml!");


            }
        }

        //Query 3
        private static void ExportXmlCategoriesByProductsCount()
        {
            using (var db = new ProductsShopContext())
            {
                
                var categories = db.Category
                    .OrderBy(c => c.CaegoryProducts.Count)
                    .Select(c => new {
                        category = c.Name,
                        productsCount = c.CaegoryProducts.Count,
                        avetagePrice = c.CaegoryProducts.Select(cc => cc.Product.Price).Average(),
                        totalRevenue = c.CaegoryProducts.Select(cc => cc.Product.Price).Sum()
                    })
                    .ToArray();

                XDocument xDoc = new XDocument(new XElement("categories"));


                foreach (var c in categories)
                {
                    
                    var productsCount = new XElement("products-count", c.productsCount);
                    var averagePrice = new XElement("average-price", c.avetagePrice);
                    var totalRevenue = new XElement("total-revenue", c.totalRevenue);

                    var categoryElement = new XElement("category");
                    categoryElement.Add( new XAttribute("name", c.category));

                    categoryElement.Add(productsCount);
                    categoryElement.Add(averagePrice);
                    categoryElement.Add(totalRevenue);

                    //dobavqme vseki element
                    xDoc.Root.Add(categoryElement);
                }

                string xmlString = xDoc.ToString();
                Console.WriteLine(xmlString);

                File.WriteAllText("categories-by-products.xml", xmlString);

                Console.WriteLine($"{categories.Length} products were exported correctry to categories-by-products.xml!");
            }


        }

        //Query 2
        private static void ExportXmlSoldProducts()
        {
            using (var db = new ProductsShopContext())
            {
                var users = db.User.Where(u => u.ProductsSold.Count > 0 
                    && u.FirstName != null
                    && u.LastName != null)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        firstname = u.FirstName,
                        lastname = u.LastName,
                        soldproducts = u.ProductsSold.Select(ps => new {
                            name = ps.Name,
                            prise = ps.Price
                        })
                    }).ToArray();

                XDocument xDoc = new XDocument();

                XElement usersElement = new XElement("users");

                foreach (var u in users)
                {
                    var userFirstName = new XAttribute("first-name", u.firstname);
                    var userLastName = new XAttribute("last-name", u.lastname);

                    var userElement = new XElement("user", userFirstName, userLastName);

                    var soldProduct = new XElement("sold-products");

                    userElement.Add(soldProduct);

                    foreach (var sp in u.soldproducts)
                    {
                        var productName = new XElement("name", sp.name);
                        var productPrise = new XElement("prise", sp.prise);
                        var product = new XElement("product", productName, productPrise);
                        soldProduct.Add(product);
                    }

                    usersElement.Add(userElement);
                }

                xDoc.Add(usersElement);

                string xmlString = xDoc.ToString();
                File.WriteAllText("users-sold-products.xml", xmlString);

                Console.WriteLine($"{users.Length} users were exported correctry to users-sold-products.xml");

            }

        }

        //Query 1
        private static void ExportXmlProductsInRange()
        {
            using (var db = new ProductsShopContext())
            {
                var products = db.Product
                    .Where(p => p.Price >= 10000 
                             && p.Price <= 20000)
                    .Where(p => p.Buyer.FirstName != null)
                    .OrderBy(p => p.Price)
                    .Select(p => new {
                        name = p.Name,
                        price = p.Price,
                        buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                    }).ToArray();

                //EXPORTVANETO STAVA NA OBRATNO TRQBVA DA SI SUZDADEM ELEMENTITE:

                XDocument xDoc = new XDocument();
                
                var productsElement = new XElement("products");

                foreach (var p in products)
                {   
                    var productName = new XAttribute("name", $"{p.name}");
                    var productPrice = new XAttribute("price", $"{p.price}");
                    var productBuyer = new XAttribute("buyer", $"{p.buyer}");

                    var product = new XElement("product", productName, productPrice, productBuyer);
                    productsElement.Add(product);
                }

                xDoc.Add(productsElement);

                string xmlString = xDoc.ToString();
                File.WriteAllText("products-in-range.xml", xmlString);
                Console.WriteLine($"{products.Length} products were exported correctry to products-in-range.xml!");
            }

        }



        //Import Data from XML

        private static void ImportProductsFromXml()
        {

            using (var db = new ProductsShopContext())
            {


                //Vzimame vsichki IDta:
                int[] userIds = db.User.Select(u => u.Id).ToArray();

                Random rnd = new Random();


                string path = @"Files/products.xml";
                string filcontent = File.ReadAllText(path);

                XDocument xmlDocument = XDocument.Parse(filcontent);

                var products = xmlDocument.Root.Elements();

                var productsList = new List<Product>();
                foreach (var p in products)
                {

                    int sellerIndex = rnd.Next(0, userIds.Length); // Index e random chiso ot 0 do 56
                    int buyerIndex = rnd.Next(0, userIds.Length);

                    //Ot random generatora vimme Id i user koito shte gi setnem na sellera
                    int sellerId = userIds[sellerIndex];

                    int? buyerId = userIds[buyerIndex];


                    //SellerId ne moje da e sushtiq kato BuyerId
                    if (sellerId == buyerId)
                    {
                        while (true)
                        {
                            sellerId = rnd.Next(0, userIds.Length);
                            if (sellerId != buyerId)
                                break;
                        }
                    }


                    //Pravim da ima i nqkolko s BuyerId null
                    if (buyerId == 4 || buyerId == 14 || buyerId == 24 || buyerId == 27 || buyerId == 45
                        || buyerId == 34 || buyerId == 44 || buyerId == 54 || buyerId == 41 || buyerId == 7)
                        buyerId = null;


                    //Tuk nqmam enulevi stoinosti
                    //produkta se sustoi ot dva elementa name i price, vzimame gi kato polzvame .Element(...)
                    string name = p.Element("name")?.Value.ToString();
                    decimal price = decimal.Parse(p.Element("price").Value.ToString());

                    Product product = new Product()
                    {
                        Name = name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    productsList.Add(product);
                }


                db.Product.AddRange(productsList);

                db.SaveChanges();

                Console.WriteLine($"{productsList.Count} products were inserted from file {path}");
            }

        }

        private static void ImportCategoriesFromXml()
        {
            string path = @"Files/categories.xml";
            string fileContent = File.ReadAllText(path);

            XDocument categoriesXmlDocument = XDocument.Parse(fileContent);

            var categoryElements = categoriesXmlDocument.Root.Elements();

            List<Category> categories = new List<Category>();
            foreach (var c in categoryElements)
            {

                //SUS .Element MOJEM DA VZEMEM KOITO SI ISKAME ELEMENT KATO MU POSOCHIM ATRIBUTA
                string name = c.Element("name")?.Value.ToString();

                Category category = new Category()
                {
                    Name = name
                };

                categories.Add(category);
            }

            using (var db = new ProductsShopContext())
            {
                db.Category.AddRange(categories);

                db.SaveChanges();

                Console.WriteLine($"{categories.Count} categories were imported from file :{path}");
            }

        }

        private static void ImportUsersFromXml()
        {

            //zapisvame si neshtata ot faila v string promenliva
            string path = @"Files/users.xml";
            string readUsersXmlFile = File.ReadAllText(path);

            //using System.Xml.Linq;   i parsvame kum  XML Documant
            XDocument usersXmlDoc = XDocument.Parse(readUsersXmlFile);

            //Vzimame vsichki elementi
            var elements = usersXmlDoc.Root.Elements();

            //Pravim si spisuk koito shte napulnim s useri
            var users = new List<User>();

            //Foreachvame elementite
            foreach (var e in elements)
            {

                //Vajno e da polzvame '?' predi .Value v sluchai che nqma takova property ili e null
                //V takuv sluchai ako imame '?' nqma da vzeme nishto.
                string firstName = e.Attribute("firstName")?.Value.ToString();

                string lastName = e.Attribute("lastName")?.Value.ToString();

                byte? age = null;
                if (e.Attribute("age")?.Value.ToString() != null)
                    age = byte.Parse(e.Attribute("age")?.Value.ToString());
                //Ako e razlichno ot null go parsvame kum byte i go zapisvame v 'age'

                //pravim si nov User obekt i go pulnim
                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                //dobavqme kum spisuka
                users.Add(user);
            }


            //dobavqme vichko v bazata
            using (var db = new ProductsShopContext())
            {
                db.User.AddRange(users);
                db.SaveChanges();
                Console.WriteLine($"{users.Count} users were imported from file :{path}");
            }


        }



        //Query 4 Json
        private static void ExportJsonUsersAndProducts()
        {
            using (var db = new ProductsShopContext())
            {
                var usersAndProducts = db.User.Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new {

                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {

                            count = u.ProductsSold.Count,
                            products = u.ProductsSold.Select(p => new {
                                name = p.Name,
                                price = p.Price
                            }).ToArray()
                        }

                    }).ToArray();


                var result = new
                {
                    usersCount = usersAndProducts.Count(),
                    users = usersAndProducts
                };

                var usersAndProductsJson = JsonConvert.SerializeObject(result, Formatting.Indented);

                File.WriteAllText("users-and-products.json", usersAndProductsJson);

            }
        }

        //Query 3 Json
        private static void ExportJsonCategoriesByProductsCount()
        {
            using (var db = new ProductsShopContext())
            {
                var categories = db.Category.OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.CaegoryProducts.Count,
                        avetagePrice = c.CaegoryProducts.Select(cc => cc.Product.Price).Average(),
                        totalRevenue = c.CaegoryProducts.Select(cc => cc.Product.Price).Sum()

                    }).ToArray();

                var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

                File.WriteAllText("categories-by-products.json", categoriesJson);
                Console.WriteLine(categoriesJson);

            }
        }

        //Query 2 Json
        private static void ExportJsonSuccessfullySoldProducts()
        {

            using (var db = new ProductsShopContext())
            {
                var users = db.User.Where(u => u.ProductsSold.Count > 0
                && u.ProductsSold.All(ps => ps.Buyer.FirstName != null
                && ps.Buyer.LastName != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new {
                        firstname = u.FirstName,
                        lastname = u.LastName,
                        soldProducts = u.ProductsSold.Select(p => new {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                    }).ToArray();

                var jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented);

                File.WriteAllText("users-sold-products.json", jsonUsers);

            }

        }

        //Query 1 Json
        private static void ExportJsonProductInRange()
        {

            using (var db = new ProductsShopContext())
            {

                var products = db.Product.Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new {
                        name = p.Name,
                        price = p.Price,
                        seller = p.Seller.FirstName + " " + p.Seller.LastName
                    }).ToArray();


                //Parsvame kum JSON
                var productsToJson = JsonConvert.SerializeObject(products, Formatting.Indented);


                //Sega xportvame vuv fail:
                File.WriteAllText("products-in-range.json", productsToJson);

            }

        }



        //Importing Data JSON

        private static void ImportProductsFromJson()
        {

            using (var db = new ProductsShopContext())
            {
                var jsonProducts = File.ReadAllText("Files/products.json");
                var products = JsonConvert.DeserializeObject<Product[]>(jsonProducts);


                //Vzimame vsichki IDta:
                int[] userIds = db.User.Select(u => u.Id).ToArray();

                Random rnd = new Random();


                foreach (var p in products)
                {
                    int sellerIndex = rnd.Next(0, userIds.Length); // Index e random chiso ot 0 do 56
                    int buyerIndex = rnd.Next(0, userIds.Length);

                    //Ot random generatora vimme Id i user koito shte gi setnem na sellera
                    int sellerId = userIds[sellerIndex];

                    int buyerId = userIds[buyerIndex];

                    //setvame si sellera
                    p.SellerId = sellerId;

                    //setvame si buyera
                    p.BuyerId = buyerId;

                    //SellerId ne moje da e sushtiq kato BuyerId
                    if (p.SellerId == p.BuyerId)
                    {
                        while (true)
                        {
                            p.SellerId = rnd.Next(0, userIds.Length);
                            if (p.SellerId != p.BuyerId)
                                break;
                        }
                    }


                    //Pravim da ima i nqkolko s BuyerId null
                    if (buyerId == 4 || buyerId == 14 || buyerId == 24 || buyerId == 27 || buyerId == 45
                        || buyerId == 34 || buyerId == 44 || buyerId == 54 || buyerId == 41 || buyerId == 7)
                        p.BuyerId = null;

                }

                db.Product.AddRange(products);
                db.SaveChanges();
                Console.WriteLine($"{products.Length} were inserted successfully!");
            }
        }

        private static void ImportCategoriesFromJson()
        {
            using (var db = new ProductsShopContext())
            {
                //Chetem ot faila
                var jsonCategories = File.ReadAllText("Files/categories.json");

                //pasrvame v masiv ot Category
                var categories = JsonConvert.DeserializeObject<Category[]>(jsonCategories);

                //I dobavqme v Bazsta
                db.Category.AddRange(categories);
                db.SaveChanges();


                Console.WriteLine($"{categories.Length} categories were inserted successfully!");
            }
        }

        private static void ImportUsersFromJson()
        {
            using (var db = new ProductsShopContext())
            {

                //JSON PROCESSING:  using newtonsoft.Json;

                //using Syste.IO;   Za da polzvame File.
                var jsonUsers = File.ReadAllText("Files/users.json");
                var users = JsonConvert.DeserializeObject<User[]>(jsonUsers);
                db.User.AddRange(users);

                db.SaveChanges();
                Console.WriteLine($"{users.Length} users inserted successfully!");

            }
        }



        //Fills CategoryProducts
        private static void SetCategories()
        {
            //Na vseki produkt po 3 kategorii:
            using (var db = new ProductsShopContext())
            {
                var categoryIds = db.Category.Select(c => c.Id).ToArray();

                var productIds = db.Product.Select(p => p.Id).ToArray();

                Random rand = new Random();

                List<CategoryProduct> categoryProductList = new List<CategoryProduct>();

                foreach (var pId in productIds)
                {


                    for (int i = 0; i < 3; i++)
                    {
                        int index = rand.Next(0, categoryIds.Length);

                        //Ne trqbva da vzimame edna i sushta kategoriq
                        while (categoryProductList.Any(cp => cp.ProductId == pId
                                && cp.CategoryId == categoryIds[index]))
                        {
                            index = rand.Next(0, categoryIds.Length);
                        }


                        var categoryProduct = new CategoryProduct()
                        {
                            ProductId = pId,
                            CategoryId = categoryIds[index]
                        };

                        categoryProductList.Add(categoryProduct);

                    }
                }

                //Dobavqme anpulniq spisuk i zapazvame promenite.
                db.CategoryProduct.AddRange(categoryProductList);
                db.SaveChanges();


                Console.WriteLine("CategoryProducts are set successfully!");
            }

        }







        /*
            using (var db = new ProductsShopContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            
             //Vzimame go kato izvikvame metoda i go podavame na Engina
             var serviceProvicer = ConfigureServices();

             var engine = new Engine(serviceProvicer);
             engine.Run();
            */

        private static IServiceProvider ConfigureServices()
        {
            //Purvo si pravim kolekciq ot servisi.
            var serviceCollection = new ServiceCollection();

            //Pri suzdavane to kazvame da ni napravi nov DbContext s tozi connectionString;
            serviceCollection.AddDbContext<ProductsShopContext>(options => options
                    .UseSqlServer(SystemConfig.connectionString));

            //Dobavqme si servisite kum nego
            serviceCollection.AddTransient<UserService>();

            serviceCollection.AddTransient<ProductService>();

            serviceCollection.AddTransient<CategoryService>();

            serviceCollection.AddTransient<CategoryProductService>();

            //i nakraq si go Suzdavame 
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }




    }
}
