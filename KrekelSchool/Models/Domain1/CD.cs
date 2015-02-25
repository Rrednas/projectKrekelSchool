using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Cd : KrekelSchool.Item
    {
        public int Size { get; set; }

        public Cd() : base()
        {
            
        }
        public Cd(string id, Soort soort, string naam, int beschikbaar, string beschrijving, int size)
            : base(id, soort, naam, beschikbaar, beschrijving)
        {
            Size = size;
        }

        public Cd(Soort soort, string naam, int beschikbaar, string beschrijving, int size)
            : base(soort, naam, beschikbaar, beschrijving)
        {
            Size = size;
        }

       
    }
}
