﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class ItemController : Controller
    {
        public List<Item> Items = new List<Item>();
        ItemRepository repository=new ItemRepository(Context);
        public static KrekelSchoolContext Context = new KrekelSchoolContext();

        public void AddItem(string naam, string beschrijving, int beschikbaar)
        {
            using (Context = new KrekelSchoolContext())
            {
                Context.Items.Create();
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
          //  ViewBag.Message = "Geef ID, naam in als zoekcriteria.";
         //   Items.AddRange(Context.Cds);
            var model = Items;

            return View(model);
        }

        

    }
}