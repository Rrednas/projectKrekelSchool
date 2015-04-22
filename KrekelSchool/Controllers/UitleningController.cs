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
        private MediatheekRepository MediatheekRepository;
        private Mediatheek mediatheek;

        public UitleningController(MediatheekRepository repos)
        {
            MediatheekRepository = repos;

            mediatheek = repos.GetMediatheek();
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
        

      

       
        public void CheckOutUitlening(Uitlening uitlening)
        {
            
            // 
            throw new System.NotImplementedException();
        }

        public void AddUitlening(Lener leerling, DateTime tot, Item item)
        {

            //item word op onbeschikbaar gezet

            
           // var lener = lenerrepos.FindBy(leerling.Id);
            //uitelning word aangemaakt met nieuw Uitgeleend item
           // var uitlening = mediatheek.VoegUitleningToe(lener, tot,nieuwItem);
            //uitlening word toegevoegd
          //  repos.Add(uitlening);
          //  repos.SaveChanges();
           
            //uitlening word gekoppeld aan lener    
           // mediatheek.LeenUitAan(lener, uitlening);
            //lenerrepos.SaveChanges();


            
            
            //Kinderboeken 1 week , andere 2 weken (Kijken op leeftijd) navragen
            //item beschikbaar false done
            //uitlening toevoegen aan leerling done
            

        }

        
    }
}