using Microsoft.AspNetCore.Mvc;
using FindMyPet.Data;
using FindMyPet.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace FindMyPet.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly FindMyPetDbContext context;

        public UsersController(FindMyPetDbContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        public IActionResult Profile(string id)
        {

            if (!this.User.Identity.IsAuthenticated){
                return Redirect("/Identity/Account/Login");
            }
            
            User user = context.Users
                .Include(u => u.MessagesSent)
                    .ThenInclude(ms => ms.Likes)
                .Include(u => u.MessagesSent)
                    .ThenInclude(ms => ms.Sender)
                .Include(u => u.MessagesReceived)
                    .ThenInclude(mr => mr.Likes)
                .Include(u => u.MessagesReceived)
                    .ThenInclude(mr => mr.Sender)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
                return RedirectToAction("All", "Pets");


            var allLikes = context.Likes
                .Include(l => l.Creator)
                .ToList();

            foreach (var currentMessage in user.MessagesReceived)
            {
                int likesCountByUserForCurrentComment = currentMessage.Likes.Where(l => l.Creator.Email == this.User.Identity.Name).Count();

                if (likesCountByUserForCurrentComment > 0)
                    currentMessage.LikeDisabled = true;
                else
                    currentMessage.LikeDisabled = false;
            }
            
            ViewBag.Messages = user.MessagesReceived.ToList();
            ViewData["CurrentId"] = id;

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == "Admin");

                if (isAdmin == true)
                {
                    return new RedirectToActionResult("Index", "Home", new { @area = "Admin" });
                }
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return View(user);
        }

        [HttpGet]
        public IActionResult MyProfile()
        {

            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            User user = context.Users
                .Include(u => u.MessagesSent)
                    .ThenInclude(ms => ms.Likes)
                .Include(u => u.MessagesSent)
                    .ThenInclude(ms => ms.Sender)
                .Include(u => u.MessagesReceived)
                    .ThenInclude(mr => mr.Likes)
                .Include(u => u.MessagesReceived)
                    .ThenInclude(mr => mr.Sender)
                .FirstOrDefault(u => u.Id == currentUser.Id);

            if (user == null)
                return RedirectToAction("All", "Pets");


            var allLikes = context.Likes
                .Include(l => l.Creator)
                .ToList();

            foreach (var currentMessage in user.MessagesReceived)
            {
                int likesCountByUserForCurrentComment = currentMessage.Likes.Where(l => l.Creator.Email == this.User.Identity.Name).Count();

                if (likesCountByUserForCurrentComment > 0)
                    currentMessage.LikeDisabled = true;
                else
                    currentMessage.LikeDisabled = false;
            }

            ViewBag.Messages = user.MessagesReceived.ToList();
            ViewData["CurrentId"] = currentUser.Id;

            bool isLoggedIn = false;
            bool isAdmin = false;
            
            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = this.User.Claims.Any(c => c.Value == "Admin");

                if (isAdmin == true)
                {
                    return new RedirectToActionResult("Index", "Home", new { @area = "Admin" });
                }
            }

            ViewData["LoggedIn"] = isLoggedIn.ToString();
            ViewData["IsAdmin"] = isAdmin.ToString();

            return View(user);
        }
        
        [HttpPost]
        public IActionResult AddMessage(string id, string Description) {

            string receverId = id;

            var currentUser = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name);

            Message message = new Message()
            {
                Content = Description,
                CreationDate = DateTime.Now,
                SenderId = currentUser.Id,
                LikeDisabled = false,
                Likes = new List<Like>(),
                ReceverId = receverId,
            };

            this.context.Messages.Add(message);

            this.context.SaveChanges();

            return RedirectToAction("Profile", "Users", new { Id = receverId });

        }
        
        [HttpGet]
        public IActionResult RemoveMessage(string userId, int messageId)
        {

            Message message = this.context.Messages
                .Include(m => m.Likes)
                .FirstOrDefault(m => m.Id == messageId);

            if (message == null)
            {
                return RedirectToAction("All", "Pets");
            }

            foreach (Like like in message.Likes)
            {
                this.context.Likes.Remove(like);
            }
            this.context.SaveChanges();


            this.context.Messages.Remove(message);
            this.context.SaveChanges();

            return RedirectToAction("Profile", "Users", new { Id = userId });
        }
    }
}