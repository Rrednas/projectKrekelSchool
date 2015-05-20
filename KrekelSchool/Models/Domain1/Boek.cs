using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrekelSchool.Models.DAL;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : Item
    {
        public string Isbn { get; set; }
        public string Auteur { get; set; }
        public string Uitgever { get; set; }
        //public Categorie Categorie { get; set; }


        //public Boek(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, IEnumerable<Categorie> categories, string isbn, string auteur, string uitgever) 
        //    : base( naam, beschikbaar, beschrijving, leeftijd, imgUrl, categories)
        //{
        //    Isbn = isbn;
        //    Auteur = auteur;
        //    Uitgever = uitgever;
            
        //}

        public Boek(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, Categorie categorie, string isbn, string auteur, string uitgever)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl, categorie)
        {
            Isbn = isbn;
            Auteur = auteur;
            Uitgever = uitgever;

        }

        public Boek(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, string isbn, string auteur, string uitgever)
            : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
            Isbn = isbn;
            Auteur = auteur;
            Uitgever = uitgever;

        }

        public Boek() { }

    }
}
