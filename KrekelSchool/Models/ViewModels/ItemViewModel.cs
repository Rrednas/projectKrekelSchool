using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models
{
    public class ItemViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; private set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public string Naam { get; private set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get; private set; }

        [Display(Name = "Beschikbaar")]
        public bool Beschikbaar { get; private set; }

        [Display(Name = "Aantal beschikbaar")]
        public int AantalBeschikbaar { get; private set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        public int Leeftijd { get; private set; }

        [Display(Name = "ISBN-nummer")]
        public string Isbn { get; set; }

        public string Auteur { get; set; }
        public string Uitgever { get; set; }

        [Display(Name = "Speelduur")]
        public int Size { get; set; }

        [Display(Name = "Thema's")]
        public ICollection<Categorie> Categories { get; set; }

        public ItemViewModel()
        {
        }

        //Item
        public ItemViewModel(Item item)
        {
            Id = item.Id;
            Naam = item.Naam;
            Beschrijving = item.Beschrijving;
            Beschikbaar = item.Beschikbaar;
            AantalBeschikbaar = item.AantalBeschikbaar;
            Leeftijd = item.Leeftijd;

        }
        
        //Boek
        public ItemViewModel(Boek boek)
        {
            Id = boek.Id;
            Naam = boek.Naam;
            Beschrijving = boek.Beschrijving;
            Beschikbaar = boek.Beschikbaar;
            AantalBeschikbaar = boek.AantalBeschikbaar;
            Leeftijd = boek.Leeftijd;
            Isbn = boek.Isbn;
            Auteur = boek.Auteur;
            Uitgever = boek.Uitgever;
        }

        //Cd
        public ItemViewModel(Cd cd)
        {
            Id = cd.Id;
            Naam = cd.Naam;
            Beschrijving = cd.Beschrijving;
            Beschikbaar = cd.Beschikbaar;
            AantalBeschikbaar = cd.AantalBeschikbaar;
            Leeftijd = cd.Leeftijd;
            Size = cd.Size;
        }

        //Dvd
        public ItemViewModel(Dvd dvd)
        {
            Id = dvd.Id;
            Naam = dvd.Naam;
            Beschrijving = dvd.Beschrijving;
            Beschikbaar = dvd.Beschikbaar;
            AantalBeschikbaar = dvd.AantalBeschikbaar;
            Leeftijd = dvd.Leeftijd;
            Size = dvd.Size;
        }

        //Spel
        public ItemViewModel(Spel spel)
        {
            Id = spel.Id;
            Naam = spel.Naam;
            Beschrijving = spel.Beschrijving;
            Beschikbaar = spel.Beschikbaar;
            AantalBeschikbaar = spel.AantalBeschikbaar;
            Leeftijd = spel.Leeftijd;
        }

        //Spel
        public ItemViewModel(Verteltas verteltas)
        {
            Id = verteltas.Id;
            Naam = verteltas.Naam;
            Beschrijving = verteltas.Beschrijving;
            Beschikbaar = verteltas.Beschikbaar;
            AantalBeschikbaar = verteltas.AantalBeschikbaar;
            Leeftijd = verteltas.Leeftijd;
        }



      
    }


    //public class BoekViewModel
    //{
    //    public BoekViewModel(Boek boek)
    //    {
    //        Id = boek.Id;
    //        Naam = boek.Naam;
    //        Beschrijving = boek.Beschrijving;
    //        Beschikbaar = boek.Beschikbaar;
    //        Leeftijd = boek.Leeftijd;
    //        Isbn = boek.Isbn;
    //        Auteur = boek.Auteur;
    //        Uitgever = boek.Uitgever;
    //        Categories = boek.Categories;
    //    }


    //    public string Id { get; private set; }

    //    [Display(Name = "Naam")]
    //    [Required(ErrorMessage = "{0} is verplicht")]
    //    public string Naam { get; private set; }

    //    [Display(Name = "Beschrijving")]
    //    public string Beschrijving { get; private set; }

    //    [Display(Name = "Aantal beschikbaar")]
    //    public bool Beschikbaar { get; private set; }

    //    public int Leeftijd { get; private set; }
    //    public string Isbn { get; set; }
    //    public string Auteur { get; set; }
    //    public string Uitgever { get; set; }
    //    public ICollection<Categorie> Categories { get; set; }
    //}
    
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