using Microsoft.AspNetCore.Mvc;
using FindMyPet.Data;
using FindMyPet.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using FindMyPet.Web.Static;

namespace FindMyPet.Web.Areas.Admin.Controllers
{
    [Area(StaticConstants.AdminRole)]
    [Authorize(Roles = StaticConstants.AdminRole)]
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
                return Redirect(StaticConstants.LoginRedirect);
            }
            
            string thisUserId = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name).Id;

            if (id == thisUserId)
            {
                return new RedirectToActionResult(StaticConstants.MyProfile, StaticConstants.Users, new { @area = StaticConstants.AdminRole });
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
                return RedirectToAction(StaticConstants.All, StaticConstants.Pets);
            
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
            ViewData[StaticConstants.CurrentId] = id;

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return View(user);
        }

        [HttpGet]
        public IActionResult MyProfile()
        {

            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
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
                return RedirectToAction(StaticConstants.All, StaticConstants.Pets);


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
            ViewData[StaticConstants.CurrentId] = currentUser.Id;

            bool isLoggedIn = false;
            bool isAdmin = false;
            
            if (this.User.Identity.IsAuthenticated)
            {
                isLoggedIn = true;
                isAdmin = this.User.Claims.Any(c => c.Value == StaticConstants.AdminRole);
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return View(user);
        }
        
        [HttpGet]
        public IActionResult LockUser(string id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
            }


            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);

                if (!isAdmin) {
                    return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();


            //disable User
            User user = this.context.Users.FirstOrDefault(u => u.Id == id);

            DateTime lockoutDate = DateTime.Now;
            lockoutDate = lockoutDate.AddMinutes(20);

            user.LockoutEnd = lockoutDate;

            this.context.Users.Update(user);
            this.context.SaveChanges();

            return RedirectToPage(StaticConstants.AllUsersRedirect, new { @area = StaticConstants.AdminRole });
            
        }
        
        [HttpGet]
        public IActionResult UnlockUser(string id)
        {
            //USER
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(StaticConstants.LoginRedirect);
            }
            
            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);

                ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
                ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

                if (!isAdmin)
                {
                    return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.IsAdmin });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            User user = this.context.Users.FirstOrDefault(u => u.Id == id);
            
            user.LockoutEnd = null;

            this.context.Users.Update(user);
            this.context.SaveChanges();

            return RedirectToPage(StaticConstants.AllUsersRedirect, new { @area = StaticConstants.AdminRole });

        }
        
        [HttpGet]
        public void AddMessage(string id, string Description) {

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

            //return RedirectToAction(StaticConstants.Profile, StaticConstants.Users, new { Id = receverId });
        }
        
        [HttpGet]
        public void RemoveMessage(int messageId)
        {
            //Admin
            Message message = this.context.Messages
                .Include(m => m.Likes)
                .FirstOrDefault(m => m.Id == messageId);
            
            foreach (Like like in message.Likes)
            {
                this.context.Likes.Remove(like);
            }
            this.context.SaveChanges();
            
            this.context.Messages.Remove(message);
            this.context.SaveChanges();

            //return RedirectToAction(StaticConstants.Profile, StaticConstants.Users, new { Id = userId });
        }
    }
}