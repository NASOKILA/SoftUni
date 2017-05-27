using System;

namespace CarsRentalSystem.Helpers
{
    using System.ComponentModel.DataAnnotations;

    //SHTE SUZDADEM ATRIBUT KOITO VALIDIRA DALI NESHTO(String) E VALIDEN URL !!!


    public class ImageUrlAttribute : ValidationAttribute
    {
        // KAZVAME NA KLASA CHE NASLEDQVA ValidationAttribute
        //SLEDOVATELNO OT TAM NASLEDQVA EDIN METOD S IME IsValid()
        public override bool IsValid(object value)
        {
            // poluchavame obekt kum koito mojem da napishem dadena logika i da vidim 
            // dali e validen

            var imageUrl = value as string;

            if (imageUrl == null)
                return true;

            return imageUrl.EndsWith(".jpeg") ||
                   imageUrl.EndsWith(".jpg") ||
                   imageUrl.EndsWith(".png");

            // NAPRAVIHME ATRIBUT KOIT MOJEM DA POLZVAME
        }
    }
}