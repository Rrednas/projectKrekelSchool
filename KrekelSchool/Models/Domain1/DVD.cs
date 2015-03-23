using System.Collections.Generic;

namespace KrekelSchool.Models.Domain1
{
    public class Dvd : KrekelSchool.Item
    {
        public int Size { get; set; }

        public Dvd(int id, string naam, bool beschikbaar, string beschrijving, int size) : base(id, naam, beschikbaar, beschrijving)
        {
            Size = size;
        }

        public Dvd()
        {
            
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
