using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using KrekelSchool.Controllers;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using Microsoft.Ajax.Utilities;

namespace KrekelSchool
{
    public class Mediatheek
    {
        
        
#region Collections
        public static ICollection<Item> Items { get; set; }
        public static ICollection<Uitlening> Uitleningen { get; set; }
        public ICollection<Categorie> Categories { get; set; }
        public ICollection<Lener> Leners { get; set; }
        public ICollection<Gebruiker> Gebruikers { get; set; }
#endregion

        public Mediatheek()
        {
            
            Uitleningen = new List<Uitlening>();
            Items = new List<Item>();
            Categories = new List<Categorie>();
            Leners= new List<Lener>();
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
        public void VerwijderUitlening() { }
        

        public void AanpassenUitlening() { }
        #endregion
        #region Item
        public void AanpassenItem() { }
         public void VoegItemToe() { }

         public void VerwijderItem() { }

        public Item LeenItemUit(Item item)
        {
            Item uitgeleendItem = Items.First(i => i.Id == item.Id);
                uitgeleendItem.WordUitgeleend();
            return uitgeleendItem;
            

        }
        

        #endregion
        #region categories
        public void AanpassenCategorie() { }
        public void VerwijderCategorie() { }
        public void VoegCategorieToe() { }
        #endregion

        #region Lener
        public void VoegLenerToe() { }
        
        public void AanpassenLener() { }
        public void VerwijderLener() { }
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

        

        #endregion


    }
}
