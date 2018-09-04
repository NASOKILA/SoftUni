using System.Linq;
using FindMyPet.Data;
using FindMyPet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Web.Controllers
{
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
            Comment comment = this.context.Comments.LastOrDefault();
            return comment;
        }

        [HttpGet]
        public ActionResult GetAllUserComments()
        {
            return View();
        }

        [HttpGet]
        public void AddLike(int id)
        {

            //var tokens = id.Split(StaticConstants.Star).ToList();
            //int returnPetId = int.Parse(tokens[0]);
            //int commentId = int.Parse(tokens[1]);
            
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);
            
            var comment = this.context.Comments.FirstOrDefault(c => c.Id == id);
            
            Like like = new Like()
            {
                CreatorId = currentUser.Id,
                CommentId = comment.Id
            };

            this.context.Likes.Add(like);
            this.context.SaveChanges();
            
            //return RedirectToAction(StaticConstants.Details, StaticConstants.Pets, new { Id = returnPetId });
        }

        [HttpGet]
        public void RemoveLike(int id)
        {
            //var tokens = id.Split(StaticConstants.Star).ToList();
            //int returnPetId = int.Parse(tokens[0]);
            //int commentId = int.Parse(tokens[1]);
            
            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            var comment = this.context.Comments
                .Include(c => c.Likes)
                .ThenInclude(l => l.Creator)
                .FirstOrDefault(c => c.Id == id);


            Like likeToRemove = comment.Likes.FirstOrDefault(l => l.Creator.Email == this.User.Identity.Name);
            
            this.context.Likes.Remove(likeToRemove);
            this.context.SaveChanges();

            //return RedirectToAction(StaticConstants.Details, StaticConstants.Pets, new { Id = returnPetId });
        }
    }
}