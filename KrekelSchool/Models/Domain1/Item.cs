using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public enum Soort
    {
        cd = 1,
        dvd = 2,
        boek = 3,
        spel = 4,
        verteltas = 5
    }

    public abstract class Item
    {
        private int id;

        private string naam;

        private int beschikbaar;

        private string beschrijving;

        

        private Soort soort;



        protected Item(int id, Soort soort, string naam, int beschikbaar, string beschrijving)
        {
            this.id = id;
            this.naam = naam;
            this.beschikbaar = beschikbaar;
            this.beschrijving = beschrijving;
            this.soort = soort;
        }

        protected Item( Soort soort,string naam, int beschikbaar, string beschrijving)
        {
            
            this.naam = naam;
            this.beschikbaar = beschikbaar;
            this.beschrijving = beschrijving;
            this.soort = soort;
        }

        public string Id
        {
            get
            {
                string id2 = "";
                if (soort == Soort.cd)
                    id2 = string.Format("CD", id);
                if (soort == Soort.spel)
                    id2 = string.Format("SPEL", id);
                if (soort == Soort.verteltas)
                    id2 = string.Format("TAS", id);
                if (soort == Soort.dvd)
                    id2 = string.Format("DVD", id);
                if (soort == Soort.boek)
                    id2 = string.Format("BOEK", id);
                return id2;
            }
            set { }
        }

        public string Naam { get; set; }

        public int Beschikbaar { get; set; }

        public string Beschrijving { get; set; }
    }
}
