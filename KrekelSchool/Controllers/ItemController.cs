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
        private ItemRepository repository;
        public static KrekelSchoolContext context = new KrekelSchoolContext();

        public ItemController()
        {
            
        }
        #region methods

        public Item WordUitgeleend(Item item)
        {
            repository.FindBy(item.Id).WordUitgeleend();
            repository.SaveChanges();
            return repository.FindBy(item.Id);
        }

        public void WordTerugGebracht(Item item)
        {
            repository.FindBy(item.Id).WordTerugGebracht();
            repository.SaveChanges();
            
        }
        #endregion
        public void addItem(string naam, string beschrijving, bool beschikbaar)
        {
            using (context = new KrekelSchoolContext())
            {
                context.Items.Create();
            }
        }

        public List<Item> getItems()
        {
            return Items;
        }

        public void removeItem(int ID)
        {
            Items.RemoveAt(ID);
        }

        public void EditItem(Item item)
        {
            Items.Find(i =>i.Id.Equals(item.Id));
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
            repository = new ItemRepository(context,id);
            ViewBag.Title = id + "-Lijst";
            ViewBag.Message = "Geef ID, naam in als zoekcriteria.";
            
            var model = repository.FindAll();
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