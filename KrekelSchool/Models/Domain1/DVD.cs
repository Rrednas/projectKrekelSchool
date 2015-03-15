using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Dvd : KrekelSchool.Item
    {
        public int Size { get; set; }

        public Dvd( string naam, bool beschikbaar,int aantalBeschikbaar, string beschrijving,int leeftijd, int size) : base(naam, beschikbaar, aantalBeschikbaar, beschrijving, leeftijd)
        {
            Size = size;
        }

        public Dvd()
        {
            
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
