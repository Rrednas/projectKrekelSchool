using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models
{
    public class BoekViewModel
    {
        public BoekViewModel() { }
        public BoekViewModel(Boek boek)
        {
            Id = boek.Id;
            Isbn = boek.Isbn;
            Naam = boek.Naam;
            Beschrijving = boek.Beschrijving;
            Beschikbaar = boek.Beschikbaar;
            Auteur = boek.Auteur;
            Uitgever = boek.Uitgever;
            Leeftijd = boek.Leeftijd;
        }

        public string Id { get; private set; }

        [Display(Name = "Isbn")]
        public string Isbn { get; private set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public string Naam { get; private set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get; private set; }

        [Display(Name = "Aantal beschikbaar")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public int Beschikbaar { get; private set; }

        [Display(Name = "Auteur")]
        public string Auteur { get; private set; }

        [Display(Name = "Uitgever")]
        public string Uitgever { get; private set; }

        [Display(Name = "Leeftijd")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public int Leeftijd { get; private set; }

    }



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
        public int Beschikbaar { get; private set; }

        [Display(Name = "Leeftijd")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public int Leeftijd { get; private set; }
    }
    
    public class ItemScreenViewModel
    {
        public ItemScreenViewModel(Item item)
        {
            Id = item.Id;
            Naam = item.Naam;
            Beschrijving = item.Beschrijving;
            Beschikbaar = item.Beschikbaar;
        }

        public string Id { get; private set; }

        [Display(Name = "Naam")]
        public string Naam { get; private set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get; private set; }

        [Display(Name = "Aantal beschikbaar")]
        public int Beschikbaar { get; private set; }

        [Display(Name = "Leeftijd")]
        public int Leeftijd { get; private set; }
    }
}