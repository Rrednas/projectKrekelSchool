using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;
using WebGrease.Css.Extensions;

namespace KrekelSchool.Controllers
{
    public class VerteltasController : Controller
    {
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public VerteltasController(MediatheekRepository repository)
        {
            MediatheekRepository = repository;
            Mediatheek = repository.GetMediatheek();
        }
        [HttpGet]
        public ActionResult Index(VoorlopigeUitlening voorlopige , User user,string zoek)
        {
            ViewBag.Title = "Verteltassen-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            IEnumerable<Verteltas> Items = Mediatheek.Verteltass.AsEnumerable();
            //BoekRepository.FindAll().OrderBy(b => b.Naam);
            IEnumerable<VerteltasViewModel> vvm = Items.Select(b => new VerteltasViewModel(b)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                vvm = vvm.Where(b => b.Naam.ToLower().Contains(zoek.ToLower()) ||
                    b.Leeftijd.ToString().Contains(zoek.ToLower()));
            }
            return View(new ItemScreenViewModel(voorlopige, vvm, user));
        }
        public ActionResult VerteltasDetail(int id)
        {
            Verteltas verteltas = Mediatheek.Verteltass.First(b => b.Id == id);
            if (verteltas == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message = verteltas.Naam;
            return PartialView(new VerteltasViewModel(verteltas));
        }
        [HttpGet]
        public ActionResult VerteltasToevoegen()
        {
            Verteltas verteltas = new Verteltas();
            ViewBag.Title = "Verteltas toevoegen";
            return PartialView(new VerteltasViewModel(verteltas));
        }

        [HttpPost]
        public ActionResult VerteltasToevoegen(VerteltasViewModel vvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Verteltas verteltas = new Verteltas();
                    MapToVerteltas(vvm, verteltas);
                    Mediatheek.VoegVerteltasToe(verteltas);
                    MediatheekRepository.SaveChanges();
                    //  BoekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", verteltas.Naam);
                    return RedirectToAction("Index");
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
            return PartialView(vvm);
        }
        [HttpGet]
        public ActionResult VerteltasAanpassen(int id)
        {
            Verteltas verteltas = Mediatheek.Verteltass.First(b => b.Id == id);
            if (verteltas == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + verteltas.Naam + " aanpassen";
            return PartialView("VerteltasToevoegen", new VerteltasViewModel(verteltas));
        }

        [HttpPost]
        public ActionResult VerteltasAanpassen(int id, VerteltasViewModel bvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Verteltas verteltas = Mediatheek.Verteltass.First(b => b.Id == id);
                    MapToVerteltas(bvm, verteltas);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", verteltas.Naam);
                    return RedirectToAction("Index");
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
            return PartialView("VerteltasToevoegen", bvm);
        }
        [HttpGet]
        public ActionResult VerteltasVerwijderen(int id)
        {
            Verteltas verteltas = Mediatheek.Verteltass.First(b => b.Id == id);
            if (verteltas == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + verteltas.Naam + " verwijderen";
            return PartialView(new VerteltasViewModel(verteltas));
        }

        [HttpPost, ActionName("VerteltasVerwijderen")]
        public ActionResult BoekVerwijderenBevestig(int id)
        {
            try
            {
                Verteltas verteltas = Mediatheek.Verteltass.First(b => b.Id == id);
                if (verteltas == null)
                    return HttpNotFound();
                Mediatheek.VerwijderVerteltas(verteltas);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", verteltas.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van boek mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Index");
        }
        
        private void MapToVerteltas(VerteltasViewModel vvm, Verteltas verteltas)
        {
            verteltas.Beschikbaar = vvm.Beschikbaar;
            verteltas.Beschrijving = vvm.Beschrijving;
            verteltas.Categories = vvm.Categories;
            verteltas.Leeftijd = vvm.Leeftijd;
            foreach (Item item in vvm.Items)
            {
                verteltas.Items.Add(item);
            }
        }
    }
}