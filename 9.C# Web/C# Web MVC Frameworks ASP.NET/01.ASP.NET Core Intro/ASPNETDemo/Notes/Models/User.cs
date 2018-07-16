using System.Collections;
using System.Collections.Generic;

namespace Notes.Models
{
    public class User
    {

        public User()
        {
            this.Notes = new List<Note>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
