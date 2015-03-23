using System.Collections.Generic;

namespace KrekelSchool.Models.Domain1
{
    public class Cd : KrekelSchool.Item
    {
        public int Size { get; set; }

        public Cd(int id, string naam, bool beschikbaar, string beschrijving, int size)
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
