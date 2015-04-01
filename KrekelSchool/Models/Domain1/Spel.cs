using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {

        public Spel( string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl) : base( naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
        }

        public Spel():base()
        {
        }
    }
}
