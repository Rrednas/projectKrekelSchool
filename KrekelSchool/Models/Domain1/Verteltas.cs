using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Verteltas : KrekelSchool.Item
    {
        public Verteltas(string id, Soort soort, string naam, int beschikbaar, string beschrijving)
            : base(id,soort, naam, beschikbaar, beschrijving)
        {
        }

        public Verteltas(Soort soort, string naam, int beschikbaar, string beschrijving) : base(soort, naam, beschikbaar, beschrijving) { }

       
    }
}
