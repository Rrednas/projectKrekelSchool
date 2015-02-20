using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public interface Iitem
    {
        bool Beschikbaar
        {
            get;
            set;
        }

        string Beschrijving
        {
            get;
            set;
        }

        Categorie Categorie
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string Isbn
        {
            get;
            set;
        }

        string Naam
        {
            get;
            set;
        }
    }
}