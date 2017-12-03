namespace Forum.Data.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Post
    {

        public Post()
        {

        }
        

        public Post(string title, string content, Category category, User author)
        {
            this.Title = title;
            this.Content = content;
            this.Category = category;
            this.Author = author;
        }
        
        public Post(string title, string content, int categoryId, int authorId)
        {
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public ICollection<PostTags> PostTags { get; set; }

    }
}
