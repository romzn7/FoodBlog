using blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index(string searchTerm = null)
        {
            var model = _db.Restuarants
                            .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                            .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                            .Take(10)
                            .Select (r => new RestuarantListViewModel
                            {
                                Id = r.id,
                                Name = r.Name,
                                City = r.City,
                                Country = r.Country,
                                CountOfReviews = r.Reviews.Count()
                            });
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restuarants", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Rabin";
            model.Location = "Teku, Kathmandu";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Location = "Teku, Kathmandu";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}