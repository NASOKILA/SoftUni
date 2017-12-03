namespace Forum.Data.Models
{
    using forum.data.models;
    using System.ComponentModel.DataAnnotations;


    public class PostTags
    {

        [Key]
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        [Key]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
