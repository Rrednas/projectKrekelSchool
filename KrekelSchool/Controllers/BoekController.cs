using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Controllers
{
    public class BoekController : Controller
    {
        //private IboekRepository BoekRepository;
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public BoekController(MediatheekRepository repos)
        {
            
            MediatheekRepository = repos;
            Mediatheek = repos.GetMediatheek();
        }

        public ActionResult Boek(string zoek)
        {
            ViewBag.Title = "Boeken-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            IEnumerable<Boek> boeken = Mediatheek.Boeks.AsEnumerable();
                //BoekRepository.FindAll().OrderBy(b => b.Naam);
            IEnumerable<BoekViewModel> bvm = boeken.Select(b => new BoekViewModel(b)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                bvm = bvm.Where(b => b.Naam.ToLower().Contains(zoek.ToLower()) ||
                    b.Leeftijd.ToString().Contains(zoek.ToLower()));
            }
            return View(bvm);
        }

        public ActionResult BoekDetail(int id)
        {
            Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message = boek.Naam;
            return PartialView(new BoekViewModel(boek));
        }

        #region Boek Toevoegen
        [HttpGet]
        public ActionResult BoekToevoegen()
        {
            Boek boek = new Boek();
            ViewBag.Title = "Boek toevoegen";
            return PartialView(new BoekViewModel(boek));
        }

        [HttpPost]
        public ActionResult BoekToevoegen(BoekViewModel bvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boek boek = new Boek();
                    MapToBoek(bvm,boek);
                    Mediatheek.VoegBoekToe(boek);
                    MediatheekRepository.SaveChanges();
                  //  BoekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", boek.Naam);
                    return RedirectToAction("Boek");
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
            return PartialView(bvm); 
        }
        #endregion


        [HttpGet]
        public ActionResult BoekAanpassen(int id)
        {
            Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + boek.Naam + " aanpassen";
            return PartialView("BoekToevoegen", new BoekViewModel(boek));
        }

        [HttpPost]
        public ActionResult BoekAanpassen(int id, BoekViewModel bvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
                    MapToBoek(bvm, boek);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", boek.Naam);
                    return RedirectToAction("Boek");
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
            return PartialView("BoekToevoegen",bvm);
        }

        [HttpGet]
        public ActionResult BoekVerwijderen(int id)
        {
            Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + boek.Naam + " verwijderen";
            return PartialView(new BoekViewModel(boek));
        }

        [HttpPost, ActionName("BoekVerwijderen")]
        public ActionResult BoekVerwijderenBevestig(int id)
        {
            try
            {
                Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
                if (boek == null)
                    return HttpNotFound();
                Mediatheek.VerwijderBoek(boek);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", boek.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van boek mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Boek");
        }

        private void MapToBoek(BoekViewModel bvm, Boek boek)
        {
            boek.Naam = bvm.Naam;
            boek.Leeftijd = bvm.Leeftijd;
            boek.Isbn = bvm.Isbn;
            boek.Uitgever = bvm.Uitgever;
            boek.Auteur = bvm.Auteur;
            boek.Beschikbaar = bvm.Beschikbaar;
            boek.Beschrijving = bvm.Beschrijving;
            boek.ImgUrl = bvm.ImgUrl;
            boek.Categorie = bvm.Categorie;
        }

    }
}