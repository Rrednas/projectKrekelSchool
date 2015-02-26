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
        private KrekelSchoolContext context = new KrekelSchoolContext();

        public void addItem(string naam, string beschrijving, bool beschikbaar)
        {
            throw new System.NotImplementedException();
        }

        public Collection<Item> getItems()
        {
            throw new System.NotImplementedException();
        }

        public void removeItem(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void editItem(string id)
        {
            Items.Find(i =>i.Id.Equals(id));
        }

        public Item getItem()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Item()
        {
            ViewBag.Message = "Klik op het gewenste item om deze te bewerken of te verwijderen.";

            return View();
        }
        public ActionResult ItemScreen( string id)
        {
            
            ViewBag.Message = "Geef ID, naam in als zoekcriteria.";
            switch (id)
            {
                case "Boeken": 
                    Items.AddRange(context.Boeken);
                    break;
                case "Cds":
                    Items.AddRange(context.Cds);
                    break;
                case "Dvds":
                    Items.AddRange(context.Dvds);
                    break;
                case "Verteltassen":
                    Items.AddRange(context.Verteltassen);
                    break;
                case "Spellen":
                    Items.AddRange(context.Spellen);
                    break;
                default:
                    throw new Exception("geen Id meegegeven");
            }
            
            var model = Items;
            return View(model);
        }

        

        public ActionResult ItemAanpassen()
        {
            return PartialView("ItemAanpassen");
        }

        [HttpPost]
        public ActionResult ReturnItemScreen()
        {
            return RedirectToAction("ItemScreen");
        }
    }
}