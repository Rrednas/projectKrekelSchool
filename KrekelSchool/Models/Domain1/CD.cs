using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class CD : KrekelSchool.Item
    {
        public int Size { get; set; }

        public CD(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, int size)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
            Size = size;
        }

        public CD()
        { 
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
