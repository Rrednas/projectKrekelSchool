using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {
        public Spel( string naam, bool beschikbaar, int aantalBeschikbaar, string beschrijving, int leeftijd) : base( naam, beschikbaar, aantalBeschikbaar, beschrijving, leeftijd)
        {
        }

        public Spel():base()
        {  
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
