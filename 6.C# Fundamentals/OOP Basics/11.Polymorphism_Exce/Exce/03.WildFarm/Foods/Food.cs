﻿using System;
using System.Collections.Generic;
using System.Text;


public abstract class Food
{
    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity { get; set; }
    
    public override string ToString()
    {
        return base.ToString();
    }
}

