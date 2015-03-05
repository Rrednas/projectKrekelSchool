﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KrekelSchool.Models.Domain1
{
    public class Verteltas : KrekelSchool.Item
    {
        public Verteltas(string id, string naam, bool beschikbaar, string beschrijving) : base(id, naam, beschikbaar, beschrijving)
        {
        }
        //public ICollection<Item> Items { get; set; }
        public virtual Categorie Categorie { get; set; }
        public  ICollection<Boek> Boeken  { get; set; }
        public ICollection<Cd> Cds { get; set; }
        public ICollection<Dvd> Dvds { get; set; }
        public ICollection<Spel> Spellen { get; set; }
    }
}
