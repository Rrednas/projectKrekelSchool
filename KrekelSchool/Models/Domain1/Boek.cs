using System;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {

        public Boek(string id, string naam, int beschikbaar, string beschrijving , int leeftijd,  string isbn, string auteur, string uitgever) 
            : base(id, naam, beschikbaar, beschrijving, leeftijd)
        {
            Isbn = isbn;
            Auteur = auteur;
            Uitgever = uitgever;
        }

        public Boek() { }

        public string Isbn { get; set; }
        public string Auteur { get; private set; }
        public string Uitgever { get; private set; }
    }
}
