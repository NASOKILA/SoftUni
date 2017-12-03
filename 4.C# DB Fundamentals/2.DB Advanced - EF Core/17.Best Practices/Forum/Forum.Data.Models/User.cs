using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Models
{
    public class User
    {

        public User()
        {

        }

        public User(string username, int password)
        {
            this.UserName = username;
            this.Password = password;
        }
        
              
        public int Id { get; set; }  

        public string UserName { get; set; }

        public int Password { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        
        public ICollection<Reply> Replies { get; set; } = new List<Reply>(); 
        
    }
}
