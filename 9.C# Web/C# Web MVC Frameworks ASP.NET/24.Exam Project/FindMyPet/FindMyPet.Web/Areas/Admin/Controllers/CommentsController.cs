using System.Linq;
using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Web.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Web.Areas.Admin.Controllers
{
    [Area(StaticConstants.AdminRole)]
    [Authorize(Roles = StaticConstants.AdminRole)]
    public class CommentsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly FindMyPetDbContext context;

        public CommentsController(
            UserManager<User> userManager,
            FindMyPetDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public Comment GetLastComment()
        {
            return this.context.Comments.LastOrDefault();
        }

        [HttpGet]
        public void AddLike(int id)
        {
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);
            var comment = this.context.Comments.FirstOrDefault(c => c.Id == id);

            Like like = new Like()
            {
                CreatorId = currentUser.Id,
                CommentId = comment.Id
            };

            this.context.Likes.Add(like);
            this.context.SaveChanges();
        }

        [HttpGet]
        public void RemoveLike(int id)
        {
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            var comment = this.context.Comments
                .Include(c => c.Likes)
                .ThenInclude(l => l.Creator)
                .FirstOrDefault(c => c.Id == id);
            
            Like likeToRemove = comment.Likes.FirstOrDefault(l => l.Creator.Email == this.User.Identity.Name);
            
            this.context.Likes.Remove(likeToRemove);
            this.context.SaveChanges();
        }
    }
}