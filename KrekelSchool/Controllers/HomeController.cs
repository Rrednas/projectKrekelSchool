using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrekelSchool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hier vind u info over de applicatie.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactgegevens van de beheerder vind u hier.";

            return View();
        }

        
    }
}