namespace FindMyPet.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int? CommentId { get; set; }

        public Comment Comment { get; set; }

        public int? MessageId { get; set; }

        public Message Message { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }
    }
}
