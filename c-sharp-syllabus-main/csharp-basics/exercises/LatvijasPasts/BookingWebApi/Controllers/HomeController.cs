using BookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using System.Data.Entity;

namespace BookingWebApi.Controllers
{
    public class HomeController : Controller
    {
        CVContext db = new CVContext();

        public ActionResult Index()
        {
            var cvs = db.CVs;
            ViewBag.CVs = cvs;
            return View();
        }

        [HttpGet]
        public ActionResult Remove(int? id)
        {
            CV cV = db.CVs.Where(cv => cv.Id==id).First();
            db.CVs.Remove(cV);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var model = db.CVs.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CV cv)
        {
            db.Entry(cv).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult AddCV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCV(CV cv)
        {
            db.CVs.Add(cv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Watch(int id)
        {
            var model = db.CVs.Find(id);
            return View(model);
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