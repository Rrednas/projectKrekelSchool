using System;
using System.Collections.Generic;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {

        public string Isbn { get; set; }
        public string Auteur { get; set; }
        public string Uitgever { get; set; }
        public ICollection<Categorie> Categories { get; set; }
        

        public Boek(string id, string naam, bool beschikbaar, string beschrijving , int leeftijd, string isbn, string auteur, string uitgever) 
            : base(id, naam, beschikbaar, beschrijving, leeftijd)
        {
            Isbn = isbn;
            Auteur = auteur;
            Uitgever = uitgever;
        }

        public Boek() { }
    }
}
