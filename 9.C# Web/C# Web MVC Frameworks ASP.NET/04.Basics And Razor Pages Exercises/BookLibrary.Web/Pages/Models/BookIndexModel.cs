namespace BookLibrary.Web.Pages.Models
{
    public class BookIndexModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public BookLibrary.Models.Author Author { get; set; }
        
        public string Status { get; set; }
    }
}
