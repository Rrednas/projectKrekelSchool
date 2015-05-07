using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class ItemScreenViewModel
    {
        public VoorlopigeUitleningViewModel Voorlopige { get; set; }
        public IEnumerable<BoekViewModel> Boeken { get; set; }
        public IEnumerable<CdViewModel> Cds { get; set; }
        public IEnumerable<DvdViewModel> Dvds { get; set; }
        public IEnumerable<SpelViewModel> Spellen { get; set; }
        public IEnumerable<VerteltasViewModel> Verteltassen { get; set; }
        public User User { get; set; }

        public ItemScreenViewModel(VoorlopigeUitlening voorlopige , IEnumerable<BoekViewModel> boek,User user)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem,voorlopige.VoorlopigeLener);
            Boeken = boek;
            User = user;
        }
        
        public ItemScreenViewModel(VoorlopigeUitlening voorlopige, IEnumerable<DvdViewModel> items)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem, voorlopige.VoorlopigeLener);
            Dvds = items;
        }
        public ItemScreenViewModel(VoorlopigeUitlening voorlopige, IEnumerable<CdViewModel> items)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem, voorlopige.VoorlopigeLener);
            Cds = items;
        }
        public ItemScreenViewModel(VoorlopigeUitlening voorlopige, IEnumerable<SpelViewModel> items)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem, voorlopige.VoorlopigeLener);
            Spellen = items;
        }
        public ItemScreenViewModel(VoorlopigeUitlening voorlopige, IEnumerable<VerteltasViewModel> items)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem, voorlopige.VoorlopigeLener);
            Verteltassen = items;
        }
       
    }
}