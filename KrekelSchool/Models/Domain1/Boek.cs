using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {

        public string Isbn
        {
            get; set; }

        public Boek(int id, string naam, int beschikbaar, string beschrijving,string isbn) : base(id, naam, beschikbaar, beschrijving)
        {
            Isbn = isbn;
        }

        public Boek(string naam, int beschikbaar, string beschrijving,string isbn)
            : base(naam, beschikbaar, beschrijving)
        {
            Isbn = isbn;
        }

    }
}
