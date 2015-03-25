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
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

namespace KrekelSchool
{
    public class LeerlingController : Controller
    {
        private ILeerlingRepository LeerlingRepository;

        private LeerlingController(ILeerlingRepository leerlinRepositry)
        {
            LeerlingRepository = leerlinRepositry;
        }

        //#region methods

        //public void KenLeningToeAan(Lener lener,Uitlening uitlening)
        //{   
        //    repos.FindBy(lener.Id).KrijgLening(uitlening);
        //    repos.SaveChanges();
        //}
        //#endregion

        //public void AddLeerling(Lener leerling)
        //{
        //    repos.Add(leerling);
        //    repos.SaveChanges();
        //}

        //public Lener getLeerling()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public List<Lener>  GetLeerlingen()
        //{
        //    return repos.FindAll().ToList();
        //}

        //public void EditLeerling(Lener leerling)
        //{
        //    RemoveLeerling(repos.FindBy(leerling.Id));
        //    AddLeerling(leerling);
        //}

        //public void RemoveLeerling(Lener leerling)
        //{
        //    repos.Delete(leerling);
        //}

        public ActionResult LenerEnUitlening()
        {
            ViewBag.Message = "Selecteer Lener of Uitlening";

            return View();
        }

        public ActionResult Leerling()
        {
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";
            IEnumerable<Lener> leerlingen = LeerlingRepository.FindAll().OrderBy(l => l.Naam);
            IEnumerable<LeerlingViewModel> lvm = leerlingen.Select(l => new LeerlingViewModel(l)).ToList();
            return View(lvm);
        }

        public ActionResult LeerlingDetail(int id)
        {
            Lener leerling = LeerlingRepository.FindBy(id);
            if (leerling == null)
                return HttpNotFound();
            ViewBag.Title = "Details van " + leerling.Naam;
            return PartialView(new LeerlingViewModel(leerling));
        }

        #region Leerling Toevoegen
        [HttpGet]
        public ActionResult LeerlingToevoegen()
        {
            Lener leerling = new Lener();
            ViewBag.Title = "Leerling toevoegen";
            return PartialView(new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult LeerlingToevoegen(LeerlingViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lener leerling = new Lener();
                    MapToLeerling(lvm, leerling);
                    LeerlingRepository.Add(leerling);
                    LeerlingRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", leerling.Naam);
                    return RedirectToAction("Leerling");
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
            return PartialView(lvm);
        }
        #endregion


        [HttpGet]
        public ActionResult LeerlingAanpassen(int id)
        {
            Lener leerling = LeerlingRepository.FindBy(id);
            if (leerling == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + leerling.Naam + " aanpassen";
            return PartialView("LeerlingToevoegen", new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult LeerlingAanpassen(int id, LeerlingViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lener leerling = LeerlingRepository.FindBy(id);
                    MapToLeerling(lvm, leerling);
                    LeerlingRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", leerling.Naam);
                    return RedirectToAction("Leerling");
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
            return PartialView("LeerlingToevoegen", lvm);
        }

        [HttpGet]
        public ActionResult LeerlingVerwijderen(int id)
        {
            Boek boek = BoekRepository.FindBy(id);
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
                Lener leerling = LeerlingRepository.FindBy(id);
                if (leerling == null)
                    return HttpNotFound();
                LeerlingRepository.Delete(leerling);
                LeerlingRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", leerling.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van boek mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Leerling");
        }

        private void MapToLeerling(LeerlingViewModel lvm, Lener leerling)
        {
            leerling.Naam = lvm.Naam;
            leerling.Voornaam = lvm.Voornaam;
        }
    }
}
