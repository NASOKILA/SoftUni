namespace RazorPagesArchitecture.Pages
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        [Required]
        [MinLength(3)]
        [DataType(DataType.Text)]
        [BindProperty(SupportsGet=true)] //This attribute authomatically binds the property 
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [BindProperty(SupportsGet = true)] //This attribute authomatically binds the property
        public string Password { get; set; }

        //With this (SupportsGet = true) we dont even need the post method
        public void OnPost(string username, string password)
        {
            //we set them to the properties
            //this.Password = password;
            //this.Username = username;

            //this is the state of the page it holds all the info
            //Id the validations are invalid we can see them under "Values, Results View"
            if (this.ModelState.IsValid)
            {
                ViewData["Username"] = this.Username;
                ViewData["Password"] = this.Password;
            }
            else
            {
                ViewData["Error"] = "Invalid Form Input!";
            }

        }


        //To use the asyncronous way we can use Tasks
        //public async Task<IActionResult> OnPost() { }
        
    }
}


