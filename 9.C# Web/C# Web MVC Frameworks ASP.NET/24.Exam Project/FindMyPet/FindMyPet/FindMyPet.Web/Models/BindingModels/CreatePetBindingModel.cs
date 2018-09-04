using System;

namespace FindMyPet.Web.Models.BindingModels
{
    public class CreatePetBindingModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public string ImageUrl { get; set; }

        public string LocationLost { get; set; }
        
        public DateTime TimeLost { get; set; }
        
        public string Gender { get; set; }

        public string Breed { get; set; }

        public string Color { get; set; }
    }
}
