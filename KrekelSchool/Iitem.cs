using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public interface Iitem
    {
        int ID
        {
            get;
            set;
        }

        string Naam
        {
            get;
            set;
        }

        string Beschrijving
        {
            get;
            set;
        }

        int Beschikbaar
        {
            get;
             set;
        }

        Categorie Categorie
        {
            get;
            set;
        }
    }
}
