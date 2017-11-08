using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MainProgram
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            string model = input[0];

            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);

            Engine engine = new Engine(engineSpeed, enginePower);


            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];

            Cargo cargo = new Cargo(cargoWeight, cargoType);


            //List of tires
            List<Tire> tires = new List<Tire>();

            //create 4 Tire classess

            double tire1Pressure = double.Parse(input[5]);
            int tire1Age = int.Parse(input[6]);
            Tire tireOne = new Tire(tire1Pressure, tire1Age);
            tires.Add(tireOne);

            double tire2Pressure = double.Parse(input[7]);
            int tire2Age = int.Parse(input[8]);
            Tire tireTwo = new Tire(tire2Pressure, tire2Age);
            tires.Add(tireTwo);

            double tire3Pressure = double.Parse(input[9]);
            int tire3Age = int.Parse(input[10]);
            Tire tireThree = new Tire(tire3Pressure, tire3Age);
            tires.Add(tireThree);

            double tire4Pressure = double.Parse(input[11]);
            int tire4Age = int.Parse(input[12]);
            Tire tireFour = new Tire(tire4Pressure, tire4Age);
            tires.Add(tireFour);

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        string command = Console.ReadLine();
        var carToPrint = new List<Car>();

        if (command == "fragile")
        {
            carToPrint = cars.Where(
                    c => c.Cargo.CargoType == command
                    && c.Tires.Any(t => t.TirePressure < 1)
                                    ).ToList();
        }
        else if (command == "flammable")
        {

            carToPrint = cars.Where(c => c.Cargo.CargoType == command
                    && c.Engine.EnginePower > 250).ToList();
        }


        foreach (var car in carToPrint)
        {
            Console.WriteLine(car.Model);
        }


    }
}

































