using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

namespace KrekelSchool.Controllers
{
    public class GebruikerController : Controller
    {
        private MediatheekRepository Repository;
        private Mediatheek Mediatheek;
        
        public GebruikerController(MediatheekRepository repository)
        {
            Repository = repository;
            Mediatheek = repository.GetMediatheek();
        }
        // GET: Gebruiker
        [HttpGet]
        public ActionResult LogIn( Gebruiker user)
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(GebruikerViewModel model,Gebruiker user)
        {
            if (ModelState.IsValid)
            {
                var gebruiker = Mediatheek.Gebruikers.First(g => g.Uname == model.Uname && g.Pswd == model.Pswd);
                if (gebruiker != null)
                {
                    user = gebruiker;
                    return Redirect("~/Item/Item");
                }
                else
                {
                   ModelState.AddModelError("","Foutief paswoord of gebruikersnaam.");
                    
                }
                
            }
            return View(model);
        }

        public ActionResult Edit(Gebruiker user)
        {
            return View();

        }
        

    }
}