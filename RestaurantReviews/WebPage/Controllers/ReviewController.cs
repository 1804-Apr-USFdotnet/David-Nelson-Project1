using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPage.Models;

namespace WebPage.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListReview()
        {
            List<ReviewModel> review = new List<ReviewModel>();
            review.Add(new ReviewModel { FirstName = "Dvid", LastName = "Neons", Age = 17 });
            review.Add(new ReviewModel { FirstName = "Did", LastName = "Nelns", Age = 17 });
            review.Add(new ReviewModel { FirstName = "Dvad", LastName = "Nelson", Age = 17 });
            review.Add(new ReviewModel { FirstName = "David", LastName = "Neldo", Age = 17 });
            return View(review);
        }
    }
}