namespace ExternalFormatProssessing.DTOs
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class StationDto
    {

        public StationDto()
        {

        }

        /*
            Tuk si definirame tova koeto trqbva da ima: 
            Shte polzvane Anortazii ot bibliotekata Newtonsoft.Json za da opredelim
            koe properti kude otiva.    

            AKO POLZVAME _ V IMETO NA SAMOTO PROPERTY NQMA DA STANE.

         */

        public int Id { get; set; }
        
        [JsonProperty("route_id")]
        public int RouteId { get; set; }

        public int Code { get; set; }

        [JsonProperty("point_id")]
        public int PointId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
