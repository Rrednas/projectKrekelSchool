using System;
using System.Collections.Generic;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {

        public string Isbn { get; set; }

        

        public Boek(string id, string naam, bool beschikbaar, string beschrijving , string isbn) : base(id, naam, beschikbaar, beschrijving)
        {
            Isbn = isbn;
        }

        public Boek() { }
        public ICollection<Categorie> Categories{ get; set; }
    }
}
