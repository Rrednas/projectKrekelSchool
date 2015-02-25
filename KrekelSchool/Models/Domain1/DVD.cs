

using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Dvd : KrekelSchool.Item
    {
        public int Size { get; set; }
        public Dvd(int id, Soort soort, string naam, int beschikbaar, string beschrijving)
            : base(id, soort,naam, beschikbaar, beschrijving)
        {
        }

        public Dvd(Soort soort, string naam, int beschikbaar, string beschrijving, int size)
            : base(soort,naam, beschikbaar, beschrijving)
        {
            Size = size;
        }

       
    }
}
