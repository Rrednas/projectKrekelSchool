using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public abstract class Item
    {

        public int Id { get; set; }

        public int Naam { get; set; }

        public int Beschikbaar { get; set; }
        public int Beschrijving { get; set; }
    }
}
