using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum.Data.Models
{
    [Table("Replies")]
    public class Reply
    {
        public Reply()
        {

        }

        public Reply(string content, Post post, User author)
        {
            this.Content = content;
            this.Post = post;
            this.Author = author;
        }

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

    }
}
