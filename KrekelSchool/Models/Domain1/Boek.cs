using System;
using System.Collections.Generic;
using System.Linq;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {

        public string Isbn { get; set; }

        

        public Boek(int id, string naam, int beschikbaar, string beschrijving , string isbn) : base(id, naam, beschikbaar, beschrijving)
        {
            get; set; }

        public Boek(string id, Soort soort, string naam, int beschikbaar, string beschrijving, string isbn)
            : base(id,soort, naam, beschikbaar, beschrijving)
        {
            Isbn = isbn;
            }

        public Boek(Soort soort, string naam, int beschikbaar, string beschrijving, string isbn)
            : base(soort,naam, beschikbaar, beschrijving)

        public Boek() :base()
            {
           
            Isbn = isbn;
        }

       

    }
}
