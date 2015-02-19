using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Leerling
    {
        public System.Collections.ObjectModel.Collection<Uitlening> Uitleningen { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int ID { get; set; }
        }
}
