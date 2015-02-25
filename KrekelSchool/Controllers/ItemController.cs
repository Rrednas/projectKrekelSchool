using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class ItemController : Controller
    {
        public Collection<Item> Items = new Collection<Item>();

        public void addItem(string naam, string beschrijving, bool beschikbaar)
        {
            Items.Add(new Item() { Naam = naam, Beschrijving = beschrijving, Beschikbaar = beschikbaar});
        }

        public Collection<Item> getItems()
        {
            return Items;
        }

        public void removeItem(int ID)
        {
            Items.RemoveAt(ID);
        }

        public void editItem(int ID)
        {
            throw new System.NotImplementedException();
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
        public ActionResult ItemScreen()
        {
            ViewBag.Message = "Geef ID, naam in als zoekcriteria.";

            var model = Items;

            return View(model);
        }

    }
}