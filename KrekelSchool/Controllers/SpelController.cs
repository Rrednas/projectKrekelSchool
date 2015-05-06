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
    public class SpelController : Controller
    {
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public SpelController(MediatheekRepository repos)
        {
            
            MediatheekRepository = repos;
            Mediatheek = repos.GetMediatheek();
        }

        public ActionResult Spel(string zoek,VoorlopigeUitlening voorlopige)
       {
            ViewBag.Title = "Spellen-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            IEnumerable<Spel> spellen = Mediatheek.Spels.AsEnumerable();
                //BoekRepository.FindAll().OrderBy(b => b.Naam);
            IEnumerable<SpelViewModel> svm = spellen.Select(s => new SpelViewModel(s)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                svm = svm.Where(b => b.Naam.ToLower().Contains(zoek.ToLower()) ||
                    b.Leeftijd.ToString().Contains(zoek.ToLower()));
            }
            return View(new ItemScreenViewModel(voorlopige,svm));
        }

        public ActionResult SpelDetail(int id)
        {
            Spel spel = Mediatheek.Spels.First(s => s.Id == id);
            if (spel == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message = spel.Naam;
            return PartialView(new SpelViewModel(spel));
        }

        #region Boek Toevoegen
        [HttpGet]
        public ActionResult SpelToevoegen()
        {
            Spel spel = new Spel();
            ViewBag.Title = "Spel toevoegen";
            return PartialView(new SpelViewModel(spel));
        }

        [HttpPost]
        public ActionResult SpelToevoegen(SpelViewModel svm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Spel spel = new Spel();
                    MapToSpel(svm,spel);
                    Mediatheek.VoegSpelToe(spel);
                    MediatheekRepository.SaveChanges();
                  //  BoekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", spel.Naam);
                    return RedirectToAction("Spel");
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
            return PartialView(svm); 
        }
        #endregion


        [HttpGet]
        public ActionResult SpelAanpassen(int id)
        {
            Spel spel = Mediatheek.Spels.First(s => s.Id == id);
            if (spel == null)
                return HttpNotFound();
            ViewBag.Title = "Spel: " + spel.Naam + " aanpassen";
            return PartialView("SpelToevoegen", new SpelViewModel(spel));
        }

        [HttpPost]
        public ActionResult SpelAanpassen(int id, SpelViewModel svm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Spel spel = Mediatheek.Spels.First(s => s.Id == id);
                    MapToSpel(svm, spel);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", spel.Naam);
                    return RedirectToAction("Spel");
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
            return PartialView("SpelToevoegen",svm);
        }

        [HttpGet]
        public ActionResult SpelVerwijderen(int id)
        {
            Spel spel = Mediatheek.Spels.First(s => s.Id == id);
            if (spel == null)
                return HttpNotFound();
            ViewBag.Title = "Spel: " + spel.Naam + " verwijderen";
            return PartialView(new SpelViewModel(spel));
        }

        [HttpPost, ActionName("BoekVerwijderen")]
        public ActionResult BoekVerwijderenBevestig(int id)
        {
            try
            {
                Spel spel = Mediatheek.Spels.First(s => s.Id == id);
            if (spel == null)
                return HttpNotFound();
                Mediatheek.VerwijderSpel(spel);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", spel.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van spel mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Spel");
        }

        private void MapToSpel(SpelViewModel svm, Spel spel)
        {
            spel.Naam = svm.Naam;
            spel.Leeftijd = svm.Leeftijd;
            spel.Beschikbaar = svm.Beschikbaar;
            spel.Beschrijving = svm.Beschrijving;
            spel.ImgUrl = svm.ImgUrl;
            spel.Categorie = svm.Categorie;
        }
        public ActionResult KiesVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(Mediatheek.Spels.First(s => s.Id == id));
            return RedirectToAction("Spel");
        }

        public ActionResult VerwijderVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(null);
            return RedirectToAction("Spel");
        }
        public ActionResult VerwijderVoorlopigeLener(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesLener(null);
            return RedirectToAction("Spel");
        }
        public ActionResult AanvaardUitlening(VoorlopigeUitlening voorlopige)
        {
            Mediatheek.VoegUitleningSpelToe(voorlopige.VoorlopigeLener, voorlopige.VoorlopigItem);
            MediatheekRepository.SaveChanges();
            voorlopige.Clear();
            TempData["Succes"] = "Uitlening succesvol aangemaakt";
            return RedirectToAction("Spel");
        }

    }
    
}