using FindMyPet.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FindMyPet.Models
{
    public class User : IdentityUser
    {

        public User()
        {
            this.MessagesSent = new List<Message>();
            this.MessagesReceived = new List<Message>();
            this.PetsFound = new List<Pet>();
            this.PetsLost = new List<Pet>();
        }
        
        public string FullName { get; set; }
        
        public string AvatarUrl { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Pet> PetsFound { get; set; }

        public ICollection<Pet> PetsLost { get; set; }

        public ICollection<Message> MessagesSent { get; set; }

        public ICollection<Message> MessagesReceived { get; set; }

        public int FeedBack { get; set; }
    }
}

