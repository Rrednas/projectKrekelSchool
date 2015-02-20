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
            ViewBag.Message = "Info over de applicatie.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact pagina van de beheerder.";

            return View();
        }

        public ActionResult AdminScreen()
        {
            ViewBag.Message = "Adminiostratie scherm.";

            return View();
        }
    }
}