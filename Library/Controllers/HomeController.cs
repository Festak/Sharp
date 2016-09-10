using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var offers = db.Offers.Where(o=>o.IsAccepted==true).ToList();
            return View(offers);
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
        [HttpGet]
        public ActionResult MakeOffer()
        {
        //    SelectList genres = new SelectList(db.Genres,"Id", "Name");
        //    ViewBag.Genres = genres;
            return View();
        }
        [HttpPost]
        public ActionResult MakeOffer(Book book)
        {
            Genre genre = db.Genres.First();
            book.Genre = genre;
            db.Books.Add(book);
            db.SaveChanges();
            return Redirect("Index");
        }



    }
}