using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyPet.Models
{
    public class Bird : Pet
    {
        public double WingsSizeInCentimeters { get; set; }

        public double FlyingSpeedPerKm { get; set; }
    }
}
