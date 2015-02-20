using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Spel : Iitem
    {
        public int ID { get; set; }
        public string Isbn { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public bool Beschikbaar { get; set; }


        public Categorie Categorie { get; set; }
    }
}
