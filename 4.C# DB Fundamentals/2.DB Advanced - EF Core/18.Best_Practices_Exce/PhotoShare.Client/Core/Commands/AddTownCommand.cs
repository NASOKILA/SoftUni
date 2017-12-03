namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using System.Linq;
    using System;

    public class AddTownCommand
    {
        // AddTown <townName> <countryName>
        public static string Execute(string[] data)
        {
            string townName = data[1];
            string country = data[2];


            if (Session.User == null)
                throw new InvalidOperationException("Invalid Credentials!");


            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                Town townExists = context.Towns.SingleOrDefault(t => t.Name == townName);

                if (townExists != null)
                    throw new ArgumentException($"Town {townName} was already added!");

                context.Towns.Add(town);
                context.SaveChanges();

                return "Town " + townName + " was added successfully!";
            }
        }
    }
}
