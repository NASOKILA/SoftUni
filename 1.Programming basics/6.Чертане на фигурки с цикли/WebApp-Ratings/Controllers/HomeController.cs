using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_Ratings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrawRating(int rating)
        {
            var fullStarsCount = rating / 10;
            var emptyStarsCount = (100 - rating) / 10;
            var halfStarsCount = 10 - fullStarsCount - emptyStarsCount;

            var stars = "";
            for (int i = 0; i < fullStarsCount; i++)
                stars += "<img src='/images/full-star.png' /> ";
            for (int i = 0; i < halfStarsCount; i++)
                stars += "<img src='/images/half-star.png' /> ";
            for (int i = 0; i < emptyStarsCount; i++)
                stars += "<img src='/images/empty-star.png' /> ";

            return View("Index", "", stars);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }      
    }
}