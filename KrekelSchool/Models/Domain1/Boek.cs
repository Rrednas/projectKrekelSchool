using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Boek : Iitem
    {
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

        public string Isbn
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
