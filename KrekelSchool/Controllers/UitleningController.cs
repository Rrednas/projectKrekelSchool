using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Drawing.Design;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class UitleningController
    {
        private IUitleningenRepository repos;

        public UitleningController(KrekelSchoolContext context)
        {
            repos = new UitleningRepository(context);
        }
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

        public void removeUitlening(Uitlening uitlening)
        {
            repos.Delete(uitlening);
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

        public void addUitlening(Leerling leerling, DateTime uitlendatum, Collection<Item> items)
        {
            throw new System.NotImplementedException();
        }
    }
}