using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Wide Eyes Sleeping Stomach, independant restaurant review application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Wide Eyes Sleeping Stomach Contact Information";

            return View();
        }
    }
}