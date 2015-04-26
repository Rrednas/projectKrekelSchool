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
        public ActionResult Cd(string zoek, VoorlopigeUitlening voorlopige)
        {
            ViewBag.Title = "Cds-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            IEnumerable<CD> items = Mediatheek.Cds.AsEnumerable();
            
            IEnumerable<CdViewModel> Vm = items.Select(b => new CdViewModel(b)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                Vm = Vm.Where(b => b.Naam.ToLower().Contains(zoek.ToLower()) ||
                    b.Leeftijd.ToString().Contains(zoek.ToLower()));
            }
            return View(new ItemScreenViewModel(voorlopige, Vm));
        }
        public ActionResult CdDetail(int id)
        {
            CD item = Mediatheek.Cds.First(b => b.Id == id);
            if (item == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message = item.Naam;
            return PartialView(new CdViewModel(item));
        }
        #region Cd Toevoegen
        [HttpGet]
        public ActionResult CdToevoegen()
        {
            CD item = new CD();
            ViewBag.Title = "Cd toevoegen";
            return PartialView(new CdViewModel(item));
        }

        [HttpPost]
        public ActionResult CdToevoegen(CdViewModel Item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CD item = new CD();
                    MapToItem(Item, item);
                    Mediatheek.VoegCdToe(item);
                    MediatheekRepository.SaveChanges();
                    
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", item.Naam);
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
            return PartialView(Item);
        }
        #endregion
        [HttpGet]
        public ActionResult CdAanpassen(int id)
        {
            CD item = Mediatheek.Cds.First(b => b.Id == id);
            if (item == null)
                return HttpNotFound();
            ViewBag.Title = "Cd: " + item.Naam + " aanpassen";
            return PartialView("CdToevoegen", new CdViewModel(item));
        }

        [HttpPost]
        public ActionResult CdAanpassen(int id, CdViewModel Item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   CD item = Mediatheek.Cds.First(b => b.Id == id);
                    MapToItem(Item, item);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", item.Naam);
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
            return PartialView("CdToevoegen",Item);
        }

        [HttpGet]
        public ActionResult CdVerwijderen(int id)
        {
            CD item = Mediatheek.Cds.First(b => b.Id == id);
            if (item == null)
                return HttpNotFound();
            ViewBag.Title = "Cd: " + item.Naam + " verwijderen";
            return PartialView(new CdViewModel(item));
        }

        [HttpPost, ActionName("CdVerwijderen")]
        public ActionResult CdVerwijderenBevestig(int id)
        {
            try
            {
                CD item = Mediatheek.Cds.First(b => b.Id == id);
                if (item == null)
                    return HttpNotFound();
                Mediatheek.VerwijderCd(item);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", item.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van item mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Cd");
        }

        private void MapToItem(CdViewModel itemvm, CD item)
        {
            item.Naam = itemvm.Naam;
            item.Leeftijd = itemvm.Leeftijd;
            item.Size = itemvm.Size;
            item.Beschikbaar = itemvm.Beschikbaar;
            item.Beschrijving = itemvm.Beschrijving;
            
            item.Categories = itemvm.Categories;
        }
        public ActionResult KiesVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(Mediatheek.Cds.First(b => b.Id == id));
           return RedirectToAction("Cd");
        }

        //public ActionResult AanvaardUitlening(VoorlopigeUitlening voorlopige)
        //{
        //    Mediatheek.VoegUitleningToe(voorlopige.VoorlopigeLener, voorlopige.VoorlopigItem);
            
        //}

    }

}