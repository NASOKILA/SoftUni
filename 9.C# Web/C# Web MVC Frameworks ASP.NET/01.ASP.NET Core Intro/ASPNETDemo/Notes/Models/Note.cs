using System;

namespace Notes.Models
{
    public class Note
    {
        public Note()
        {
            this.CreationTime = DateTime.Now;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public DateTime CreationTime { get; set; }

        public User Author { get; set; }

        public int AuthorId { get; set; }
    }
}
