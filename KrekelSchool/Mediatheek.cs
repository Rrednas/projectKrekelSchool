using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class Mediatheek
    {
#region Collections
        public ICollection<Item> Items { get; set; }
        public ICollection<Uitlening> Uitleningen { get; set; }
        public ICollection<Categorie> Categories { get; set; }
        public ICollection<Lener> Leners { get; set; }
        public ICollection<Gebruiker> Gebruikers { get; set; }
#endregion

        
#region methods
        #region Toevoegen
        public void VoegItemToe() { }
        public void VoegUitleningToe() { }
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
#endregion


    }
}
