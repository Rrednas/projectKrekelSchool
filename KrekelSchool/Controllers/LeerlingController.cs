using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class LeerlingController : Controller
    {
        public Collection<Leerling> Leerlingen = new Collection<Leerling>();

        public void addLeerling(string naam, string voornaam)
        {
            throw new System.NotImplementedException();
        }

        public Leerling getLeerling()
        {
            throw new System.NotImplementedException();
        }

        public Collection<Leerling>  getLeerlingen()
        {
            throw new System.NotImplementedException();
        }

        public void editLeerling(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void removeLeerling(int ID)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult LeerlingScreen()
        {
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";

            var model = Leerlingen;

            return View(model);
        }
    }
}
