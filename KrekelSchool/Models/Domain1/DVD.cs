using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class DVD : Iitem
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public bool Beschikbaar { get; set; }

        int Iitem.Beschikbaar
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
