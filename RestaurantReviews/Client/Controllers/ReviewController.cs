using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Models;

namespace Client.Controllers
{
    public class ReviewController : Controller
    {
        private 

        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListReview()
        {

            List<ReviewModel> review = new List<ReviewModel>();
            review.Add(new ReviewModel { Name = "David Nel", Rating = 17, RestaurantID = 14344, text = "To do" });
            review.Add(new ReviewModel { Name = "Hata Pon", Rating = 1, RestaurantID = 11244, text = "Pata pon Don Chaka" });
            review.Add(new ReviewModel { Name = "Fancy Pants", Rating = 3, RestaurantID = 15344, text = "To do dah" });
            review.Add(new ReviewModel { Name = "Butz Klazer", Rating = 6, RestaurantID = 94282, text = "Mimiery" });



            return View(review);
        }

        [HttpPost]
        public ActionResult CreateReview(NewReviewViewModel newReviewViewModel)
        {
            return View();
        }

        public ActionResult DeleteReview()
        {
            return View();
        }



    }
}