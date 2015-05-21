using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrekelSchool.Models.Domain1
{
    public class VoorlopigeUitlening
    {
        public Lener VoorlopigeLener { get; set; }
        public Item VoorlopigItem { get; set; }

        public VoorlopigeUitlening()
        {
            
        }

        public void KiesItem(Item item)
        {
            VoorlopigItem = item;
        }

        public void KiesLener(Lener lener)
        {
            VoorlopigeLener = lener;
        }

        public void Clear()
        {
            VoorlopigeLener = null;
            VoorlopigItem = null;
        }
    }
}