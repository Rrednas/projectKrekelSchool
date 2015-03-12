using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using Microsoft.Ajax.Utilities;

namespace KrekelSchool
{
    public class Mediatheek
    {
        private UitleningRepository UitleningRepository { get; set; }
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
            ;
        }
        
#region methods
        #region Toevoegen
        public void VoegItemToe() { }

        public static void VoegUitleningToe(Lener l , DateTime eindTijd,Item i)
        {
            if (!MagUitlenen(l))
                throw new ApplicationException("Lener heeft maximum uitleningen bereikt");
            Uitlening nieuweUitlening = new Uitlening(i, eindTijd);
            if(Uitleningen.Contains(nieuweUitlening))
                throw new ApplicationException("Uitlening bestaat al");
                    
                    Uitleningen.Add(nieuweUitlening);
                    //niet hier
                    //l.Uitleningen.Add(nieuweUitlening);
                    //niet hier
                    //i.Beschikbaar = false;


        }   
        public void VoegLenerToe() { }
        public void VoegGebruikerToe() { }
        public void VoegCategorieToe() { }
        #endregion
        #region Aanpassen
        public void AanpassenItem() { }
        public void AanpassenUitlening() { }
        public void AanpassenLener() { }
        public void AanpassenGebruiker() { }
        public void AanpassenCategorie() { }
        #endregion
        #region Verwijderen
        public void VerwijderItem() { }
        public void VerwijderUitlening() { }
        public void VerwijderLener() { }
        public void VerwijderGebruiker() { }
        public void VerwijderCategorie() { }
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

        public static bool MagUitlenen(Lener l)
        {
            if(!(l.Uitleningen.Count < 3 )) throw new ApplicationException("Lener heeft maximum uitleningen  bereikt");
            return true;
        }

        #endregion


    }
}
