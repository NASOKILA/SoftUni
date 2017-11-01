using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public bool negative = false;

    public Box()
    {
       
    }

    public Box(decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
        
    }


    //Vtora zadata data validation internali in a private setter:

    public decimal Length
    {
        get { return this.length; }
        set
        {
            //Ne zabravqi che tuka se slava value
            if (value <= 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
                negative = true;
            }

            //Ne zabravqi che tuka se slava value
            this.length = value;
        }
    }

    public decimal Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
                negative = true;
            }

            this.width = value;
        }
    }

    public decimal Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                negative = true;
            }

            this.height = value;
        }
    }


    //PROMENQME SI NAVSQKUR DA E S GLAVNA BUKVA !!!!!

    //Volume  
    public decimal Volume()
    {
        decimal result = this.Length * this.Width * this.Height;
        return result;
    }

    //Lateral Surface
    public decimal LateralSurface()
    {
        decimal result = (2 * this.Length * this.Height) + (2 * this.Width  * this.Height);
        return result;
    }

    //Surface Area
    public decimal SurfaceArea()
    {
        decimal result = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        return result;
    }


    



}

