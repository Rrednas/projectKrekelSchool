using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {
        public Spel(int id, string naam, int beschikbaar, string beschrijving) : base(id, naam, beschikbaar, beschrijving)
        {
        }

        public Spel(string naam, int beschikbaar, string beschrijving)
            : base(naam, beschikbaar, beschrijving)
        {
            

        }

        
    }
}
