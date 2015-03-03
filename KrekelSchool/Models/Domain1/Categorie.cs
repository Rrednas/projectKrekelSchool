using System.Collections.ObjectModel;

namespace KrekelSchool.Models.Domain1
{
    public class Categorie
    {
        public int ID { get; set; }
        public int Beschrijving { get; set; }

        public Collection<Item> Items
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Categorie()
        {
            
        }
    }
}
