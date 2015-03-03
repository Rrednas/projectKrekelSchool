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

        public void EditUitlening(Uitlening uitlening)
        {
            // Remove add = edit?
            // removeUitlening(uitlening);
           
        }

        public void RemoveUitlening(Uitlening uitlening)
        {
            repos.Delete(uitlening);
        }

        public Uitlening GetUitlening()
        {
            throw new System.NotImplementedException();
        }

        public Collection<Uitlening> GetUitleningen()
        {
            throw new System.NotImplementedException();
        }

        public void CheckOutUitlening(Uitlening uitlening)
        {
            // uitleningeinddatum < huidigeDatum => Boete 
            // schade Claim => Boete (laag, hoge claim)
            // UitleningeindDatum > huidige datum => No problem check that shit out
            throw new System.NotImplementedException();
        }

        public void AddUitlening(Leerling leerling, DateTime uitlendatum, Collection<Item> items)
        {
            
            throw new System.NotImplementedException();
        }
    }
}