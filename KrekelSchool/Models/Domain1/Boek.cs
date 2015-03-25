﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrekelSchool.Models.DAL;

namespace KrekelSchool.Models.Domain1
{
    public class Boek : KrekelSchool.Item
    {
        public string Isbn { get; set; }
        public string Auteur { get; set; }
        public string Uitgever { get; set; }

        public ICollection<Categorie> Categories { get; set; }
        

        public Boek( string naam, bool beschikbaar, string beschrijving , int leeftijd, Categorie categorie, string isbn, string auteur, string uitgever) 
            : base( naam, beschikbaar, beschrijving, leeftijd)
        {
            Categories = new Collection<Categorie>();
            Context = new KrekelSchoolContext();
            Categories.Add(categorie);
            Context.SaveChanges();
            Isbn = isbn;
            Auteur = auteur;
            Uitgever = uitgever;
        }

        public Boek() { }
    }
}
