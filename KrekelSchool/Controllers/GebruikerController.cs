using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class GebruikerController
    {
        public Collection<Gebruiker> Gebruikers
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void addGebruiker(bool admin, string naam, string voornaam, string email)
        {
            throw new System.NotImplementedException();
        }

        public void editGebruiker(int ID)
        {
            throw new System.NotImplementedException();
        }

        public Gebruiker getGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public Collection<Gebruiker> getGebruikers()
        {
            throw new System.NotImplementedException();
        }

        public void removeGerbuiker(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}
