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
    public class LenerController : Controller
    {
        public List<Lener> Lener = new List<Lener>();
        public static KrekelSchoolContext Context = new KrekelSchoolContext();
        private LenerRepository repos = new LenerRepository(Context);

       

        public void AddLener(Lener lener)
        {
            repos.Add(lener);
        }

        //public Lener getLeerling()
        //{
        //    throw new System.NotImplementedException();
        //}

        public List<Lener> GetLeners()
        {
            return repos.FindAll().ToList();
        }

        public void EditLener(Lener lener)
        {
            RemoveLener(repos.FindBy(lener.Id));
            AddLener(lener);
        }

        public void RemoveLener(Lener lener)
        {
            repos.Delete(lener);
        }

        public ActionResult LenerScreen()
        {
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";

            var model = GetLeners();

            return View(model);
        }
    }
}
