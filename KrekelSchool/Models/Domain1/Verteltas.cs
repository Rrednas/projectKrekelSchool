﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Verteltas : Item
    {
        //public ICollection<Item> Items { get; set; }
        //public virtual Categorie Categorie { get; set; }
        //public ICollection<Boek> Boeken { get; set; }
        //public ICollection<Cd> Cds { get; set; }
        //public ICollection<Dvd> Dvds { get; set; }
        //public ICollection<Spel> Spellen { get; set; }

        public Verteltas(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl) : base(naam, beschikbaar, beschrijving, leeftijd, imgUrl)
        {
        }

        public Verteltas() { }

        public ICollection<Item> Items { get;
            set;
        }
       
    }
}
