using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Models;
using LibraryLogic;
using DBEntity;


namespace Client.Controllers
{
    public class ReviewController : Controller
    {
        private Library library;

        public ReviewController()
        {
            library = new Library();
        }

        public List<ReviewModel> convertReview(List<Review> RawReview)
        {
            List<ReviewModel> Review = new List<ReviewModel>();
            ReviewModel newReview = new ReviewModel();

            for (int i = 0; i < RawReview.Count; i++)
            {
                newReview = new ReviewModel();
                newReview.ID = RawReview[i].ID;
                newReview.Name = RawReview[i].Name;
                newReview.Rating = (int)RawReview[i].Rating;
                newReview.RestaurantID = (int)RawReview[i].RestaurantID;
                newReview.text = RawReview[i].Text;
                Review.Add(newReview);
            }
            return Review;
        }



        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListReview()
        {
            var rawreview = library.ReturnReview();
            List<ReviewModel> review = new List<ReviewModel>();
            review = convertReview(rawreview);
            return View(review);
        }

        //[HttpPost]
        //public ActionResult CreateReview(NewReviewViewModel newReviewViewModel)
        //{
        //    return View();
        //}

        public ActionResult DeleteReview()
        {
            return View();
        }



    }
}