﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using KrekelSchool.Controllers;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;

namespace KrekelSchool
{
    public class Mediatheek
    {
        public int Id { get; set; }
        
#region Collections
     //   public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Boek> Boeks { get; set; }
        public virtual ICollection<CD> Cds { get; set; }
        public virtual ICollection<DVD> Dvds { get; set; }
        public virtual ICollection<Verteltas> Verteltass { get; set; }
        public virtual ICollection<Spel> Spels{ get; set; } 
        public virtual ICollection<Uitlening> Uitleningen { get; set; }
        public virtual ICollection<Categorie> Categories { get; set; }
        public virtual ICollection<Lener> Leners { get; set; }
        public virtual ICollection<Gebruiker> Gebruikers { get; set; }
#endregion

        public Mediatheek()
        {
            Cds = new List<CD>();
            Dvds = new List<DVD>();
            Spels = new List<Spel>();
            Verteltass = new List<Verteltas>();
            Boeks = new List<Boek>();
            Uitleningen = new List<Uitlening>();
            //Items = new List<Item>();
            Categories = new List<Categorie>();
            Leners = new List<Lener>();
            Gebruikers = new List<Gebruiker>();

            
        }
        
#region methods
        #region Uitlening
       

        public Uitlening VoegUitleningToe(Lener l , DateTime eindTijd,Item i)
        {
            if (!MagUitlenen(l))
                throw new ApplicationException("Lener heeft maximum uitleningen bereikt");
            Uitlening nieuweUitlening = new Uitlening(i, eindTijd);
            if(Uitleningen.Contains(nieuweUitlening))
                throw new ApplicationException("Uitlening bestaat al");
                    
                    Uitleningen.Add(nieuweUitlening);
            return nieuweUitlening;
            //l.Uitleningen.Add(nieuweUitlening);
            //niet hier
            //i.Beschikbaar = false;


        }

        public void VerwijderUitlening(Uitlening uitlening)
        {
            Uitleningen.Remove(uitlening);
        }
        

        public void AanpassenUitlening() { }
        #endregion
        #region Item
        public void AanpassenItem() { }

        public ICollection<Boek> FindListFor(Item item)
        {  
         
            //var meh=GetType().GetField(typeof (Item)+"s");
            //return (ICollection<Item>) Boeks;
            return Boeks;

        } 
        public void VoegBoekToe(Boek boek)
        {

            Boeks.Add(boek);

        }

         public void VerwijderItem() { }

        public Item LeenItemUit(Item item)
        {
            Item uitgeleendItem = FindListFor(item).First(i => i.Id == item.Id);
                uitgeleendItem.WordUitgeleend();
            return uitgeleendItem;
            

        }
        

        #endregion
        #region categories

        public void AanpassenCategorie(Categorie categorie)
        {
          
        }

        public void VerwijderCategorie(Categorie categorie)
        {
            Categories.Remove(categorie);
        }

        public void VoegCategorieToe(Categorie categorie)
        {
            Categories.Add(categorie);
        }
        #endregion

        #region Lener

        public void VoegLenerToe(Lener lener    )
        {
            Leners.Add(lener);
        }
        
        public void AanpassenLener() { }

        public void VerwijderLener(Lener lener)
        {
            Leners.Remove(lener);
        }
        public static bool MagUitlenen(Lener l)
        {
            if(!(l.Uitleningen.Count < 3 )) throw new ApplicationException("Lener heeft maximum uitleningen  bereikt");
            return true;
        }

        public Lener LeenUitAan(Lener lener,Uitlening uitlening)
        {
            var aangepastelener = Leners.First(l => l.Id == lener.Id);
            aangepastelener.KrijgLening(uitlening);
            return aangepastelener;
        }
        #endregion
        #region gebruiker
        public void VerwijderGebruiker() { }
        public void VoegGebruikerToe() { }
        public void AanpassenGebruiker() { }
        #endregion
        #region SpecialFinds
        public ICollection<Item> FindAllItemsOf(String type)
        {
            return null;
        }

        public ICollection<Item> FindAllBeschikbareItemsOf()
        {
            return null;
        }

        public ICollection<Item> FindAllItemsBy(string search)
        {
            return null;
        }

        public ICollection<Uitlening> FindAllUitleningenBy(string search)
        {
            return null;
        }
        #endregion

        public bool LenerBestaat(string vnaam, string naam)
        {
            bool bestaat=false;
            foreach(Lener lener in Leners)
            {
                if (lener.Voornaam == vnaam && lener.Naam == naam)
                {
                    bestaat = true;
                }
                
            }
            
            return bestaat;
        }
        #endregion

        


    }
}
