using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tire
{
    private double tirePressure;
    private int tireAge;

    public Tire()
    {

    }

    public Tire(double tirePressure, int tireAge)
    {
        this.TirePressure = tirePressure;
        this.TireAge = tireAge;
    }

    public double TirePressure
    {
        get { return this.tirePressure; }
        set
        {
            this.tirePressure = value;
        }
    }

    public int TireAge
    {
        get { return this.tireAge; }
        set
        {
            this.tireAge = value;
        }
    }
    
}

