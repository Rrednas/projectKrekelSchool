using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Controllers
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

        public ActionResult UitleningScreen()
        {
            IEnumerable<Uitlening> uitleningen = mediatheek.Uitleningen.OrderBy(u => u.BeginDatum);
            return View(uitleningen);
        }
        //public ActionResult Create()
        //{
        //    return PartialView(new UitleningViewModel(new Uitlening()));
        //}
        public ActionResult UitleningPartial(VoorlopigeUitlening voorlopigeUitlening)
        {

            return PartialView(voorlopigeUitlening);
        }

        public Action KiesLener(VoorlopigeUitlening voorlopigeUitlening,int id)
        {

            voorlopigeUitlening.KiesLener(mediatheek.Leners.First(l => l.Id == id));
            return null;

        }

        
        

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