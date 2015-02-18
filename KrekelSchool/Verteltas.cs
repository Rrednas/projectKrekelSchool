using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

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
        public bool Beschikbaar { get; set; }
    }
}
