using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : Item
    {
        public Categorie Categorie { get; set; }

        public Spel( string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, Categorie categorie) : base( naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
            Categorie = categorie;
            Categories = new Collection<Categorie>();
            Categories.Add(categorie);
        }

        public Spel():base()
        {
        }
    }
}
