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

    public Box()
    {
        
    }

    public Box(decimal length, decimal width, decimal height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }


    //Volume
    public decimal Volume()
    {
        decimal result = this.length * this.width * this.height;
        return result;
    }

    //Lateral Surface
    public decimal LateralSurface()
    {
        decimal result = (2 * this.length * this.height) + (2 * this.width  * this.height);
        return result;
    }

    //Surface Area
    public decimal SurfaceArea()
    {
        decimal result = (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        return result;
    }




}

