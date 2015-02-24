using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class UitleningController
    {
        public Collection<Uitlening> Uitleningen
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void editUitlening(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void removeUitlening(int ID)
        {
            throw new System.NotImplementedException();
        }

        public Uitlening getUitlening()
        {
            throw new System.NotImplementedException();
        }

        public Collection<Uitlening> getUitleningen()
        {
            throw new System.NotImplementedException();
        }

        public void checkOutUitlening(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void addUitlening(Leerling leerling, DateTime uitlendatum, Collection<Iitem> items)
        {
            throw new System.NotImplementedException();
        }
    }
}