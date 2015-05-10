using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class CD : Item
    {
        public int Size { get; set; }
        public Categorie Categorie { get; set; }

        public CD(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, IEnumerable<Categorie> categories, int size)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl, categories)
        {
            Size = size;
        }

        public CD(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, Categorie categorie, int size)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl, categorie)
        {
            Size = size;
        }

        public CD(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, int size)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
            Size = size;
        }

        public CD()
        {
        }
    }
}
