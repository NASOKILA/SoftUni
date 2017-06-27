using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(' ')
                .ToArray();

            List<Vehicle> vehicles = new List<Vehicle>();

            int carsTotalHorsePower = 0;
            int trucksTotalHorsePower = 0;
            int carsCount = 0;
            int trucksCount = 0;

            while (command[0] != "End")
            {
                string type = string.Empty;

                if (command[0] == "car")
                    type = "Car";
                else if(command[0] == "truck")
                    type = "Truck";
                else
                    type = command[0];

                string model = command[1];
                string color = command[2];
                int horsePower = int.Parse(command[3]);

                Vehicle vehicle = new Vehicle()
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    HorsePower = horsePower
                };

                if (type.Equals("Car"))
                {
                    carsTotalHorsePower += horsePower;
                    carsCount++;
                }
                else if (type.Equals("Truck"))
                {
                    trucksTotalHorsePower += horsePower;
                    trucksCount++;
                }


                vehicles.Add(vehicle);

                command = Console.ReadLine()
                .Split(' ')
                .ToArray();
            }


            string modelRecived = Console.ReadLine();
            while (modelRecived != "Close the Catalogue")
            {
                Vehicle vehicle = vehicles.Where(v => v.Model == modelRecived).FirstOrDefault();
                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.HorsePower}");


                modelRecived = Console.ReadLine();
            }

            double carsAverageHorsePower = (double)carsTotalHorsePower / carsCount;
            double trucksAverageHorsePower = (double)trucksTotalHorsePower / trucksCount;

            if (carsCount == 0)
                carsAverageHorsePower = 0;
            if (trucksCount == 0)
                trucksAverageHorsePower = 0;

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsePower:F2}.");
        }
    }
}
