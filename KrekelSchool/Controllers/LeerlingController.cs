using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class LeerlingController : Controller
    {
        public List<Leerling> Leerlingen = new List<Leerling>();
        private ILeerlingrepository repos = new LeerlingRepository(new KrekelSchoolContext());

       

        public void AddLeerling(Leerling leerling)
        {
            repos.Add(leerling);
        }

        //public Leerling getLeerling()
        //{
        //    throw new System.NotImplementedException();
        //}

        public List<Leerling>  GetLeerlingen()
        {
            return repos.FindAll().ToList();
        }

        public void EditLeerling(Leerling leerling)
        {
            RemoveLeerling(repos.FindBy(leerling.ID));
            AddLeerling(leerling);
        }

        public void RemoveLeerling(Leerling leerling)
        {
            repos.Delete(leerling);
        }

        public ActionResult LeerlingScreen()
        {
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";

            var model = GetLeerlingen();

            return View(model);
        }
    }
}
