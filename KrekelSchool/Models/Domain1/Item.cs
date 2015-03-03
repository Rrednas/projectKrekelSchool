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
        protected Item( string id , string naam , int beschikbaar , string beschrijving, int leeftijd)
        {
            Id = id;
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
            Leeftijd = leeftijd;
        }

        protected Item()
        {
            
        }
        public string Id { get; set; }
        public string Naam { get; set; }
        public int Beschikbaar { get; set; }
        public string Beschrijving { get; set; }
        public int Leeftijd { get; private set; }
    }
}
