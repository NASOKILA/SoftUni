using FindMyPet.Data;
using FindMyPet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindMyPet.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessagesController : Controller
    {
        private readonly FindMyPetDbContext context;

        public MessagesController(FindMyPetDbContext context)
        {
            this.context = context;
        }

     

        [HttpGet]
        public IActionResult AddLike(string id)
        {

            var tokens = id.Split("*").ToList();

            string returnUserId = tokens[0];

            int messageId = int.Parse(tokens[1]);
            
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            var message = this.context.Messages.FirstOrDefault(c => c.Id == messageId);

            Like like = new Like()
            {
                CreatorId = currentUser.Id,
                MessageId = message.Id
            };

            this.context.Likes.Add(like);
            this.context.SaveChanges();

            
            return RedirectToAction("Profile", "Users", new { Id = returnUserId });
        }

        [HttpGet]
        public IActionResult RemoveLike(string id)
        {

            var tokens = id.Split("*").ToList();

            string returnUserId = tokens[0];

            int commentId = int.Parse(tokens[1]);

            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            var message = this.context.Messages
                .Include(c => c.Likes)
                .ThenInclude(l => l.Creator)
                .FirstOrDefault(c => c.Id == commentId);

            
            Like likeToRemove = message.Likes.FirstOrDefault(l => l.Creator.Email == this.User.Identity.Name);

            this.context.Likes.Remove(likeToRemove);
            this.context.SaveChanges();
            

            return RedirectToAction("Profile", "Users", new { Id = returnUserId });
        }

    }
}