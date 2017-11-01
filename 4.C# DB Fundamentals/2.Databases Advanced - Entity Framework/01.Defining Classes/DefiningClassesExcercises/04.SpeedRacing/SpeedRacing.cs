using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SpeedRacing
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            string model = input[0];
            decimal fuelAmount = decimal.Parse(input[1]);
            decimal fuelConsumptionFor1km = decimal.Parse(input[2]);

            /*Model trqbva da e unique zatova kazvame 
             ako nqmame takuv model v cars da napravim. */
            if (!cars.Any(c => c.Model == model))
            {
                Car newCar = new Car();
                newCar.Model = model;
                newCar.FuelAmount = fuelAmount;
                newCar.FuelConsumptionForOneKm = fuelConsumptionFor1km;

                cars.Add(newCar);
            }
        }


        string command = "";
        while (command != "End")
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            if (input[0] == "End")
                break;

            string model = input[1];
            decimal amountOfKm = decimal.Parse(input[2]);

            Car car = cars.Find(c => c.Model == model);


            //try the function
            car.CalculateDistance(model,amountOfKm);



            command = input[0];
           
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravalled}");
        }


    }
   

}

