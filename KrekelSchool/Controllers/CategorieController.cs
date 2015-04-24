using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

namespace KrekelSchool.Controllers
{
    public class CategorieController : Controller
    {
        private IMediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;
        public CategorieController(IMediatheekRepository repository)
        {
            MediatheekRepository = repository;
            Mediatheek = MediatheekRepository.GetMediatheek();
        }
        // GET: Categorie
        public ActionResult Index(string zoek)
        {
            IEnumerable<Categorie>categories = Mediatheek.Categories.OrderBy(l => l.Beschrijving);
            IEnumerable<CategorieViewModel> cvm = categories.Select(l => new CategorieViewModel(l)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                cvm = cvm.Where(s => s.Beschrijving.ToLower().Contains(zoek.ToLower()) ||
                    s.Id.ToString().Contains(zoek.ToLower()) 
                    );
            }
            return View(cvm);
        }
        #region Leerling Toevoegen
        [HttpGet]
        public ActionResult CategorieToevoegen()
        {
            Categorie cat = new Categorie();
            ViewBag.Title = "Categorie toevoegen";
            return PartialView(new CategorieViewModel(cat));
        }

        [HttpPost]
        public ActionResult CategorieToevoegen(CategorieViewModel cvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categorie cat = new Categorie();
                    MapToCategorie(cvm, cat);
                    Mediatheek.VoegCategorieToe(cat);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", cat.Beschrijving);
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
            return PartialView(cvm);
        }
        #endregion


        [HttpGet]
        public ActionResult CategorieAanpassen(int id)
        {
            Categorie cat = Mediatheek.Categories.First(l => l.Id == id);
            if (cat == null)
                return HttpNotFound();
            ViewBag.Title = "Categorien aanpassen";
            return PartialView("CategorieToevoegen", new CategorieViewModel(cat));
        }

        [HttpPost]
        public ActionResult CategorieAanpassen(int id, CategorieViewModel cvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categorie cat = Mediatheek.Categories.First(l => l.Id == id);
                    MapToCategorie(cvm, cat);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", cat.Beschrijving);
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
            return PartialView("CategorieToevoegen", cvm);
        }

        [HttpGet]
        public ActionResult CategorieVerwijderen(int id)
        {
            Categorie cat = Mediatheek.Categories.First(l => l.Id == id);
            if (cat == null)
                return HttpNotFound();
            ViewBag.Title = "Categorie verwijderen";
            return PartialView(new CategorieViewModel(cat));
        }

        [HttpPost, ActionName("CategorieVerwijderen")]
        public ActionResult CategorieVerwijderenBevestig(int id)
        {
            try
            {
                Categorie cat = Mediatheek.Categories.First(l => l.Id == id);
                if (cat == null)
                    return HttpNotFound();
                Mediatheek.VerwijderCategorie(cat);
                MediatheekRepository.SaveChanges();
                ViewBag.Title = "Leerling verwijderen";
                TempData["Message"] = String.Format("{0} werd verwijderd!", cat.Beschrijving);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van categorie mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Index");
        }

        private void MapToCategorie(CategorieViewModel cvm, Categorie cat)
        {
            cat.Beschrijving = cvm.Beschrijving;
        }
    }
 }
