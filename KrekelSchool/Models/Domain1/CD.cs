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

        public CD(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, int size, Categorie categorie)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
            Size = size;
            Categorie = categorie;
            Categories = new Collection<Categorie>();
            Categories.Add(categorie);
        }

        public CD()
        {
        }
    }
}
