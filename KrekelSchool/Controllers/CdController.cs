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
	public class CdController : Controller
	{
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public CdController(MediatheekRepository repos)
        {
            
            MediatheekRepository = repos;
            Mediatheek = repos.GetMediatheek();
        }

        public ActionResult Cd(string zoek,VoorlopigeUitlening voorlopige)
       {
            ViewBag.Title = "CD-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            IEnumerable<CD> cds = Mediatheek.Cds.AsEnumerable();
            IEnumerable<CdViewModel> cvm = cds.Select(b => new CdViewModel(b)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                cvm = cvm.Where(c => c.Naam.ToLower().Contains(zoek.ToLower()) ||
                    c.Leeftijd.ToString().Contains(zoek.ToLower()));
            }
            return View(new ItemScreenViewModel(voorlopige,cvm));
        }

        public ActionResult CdDetail(int id)
        {
            CD cd = Mediatheek.Cds.First(c => c.Id == id);
            if (cd == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message = cd.Naam;
            return PartialView(new CdViewModel(cd));
        }

        #region CD Toevoegen
        [HttpGet]
        public ActionResult CdToevoegen()
        {
            CD cd = new CD();
            ViewBag.Title = "CD toevoegen";
            return PartialView(new CdViewModel(cd));
        }

        [HttpPost]
        public ActionResult CdToevoegen(CdViewModel cvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CD cd = new CD();
                    MapToCd(cvm,cd);
                    Mediatheek.VoegCdToe(cd);
                    MediatheekRepository.SaveChanges();
                  //  BoekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", cd.Naam);
                    return RedirectToAction("Cd");
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
            return PartialView(cvm); 
        }
        #endregion


        [HttpGet]
        public ActionResult CdAanpassen(int id)
        {
            CD cd = Mediatheek.Cds.First(c => c.Id == id);
            if (cd == null)
                return HttpNotFound();
            ViewBag.Title = "CD: " + cd.Naam + " aanpassen";
            return PartialView("CdToevoegen", new CdViewModel(cd));
        }

        [HttpPost]
        public ActionResult BoekAanpassen(int id, CdViewModel cvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CD cd = Mediatheek.Cds.First(c => c.Id == id);
                    MapToCd(cvm, cd);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", cd.Naam);
                    return RedirectToAction("Cd");
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
            return PartialView("CdToevoegen",cvm);
        }

        [HttpGet]
        public ActionResult CdVerwijderen(int id)
        {
            CD cd = Mediatheek.Cds.First(c => c.Id == id);
            if (cd == null)
                return HttpNotFound();
            ViewBag.Title = "CD: " + cd.Naam + " verwijderen";
            return PartialView(new CdViewModel(cd));
        }

        [HttpPost, ActionName("CdVerwijderen")]
        public ActionResult CdVerwijderenBevestig(int id)
        {
            try
            {
                CD cd = Mediatheek.Cds.First(c => c.Id == id);
                if (cd == null)
                    return HttpNotFound();
                Mediatheek.VerwijderCd(cd);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", cd.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van CD mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Cd");
        }

        private void MapToCd(CdViewModel cvm, CD cd)
        {
            cd.Naam = cvm.Naam;
            cd.Leeftijd = cvm.Leeftijd;
            cd.Beschikbaar = cvm.Beschikbaar;
            cd.Beschrijving = cvm.Beschrijving;
            cd.ImgUrl = cvm.ImgUrl;
            cd.Categorie = cvm.Categorie;
        }
        public ActionResult KiesVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(Mediatheek.Cds.First(b => b.Id == id));
           return RedirectToAction("Cd");
        }

        public ActionResult VerwijderVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(null);
            return RedirectToAction("Cd");
        }
        public ActionResult VerwijderVoorlopigeLener(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesLener(null);
            return RedirectToAction("Cd");
        }
        public ActionResult AanvaardUitlening(VoorlopigeUitlening voorlopige)
        {
            Mediatheek.VoegUitleningCdToe(voorlopige.VoorlopigeLener, voorlopige.VoorlopigItem);
            MediatheekRepository.SaveChanges();
            voorlopige.Clear();
            TempData["Succes"] = "Uitlening succesvol aangemaakt";
            return RedirectToAction("Cd");
        }
	}
}