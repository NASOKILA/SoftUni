using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyPet.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly FindMyPetDbContext _context;
        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            FindMyPetDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _context = context;
        }
        
        public string Username { get; set; }
        
        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            
            [Display(Name = StaticConstants.UserName)]
            public string UserName { get; set; }

            [Display(Name = StaticConstants.FullName)]
            public string FullName { get; set; }
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = StaticConstants.PhoneNumber)]
            public string PhoneNumber { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = StaticConstants.DateOfBirth)]
            public DateTime DateOfBirth { get; set; }
            
            [Display(Name = StaticConstants.AvatarUpload)]
            public IFormFile AvatarUpload { get; set; }

        }

        public IActionResult OnGetAsync()
        {
            var user = _context.Users.Find(_userManager.GetUserId(User));

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            

            var userName = user.UserName;
            var email = user.Email;
            var phoneNumber = user.PhoneNumber;
            var dateOfBirth = user.DateOfBirth;
            var avatarUrl = user.AvatarUrl;
            var fullName = user.FullName;

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth,
                FullName = fullName
            };

            IsEmailConfirmed = user.EmailConfirmed;

            ViewData["Image"] = user.AvatarUrl;


            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();


            return Page();
        }

        public IActionResult OnPostAsync()
        {
            Input.UserName = Input.Email;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var avatarUpload = Input.AvatarUpload;
            

            var fullFilePath = "";
            string locationToUse = "";
            if (avatarUpload != null)
            {
                //get previous image from folder
                string[] filePaths = Directory.GetFiles(@"wwwroot/images", "*", SearchOption.TopDirectoryOnly);

                var oldFile = filePaths.FirstOrDefault(p => p.Contains(this.User.Identity.Name));
                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }

             

                locationToUse = "/images/" + Input.Email + "-" + avatarUpload.FileName;

                fullFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Input.Email + "-" + avatarUpload.FileName);

                var fileStream = new FileStream(fullFilePath, FileMode.Create);
                
                avatarUpload.CopyTo(fileStream);
                    
                fileStream.Close();
            }

            var user = _context.Users.Find(_userManager.GetUserId(User));

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            if (avatarUpload != null)
            {
                user.AvatarUrl = locationToUse;
            }

            user.PhoneNumber = Input.PhoneNumber;
            user.Email = Input.Email;
            user.DateOfBirth = Input.DateOfBirth;
            user.FullName = Input.FullName;

            _context.Users.Update(user);

            _context.SaveChanges();


            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();


            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
        
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
