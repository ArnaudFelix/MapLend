using MapLend.Mvc.Infrastructure;
using MapLend.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapLend.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Populate()
        {
            using (var db = new ApplicationDbContext())
            {
                PopulateDatabase.Seed(db);
            }

            return RedirectToAction("Index");
        }
    }
}