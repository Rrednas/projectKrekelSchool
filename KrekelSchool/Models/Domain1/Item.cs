using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrekelSchool.Models.DAL;

namespace KrekelSchool.Models.Domain1
{
    public abstract class Item
    {
        protected Item(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, IEnumerable<Categorie> categories  )
        {
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
            Leeftijd = leeftijd;
            ImgUrl = imgUrl;
            Categories = new List<Categorie>(categories);
            VoegCategoriesToe(Categories);
        }

        protected Item(string naam, bool beschikbaar, string beschrijving, int leeftijd, string imgUrl, Categorie categorie)
        {
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
            Leeftijd = leeftijd;
            ImgUrl = imgUrl;
            Categorie = categorie;
        }

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

        public virtual ICollection<Categorie> Categories {get; set; }

        public virtual Categorie Categorie { get; set; }


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

        public void VoegCategorieToe(Categorie categorie)
        {
            if (Categories.Contains(categorie))
            {
                throw new ApplicationException("Categorie bestaat al");
            }

            Categories.Add(categorie);
        }

        public void VoegCategoriesToe(ICollection<Categorie> list)
        {
            foreach (Categorie categorie in list)
            {
                Categories.Add(categorie);
            }
        }
#endregion
    }
}
