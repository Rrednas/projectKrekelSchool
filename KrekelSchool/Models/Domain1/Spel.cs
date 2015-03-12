using System.Collections.Generic;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {
        public Spel(string id, string naam, bool beschikbaar, string beschrijving, int leeftijd) : base(id, naam, beschikbaar, beschrijving, leeftijd)
        {
        }

        public Spel():base()
        {  
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
