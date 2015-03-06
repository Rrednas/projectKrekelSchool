using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models
{
    public class ItemViewModel
    {

        public ItemViewModel(Item item)
        {
            Id = item.Id;
            Naam = item.Naam;
            Beschrijving = item.Beschrijving;
            Beschikbaar = item.Beschikbaar;
            Leeftijd = item.Leeftijd;
        }


        public string Id { get; private set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public string Naam { get; private set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get; private set; }

        [Display(Name = "Aantal beschikbaar")]
        public bool Beschikbaar { get; private set; }

        public int Leeftijd { get; private set; }
    }

    public class BoekViewModel
    {

        public BoekViewModel(Boek boek)
        {
            Id = boek.Id;
            Naam = boek.Naam;
            Beschrijving = boek.Beschrijving;
            Beschikbaar = boek.Beschikbaar;
            Leeftijd = boek.Leeftijd;
            Isbn = boek.Isbn;
            Auteur = boek.Auteur;
            Uitgever = boek.Uitgever;
            Categories = boek.Categories;
        }


        public string Id { get; private set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public string Naam { get; private set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get; private set; }

        [Display(Name = "Aantal beschikbaar")]
        public bool Beschikbaar { get; private set; }

        public int Leeftijd { get; private set; }
        public string Isbn { get; set; }
        public string Auteur { get; set; }
        public string Uitgever { get; set; }
        public ICollection<Categorie> Categories { get; set; }
    }
    
    //public class ItemScreenViewModel
    //{
    //    public ItemScreenViewModel(Item item)
    //    {
    //        Id = item.Id;
    //        Naam = item.Naam;
    //        Beschrijving = item.Beschrijving;
    //        Beschikbaar = item.Beschikbaar;
    //    }

    //    public string Id { get; private set; }

    //    [Display(Name = "Naam")]
    //    public string Naam { get; private set; }

    //    [Display(Name = "Beschrijving")]
    //    public string Beschrijving { get; private set; }

    //    [Display(Name = "Aantal beschikbaar")]
    //    public bool Beschikbaar { get; private set; }
    //}
}