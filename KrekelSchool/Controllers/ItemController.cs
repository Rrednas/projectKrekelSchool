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
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class ItemController : Controller
    {
        public List<Item> Items = new List<Item>();
        public static KrekelSchoolContext Context = new KrekelSchoolContext();
        private ItemRepository Repository;


        public ActionResult Item()
        {
            ViewBag.Message = "Klik op het gewenste item om deze te bewerken of te verwijderen.";

            return View();
        }
        public ActionResult ItemScreen( string id)
        {
            Repository = new ItemRepository(Context,id);
            ViewBag.Title = id + "-Lijst";
            ViewBag.Message = "Geef ID, naam in als zoekcriteria.";
            
            var model = Repository.FindAll();
            return View(model);
        }
        

        public ActionResult ItemAanpassen()
        {
            return PartialView("ItemAanpassen");
        }

        public ActionResult ItemToevoegen()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Itemtoevoegen(Boek item, string id)
        {
            Repository = new ItemRepository(Context, id);
           
            Repository.Add(item);
            Repository.SaveChanges();
            TempData["message"] = String.Format("Brouwer {0} werd gecreëerd", item.Naam);
            return RedirectToAction("ItemScreen");
        }

        [HttpPost]
        public ActionResult ReturnItemScreen()
        {
            return RedirectToAction("ItemScreen");
        }

    }
}