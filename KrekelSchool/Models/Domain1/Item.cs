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
    public abstract class Item
    {
        private int id;

        private string naam;

        private int beschikbaar;

        private string beschrijving;

        protected Item(int id,string naam,int beschikbaar,string beschrijving)
        {
            this.id = id;
            this.naam = naam;
            this.beschikbaar = beschikbaar;
            this.beschrijving = beschrijving;
        }

        protected Item(string naam, int beschikbaar, string beschrijving)
        {
            
            this.naam = naam;
            this.beschikbaar = beschikbaar;
            this.beschrijving = beschrijving;
        }

        public int Id { get; set; }

        public string Naam { get; set; }

        public int Beschikbaar { get; set; }

        public string Beschrijving { get; set; }
    }
}
