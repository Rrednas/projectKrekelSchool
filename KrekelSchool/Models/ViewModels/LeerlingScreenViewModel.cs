using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class LeerlingScreenViewModel
    {
        public VoorlopigeUitleningViewModel Voorlopige { get; set; }
        public IEnumerable<LeerlingViewModel> Leners { get; set; }

        public LeerlingScreenViewModel(VoorlopigeUitlening voorlopige , IEnumerable<LeerlingViewModel> obj)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem,voorlopige.VoorlopigeLener);
            Leners = obj;
        }
    }
}