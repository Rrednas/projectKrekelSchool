using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class Verteltas : Iitem
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

        public int ID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int Beschikbaar { get; set; }


        public Categorie Categorie
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
