using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum.Data.Models
{
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

        //Tozi shte priema i foreign keyovete za da go polzvame v samata baza !!!
        public Post(string title, string content, int categoryId, int authorId)
        {
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
        }



        //Vsichki propertita otgovarqt na tablici v baza
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        // Kazvame che tova e ForeignKey socheshto kum Author
        public User Author { get; set; }
        // Avtora ni e User, tova e NAVIGACIONNO PROPERTY

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; }

        //SLAGAME VRUZKA MANY TO MANY
        //Slagame si i kolekciq ot tagove:
        public ICollection<PostTags> PostTags { get; set; }



        //Bi trqbvalo vsichko da e keshirano
    }
}
