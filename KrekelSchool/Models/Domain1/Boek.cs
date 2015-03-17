using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {
        public string Isbn { get; set; }
        public string Auteur { get; set; }
        public string Uitgever { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Boek_Id { get; set; }

        public ICollection<Categorie> Categories { get; set; }
        

        public Boek( string naam, bool beschikbaar, int aantalBeschikbaar, string beschrijving , int leeftijd, string isbn, string auteur, string uitgever) 
            : base( naam, beschikbaar, aantalBeschikbaar, beschrijving, leeftijd)
        {
            Isbn = isbn;
            Auteur = auteur;
            Uitgever = uitgever;
        }

        public Boek() { }
    }
}
