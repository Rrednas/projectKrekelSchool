using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class VoorlopigeUitleningViewModel
    {
        public Item Item { get; set; }
        public Lener Lener { get; set; }

        public VoorlopigeUitleningViewModel()
        {
            
        }

        public VoorlopigeUitleningViewModel(Item item , Lener lener)
        {
            Item = item;
            Lener = lener;
        }
    }
}