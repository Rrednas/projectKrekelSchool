using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

namespace KrekelSchool.Controllers
{
    public class UitleningController: Controller
    {
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public UitleningController(MediatheekRepository mediatheekRepository)
        {
            MediatheekRepository = mediatheekRepository;
            Mediatheek = mediatheekRepository.GetMediatheek();
        }

        public ActionResult Uitlening(string zoek)
        {
            ViewBag.Title = "Uitleningen-Lijst";
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";
            IEnumerable<Uitlening> uitleningen = Mediatheek.Uitleningen.OrderBy(u => u.Begindatum);
            IEnumerable<UitleningViewModel> uvm = uitleningen.Select(u => new UitleningViewModel(u)).ToList();

            IEnumerable<Item> items = Mediatheek.Items.OrderBy(i => i.Id);
            IEnumerable<ItemViewModel> ivm = items.Select(i => new ItemViewModel(i)).ToList();

            IEnumerable<Lener> leners = Mediatheek.Leners.OrderBy(l => l.Id);
            IEnumerable<LeerlingViewModel> lvm = leners.Select(l => new LeerlingViewModel(l)).ToList();

            if (!String.IsNullOrEmpty(zoek))
            {
                uvm = uvm.Where(u => u.Lener.Naam.ToLower().Contains(zoek.ToLower()) ||
                    u.Lener.Voornaam.ToLower().Contains(zoek.ToLower()) ||
                    u.Item.Naam.ToLower().Contains(zoek.ToLower()) ||
                    u.BeginDatum.ToString().Contains(zoek.ToLower()) ||
                    u.EindDatum.ToString().Contains(zoek.ToLower())
                    );
            }
            return View(new UitleningScreenViewModel(uvm, ivm, lvm));
        }
        
        [HttpGet]
        public ActionResult UitleningAanpassen(int id)
        {
            Uitlening uitlening = Mediatheek.Uitleningen.First(u => u.Id == id);
            if (uitlening == null)
                return HttpNotFound();
            ViewBag.Title = "Uitlening aanpassen";
            return PartialView(new UitleningViewModel(uitlening));
        }

        [HttpPost]
        public ActionResult UitleningAanpassen(int id, UitleningViewModel uvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Uitlening uitlening = Mediatheek.Uitleningen.First(u => u.Id == id);
                    MapToUitlening(uvm, uitlening);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("Uitlening met item: {0}, van {1}, {2} werd aangepast.",
                        uitlening.Item.Naam, uitlening.Lener.Naam, uitlening.Lener.Voornaam);
                    return RedirectToAction("Uitlening");
                }
            }
            catch (DbEntityValidationException dbEx)
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
            Uitlening uitleningVm = Mediatheek.Uitleningen.First(u => u.Id == id);
            return PartialView("UitleningAanpassen",uvm);
        }

        [HttpGet]
        public ActionResult UitleningVerwijderen(int id)
        {
            Uitlening uitlening = Mediatheek.Uitleningen.First(u => u.Id == id);
            if (uitlening == null)
                return HttpNotFound();
            ViewBag.Title = "Leerling verwijderen";
            return PartialView(new UitleningViewModel(uitlening));
        }

        [HttpPost, ActionName("UitleningVerwijderen")]
        public ActionResult UitleningVerwijderenBevestig(int id)
        {
            try
            {
                Uitlening uitlening = Mediatheek.Uitleningen.First(u => u.Id == id);
                if (uitlening == null)
                    return HttpNotFound();
                Mediatheek.VerwijderUitlening(uitlening);
                MediatheekRepository.SaveChanges();
                ViewBag.Title = "Uitlening verwijderen";
                TempData["Message"] = String.Format("Uitlening met item: {0}, van {1}, {2} werd verwijderd.",
                        uitlening.Item.Naam, uitlening.Lener.Naam, uitlening.Lener.Voornaam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van leerling mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Uitlening");
        }

        private void MapToUitlening(UitleningViewModel uvm, Uitlening uitlening)
        {
            uitlening.Begindatum = uvm.BeginDatum;
            uitlening.Einddatum = uvm.EindDatum;
            uitlening.Item = uvm.Item;
            uitlening.Lener = Mediatheek.Leners.First();
        }

        //public ActionResult UitleningPartial(VoorlopigeUitlening voorlopigeUitlening)
        //{

        //    return PartialView(voorlopigeUitlening);
        //}

        //public Action KiesLener(VoorlopigeUitlening voorlopigeUitlening,int id)
        //{
        //    voorlopigeUitlening.KiesLener(Mediatheek.Leners.First(l => l.Id == id));
        //    return null;
        //}

        
        

        //[HttpPost]
        //public ActionResult Create(UitleningViewModel uitleningVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //try
        //        //{
        //        //    Uitlening uitlening = new Uitlening();

        //        //}
        //    }
        //}
        

      

       
        public void CheckOutUitlening(Uitlening uitlening)
        {
            
            // 
            throw new System.NotImplementedException();
        }

        //public void AddUitlening(Lener leerling, DateTime tot, Item item)
        //{

        //    //item word op onbeschikbaar gezet

            
        //   // var lener = lenerrepos.FindBy(leerling.Id);
        //    //uitelning word aangemaakt met nieuw Uitgeleend item
        //   // var uitlening = mediatheek.VoegUitleningToe(lener, tot,nieuwItem);
        //    //uitlening word toegevoegd
        //  //  repos.Add(uitlening);
        //  //  repos.SaveChanges();
           
        //    //uitlening word gekoppeld aan lener    
        //   // mediatheek.LeenUitAan(lener, uitlening);
        //    //lenerrepos.SaveChanges();


            
            
        //    //Kinderboeken 1 week , andere 2 weken (Kijken op leeftijd) navragen
        //    //item beschikbaar false done
        //    //uitlening toevoegen aan leerling done
            

        //}

        
    }
}