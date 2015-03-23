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
        public List<Lener> Leerlingen = new List<Lener>();
        private ILeerlingRepository repos = new LeerlingRepository(new KrekelSchoolContext());

        #region methods

        public void KenLeningToeAan(Lener lener,Uitlening uitlening)
        {   
            repos.FindBy(lener.Id).KrijgLening(uitlening);
            repos.SaveChanges();
        }
        #endregion

        public void AddLeerling(Lener leerling)
        {
            repos.Add(leerling);
            repos.SaveChanges();
        }

        //public Lener getLeerling()
        //{
        //    throw new System.NotImplementedException();
        //}

        public List<Lener>  GetLeerlingen()
        {
            return repos.FindAll().ToList();
        }

        public void EditLeerling(Lener leerling)
        {
            RemoveLeerling(repos.FindBy(leerling.Id));
            AddLeerling(leerling);
        }

        public void RemoveLeerling(Lener leerling)
        {
            repos.Delete(leerling);
        }

        public ActionResult LenerEnUitlening()
        {
            ViewBag.Message = "Selecteer Lener of Uitlening";

            return View();
        }

        public ActionResult LeerlingScreen()
        {
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";

            var model = GetLeerlingen();

            return View(model);
        }
    }
}
