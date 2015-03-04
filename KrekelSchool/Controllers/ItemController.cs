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
        private ItemRepository repository;
        public static KrekelSchoolContext context = new KrekelSchoolContext();

        //public void addItem(Item item)
        //{
        //    using (context = new KrekelSchoolContext())
        //    {
        //        context.Items.Create();
        //    }
        //}

        //public List<Item> getItems()
        //{
        //    return Items;
        //}

        //public void removeItem(int ID)
        //{
        //    Items.RemoveAt(ID);
        //}

        //public void editItem(string id)
        //{
        //    Items.Find(i =>i.Id.Equals(id));
        //}

        //public Item getItem()
        //{
        //    throw new System.NotImplementedException();
        //}

        public ActionResult Item()
        {
            ViewBag.Message = "Klik op het gewenste item om deze te bewerken of te verwijderen.";

            return View();
        }

        public ActionResult ItemScreen(string id)
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

        public ActionResult ItemToevoegen()
        {
            return View(new BoekViewModel(new Boek()));
        }

        [HttpPost]
        public ActionResult ItemToevoegen(BoekViewModel bvm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Boek boek = new Boek(bvm.Id, bvm.Naam, bvm.Beschikbaar, bvm.Beschrijving, bvm.Leeftijd, bvm.Isbn, bvm.Auteur, bvm.Uitgever);
                    repository.Add(boek);
                    repository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", boek.Naam);
                    return RedirectToAction("ItemScreen");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                
            }
            return View(bvm);
        }

        [HttpPost]
        public ActionResult ReturnItemScreen()
        {
            return RedirectToAction("ItemScreen");
        }
    }
}