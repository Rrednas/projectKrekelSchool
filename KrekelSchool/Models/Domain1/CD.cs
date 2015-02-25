using System;

namespace KrekelSchool.Models.Domain1
{
    public class Cd : KrekelSchool.Item
    {
        public int Size { get; set; }
        public Cd(int id, string naam, int beschikbaar, string beschrijving,int size) : base(id, naam, beschikbaar, beschrijving)
        {
            Size = size;
        }

        public Cd(string naam, int beschikbaar, string beschrijving,int size) : base(naam,beschikbaar,beschrijving)
        {
            Size = size;
        }
        
    }
}
