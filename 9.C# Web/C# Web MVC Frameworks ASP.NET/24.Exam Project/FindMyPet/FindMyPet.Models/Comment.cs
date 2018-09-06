using System;
using System.Collections.Generic;

namespace FindMyPet.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Likes = new List<Like>();
        }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public string Content { get; set; }
        
        public DateTime CreationDate { get; set; }

        public bool LikeDisabled { get; set; }
        
        public ICollection<Like> Likes { get; set; }
    }
}
