﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {

        public Spel( string naam, bool beschikbaar, string beschrijving, int leeftijd) : base( naam, beschikbaar, beschrijving, leeftijd)
        {
        }

        public Spel():base()
        {  
        }
        public ICollection<Categorie> Categories { get; set; }
    }
}
