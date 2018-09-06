using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindMyPet.Web.Areas.Admin.Controllers
{
    [Area(StaticConstants.AdminRole)]
    [Authorize(Roles = StaticConstants.AdminRole)]
    public class MessagesController : Controller
    {
        private readonly FindMyPetDbContext context;

        public MessagesController(FindMyPetDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public Message GetLastMessage()
        {
            return this.context.Messages.LastOrDefault();
        }
        
        [HttpGet]
        public void AddLike(int id)
        {   
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            var message = this.context.Messages.FirstOrDefault(c => c.Id == id);

            Like like = new Like()
            {
                CreatorId = currentUser.Id,
                MessageId = message.Id
            };

            this.context.Likes.Add(like);
            this.context.SaveChanges();
        }

        [HttpGet]
        public void RemoveLike(int id)
        {
         
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            var message = this.context.Messages
                .Include(c => c.Likes)
                .ThenInclude(l => l.Creator)
                .FirstOrDefault(c => c.Id == id);
            
            Like likeToRemove = message.Likes.FirstOrDefault(l => l.Creator.Email == this.User.Identity.Name);

            this.context.Likes.Remove(likeToRemove);

            this.context.SaveChanges();
        }
    }
}