using System.Collections.ObjectModel;

namespace KrekelSchool.Models.Domain1
{
    public class Verteltas : Iitem
    {
        public virtual Collection<Iitem> Items { get; set; }

        public int ID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int Beschikbaar { get; set; }
        public Categorie Categorie { get; set; }
    }
}
