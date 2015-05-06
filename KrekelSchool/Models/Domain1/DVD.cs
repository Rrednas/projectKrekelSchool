using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class DVD : Item
    {
        public int Size { get; set; }


        public DVD(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, int size)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
            Size = size;
        }

        public DVD()
        {

        }
    }
}
