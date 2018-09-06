using System;
using System.Collections.Generic;

namespace FindMyPet.Models
{
    public class Message
    {

        public Message()
        {
            this.Likes = new List<Like>();
        }

        public int Id { get; set; }

        public string SenderId { get; set; }

        public User Sender { get; set; }

        public string ReceverId { get; set; }

        public User Recever { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public bool LikeDisabled { get; set; }
        
        public ICollection<Like> Likes { get; set; }
    }
}
