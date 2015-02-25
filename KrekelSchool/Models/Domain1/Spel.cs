using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {
        public Spel(int id, Soort soort, string naam, int beschikbaar, string beschrijving)
            : base(id, soort, naam, beschikbaar, beschrijving)
        {
        }

        public Spel(Soort soort, string naam, int beschikbaar, string beschrijving)
            : base(soort,naam, beschikbaar, beschrijving)
        {
            

        }

        
    }
}
