﻿using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class ItemController : Controller
    {
        public Collection<Iitem> Items
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void addItem(string naam, string beschrijving, bool beschikbaar)
        {
            throw new System.NotImplementedException();
        }

        public Collection<Iitem> getItems()
        {
            throw new System.NotImplementedException();
        }

        public void removeItem(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void editItem(int ID)
        {
            throw new System.NotImplementedException();
        }

        public Iitem getItem()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Item()
        {
            ViewBag.Message = "Item scherm.";

            return View();
        }
        public ActionResult AdminScreen()
        {
            ViewBag.Message = "Adminiostratie scherm.";

            return View();
        }
    }
}