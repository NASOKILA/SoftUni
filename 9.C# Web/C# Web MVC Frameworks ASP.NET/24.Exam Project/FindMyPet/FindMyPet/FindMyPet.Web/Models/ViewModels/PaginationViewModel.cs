using FindMyPet.Models;
using FindMyPet.Web.Models.BindingModels;
using System.Collections.Generic;

namespace FindMyPet.Web.Models.ViewModels
{
    public class PaginationViewModel
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public List<ListPetsBindingModel> Pets { get; set; }
    }
}
