using forum.data.models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Models
{
    public class PostTags
    {
        //TOVA SHTE DEISTVA KATO MAPPING TABLICA
        [Key]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
