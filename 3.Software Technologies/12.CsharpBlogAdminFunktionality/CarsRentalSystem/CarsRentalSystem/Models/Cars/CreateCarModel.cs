
using CarsRentalSystem.DataModels;
using CarsRentalSystem.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CarsRentalSystem.Models.Cars
{
    //Tozi klas shte sudurja samo tova koeto usera trqbva da dobavi vuv FORMICHKATA ZA SUZDAVANE
    // ISKAME POCHTI VSICHKO BEZ IDtata
    public class CreateCarModel
    {
        //KOPIRAME VSICHKO OSVEN IDtata I Owners


        [Required]
        [MaxLength(25)] // HUBAVO E DA OGRANICHAVAME NESHTATA ZASHTOTO SHTE ZAEMAT MNOGO MQSTO V BAZATA AKO SLOJIM MNOGO KOLI
        public string Brand { get; set; }

        [Required]
        [MaxLength(25)] // HUBAVO E DA OGRANICHAVAME NESHTATA ZASHTOTO SHTE ZAEMAT MNOGO MQSTO V BAZATA AKO SLOJIM MNOGO KOLI
        public string Model { get; set; }

        public string Color { get; set; }

        [Range(1992, 2017)]
        public int Year { get; set; }
         
        [Required]
        [Display(Name = "Price Per Day")]  // ZA DA NEE SLQTO KATO GO PODAVAME NA HTMLa
        public decimal PricePerDay { get; set; }


        public int? Power { get; set; }
        // Sus ? pred int nie go pravim da ne e Required, t.e. da e NULLABLE

        [Required]
        public double Engine { get; set; }

        [Display(Name = "Engine Type")]
        [ScaffoldColumn(false)]  // KATO GO SETNEM NA FALSE  Html.EditorForModel GO SKIPVA I MOJEM DA SI GO SLOJIM SAMI
        public EngineType EngineType { get; set; } // TOVA E ENUMERACIQ KOQTO SUZDADOHME ZA TIP NA DVIGATEL
                                                   //TAKA SE POLZVA

       
        [Display(Name = "Image Url")]
        [Url] // TOVA SLUJI ZA VALIDACIQ DAI REALNO VUVEDENIQ STRING E ISTINSKI URL
        [ImageUrl]  // NIE SI GO NAPRAVIHME TOZI ATRIBUT I SEGA MOJEM DA GO POLZVAME
        public string ImageUrl { get; set; }



    }
}