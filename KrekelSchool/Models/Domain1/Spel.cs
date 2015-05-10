using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : Item
    {
       
        public Spel( string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, IEnumerable<Categorie> categories) : base( naam, beschikbaar, beschrijving, leeftijd, imgUrl, categories)
        {
        }

        public Spel(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, Categorie categorie)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl, categorie)
        {
        }

        public Spel(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
        }


        public Spel():base()
        {
        }
    }
}
