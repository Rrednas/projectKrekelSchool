using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class DVD : KrekelSchool.Item
    {
        public int Size { get; set; }


        public DVD( string naam, bool beschikbaar, int totaalAantal, string beschrijving,int leeftijd, int size) : base(naam, beschikbaar, totaalAantal, beschrijving, leeftijd)
        {
            Size = size;
        }

        public DVD()
        {
            
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
