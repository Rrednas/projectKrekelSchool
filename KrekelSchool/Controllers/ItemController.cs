using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.UI;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class ItemController : Controller
    {
        public List<Item> Items = new List<Item>();
        public static KrekelSchoolContext Context = new KrekelSchoolContext();
        private ItemRepository Repository;
        private ItemViewModel vm;

        public ActionResult Item()
        {
            ViewBag.Message = "Klik op het gewenste item om deze te bewerken of te verwijderen.";

            return View();
        }
        public ActionResult ItemScreen(string id)
        {
            Repository = new ItemRepository(Context,id);
            ViewBag.Title = id + "-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            ViewBag.id = id;
            var model = Repository.FindAll();
            return View(model);
        }

        
        public ActionResult ItemToevoegen(string id)
        {
            Repository = new ItemRepository(Context,id);
            ViewBag.Title = id + " Toevoegen";
            ViewBag.Message = "Geef de gegevens in.";
            ViewBag.id = id;
            switch (id)
            {
                case "Boeken":
                    Boek boek = new Boek();
                    vm = new ItemViewModel(boek);
                    break;
                case "Cds":
                    Cd cd = new Cd();
                    vm = new ItemViewModel(cd);
                    break;
                case "Dvds":
                    Dvd dvd = new Dvd();
                    vm = new ItemViewModel(dvd);
                    break;
                case "Verteltassen":
                    Verteltas vt = new Verteltas();
                    vm = new ItemViewModel(vt);
                    break;
                case "Spellen":
                    Spel spel = new Spel();
                    vm = new ItemViewModel(spel);
                    break;
                default:
                    throw new Exception("geen Id meegegeven");
            }
            return PartialView(vm);
        }

        [HttpPost]
        [ActionName("Itemtoevoegen")]
        public ActionResult ItemToevoegen_post(string id)
        {
            ViewBag.id = id;
            if (ModelState.IsValid)
            {
                Repository = new ItemRepository(Context, id);
                if (id == "Boeken")
                {
                    Boek boek = new Boek();
                    Repository.Add(boek);
                    Repository.SaveChanges();
                    return RedirectToRoute("Item/ItemScreen/" + id);
                }
            }
            return PartialView("ItemToevoegen");
        }


    }
}