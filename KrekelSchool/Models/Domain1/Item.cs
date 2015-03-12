using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public abstract class Item
    {
        protected Item(int id, string naam, bool beschikbaar, string beschrijving)
        {
            Id = id;
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
        }

        protected Item()
        {

        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public bool Beschikbaar { get; set; }
        public string Beschrijving { get; set; }
        #region methods

       
        public void WordUitgeleend()
        {
            if (!Beschikbaar)
            {
                throw new ApplicationException("Item is al uitgeleend");
            }
            else
            {
                Beschikbaar = false;
            }
        }
#endregion
    }
}
