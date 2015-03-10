using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

namespace KrekelSchool
{
    public class UitleningController: Controller
    {
        private IUitleningenRepository repos;

        public UitleningController(KrekelSchoolContext context)
        {
            repos = new UitleningRepository(context);
        }

        //public View Index()
        //{
        //    return View;
        //}
        //public ActionResult Create()
        //{
        //    return PartialView(new UitleningViewModel(new Uitlening()));
        //}



        //[HttpPost]
        //public ActionResult Create(UitleningViewModel uitleningVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //try
        //        //{
        //        //    Uitlening uitlening = new Uitlening();

        //        //}
        //    }
        //}
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
            // Item schade op geclaimde schade.
            // UitleningeindDatum > huidige datum => No problem check that shit out
            // beschikbaar van item op true
            // 
            throw new System.NotImplementedException();
        }

        public void AddUitlening(Lener leerling, DateTime tot, Item item)
        {

            //item word op onbeschikbaar gezet
            var itemController = new ItemController();
            var nieuwItem = itemController.WordUitgeleend(item);
            //uitelning word aangemaakt met nieuw Uitgeleend item
            var uitlening = new Uitlening(nieuwItem, tot);
            //uitlening word toegevoegd
            repos.Add(uitlening);
            repos.SaveChanges();
            //uitlening word gekoppeld aan lener
            var leerlingController = new LeerlingController();
            leerlingController.KenLeningToeAan(leerling,uitlening);
            
            
            //Kinderboeken 1 week , andere 2 weken (Kijken op leeftijd) navragen
            //item beschikbaar false done
            //uitlening toevoegen aan leerling done

            
        }

        
    }
}