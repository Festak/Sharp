
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using CarShop.Models;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {


        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
     
              var genres = from g in db.Genres
                         select g;
        
            ViewBag.Genres = genres;
            return View(db.Books);
        }

        public ActionResult Genres()
        {
            return View(db.Genres);
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
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "BookId,BookName,GenreId,PriceId, Description, Count")]Book book)
        {
            if (ModelState.IsValid)
            {
                book.Count = 1;
                db.Entry(book).State = EntityState.Added;
               
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);

        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            { return HttpNotFound(); }
            Book book = db.Books.Find(id);
            if (book != null) { return View(book); }
            return HttpNotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null) { return HttpNotFound(); }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("ShowList");

        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult BookConfirm()
        {
            return View(db.Books);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult BookConfirmed(int? id)
        {
            if (id == null)
            { return HttpNotFound(); }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                book.IsAccepted = true;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("BookConfirm");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult ShowList(string searchString)
        {
            var books = from b in db.Books
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.BookName.Contains(searchString)).OrderBy(b => b.BookName);

            }
            return View(books.ToList());
        }




    }
}