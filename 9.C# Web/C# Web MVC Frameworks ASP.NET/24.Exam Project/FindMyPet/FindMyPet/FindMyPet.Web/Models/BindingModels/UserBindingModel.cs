using FindMyPet.Models;
using System;
using System.Collections.Generic;

namespace FindMyPet.Web.Models.BindingModels
{
    public class UserBindingModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }
        
        public string Email { get; set; }
        
        public int FeedBack { get; set; }
    }
}
