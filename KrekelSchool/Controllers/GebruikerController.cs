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
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

       
            
            
        private GebruikerRepository Repository;
        
        public GebruikerController(GebruikerRepository repository,MediatheekRepository repos)
        {
            Repository = repository;
            MediatheekRepository = repos;
            Mediatheek = repos.GetMediatheek();
        }
        // GET: Gebruiker
        [HttpGet]
        public ActionResult LogIn(User user)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(GebruikerViewModel model,User user)
        {
            
            
            //if (ModelState.IsValid)
            //{
                var gebruiker = Mediatheek.Gebruikers.First(g => g.Uname == model.Uname && g.Pswd == model.Pswd);
               if (gebruiker != null) {
                   user.LogInUser(gebruiker);
                   return RedirectToAction("LogIn");
                //}
                
            }

            
            ModelState.AddModelError("", "Foutief paswoord of gebruikersnaam.");
            return View(model); 

        }
        [HttpGet]
        public ActionResult Edit(int id,User user)
        {
            
             
       
            Gebruiker gebruiker = Mediatheek.Gebruikers.First(b => b.Id == id);
            if (gebruiker == null)
                return HttpNotFound();
            ViewBag.Title = "Gebruiker: " + gebruiker.Naam + " aanpassen";
            return PartialView("Add", new GebruikerViewModel(gebruiker));
        }

        [HttpPost]
        public ActionResult Edit(int id, GebruikerViewModel gvm,User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Gebruiker gebruiker = Mediatheek.Gebruikers.First(b => b.Id == id);
                    MapToGebruiker(gvm, gebruiker);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", gebruiker.Naam);
                    return RedirectToAction("Gebruikers");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return PartialView("Add",gvm);
        }

        private void MapToGebruiker(GebruikerViewModel gvm, Gebruiker gebruiker)
        {
            gebruiker.Id = gvm.Id;
            gebruiker.Naam = gvm.Naam;
            gebruiker.Uname = gvm.Uname;
            gebruiker.Pswd = gvm.Pswd;
        }
        
        [HttpGet]
        public ActionResult AddVrijwilliger()
        {
            Vrijwilliger gebruiker = new Vrijwilliger();
            ViewBag.Title = "Boek toevoegen";
            return PartialView(new GebruikerViewModel(gebruiker));
        }

        [HttpPost]
        public ActionResult AddVrijwilliger(GebruikerViewModel gvm , User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Vrijwilliger gebruiker = new Vrijwilliger();
                    MapToGebruiker(gvm, gebruiker);
                    Mediatheek.VoegGebruikerToe(gebruiker);
                    MediatheekRepository.SaveChanges();
                   
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", gebruiker.Naam);
                    return RedirectToAction("Gebruikers");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return PartialView(gvm);
        }
        [HttpGet]
        public ActionResult AddMedewerker()
        {
            Medewerker gebruiker = new Medewerker();
            ViewBag.Title = "Boek toevoegen";
            return PartialView(new GebruikerViewModel(gebruiker));
        }

        [HttpPost]
        public ActionResult AddMedewerker(GebruikerViewModel gvm, User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Medewerker gebruiker = new Medewerker();
                    MapToGebruiker(gvm, gebruiker);
                    Mediatheek.VoegGebruikerToe(gebruiker);

                    MediatheekRepository.SaveChanges();
                    
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", gebruiker.Naam);
                    return RedirectToAction("Gebruikers");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return PartialView(gvm);
        }
        [HttpGet]
        public ActionResult Remove(int id, User user)
        {
            
            Gebruiker gebruiker = Mediatheek.Gebruikers.First(b => b.Id == id);
            if (gebruiker == null)
                return HttpNotFound();
            ViewBag.Title = "Gebruiker: " + gebruiker.Naam + " verwijderen";
            return PartialView(new GebruikerViewModel(gebruiker));
        }

        [HttpPost]
        public ActionResult Remove(int id, GebruikerViewModel gvm, User user)
        {
           
            try
            {
                Gebruiker gebruiker = Mediatheek.Gebruikers.First(b => b.Id == id);
                if (gebruiker == null)
                    return HttpNotFound();
                Mediatheek.VerwijderGebruiker(gebruiker);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", gebruiker.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van boek mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("LogIn");
        }

        public ActionResult Gebruikers(User user)
        {
            
            IEnumerable<Gebruiker> gebruikers= Mediatheek.Gebruikers.AsEnumerable();
            
            IEnumerable<GebruikerViewModel> gvm =gebruikers.Select(g => new GebruikerViewModel(g)).ToList();
            return View(gvm);
        }
    }
}