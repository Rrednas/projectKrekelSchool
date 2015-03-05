using System.Collections.Generic;

namespace KrekelSchool.Models.Domain1
{
    public class Cd : KrekelSchool.Item
    {
        public int Size { get; set; }

        public Cd(string id, string naam, int beschikbaar, string beschrijving, int size)
            : base(id, naam, beschikbaar, beschrijving)
        {
            Size = size;
        }

        public Cd()
        {
            
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
