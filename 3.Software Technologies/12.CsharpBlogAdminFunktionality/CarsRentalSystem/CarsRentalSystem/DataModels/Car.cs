


namespace CarsRentalSystem.DataModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    // Tova e model za kola koqto usera moje da dobavi
    public class Car
    {
        public int id { get; set; }

        [Required]
        [MaxLength(25)] // HUBAVO E DA OGRANICHAVAME NESHTATA ZASHTOTO SHTE ZAEMAT MNOGO MQSTO V BAZATA AKO SLOJIM MNOGO KOLI
        public string Brand { get; set; }

        [Required]
        [MaxLength(25)] // HUBAVO E DA OGRANICHAVAME NESHTATA ZASHTOTO SHTE ZAEMAT MNOGO MQSTO V BAZATA AKO SLOJIM MNOGO KOLI
        public string Model { get; set; }

   
        [Range(1992, 2017)]
        public int Year { get; set; }

        
        public string Color { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

       
        public int? Power { get; set; }
        // Sus ? pred int nie go pravim da ne e Required, t.e. da e NULLABLE

        [Required]
        public double Engine { get; set; }

        public EngineType EngineType { get; set; } // TOVA E ENUMERACIQ KOQTO SUZDADOHME ZA TIP NA DVIGATEL
                                                   //TAKA SE POLZVA

        
        public string ImageUrl { get; set; }


        //NIE TRQBVA DA NAPRAVIM VRUKA SUS USERA ZA DA KAJEM KOI Q E PUSNAL TAZI KOLA ZA PRODAJBA !
        [Required]
        public string OwnerId { get; set; } // TOVA E VRUZKA KUM TABLICA OT USERITE V BAZATA
        //PRAVIM IDto DA E STRING ZASHTOTO NA USERITE TAKA E NAPRAVENO ZA TOVA GO PRAVIM I NIE!

        public virtual User Owner { get; set; }
        // KOITOCHNO E OWNERA DIREKTNO SUS KLSA ZA DA MOJEM DA GO DOSTUPIM



        //No edin user moje da ima poveche koli koito da prodava


// TRQBVA V CARS I V USERS DA KAJEM N BAZATA KOI E RENTNAL DADENA KOLA I KOLKO PUTI E RENTNATA!

        public Car() {
            this.Rentings = new HashSet<Renting>();
        }

        public virtual ICollection<Renting> Rentings { get; set; }

        // TRQBVA I DA GO DOBAVIM V BAZATA T.E. V CarsDbContext.cs  : public virtual IDbSet<Renting> Rentings  {get; set;}


            // PO DEFAULT DAVA FALSE NA VSICHKI VAJNOOOOOOOO!!!!
        public bool IsRented { get; set; }


    }
}