using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class LeerlingController
    {
        public Collection<Leerling> Leerlingen
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void addLeerling(string naam, string voornaam)
        {
            throw new System.NotImplementedException();
        }

        public Leerling getLeerling()
        {
            throw new System.NotImplementedException();
        }

        public Collection<Leerling>  getLeerlingen()
        {
            throw new System.NotImplementedException();
        }

        public void editLeerling(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void removeLeerling(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}
