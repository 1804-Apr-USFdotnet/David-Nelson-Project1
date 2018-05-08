using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBEntity;
using LibraryLogic;

namespace Client.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantDBEntities db = new RestaurantDBEntities();

        // GET: Restaurants
        //public ActionResult Index()
        //{
        //    return View(db.Restaurants.ToList());
        //}
        
        // GET: Restaurants that contain input within name
        public ActionResult Index(string searchString)
        {
            var restaurants = from r in db.Restaurants select r;

            if(!String.IsNullOrEmpty(searchString))
            {
                restaurants = restaurants.Where(s => s.Name.Contains(searchString));
            }
            return View(restaurants.ToList());
        }

        // GET: Restaurants order by location alphabetically then name
        public ActionResult LocationOrder()
        {
            return View(db.Restaurants.OrderBy(x => new { x.Location, x.Name }).ToList());
        }

        // GET: Restaurants order by alphabetically descending
        public ActionResult Descending()
        {
            return View(db.Restaurants.OrderByDescending(x=> new { x.Name }).ToList());
        }

        // GET: Restaurants order by alphabetically
        public ActionResult Ascending()
        {
            return View(db.Restaurants.OrderBy(x => new { x.Name }).ToList());
        }

        // GET: Restaurant Reviews
        public ActionResult TopThree()
        {
            Library library = new Library();
            List<Restaurant> topThree = new List<Restaurant>();
            topThree = library.TopThree(db.Reviews.ToList(), db.Restaurants.ToList());
            return View(topThree);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
