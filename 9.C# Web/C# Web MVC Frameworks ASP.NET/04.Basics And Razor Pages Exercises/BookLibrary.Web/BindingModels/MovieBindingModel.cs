namespace BookLibrary.Web.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class MovieBindingModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title minimum length is 3 characters.")]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        [Url(ErrorMessage = "Url is required.")]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Director minimum length is 3 characters.")]
        public string Director { get; set; }
    }
}
