using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private int engineSpeed;
    private int enginePower;

    public Engine()
    {

    }

    public Engine(int engineSpeed, int enginePower)
    {
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
    }

    public int EngineSpeed
    {
        get { return this.engineSpeed; }
        set
        {
            this.engineSpeed = value;
        }
    }

    public int EnginePower
    {
        get { return this.enginePower; }
        set
        {
            this.enginePower = value;
        }
    }

   


}
