using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult BookConfirm()
        {
            var offer = db.Offers.Where(o => o.IsAccepted == false).ToList();
            return View(offer);
        }
        [HttpGet]
        public ActionResult BookConfirmed(int? id)
        {
            if (id == null)
            { return HttpNotFound(); }
       
            Offer offer = db.Offers.Find(id);
            if (offer != null)
            {
                offer.IsAccepted = true;
                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("BookConfirm");
        }



    }
}