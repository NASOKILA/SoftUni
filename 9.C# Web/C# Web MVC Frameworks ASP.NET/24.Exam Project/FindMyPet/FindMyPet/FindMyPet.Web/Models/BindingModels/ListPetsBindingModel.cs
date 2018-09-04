using FindMyPet.Models;
using System;

namespace FindMyPet.Web.Models.BindingModels
{
    public class ListPetsBindingModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public string LocationLost { get; set; }

        public DateTime TimeLost { get; set; }

        public DateTime? TimeFound { get; set; }

        public string Status { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public string FounderId { get; set; }

        public User Founder { get; set; }

    }
}
