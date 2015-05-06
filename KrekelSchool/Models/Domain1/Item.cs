using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrekelSchool.Models.DAL;

namespace KrekelSchool.Models.Domain1
{
    public abstract class Item
    {
        protected Item(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl)
        {
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
            Leeftijd = leeftijd;
            ImgUrl = imgUrl;
        }

        protected Item()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naam { get; set; }

        public bool Beschikbaar{ get; set; }
        public string Beschrijving { get; set; }
        public int Leeftijd { get; set; }
        public string ImgUrl { get; set; }

        public virtual ICollection<Categorie> Categories
        {get; set; }


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

        public void WordTerugGebracht()
        {
            if (Beschikbaar)
            {
                throw new ApplicationException("Dit item was al teruggebracht");
            }
            Beschikbaar = true;
           
        }
#endregion
    }
}
