using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public abstract class Item
    {
        public Item( int id , string naam , int beschikbaar , string beschrijving)
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

        public int Beschikbaar { get; set; }
        public string Beschrijving { get; set; }
    }
}
