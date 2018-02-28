using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IMDB.Models
{
    public class Event
    {

        //V TOZI KLAS KAZVAME KAKTO TRQBVA DA PREDSTAVLQVA I DA IMA EDIN EVENT.
        //Polzval sum direktno publichni propertita bez private poleta za enkapsulaciq.


        [Key] //sus key kazvame che tova e kluch vupreki che samo se doseshta 
        public int Id { get; set; } //public oznachava che e dostupno za vseki, int predstavlqva chislo

        [Required] //sus Required kazvame che vsichki propertita che sa zaduljitelni toest ne moje da sa NULL prazni
        [AllowHtml] // s tozi atribut kazvame che ako nqkoi idiot napishe html kod v poleto da go smqta za string
        public string Name { get; set; } //string predstavlqva text

        [Required]
        [AllowHtml]
        public string Location { get; set; } 

        [Required]
        [AllowHtml]
        public DateTime StartDateAndTime { get; set; } //DateTime ochakva data i chas no moje i samo data to si go dopulva avtomatichno

        [Required]
        [AllowHtml]
        public DateTime EndDateAndTime { get; set; }



        /*
         public oznachava che e dostupno za vseki.
         private ozn che e dostupno smo za tozi klas, po default edno pole e private.
         protected ozn che e dostupno samo za toi klas i tezi koito go nasledqvat.
         internal ozn che e kato public no samo za tozi proekt (biblioteka), po default klasovete v dadena biblioteka sa internal
         */
    }
}