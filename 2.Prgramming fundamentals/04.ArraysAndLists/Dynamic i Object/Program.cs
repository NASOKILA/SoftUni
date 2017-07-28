using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_i_Object
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic naso = "ubavec";
            naso = 4;
            naso = true;
            bool nasin = naso;

            object asi = "groznik";
            asi = 4;
            int a = (int)asi;

            object toni = new
            {
                aa = 4,
                bb = "sadwd",
                cc = true
            };

            dynamic ivo = new
            {
                mario = "hahaha",
                kiro = 4.5
            };

            // Ima i osht za uchene no e za po napred
        }
    }
}
