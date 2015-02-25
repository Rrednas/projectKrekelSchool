using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Cd : KrekelSchool.Item
    {
        public int Size { get; set; }
        public Cd(int id, string naam, int beschikbaar, string beschrijving,int size) : base(id,naam, beschikbaar, beschrijving)
        {
            Size = size;
            id = id + 1;
        }

        public Cd(string naam, int beschikbaar, string beschrijving,int size) : base(naam,beschikbaar,beschrijving)
        {
            Size = size;
        }

       
    }
}
