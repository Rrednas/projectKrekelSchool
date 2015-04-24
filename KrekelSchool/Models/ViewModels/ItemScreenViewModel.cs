using System;
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

        public ItemScreenViewModel(VoorlopigeUitlening voorlopige , IEnumerable<BoekViewModel> boek)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem,voorlopige.VoorlopigeLener);
            Boeken = boek;
        }
    }
}