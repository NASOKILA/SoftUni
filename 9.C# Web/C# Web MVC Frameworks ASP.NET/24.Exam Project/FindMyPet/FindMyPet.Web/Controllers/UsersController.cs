using Microsoft.AspNetCore.Mvc;
using FindMyPet.Data;
using FindMyPet.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using FindMyPet.Web.Static;

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
                return Redirect(StaticConstants.LoginRedirect);
            }

            string thisUserId = context.Users.FirstOrDefault(u => u.Email == this.User.Identity.Name).Id;

            if (id == thisUserId) {
                return new RedirectToActionResult(StaticConstants.MyProfile, StaticConstants.Users, new { @area = StaticConstants.Empty });
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
            ViewData["CurrentUserId"] = thisUserId;
            ViewData[StaticConstants.CurrentId] = id;

            bool isLoggedIn = false;
            bool isAdmin = false;

            var currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                isLoggedIn = true;

                isAdmin = currentUser.Claims.Any(c => c.Value == StaticConstants.AdminRole);

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return View(user);
        }

        [HttpGet]
        public IActionResult LockUser()
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


                ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
                ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();
                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.AllUsers, StaticConstants.Users, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.AdminRole] = isAdmin.ToString();

            return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.Empty });

        }

        [HttpGet]
        public IActionResult UnlockUser()
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
                
                ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
                ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.AllUsers, StaticConstants.Users, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return new RedirectToActionResult(StaticConstants.All, StaticConstants.Pets, new { @area = StaticConstants.Empty });
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

                if (isAdmin == true)
                {
                    return new RedirectToActionResult(StaticConstants.Index, StaticConstants.Home, new { @area = StaticConstants.AdminRole });
                }
            }

            ViewData[StaticConstants.LoggedIn] = isLoggedIn.ToString();
            ViewData[StaticConstants.IsAdmin] = isAdmin.ToString();

            return View(user);
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
        }
        
        [HttpGet]
        public void RemoveMessage(int messageId)
        {
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
        }
    }
}