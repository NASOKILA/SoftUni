using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Car
{
    public string Model { get; set; }
    public decimal FuelAmount { get; set; }
    public decimal FuelConsumptionForOneKm { get; set; }
    public decimal DistanceTravalled { get; set; }

    public Car()
    {

    }

    public Car( string model, decimal fuelAmount, decimal fuelConsumption)
    {
        DistanceTravalled = 0;
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionForOneKm = fuelConsumption;
    }

    public void CalculateDistance(string model, decimal amountOfKm)
    {

        decimal kmItCanRun = FuelAmount / FuelConsumptionForOneKm;

        if (kmItCanRun >= amountOfKm)
        {
            decimal fuelAmountToRedude = amountOfKm * FuelConsumptionForOneKm;

            FuelAmount -= fuelAmountToRedude;
            DistanceTravalled += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }

         
    }

}

