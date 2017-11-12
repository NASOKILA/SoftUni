using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P02_DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                
             /*ZADACHITE GI IMAM VECHE VUV FAILOVE !
                 
            Comments:
                KATO POLZVAME .Include() NIE VZIMAME VSICHKO OT TABLICATA KOQTO INKLUVAME !!!
                TOVA PRAVI PROCESA PO BAVEN, PO DOBRE E DA VZIMAME SAMO TOVA KOETO NI E NUJNO.

                Po dobre e da polzvame anonimni obekti vus Select()  :
                    Primer:
                    .Select( a => new {

                        //OT TUK SI VZZIMME SAMO TOVA KOETO NI TRQBVA !!!
                    })

             
             */

            }
        }
    }
}