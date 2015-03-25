﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public abstract class Item
    {
        protected Item(string naam, bool beschikbaar, string beschrijving, int leeftijd)
        {
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
            Leeftijd = leeftijd;
        }

        protected Item()
        {

        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naam { get; set; }

        public bool Beschikbaar{ get; set; }
        public string Beschrijving { get; set; }
        public int Leeftijd { get; set; }

        public KrekelSchoolContext Context;
        #region methods

       
        public void WordUitgeleend()
        {
            if (!Beschikbaar)
            {
                throw new ApplicationException("Item is al uitgeleend");
            }
            else
            {
                Beschikbaar = false;
            }
        }
#endregion
    }
}
